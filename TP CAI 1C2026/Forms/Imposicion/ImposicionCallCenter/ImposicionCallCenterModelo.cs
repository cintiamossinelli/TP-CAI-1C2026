namespace TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter
{
    internal class ImposicionCallCenterModelo
    {
        private List<Cliente> clientes = new List<Cliente>
        {
            new Cliente(12345678, "Juan Pérez"),
            new Cliente(87654321, "María García"),
            new Cliente(30123456789, "Empresa SRL")
        };

        private List<string> ciudades = new List<string>
        {
            "Buenos Aires",
            "Córdoba",
            "Rosario",
            "Mendoza",
            "Tucumán"
        };

        private List<string> centrosDistribucion = new List<string>
        {
            "CD Buenos Aires",
            "CD Córdoba",
            "CD Rosario",
            "CD Mendoza",
            "CD Tucumán"
        };

        private List<string> agencias = new List<string>
        {
            "Agencia Centro",
            "Agencia Norte",
            "Agencia Sur",
            "Agencia Este",
            "Agencia Oeste"
        };

        private int ultimoNumeroGuia = 1000;

        public List<string> ObtenerCiudades()
        {
            return ciudades;
        }

        public List<string> ObtenerCDs()
        {
            return centrosDistribucion;
        }

        public List<string> ObtenerAgencias()
        {
            return agencias;
        }

        public Cliente BuscarCliente(string idCliente)
        {
            if (!long.TryParse(idCliente, out long id) || id <= 0)
                return null;
            if (idCliente.Length != 8 && idCliente.Length != 11)
                return null;

            return clientes.FirstOrDefault(c => c.Id == id);
        }

        public bool AgregarEncomienda(string tipoCaja, string cantidad, List<Encomienda> encomiendas, out string error)
        {
            error = string.Empty;

            if (!int.TryParse(cantidad, out int cant) || cant <= 0)
            {
                error = "La cantidad debe ser un valor numérico, entero y positivo.";
                return false;
            }

            encomiendas.Add(new Encomienda(tipoCaja, cant));
            return true;
        }

        public bool Confirmar(string dniDestinatario, List<Encomienda> encomiendas, out string mensajeExito, out string error)
        {
            error = string.Empty;
            mensajeExito = string.Empty;

            if (string.IsNullOrWhiteSpace(dniDestinatario))
            {
                error = "Debe ingresar el DNI del destinatario.";
                return false;
            }

            if (!long.TryParse(dniDestinatario, out long dni) || dni <= 0)
            {
                error = "El DNI debe ser numérico y positivo.";
                return false;
            }

            if (encomiendas.Count == 0)
            {
                error = "Debe agregar al menos una encomienda.";
                return false;
            }

            List<string> guiasGeneradas = new List<string>();
            foreach (var encomienda in encomiendas)
            {
                for (int i = 0; i < encomienda.Cantidad; i++)
                {
                    ultimoNumeroGuia++;
                    guiasGeneradas.Add($"CC-{ultimoNumeroGuia}");
                }
            }

            mensajeExito = $"Guías generadas: {string.Join(", ", guiasGeneradas)}";
            return true;
        }
    }
}
