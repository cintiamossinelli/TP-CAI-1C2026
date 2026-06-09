using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDRRetiro;

internal class EmisionHDRRetiroModelo
{
    public List<Guia> guiasAgregadas = new List<Guia>();
    public Fletero? fleteroSeleccionado = null;
    private int _idCDFletero = 0;

    internal Fletero? BuscarFletero(string dni)
    {
        if (string.IsNullOrWhiteSpace(dni))
        {
            MessageBox.Show(
                "El DNI no puede estar vacío.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return null;
        }

        if (!int.TryParse(dni, out int dniInt) ||
            dniInt <= 0 ||
            dni.Length != 8)
        {
            MessageBox.Show(
                "El DNI debe ser numérico, positivo y de 8 dígitos.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return null;
        }

        FleteroEntidad? entidad =
            FleteroAlmacen.Fleteros
            .FirstOrDefault(f => f.DNI == dniInt);

        if (entidad == null)
        {
            MessageBox.Show(
                $"No se encontró ningún fletero con DNI {dni}.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return null;
        }

        _idCDFletero = entidad.IdCentroDeDistribucion;

        fleteroSeleccionado = new Fletero
        {
            Dni = entidad.DNI,
            Nombre = entidad.Nombre
        };

        return fleteroSeleccionado;
    }

    internal List<string> ObtenerLocalidades()
    {
        return CiudadAlmacen.Ciudades
            .Select(c => c.Nombre)
            .ToList();
    }

    internal string ObtenerLocalidadFletero()
    {
        CiudadEntidad? ciudad =
            CiudadAlmacen.Ciudades
            .FirstOrDefault(c =>
                c.IdCentroDeDistribucion == _idCDFletero);

        return ciudad?.Nombre ?? string.Empty;
    }

    internal List<Guia> ObtenerGuiasPendientes()
    {
        return GuiaAlmacen.Guias
            .Where(g =>
                (g.Estado == EstadoGuiaEnum.ImpuestaEnCallCenter ||
                 g.Estado == EstadoGuiaEnum.ImpuestaEnAgencia)
                && PerteneceAlCDDelFletero(g))
            .Select(g => new Guia
            {
                NGuia = g.NroGuia,
                TipoCaja = g.TipoCaja.ToString(),
                LugarRetiro = ResolverLugarRetiro(g)
            })
            .ToList();
    }

    internal Guia? BuscarGuia(string nGuia)
    {
        if (string.IsNullOrWhiteSpace(nGuia))
        {
            MessageBox.Show(
                "Debe ingresar un número de guía.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return null;
        }

        Guia? guia =
            ObtenerGuiasPendientes()
            .FirstOrDefault(g => g.NGuia == nGuia);

        if (guia == null)
        {
            MessageBox.Show(
                $"No se encontró ninguna guía con el número {nGuia}.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return null;
        }

        return guia;
    }

    internal bool GenerarHDR(out string mensajeExito, out string error)
    {
        error = string.Empty;
        mensajeExito = string.Empty;

        if (fleteroSeleccionado == null)
        {
            MessageBox.Show(
                "Debe buscar y seleccionar un fletero.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return false;
        }

        if (guiasAgregadas.Count == 0)
        {
            error = "Debe agregar al menos una guía a la HDR.";
            return false;
        }

        string lugarComun = guiasAgregadas[0].LugarRetiro;

        if (guiasAgregadas.Any(g => g.LugarRetiro != lugarComun))
        {
            error = "Todas las guías deben tener el mismo lugar de retiro.";
            return false;
        }

        foreach (Guia guia in guiasAgregadas)
        {
            GuiaEntidad? guiaEntidad =
                GuiaAlmacen.Guias
                .FirstOrDefault(g => g.NroGuia == guia.NGuia);

            if (guiaEntidad == null)
                continue;

            guiaEntidad.Estado = EstadoGuiaEnum.PendienteDeRetiro;

            guiaEntidad.Historial ??= new List<HistorialGuia>();

            guiaEntidad.Historial.Add(new HistorialGuia
            {
                Fecha = DateTime.Now,
                Estado = EstadoGuiaEnum.PendienteDeRetiro
            });
        }

        GuiaAlmacen.Guardar();

        int nuevoNroHDR =
            HDRRetiroAlmacen.HDRRetiros.Count > 0
                ? HDRRetiroAlmacen.HDRRetiros.Max(h => h.NroHDR) + 1
                : 1;

        HDRRetiroAlmacen.Agregar(new HDRRetiroEntidad
        {
            NroHDR = nuevoNroHDR,
            DniFletero = fleteroSeleccionado.Dni,
            Fecha = DateTime.Now,
            Domicilio = lugarComun,
            CantEncomiendas = guiasAgregadas.Count,
            Guias = guiasAgregadas.Select(g => g.NGuia).ToList(),
            Estado = EstadoHDREnum.Emitida
        });

        HDRRetiroAlmacen.Guardar();

        mensajeExito =
            $"HDR N° {nuevoNroHDR} generada correctamente " +
            $"para el fletero {fleteroSeleccionado.Nombre}.";

        return true;
    }

    internal void AgregarGuia(string nGuia)
    {
        Guia? guia = BuscarGuia(nGuia);

        if (guia != null &&
            !guiasAgregadas.Any(g => g.NGuia == guia.NGuia))
        {
            guiasAgregadas.Add(guia);
        }
    }

    internal void Limpiar()
    {
        fleteroSeleccionado = null;
        guiasAgregadas.Clear();
        _idCDFletero = 0;
    }

    // ── Helpers privados ──────────────────────────────────────────

    private bool PerteneceAlCDDelFletero(GuiaEntidad g)
    {
        if (g.TipoImposicion == TipoImposicionEnum.EnDomicilio)
        {
            return g.IdCentroDeDistribucionImposicion == _idCDFletero;
        }

        if (g.TipoImposicion == TipoImposicionEnum.Agencia)
        {
            CiudadEntidad? ciudad =
                CiudadAlmacen.Ciudades
                .FirstOrDefault(c =>
                    c.Agencias.Contains(g.IdAgenciaImposicion));

            return ciudad?.IdCentroDeDistribucion == _idCDFletero;
        }

        return false;
    }

    private static string ResolverLugarRetiro(GuiaEntidad g)
    {
        if (g.TipoImposicion == TipoImposicionEnum.Agencia)
        {
            AgenciaEntidad? agencia =
                AgenciaAlmacen.Agencias
                .FirstOrDefault(a =>
                    a.IdAgencia == g.IdAgenciaImposicion);

            return agencia?.Nombre
                ?? $"Agencia {g.IdAgenciaImposicion}";
        }

        if (g.TipoImposicion == TipoImposicionEnum.EnDomicilio)
        {
            return g.DireccionRetiroDomicilio;
        }

        return string.Empty;
    }
}
