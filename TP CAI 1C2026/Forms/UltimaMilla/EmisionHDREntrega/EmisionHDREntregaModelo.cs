// EmisionHDREntregaModelo.cs
namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega
{
    internal class EmisionHDREntregaModelo
    {
        private List<Fletero> fleteros = new List<Fletero>
        {
            new Fletero(12345678, "Carlos López"),
            new Fletero(87654321, "Roberto Gómez"),
            new Fletero(11223344, "Pedro Martínez")
        };

        private List<Guia> guias = new List<Guia>
        {
            new Guia("CC-1001", "S", "Av. Corrientes 1234, Buenos Aires"),
            new Guia("CC-1002", "M", "Agencia Centro"),
            new Guia("CC-1003", "L", "Av. Santa Fe 567, Buenos Aires"),
            new Guia("CC-1004", "XL", "Agencia Norte"),
            new Guia("CC-1005", "S", "Av. Rivadavia 890, Buenos Aires")
        };

        private int ultimoNumeroHDR = 500;

        public Fletero? BuscarFletero(string dni)
        {
            if (!int.TryParse(dni, out int dniInt) || dniInt <= 0)
                return null;
            if (dni.Length != 8)
                return null;
            return fleteros.FirstOrDefault(f => f.Dni == dniInt);
        }

        public List<Guia> ObtenerGuiasPendientes()
        {
            return guias;
        }

        public Guia? BuscarGuia(string nGuia)
        {
            if (string.IsNullOrWhiteSpace(nGuia))
                return null;
            return guias.FirstOrDefault(g => g.NGuia == nGuia);
        }

        private List<string> localidades = new List<string>
        {
            "Buenos Aires",
            "Córdoba",
            "Rosario",
            "Mendoza",
            "Tucumán"
        };

        public List<string> ObtenerLocalidades()
        {
            return localidades;
        }
        public bool GenerarHDR(Fletero fletero, List<Guia> guiasAgregadas, out string mensajeExito, out string error)
        {
            error = string.Empty;
            mensajeExito = string.Empty;

            if (guiasAgregadas.Count == 0)
            {
                error = "Debe agregar al menos una guía a la HDR.";
                return false;
            }

            ultimoNumeroHDR++;
            mensajeExito = $"HDR N° {ultimoNumeroHDR} generada correctamente para el fletero {fletero.Nombre}.";
            return true;
        }
    }
}
