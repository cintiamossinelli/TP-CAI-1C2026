namespace TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte;

using System.Linq;
using TP_CAI_1C2026.Forms.Almacen;

public class EmisionHDRTransporteModelo
{
    private List<GuiaEncomienda> guiasDisponibles = new();
    private List<GuiaEncomienda> guiasAgregadas = new();

    public EmisionHDRTransporteModelo()
    {
        guiasDisponibles = ObtenerGuiasDesdeAlmacen();
    }

    // Valida que el Centro de Distribución seleccionado coincida con los destinos
    // de las colecciones mostradas en los ListView del formulario.
    internal bool ValidarCentrosEnListas(CentroDeDistribucion? seleccionado, IEnumerable<Transporte>? transportes, IEnumerable<GuiaEncomienda>? guias)
    {
        if (seleccionado == null)
        {
            MessageBox.Show("Debe seleccionar un Centro de Distribución destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (transportes != null)
        {
            foreach (var t in transportes)
            {
                if (t == null) continue;
                if (t.Destino == null) continue;
                if (t.Destino.Id != seleccionado.Id)
                {
                    MessageBox.Show("El Centro de Distribución seleccionado no coincide con los transportes listados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        if (guias != null)
        {
            foreach (var g in guias)
            {
                if (g == null) continue;
                if (g.Destino == null) continue;
                if (g.Destino.Id != seleccionado.Id)
                {
                    MessageBox.Show("El Centro de Distribución seleccionado no coincide con las guías listadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        return true;
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

        internal GuiaEncomienda? BuscarGuia(string numeroGuia, CentroDeDistribucion? destinoSeleccionado)
    {
        if (string.IsNullOrWhiteSpace(numeroGuia))
        {
            MessageBox.Show("Debe ingresar un N° de guía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        if (destinoSeleccionado == null)
        {
            MessageBox.Show("Debe seleccionar un Centro de Distribución destino antes de buscar guías.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var numeroNormalizado = numeroGuia.Trim().ToUpper();

        var guiaEncontrada = guiasDisponibles.FirstOrDefault(g => g.NumeroGuia.ToUpper() == numeroNormalizado);

        if (guiaEncontrada == null || guiaEncontrada.Destino.Id != destinoSeleccionado.Id)
        {
            MessageBox.Show("La guía no existe o no corresponde al destino seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        return guiaEncontrada;
    }

    // Busca guías disponibles por número (coincidencia parcial, case-insensitive) filtradas por destino
    internal List<GuiaEncomienda> BuscarGuiasPorNumero(string numeroParcial, CentroDeDistribucion? destinoSeleccionado)
    {
        if (destinoSeleccionado == null)
        {
            MessageBox.Show("Debe seleccionar un Centro de Distribución destino antes de buscar guías.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<GuiaEncomienda>();
        }

        if (string.IsNullOrWhiteSpace(numeroParcial))
        {
            // Retornar lista vacía para que el formulario decida mostrar todo
            return new List<GuiaEncomienda>();
        }

        var term = numeroParcial.Trim().ToUpper();
        var matches = guiasDisponibles
            .Where(g => g.NumeroGuia != null && g.NumeroGuia.ToUpper().Contains(term) && g.Destino.Id == destinoSeleccionado.Id)
            .ToList();

        if (!matches.Any())
        {
            MessageBox.Show("No existen guías que coincidan con la búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return matches;
    }

    internal bool AgregarGuia(GuiaEncomienda? guia)
    {
        if (guia == null)
        {
            MessageBox.Show("Debe seleccionar una guía para agregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (guiasAgregadas.Any(g => g.NumeroGuia == guia.NumeroGuia))
        {
            MessageBox.Show("La guía ya fue agregada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        guiasAgregadas.Add(guia);
        guiasDisponibles.Remove(guia);

        return true;
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

    internal bool QuitarGuia(GuiaEncomienda? guia)
    {
        if (guia == null)
        {
            MessageBox.Show("Debe seleccionar una guía para quitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        guiasAgregadas.Remove(guia);
        guiasDisponibles.Add(guia);

        return true;
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

        var origenesGuias = GuiaAlmacen.Guias
            .Where(g => numerosGuias.Contains(g.NroGuia))
            .Select(g => g.IdCentroDeDistribucionImposicion)
            .Distinct()
            .ToList();

        if (origenesGuias.Count != 1)
        {
            MessageBox.Show("Todas las guías seleccionadas deben pertenecer al mismo Centro de Distribución de imposición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            IdCentroDeDistribucionOrigen = origenesGuias.Single(),
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

    internal List<GuiaEncomienda> ObtenerGuiasAgregadas()
    {
        return guiasAgregadas.ToList();
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

        var guiasAsignadas = HDRTransporteAlmacen.HDRTransportes
            .Where(h => h.Guias != null)
            .SelectMany(h => h.Guias)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return GuiaAlmacen.Guias
            .Where(g => g.Estado == EstadoGuiaEnum.Admitida)
            .Where(g => g.TipoImposicion == TipoImposicionEnum.CD)
            .Where(g => g.TipoEntrega == TipoEntregaEnum.CD)
            .Where(g => !guiasAsignadas.Contains(g.NroGuia))
            .Select(g => new
            {
                Guia = g,
                IdCentroOrigen = ResolverIdCentroOrigen(g),
                IdCentroDestino = ResolverIdCentroDestino(g)
            })
            .Where(x => x.IdCentroOrigen.HasValue
                && x.IdCentroDestino.HasValue
                && x.IdCentroOrigen.Value != x.IdCentroDestino.Value
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
        return ServicioAlmacen.Servicios.FirstOrDefault(servicio =>
            servicio.IdEmpresaTransporte == transporte.Empresa.Id
            && servicio.Paradas != null
            && servicio.Paradas.Any(parada =>
                parada.IdCentroDeDistribucion == transporte.Destino.Id
                && parada.Fecha.Date == transporte.Fecha.Date
                && parada.Fecha.TimeOfDay == transporte.Hora));
    }

    private int? ResolverIdCentroOrigen(GuiaEntidad guia)
    {
        return guia.TipoImposicion switch
        {
            TipoImposicionEnum.CD => guia.IdCentroDeDistribucionImposicion,
            TipoImposicionEnum.Agencia => ResolverIdCentroPorAgencia(guia.IdAgenciaImposicion),
            TipoImposicionEnum.EnDomicilio => guia.IdCentroDeDistribucionImposicion,
            _ => null
        };
    }

    private int? ResolverIdCentroDestino(GuiaEntidad guia)
    {
        return guia.TipoEntrega switch
        {
            TipoEntregaEnum.CD => guia.IdCentroDeDistribucionEntrega,
            TipoEntregaEnum.Agencia => ResolverIdCentroPorAgencia(guia.IdAgenciaEntrega),
            TipoEntregaEnum.ADomicilio => guia.IdCentroDeDistribucionEntrega,
            _ => null
        };
    }

    private int? ResolverIdCentroPorAgencia(int idAgencia)
    {
        return CiudadAlmacen.Ciudades
            .FirstOrDefault(c => c.Agencias != null && c.Agencias.Contains(idAgencia))
            ?.IdCentroDeDistribucion;
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
