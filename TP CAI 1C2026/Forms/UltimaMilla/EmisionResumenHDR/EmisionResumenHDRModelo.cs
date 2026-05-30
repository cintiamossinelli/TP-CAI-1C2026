using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDR
{
    internal class EmisionResumenHDRModelo
    {
        internal Fletero? BuscarFletero(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("El DNI del fletero no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var cuitFormateado = NormalizarCuit(text);
            if (cuitFormateado == null) // es que no es válido
            {
                MessageBox.Show("El DNI del fletero debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Simulación de búsqueda en una base de datos o servicio
            var FleterosSimulados = new List<Fletero>
            {
                new Fletero { Dni = "32443521", Nombre = "Jorge Fernandez" },
                new Fletero { Dni = "33678891", Nombre = "Tomas Sanchez" },
                new Fletero { Dni = "29535430", Nombre = "Yanina Mossinelli" },
                new Fletero { Dni = "40802312", Nombre = "José Perez" },
                new Fletero { Dni = "30461832", Nombre = "Juan Gonzalez" }
            };

            var fleteroEncontrado = FleterosSimulados.Find(c => c.Dni == cuitFormateado);
            if (fleteroEncontrado == null)
            {
                MessageBox.Show($"No se encontró un fletero con DNI {cuitFormateado}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return fleteroEncontrado;
        }

        public static string? NormalizarCuit(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return null;
            }

            // Dejar solo números
            string dni = new string(texto.Where(char.IsDigit).ToArray());

            if (!long.TryParse(dni, out _))
            {
                return null;
            }

            if (dni.Length != 7 && dni.Length != 8)
            {
                return null;
            }
            else
            {
                return dni;
            }
        }
      
        private List<HDREntrega> EntregasSimuladas = new List<HDREntrega>
        {
            new HDREntrega(1001, "Av. Corrientes 1234, CABA", 5, "32443521"),
            new HDREntrega(1002, "Calle Florida 450, CABA", 3, "32443521"),
            new HDREntrega(1003, "Av. Santa Fe 2900, CABA", 8, "33678891"),
            new HDREntrega(1004, "Brandsen 805, CABA", 4, "29535430")
        };

        private List<HDRRetiro> RetirosSimuladas = new List<HDRRetiro>
        {
            new HDRRetiro(5001, "Depósito Central Barracas", 2, "32443521"),
            new HDRRetiro(5002, "Sucursal Flores, Rivadavia 7000", 6, "33678891"),
            new HDRRetiro(5003, "Sucursal Belgrano, Cabildo 2200", 1, "33678891")
        };

        public List<HDREntrega> BuscarEntregasPorDni(string dni)
        {
            List<HDREntrega> resultado = new List<HDREntrega>();
            foreach (var entrega in EntregasSimuladas)
            {
                if (entrega.DniFleteroAsignado == dni)
                {
                    resultado.Add(entrega);
                }
            }
            return resultado;
        }

        public List<HDRRetiro> BuscarRetirosPorDni(string dni)
        {
            List<HDRRetiro> resultado = new List<HDRRetiro>();
            foreach (var retiro in RetirosSimuladas)
            {
                if (retiro.DniFleteroAsignado == dni)
                {
                    resultado.Add(retiro);
                }
            }
            return resultado;
        }

        // Devuelve ambos listados filtrados por DNI en una sola llamada
        public (List<HDREntrega> entregas, List<HDRRetiro> retiros) ObtenerEntregasYRetirosPorDni(string dni)
        {
            var entregas = BuscarEntregasPorDni(dni);
            var retiros = BuscarRetirosPorDni(dni);
            return (entregas, retiros);
        }

        // Intenta obtener entregas y retiros por DNI; si no hay ninguno devuelve false y un mensaje
        public bool TryObtenerEntregasYRetirosPorDni(string dni, out List<HDREntrega> entregas, out List<HDRRetiro> retiros, out string mensaje)
        {
            entregas = BuscarEntregasPorDni(dni);
            retiros = BuscarRetirosPorDni(dni);

            if ((entregas == null || entregas.Count == 0) && (retiros == null || retiros.Count == 0))
            {
                mensaje = $"El DNI {dni} no tiene hojas de ruta asociadas.";
                return false;
            }

            mensaje = string.Empty;
            return true;
        }
    }
}

