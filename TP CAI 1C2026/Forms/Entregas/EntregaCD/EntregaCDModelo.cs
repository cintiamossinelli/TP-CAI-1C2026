namespace TP_CAI_1C2026.Forms.Entregas.EntregaCD;

internal class EntregaCDModelo
{
    private List<Guia> guias = new List<Guia>
    {
        new Guia { NGuia = "CD-3-1", Estado = "Pendiente de entrega", TipoPaquete = "S", DestinatarioDNI = "22334455" },
        new Guia { NGuia = "CD-3-2", Estado = "Pendiente de entrega", TipoPaquete = "M", DestinatarioDNI = "33445566" },
        new Guia { NGuia = "AG-5-1", Estado = "Pendiente de entrega", TipoPaquete = "L", DestinatarioDNI = "44556677" },
        new Guia { NGuia = "AG-9-13", Estado = "Pendiente de entrega", TipoPaquete = "XL", DestinatarioDNI = "55667788" },
        new Guia { NGuia = "AG-10-15", Estado = "Pendiente de entrega", TipoPaquete = "S", DestinatarioDNI = "66778899" },
        new Guia { NGuia = "AG-11-16", Estado = "Pendiente de entrega", TipoPaquete = "M", DestinatarioDNI = "77889900" },
        new Guia { NGuia = "AG-11-18", Estado = "Pendiente de entrega", TipoPaquete = "L", DestinatarioDNI = "88990011" },
        new Guia { NGuia = "AG-18-20", Estado = "Pendiente de entrega", TipoPaquete = "XL", DestinatarioDNI = "99001122" },
        new Guia { NGuia = "CD-4-5", Estado = "Pendiente de entrega", TipoPaquete = "S", DestinatarioDNI = "10111213" },
        new Guia { NGuia = "CC-1-30", Estado = "Pendiente de entrega", TipoPaquete = "S", DestinatarioDNI = "22334455" },
        new Guia { NGuia = "CD-3-50", Estado = "Pendiente de entrega", TipoPaquete = "M", DestinatarioDNI = "33445566" },
        new Guia { NGuia = "CD-23-150", Estado = "Pendiente de entrega", TipoPaquete = "L", DestinatarioDNI = "44556677" },
        new Guia { NGuia = "CC-1-99", Estado = "Pendiente de entrega", TipoPaquete = "XL", DestinatarioDNI = "55667788" },
        new Guia { NGuia = "CC-1-65", Estado = "Pendiente de entrega", TipoPaquete = "S", DestinatarioDNI = "66778899" },
        new Guia { NGuia = "AG-11-87", Estado = "Pendiente de entrega", TipoPaquete = "M", DestinatarioDNI = "77889900" },
        new Guia { NGuia = "AG-13-98", Estado = "Pendiente de entrega", TipoPaquete = "L", DestinatarioDNI = "88990011" },
        new Guia { NGuia = "CD-2-235", Estado = "Pendiente de entrega", TipoPaquete = "XL", DestinatarioDNI = "99001122" },
        new Guia { NGuia = "CD-4-301", Estado = "Pendiente de entrega", TipoPaquete = "S", DestinatarioDNI = "10111213" },
        new Guia { NGuia = "CD-3-305", Estado = "Entregada", TipoPaquete = "S", DestinatarioDNI = "22334455" },
        new Guia { NGuia = "CD-3-7", Estado = "Impuesta", TipoPaquete = "M", DestinatarioDNI = "33445566" },
        new Guia { NGuia = "AG-5-17", Estado = "Admitida", TipoPaquete = "L", DestinatarioDNI = "44556677" },
        new Guia { NGuia = "AG-9-106", Estado = "En Tránsito", TipoPaquete = "XL", DestinatarioDNI = "55667788" },
        new Guia { NGuia = "AG-10-159", Estado = "Impuesta", TipoPaquete = "S", DestinatarioDNI = "66778899" },
        new Guia { NGuia = "AG-11-166", Estado = "Entregada", TipoPaquete = "M", DestinatarioDNI = "77889900" },
        new Guia { NGuia = "AG-11-188", Estado = "Entregada", TipoPaquete = "L", DestinatarioDNI = "88990011" },
        new Guia { NGuia = "AG-18-205", Estado = "Impuesta", TipoPaquete = "XL", DestinatarioDNI = "99001122" },
        new Guia { NGuia = "CD-4-506", Estado = "Admitida", TipoPaquete = "S", DestinatarioDNI = "10111213" },
        new Guia { NGuia = "CC-1-307", Estado = "Admitida", TipoPaquete = "S", DestinatarioDNI = "22334455" },
        new Guia { NGuia = "CD-3-509", Estado = "Admitida", TipoPaquete = "M", DestinatarioDNI = "33445566" },
        new Guia { NGuia = "CD-23-900", Estado = "Impuesta", TipoPaquete = "L", DestinatarioDNI = "44556677" },
        new Guia { NGuia = "CC-1-991", Estado = "Impuesta", TipoPaquete = "XL", DestinatarioDNI = "55667788" },
        new Guia { NGuia = "CC-1-653", Estado = "En Tránsito", TipoPaquete = "S", DestinatarioDNI = "66778899" },
        new Guia { NGuia = "AG-11-879", Estado = "En Tránsito", TipoPaquete = "M", DestinatarioDNI = "77889900" },
        new Guia { NGuia = "AG-13-989", Estado = "Admitida", TipoPaquete = "L", DestinatarioDNI = "88990011" },
        new Guia { NGuia = "CD-2-240", Estado = "Impuesta", TipoPaquete = "XL", DestinatarioDNI = "99001122" },
        new Guia { NGuia = "CD-4-370", Estado = "Impuesta", TipoPaquete = "S", DestinatarioDNI = "10111213" },
    };

    private List<Destinatario> destinatarios = new List<Destinatario>
    {
        new Destinatario { Dni = "22334455", Nombre = "Juan Pérez" },
        new Destinatario { Dni = "33445566", Nombre = "María García" },
        new Destinatario { Dni = "44556677", Nombre = "Pedro Martínez" },
        new Destinatario { Dni = "55667788", Nombre = "Ana López" },
        new Destinatario { Dni = "66778899", Nombre = "Luis Fernández" },
        new Destinatario { Dni = "77889900", Nombre = "Sofía Gómez" },
        new Destinatario { Dni = "88990011", Nombre = "Carlos Rodríguez" },
        new Destinatario { Dni = "99001122", Nombre = "Laura Sánchez" },
        new Destinatario { Dni = "10111213", Nombre = "Diego Torres" },
        new Destinatario { Dni = "11121314", Nombre = "Marta Díaz" }
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
        var resultado = guias
            .Where(g => g.Estado == "Pendiente de entrega" && g.DestinatarioDNI == dni)
            .ToList();

        if (resultado == null || resultado.Count == 0)
        {
            MessageBox.Show("No se encontraron guías pendientes para el DNI ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return resultado;
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
