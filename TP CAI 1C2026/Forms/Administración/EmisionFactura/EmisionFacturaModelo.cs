using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TP_CAI_1C2026.Forms.Administración.EmisionFactura
{
    internal class EmisionFacturaModelo
    {
        internal Cliente? BuscarCliente(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show(
                    "El CUIT del cliente no puede estar vacío.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }

            var cuitFormateado =
                NormalizarCuit(text);

            if (cuitFormateado == null)
            {
                MessageBox.Show(
                    "El CUIT del cliente debe ser válido.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }

            // Simulación de clientes
            var clientesSimulados =
                new List<Cliente>
                {
                    new Cliente
                    {
                        Cuit = "33-63761744-9",
                        RazonSocial = "Empresa A"
                    },

                    new Cliente
                    {
                        Cuit = "30-64621216-9",
                        RazonSocial = "Empresa B"
                    },

                    new Cliente
                    {
                        Cuit = "30-67337754-4",
                        RazonSocial = "Empresa C"
                    }
                };

            var clienteEncontrado =
                clientesSimulados
                .FirstOrDefault(c =>
                    c.Cuit == cuitFormateado);

            if (clienteEncontrado == null)
            {
                MessageBox.Show(
                    $"No se encontró un cliente con CUIT {cuitFormateado}.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }

            return clienteEncontrado;
        }

        internal List<GuiasAFacturar>
            ObtenerGuiasPendientes(Cliente cliente)
        {
            // Simulación de guías pendientes

            return new List<GuiasAFacturar>
            {
                new GuiasAFacturar
                {
                    Id = "G001",
                    Fecha = new DateTime(2026, 05, 10),
                    Monto = 1000
                },

                new GuiasAFacturar
                {
                    Id = "G002",
                    Fecha = new DateTime(2026, 05, 11),
                    Monto = 1500
                },

                new GuiasAFacturar
                {
                    Id = "G003",
                    Fecha = new DateTime(2026, 05, 12),
                    Monto = 2000
                }
            };
        }

        internal decimal CalcularTotal(
            List<GuiasAFacturar> guias)
        {
            return guias.Sum(g => g.Monto);
        }

        internal Factura EmitirFactura(
            Cliente cliente,
            List<GuiasAFacturar> guias)
        {
            var total =
                CalcularTotal(guias);

            var factura =
                new Factura
                {
                    Numero = GenerarNumeroFactura(),
                    Cliente = cliente,
                    Fecha = DateTime.Now,
                    Total = total,
                    Guias = guias
                };

            return factura;
        }

        private string GenerarNumeroFactura()
        {
            return $"FAC-{DateTime.Now.Ticks}";
        }

        public static string? NormalizarCuit(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return null;
            }

            string cuit =
                new string(
                    texto.Where(char.IsDigit).ToArray());

            if (cuit.Length != 11)
            {
                return null;
            }

            if (!long.TryParse(cuit, out _))
            {
                return null;
            }

            int[] multiplicadores =
            {
                5,4,3,2,7,6,5,4,3,2
            };

            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma +=
                    (cuit[i] - '0') *
                    multiplicadores[i];
            }

            int resto = suma % 11;

            int digitoVerificador =
                11 - resto;

            if (digitoVerificador == 11)
            {
                digitoVerificador = 0;
            }
            else if (digitoVerificador == 10)
            {
                digitoVerificador = 9;
            }

            if (digitoVerificador !=
                (cuit[10] - '0'))
            {
                return null;
            }

            return
                $"{cuit[..2]}-{cuit.Substring(2, 8)}-{cuit[10]}";
        }
    }
}
