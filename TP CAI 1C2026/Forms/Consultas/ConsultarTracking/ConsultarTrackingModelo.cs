namespace TP_CAI_1C2026.Forms.Consultas.ConsultarTracking;

internal class ConsultarTrackingModelo
{
    private List<Guia> guias = new List<Guia>
    {
        new Guia
        {
            NGuia = "CD-3-1",
            CuitDniCuil = "33-63761744-9",
            Origen = "CD Buenos Aires",
            Destino = "CD Córdoba",
            TipoCaja = "S",
            Historial = new List<HistorialGuia>
            {
                new HistorialGuia { Fecha = "01/05/2026", Estado = "Impuesta pero no admitida" },
                new HistorialGuia { Fecha = "02/05/2026", Estado = "Admitida" }
            }
        },
        new Guia
        {
            NGuia = "AG-5-1",
            CuitDniCuil = "30-64621216-9",
            Origen = "Agencia Rosario Norte",
            Destino = "Agencia Santa Fe Centro",
            TipoCaja = "M",
            Historial = new List<HistorialGuia>
            {
                new HistorialGuia { Fecha = "03/05/2026", Estado = "Impuesta pero no admitida" },
                new HistorialGuia { Fecha = "04/05/2026", Estado = "Admitida" },
                new HistorialGuia { Fecha = "05/05/2026", Estado = "Entregada" }
            }
        },
        new Guia
        {
            NGuia = "CD-4-1",
            CuitDniCuil = "30-67337754-4",
            Origen = "CD Córdoba",
            Destino = "CD Rosario",
            TipoCaja = "L",
            Historial = new List<HistorialGuia>
            {
                new HistorialGuia { Fecha = "06/05/2026", Estado = "Impuesta pero no admitida" }
            }
        }
    };

    internal Guia? BuscarGuia(string nGuia)
    {
        if (string.IsNullOrWhiteSpace(nGuia))
        {
            MessageBox.Show("El número de guía no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var guiaEncontrada = guias.FirstOrDefault(g => g.NGuia == nGuia);
        if (guiaEncontrada == null)
        {
            MessageBox.Show($"No se encontró ninguna guía con el número {nGuia}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        return guiaEncontrada;
    }
}
