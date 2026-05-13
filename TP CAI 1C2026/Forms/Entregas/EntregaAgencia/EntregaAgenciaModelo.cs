namespace TP_CAI_1C2026.Forms.Entregas.EntregaAgencia;

internal class EntregaAgenciaModelo
{
    private List<Guia> guias = new List<Guia>
    {
    new Guia { NGuia = "CD-COR-111", Estado = "Admitida", TipoPaquete = "S" },
    new Guia { NGuia = "AG-TUC-12", Estado = "Admitida", TipoPaquete = "M" },
    new Guia { NGuia = "AG-SAL-56", Estado = "Admitida", TipoPaquete = "L" },
    new Guia { NGuia = "AG-CAT-1236", Estado = "Admitida", TipoPaquete = "XL" }
    };

    private List<Destinatario> destinatarios = new List<Destinatario>
    {
    new Destinatario { Dni = "22334455", Nombre = "Juan Pérez" },
    new Destinatario { Dni = "33445566", Nombre = "María García" },
    new Destinatario { Dni = "44556677", Nombre = "Pedro Martínez" }
    };

    internal Destinatario? BuscarDestinatario(string dni)
    {
        if (string.IsNullOrWhiteSpace(dni))
        {
            MessageBox.Show("El DNI no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        if (!long.TryParse(dni, out _) || dni.Length != 8)
        {
            MessageBox.Show("El DNI debe ser numérico y de 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var destinatario = destinatarios.FirstOrDefault(d => d.Dni == dni);
        if (destinatario == null)
        {
            MessageBox.Show($"No se encontró ningún destinatario con DNI {dni}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        return destinatario;
    }

    internal List<Guia> ObtenerGuiasPorDestinatario(string dni)
    {
        return guias.Where(g => g.Estado == "Admitida").ToList();
    }

    internal bool RegistrarEntrega(List<Guia> guiasAEntregar)
    {
        if (guiasAEntregar.Count == 0)
        {
            MessageBox.Show("Debe seleccionar al menos una guía para entregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        foreach (var guia in guiasAEntregar)
        {
            var guiaEnLista = guias.FirstOrDefault(g => g.NGuia == guia.NGuia);
            if (guiaEnLista != null)
                guiaEnLista.Estado = "Entregada";
        }

        return true;
    }
}