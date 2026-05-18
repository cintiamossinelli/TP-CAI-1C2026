namespace TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte;

using System.Linq;

public class EmisionHDRTransporteModelo
{
    private List<GuiaEncomienda> guiasDisponibles = new();
    private List<GuiaEncomienda> guiasAgregadas = new();

    public EmisionHDRTransporteModelo()
    {
        guiasDisponibles = ObtenerGuiasMock();
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
        // Lista ampliada de Centros de Distribución representando distintas provincias/ciudades
        return new List<CentroDeDistribucion>
        {
            new CentroDeDistribucion { Id = 1, Nombre = "Rosario" },
            new CentroDeDistribucion { Id = 2, Nombre = "Santa Fe" },
            new CentroDeDistribucion { Id = 3, Nombre = "Buenos Aires" },
            new CentroDeDistribucion { Id = 4, Nombre = "Córdoba" },
            new CentroDeDistribucion { Id = 5, Nombre = "Mendoza" },
            new CentroDeDistribucion { Id = 6, Nombre = "Salta" },
            new CentroDeDistribucion { Id = 7, Nombre = "Jujuy" },
            new CentroDeDistribucion { Id = 8, Nombre = "San Miguel de Tucumán" },
            new CentroDeDistribucion { Id = 9, Nombre = "Neuquén" },
            new CentroDeDistribucion { Id = 10, Nombre = "Mar del Plata" },
            new CentroDeDistribucion { Id = 11, Nombre = "La Plata" },
            new CentroDeDistribucion { Id = 12, Nombre = "San Juan" }
        };
    }

    internal List<EmpresaTransporte> ObtenerEmpresasTransporte()
    {
        return new List<EmpresaTransporte>
        {
            new EmpresaTransporte { Id = 1, Nombre = "Flecha Bus" },
            new EmpresaTransporte { Id = 2, Nombre = "Chevallier" },
            new EmpresaTransporte { Id = 3, Nombre = "Andesmar" },
            new EmpresaTransporte { Id = 4, Nombre = "El Rosarino" },
            new EmpresaTransporte { Id = 5, Nombre = "Via Bariloche" },
            new EmpresaTransporte { Id = 6, Nombre = "Pullman" },
            new EmpresaTransporte { Id = 7, Nombre = "Plusmar" }
        };
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

        var transportes = ObtenerTransportesMock();

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

        return new HDRTransporte
        {
            Id = new Random().Next(1000, 9999),
            FechaEmision = DateTime.Now,
            Destino = destinoSeleccionado!,
            Transporte = transporteSeleccionado!,
            Guias = guiasAgregadas.ToList()
        };
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

    private List<Transporte> ObtenerTransportesMock()
    {
        var centros = ObtenerCentrosDeDistribucion();
        var empresas = ObtenerEmpresasTransporte();

        var fechas = new[] { DateTime.Today.AddDays(-1), DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today.AddDays(2) };

        var lista = new List<Transporte>();

        // Para cada centro generamos varios transportes repartidos en diferentes fechas y empresas
        var rand = new Random(42);
        foreach (var centro in centros)
        {
            foreach (var fecha in fechas)
            {
                // Crear 1 o 2 transportes por fecha para el centro, con empresas rotando
                int count = 1 + (rand.Next() % 2);
                for (int i = 0; i < count; i++)
                {
                    var empresa = empresas[(rand.Next() % empresas.Count)];
                    var hora = new TimeSpan(6 + rand.Next(12), rand.Next(0, 60), 0);
                    lista.Add(new Transporte { Fecha = fecha, Hora = hora, Empresa = empresa, Destino = centro });
                }
            }
        }

        // Ordenar por fecha/hora para facilitar la lectura
        return lista.OrderBy(t => t.Fecha).ThenBy(t => t.Hora).ToList();
    }

    private List<GuiaEncomienda> ObtenerGuiasMock()
    {
        var centros = ObtenerCentrosDeDistribucion();

        // Generar múltiples guías por cada centro/provincia
        var guias = new List<GuiaEncomienda>();
        var tipos = new[] { "S", "M", "L", "XL" };

        foreach (var centro in centros)
        {
            // Crear entre 4 y 8 guías por centro para tener variedad
            for (int i = 1; i <= 6; i++)
            {
                // Limitar el primer número (id de centro) al rango 1..50
                var centroCodigo = centro.Id;
                if (centroCodigo < 1) centroCodigo = 1;
                if (centroCodigo > 50)
                {
                    // Mapear cualquier id fuera de rango al rango 1..50 de forma circular
                    centroCodigo = ((centroCodigo - 1) % 50) + 1;
                }

                guias.Add(new GuiaEncomienda
                {
                    NumeroGuia = $"CD-{centroCodigo}-{i:D2}",
                    TipoEncomienda = tipos[(i - 1) % tipos.Length],
                    Destino = centro
                });
            }
        }

        // Guías adicionales con números diferentes para pruebas de búsqueda (primer número limitado a 1..50)
        guias.Add(new GuiaEncomienda { NumeroGuia = "CD-50-01", TipoEncomienda = "M", Destino = centros.First() });
        guias.Add(new GuiaEncomienda { NumeroGuia = "CD-03-99", TipoEncomienda = "L", Destino = centros.First(c => c.Id == 3) });

        return guias;
    }
}