using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.Entregas.EntregaCD;

internal class EntregaCDModelo
{
    internal Destinatario? BuscarDestinatario(string dni, out string error)
    {
        error = string.Empty;

        if (string.IsNullOrWhiteSpace(dni))
        {
            error = "El DNI no puede estar vacío.";
            return null;
        }

        if (!long.TryParse(dni, out _) || dni.Length != 8)
        {
            error = "El DNI debe ser numérico y de 8 dígitos.";
            return null;
        }

        GuiaEntidad? guiaEntidad =
            GuiaAlmacen.Guias
            .FirstOrDefault(g =>
                g.DniDestinatario == dni
                && g.Estado == EstadoGuiaEnum.PendienteDeEntrega
                && g.TipoEntrega == TipoEntregaEnum.CD
                && g.IdCentroDeDistribucionEntrega == Program.CdActual);

        if (guiaEntidad == null)
        {
            error = $"No se encontró ningún destinatario con DNI {dni}.";
            return null;
        }

        return new Destinatario
        {
            Dni = guiaEntidad.DniDestinatario,
            Nombre = guiaEntidad.NombreDestinatario
        };
    }

    internal List<Guia> ObtenerGuiasPorDestinatario(string dni)
    {
        var resultado =
            GuiaAlmacen.Guias
            .Where(g =>
                g.DniDestinatario == dni
                && g.Estado == EstadoGuiaEnum.PendienteDeEntrega
                && g.TipoEntrega == TipoEntregaEnum.CD
                && g.IdCentroDeDistribucionEntrega == Program.CdActual)
            .Select(g => new Guia
            {
                NGuia = g.NroGuia,
                Estado = g.Estado.ToString(),
                TipoPaquete = g.TipoCaja.ToString(),
                DestinatarioDNI = g.DniDestinatario
            })
            .ToList();

        if (resultado.Count == 0)
        {
            MessageBox.Show(
                "No se encontraron guías pendientes para el DNI ingresado.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        return resultado;
    }

    internal bool RegistrarEntrega(List<Guia> guiasAEntregar, out string error)
    {
        error = string.Empty;

        if (guiasAEntregar.Count == 0)
        {
            error = "Debe seleccionar al menos una guía para entregar.";
            return false;
        }

        foreach (Guia guia in guiasAEntregar)
        {
            GuiaEntidad? guiaEntidad =
                GuiaAlmacen.Guias
                .FirstOrDefault(g => g.NroGuia == guia.NGuia);

            if (guiaEntidad == null)
                continue;

            guiaEntidad.Estado = EstadoGuiaEnum.Entregada;

            guiaEntidad.Historial ??= new List<HistorialGuia>();

            guiaEntidad.Historial.Add(new HistorialGuia
            {
                Fecha = DateTime.Now,
                Estado = EstadoGuiaEnum.Entregada
            });
        }

        GuiaAlmacen.Guardar();

        return true;
    }
}
