namespace TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte;

using System.Linq;
using System.Globalization;
using System.Text;
using TP_CAI_1C2026.Forms.Almacen;

public class EmisionHDRTransporteModelo
{
    private List<GuiaEncomienda> guiasDisponibles = new();
    private List<GuiaEncomienda> guiasAgregadas = new();

    public EmisionHDRTransporteModelo()
    {
        guiasDisponibles = ObtenerGuiasDesdeAlmacen();
    }

    internal List<CentroDeDistribucion> ObtenerCentrosDeDistribucion()
    {
        return CentroDeDistribucionAlmacen.CentrosDeDistribucion
            .Select(MapearCentroDeDistribucion)
            .OrderBy(c => c.Nombre)
            .ToList();
    }

    internal List<EmpresaTransporte> ObtenerEmpresasTransporte()
    {
        return EmpresaTransporteAlmacen.EmpresasTransporte
            .Select(MapearEmpresaTransporte)
            .OrderBy(e => e.Nombre)
            .ToList();
    }

    internal List<Transporte> BuscarTransportes(
        DateTime fecha,
        EmpresaTransporte? empresaSeleccionada,
        CentroDeDistribucion? destinoSeleccionado)
    {
        if (fecha.Date < DateTime.Today)
        {
            MessageBox.Show(
                "La fecha debe ser igual a hoy o posterior.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return new List<Transporte>();
        }

        if (destinoSeleccionado == null)
        {
            MessageBox.Show("Debe seleccionar un Centro de Distribución destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<Transporte>();
        }

        var transportes = ObtenerTransportesDesdeAlmacen();

        var resultado = transportes
            .Where(t => t.Fecha.Date == fecha.Date)
            .Where(t => t.Destino.Id == destinoSeleccionado.Id);

        if (empresaSeleccionada != null)
        {
            resultado = resultado.Where(t => t.Empresa.Id == empresaSeleccionada.Id);
        }

        var lista = resultado.ToList();

        if (!lista.Any())
        {
            MessageBox.Show("No se encontraron transportes para los filtros ingresados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return lista;
    }

    // Busca guías disponibles por número, sin restringir su destino.
    internal List<GuiaEncomienda> BuscarGuiasPorNumero(string numeroParcial)
    {
        if (string.IsNullOrWhiteSpace(numeroParcial))
        {
            // Retornar lista vacía para que el formulario decida mostrar todo
            return new List<GuiaEncomienda>();
        }

        var term = numeroParcial.Trim().ToUpper();
        var matches = guiasDisponibles
            .Where(g => g.NumeroGuia != null && g.NumeroGuia.ToUpper().Contains(term))
            .ToList();

        if (!matches.Any())
        {
            MessageBox.Show("No existen guías que coincidan con la búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return matches;
    }

    // Añade varias guías a la vez. Si la colección está vacía o nula muestra mensaje y retorna lista vacía.
    internal List<GuiaEncomienda> AgregarGuias(IEnumerable<GuiaEncomienda>? guias)
    {
        if (guias == null || !guias.Any())
        {
            MessageBox.Show("Seleccione un Item y vuelva a intentar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return new List<GuiaEncomienda>();
        }

        var agregadas = new List<GuiaEncomienda>();
        foreach (var guia in guias)
        {
            if (guia == null) continue;
            // evitar duplicados
            if (guiasAgregadas.Any(g => g.NumeroGuia == guia.NumeroGuia)) continue;
            // solo agregar si está disponible
            var disponible = guiasDisponibles.FirstOrDefault(g => g.NumeroGuia == guia.NumeroGuia);
            if (disponible != null)
            {
                guiasAgregadas.Add(disponible);
                guiasDisponibles.Remove(disponible);
                agregadas.Add(disponible);
            }
        }

        return agregadas;
    }

    // Quitar varias guías a la vez. Si la colección está vacía o nula muestra mensaje y retorna lista vacía.
    internal List<GuiaEncomienda> QuitarGuias(IEnumerable<GuiaEncomienda>? guias)
    {
        if (guias == null || !guias.Any())
        {
            MessageBox.Show("Seleccione un Item y vuelva a intentar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return new List<GuiaEncomienda>();
        }

        var quitadas = new List<GuiaEncomienda>();
        foreach (var guia in guias)
        {
            if (guia == null) continue;

            // intentar quitar por objeto referenciado en la colección de agregadas
            var existente = guiasAgregadas.FirstOrDefault(g => g.NumeroGuia == guia.NumeroGuia);
            if (existente != null)
            {
                guiasAgregadas.Remove(existente);
                guiasDisponibles.Add(existente);
                quitadas.Add(existente);
            }
        }

        return quitadas;
    }

    internal HDRTransporte? GenerarHDR(
        CentroDeDistribucion? destinoSeleccionado,
        Transporte? transporteSeleccionado)
    {
        if (!ValidarGeneracionHDR(destinoSeleccionado, transporteSeleccionado))
        {
            return null;
        }

        var guiasYaAsignadas = HDRTransporteAlmacen.HDRTransportes
            .Where(h => h.Guias != null)
            .SelectMany(h => h.Guias)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        if (guiasAgregadas.Any(g => guiasYaAsignadas.Contains(g.NumeroGuia)))
        {
            MessageBox.Show("Una o más guías seleccionadas ya fueron asignadas a otra HDR.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var servicio = BuscarServicio(transporteSeleccionado!);
        if (servicio == null || servicio.Paradas == null || !servicio.Paradas.Any())
        {
            MessageBox.Show("No se pudo identificar el servicio seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var numerosGuias = guiasAgregadas
            .Select(g => g.NumeroGuia)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var entidadesGuias = GuiaAlmacen.Guias
            .Where(g => numerosGuias.Contains(g.NroGuia))
            .ToList();

        int? idCentroOrigen = entidadesGuias
            .Select(ResolverIdCentroOrigen)
            .FirstOrDefault(idCentro => idCentro.HasValue);

        if (!idCentroOrigen.HasValue)
        {
            MessageBox.Show("No se pudo determinar el Centro de Distribución de origen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var hdr = new HDRTransporte
        {
            Id = ObtenerProximoNumeroHDR(),
            FechaEmision = DateTime.Now,
            Destino = destinoSeleccionado!,
            Transporte = transporteSeleccionado!,
            Guias = guiasAgregadas.ToList()
        };

        HDRTransporteAlmacen.Agregar(new HDRTransporteEntidad
        {
            NroHDR = hdr.Id,
            IdServicio = servicio.IdServicio,
            FechaEmision = hdr.FechaEmision,
            IdCentroDeDistribucionOrigen = idCentroOrigen.Value,
            IdCentroDeDistribucionDestino = hdr.Destino.Id,
            Guias = hdr.Guias.Select(g => g.NumeroGuia).ToList()
        });
        HDRTransporteAlmacen.Guardar();
        ActualizarEstadoGuias(hdr.Guias);

        return hdr;
    }

    internal List<GuiaEncomienda> ObtenerGuiasDisponibles()
    {
        return guiasDisponibles.ToList();
    }

    private bool ValidarGeneracionHDR(
        CentroDeDistribucion? destinoSeleccionado,
        Transporte? transporteSeleccionado)
    {
        if (destinoSeleccionado == null)
        {
            MessageBox.Show("Debe seleccionar un Centro de Distribución destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (transporteSeleccionado == null)
        {
            MessageBox.Show("Debe seleccionar un transporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (transporteSeleccionado.Destino == null
            || transporteSeleccionado.Destino.Id != destinoSeleccionado.Id)
        {
            MessageBox.Show(
                "El Centro de Distribución destino seleccionado no coincide con el destino del servicio seleccionado.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }

        if (!guiasAgregadas.Any())
        {
            MessageBox.Show("Debe agregar al menos una guía para generar la HDR.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    private List<Transporte> ObtenerTransportesDesdeAlmacen()
    {
        var centros = CentroDeDistribucionAlmacen.CentrosDeDistribucion
            .ToDictionary(c => c.IdCentroDeDistribucion, MapearCentroDeDistribucion);

        var empresas = EmpresaTransporteAlmacen.EmpresasTransporte
            .ToDictionary(e => e.IdEmpresaTransporte, MapearEmpresaTransporte);

        return ServicioAlmacen.Servicios
            .SelectMany(servicio =>
            {
                if (!empresas.TryGetValue(servicio.IdEmpresaTransporte, out var empresa) || servicio.Paradas == null)
                {
                    return Enumerable.Empty<Transporte>();
                }

                return servicio.Paradas
                    .Where(parada => centros.ContainsKey(parada.IdCentroDeDistribucion))
                    .Select(parada => new Transporte
                    {
                        IdServicio = servicio.IdServicio,
                        Fecha = parada.Fecha,
                        Hora = parada.Fecha.TimeOfDay,
                        Empresa = empresa,
                        Destino = centros[parada.IdCentroDeDistribucion]
                    });
            })
            .OrderBy(t => t.Fecha)
            .ThenBy(t => t.Hora)
            .ToList();
    }

    private List<GuiaEncomienda> ObtenerGuiasDesdeAlmacen()
    {
        var centros = CentroDeDistribucionAlmacen.CentrosDeDistribucion
            .ToDictionary(c => c.IdCentroDeDistribucion, MapearCentroDeDistribucion);

        return GuiaAlmacen.Guias
            .Where(g => g.Estado == EstadoGuiaEnum.Admitida)
            .Select(g => new
            {
                Guia = g,
                IdCentroDestino = ResolverIdCentroDestino(g),
                LugarOrigen = ResolverLugarOrigen(g),
                LugarDestino = ResolverLugarDestino(g)
            })
            .Where(x => x.IdCentroDestino.HasValue
                && x.LugarOrigen != null
                && x.LugarDestino != null
                && !string.Equals(x.LugarOrigen, x.LugarDestino, StringComparison.OrdinalIgnoreCase)
                && centros.ContainsKey(x.IdCentroDestino.Value))
            .Select(g => new GuiaEncomienda
            {
                NumeroGuia = g.Guia.NroGuia,
                TipoEncomienda = g.Guia.TipoCaja.ToString(),
                Destino = centros[g.IdCentroDestino!.Value]
            })
            .OrderBy(g => g.NumeroGuia)
            .ToList();
    }

    private CentroDeDistribucion MapearCentroDeDistribucion(CentroDeDistribucionEntidad centroEntidad)
    {
        return new CentroDeDistribucion
        {
            Id = centroEntidad.IdCentroDeDistribucion,
            Nombre = centroEntidad.Nombre
        };
    }

    private EmpresaTransporte MapearEmpresaTransporte(EmpresaTransporteEntidad empresaEntidad)
    {
        return new EmpresaTransporte
        {
            Id = empresaEntidad.IdEmpresaTransporte,
            Nombre = empresaEntidad.Nombre
        };
    }

    private int ObtenerProximoNumeroHDR()
    {
        return HDRTransporteAlmacen.HDRTransportes.Any()
            ? HDRTransporteAlmacen.HDRTransportes.Max(h => h.NroHDR) + 1
            : 1;
    }

    private ServicioEntidad? BuscarServicio(Transporte transporte)
    {
        return ServicioAlmacen.Servicios
            .FirstOrDefault(servicio => servicio.IdServicio == transporte.IdServicio);
    }

    private int? ResolverIdCentroOrigen(GuiaEntidad guia)
    {
        return guia.TipoImposicion switch
        {
            TipoImposicionEnum.CD => guia.IdCentroDeDistribucionImposicion,
            TipoImposicionEnum.Agencia => ResolverIdCentroPorAgencia(guia.IdAgenciaImposicion),
            TipoImposicionEnum.EnDomicilio => ResolverIdCentroPorDireccion(guia.DireccionRetiroDomicilio),
            _ => null
        };
    }

    private int? ResolverIdCentroDestino(GuiaEntidad guia)
    {
        return guia.TipoEntrega switch
        {
            TipoEntregaEnum.CD => guia.IdCentroDeDistribucionEntrega,
            TipoEntregaEnum.Agencia => ResolverIdCentroPorAgencia(guia.IdAgenciaEntrega),
            TipoEntregaEnum.ADomicilio => ResolverIdCentroPorDireccion(guia.DireccionEntrega),
            _ => null
        };
    }

    private int? ResolverIdCentroPorAgencia(int idAgencia)
    {
        return CiudadAlmacen.Ciudades
            .FirstOrDefault(c => c.Agencias != null && c.Agencias.Contains(idAgencia))
            ?.IdCentroDeDistribucion;
    }

    private int? ResolverIdCentroPorDireccion(string? direccion)
    {
        var direccionNormalizada = NormalizarTexto(direccion);
        if (string.IsNullOrWhiteSpace(direccionNormalizada))
        {
            return null;
        }

        if (direccionNormalizada.Contains("caba"))
        {
            return CiudadAlmacen.Ciudades
                .FirstOrDefault(c => NormalizarTexto(c.Nombre) == "buenos aires")
                ?.IdCentroDeDistribucion;
        }

        return CiudadAlmacen.Ciudades
            .FirstOrDefault(c => direccionNormalizada.Contains(NormalizarTexto(c.Nombre)))
            ?.IdCentroDeDistribucion;
    }

    private string? ResolverLugarOrigen(GuiaEntidad guia)
    {
        return guia.TipoImposicion switch
        {
            TipoImposicionEnum.CD => $"CD:{guia.IdCentroDeDistribucionImposicion}",
            TipoImposicionEnum.Agencia => $"AGENCIA:{guia.IdAgenciaImposicion}",
            TipoImposicionEnum.EnDomicilio => ResolverLugarDomicilio(guia.DireccionRetiroDomicilio),
            _ => null
        };
    }

    private string? ResolverLugarDestino(GuiaEntidad guia)
    {
        return guia.TipoEntrega switch
        {
            TipoEntregaEnum.CD => $"CD:{guia.IdCentroDeDistribucionEntrega}",
            TipoEntregaEnum.Agencia => $"AGENCIA:{guia.IdAgenciaEntrega}",
            TipoEntregaEnum.ADomicilio => ResolverLugarDomicilio(guia.DireccionEntrega),
            _ => null
        };
    }

    private string? ResolverLugarDomicilio(string? direccion)
    {
        var direccionNormalizada = NormalizarTexto(direccion);
        return string.IsNullOrWhiteSpace(direccionNormalizada)
            ? null
            : $"DOMICILIO:{direccionNormalizada}";
    }

    private string NormalizarTexto(string? texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            return string.Empty;
        }

        var textoNormalizado = texto.Normalize(NormalizationForm.FormD);
        var resultado = new StringBuilder();

        foreach (var caracter in textoNormalizado)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(caracter) != UnicodeCategory.NonSpacingMark)
            {
                resultado.Append(char.ToLowerInvariant(caracter));
            }
        }

        return resultado.ToString().Normalize(NormalizationForm.FormC).Trim();
    }

    private void ActualizarEstadoGuias(IEnumerable<GuiaEncomienda> guias)
    {
        var numerosGuias = guias
            .Select(g => g.NumeroGuia)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var guiaEntidad in GuiaAlmacen.Guias.Where(g => numerosGuias.Contains(g.NroGuia)))
        {
            guiaEntidad.Estado = EstadoGuiaEnum.PendienteDeTransporte;
            guiaEntidad.Historial ??= new List<HistorialGuia>();
            guiaEntidad.Historial.Add(new HistorialGuia
            {
                Fecha = DateTime.Now,
                Estado = EstadoGuiaEnum.PendienteDeTransporte
            });
        }

        GuiaAlmacen.Guardar();
    }
}
