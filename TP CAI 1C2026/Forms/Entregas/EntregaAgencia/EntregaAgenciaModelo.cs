using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.Entregas.EntregaAgencia;

internal class EntregaAgenciaModelo
{
    internal Destinatario? BuscarDestinatario(string dni)
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

        if (!long.TryParse(dni, out _) || dni.Length != 8)
        {
            MessageBox.Show(
                "El DNI debe ser numérico y de 8 dígitos.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return null;
        }

        GuiaEntidad? guiaEntidad =
            GuiaAlmacen.Guias
            .FirstOrDefault(g =>
                g.DniDestinatario == dni
                && g.Estado == EstadoGuiaEnum.PendienteDeEntrega
                && g.TipoEntrega == TipoEntregaEnum.Agencia);

        if (guiaEntidad == null)
        {
            MessageBox.Show(
                $"No se encontró ningún destinatario con DNI {dni}.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

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
                && g.TipoEntrega == TipoEntregaEnum.Agencia)
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

    internal bool RegistrarEntrega(List<Guia> guiasAEntregar)
    {
        if (guiasAEntregar.Count == 0)
        {
            MessageBox.Show(
                "Debe seleccionar al menos una guía para entregar.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

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

            AgenciaEntidad? agencia =
                AgenciaAlmacen.Agencias
                .FirstOrDefault(a =>
                    a.IdAgencia == guiaEntidad.IdAgenciaEntrega);

            if (agencia != null)
            {
                ComisionAgencia? comision =
                    agencia.Comisiones
                    .FirstOrDefault(c =>
                        c.TamañoEncomienda == guiaEntidad.TipoCaja);

                if (comision != null)
                {
                    guiaEntidad.ComisionAgencia ??=
                        new List<GuiaComisionAgencia>();

                    guiaEntidad.ComisionAgencia.Add(
                        new GuiaComisionAgencia
                        {
                            IdAgencia = guiaEntidad.IdAgenciaEntrega,
                            Importe = comision.Importe
                        });
                }
            }
        }

        GuiaAlmacen.Guardar();

        return true;
    }
}
