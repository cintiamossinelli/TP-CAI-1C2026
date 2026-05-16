using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Administración.CuentaCorrienteCliente
{
    internal class CuentaCorrienteClienteModelo
    {
        internal Cliente? BuscarCliente(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("El CUIT, CUIL o DNI del cliente no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var cuitFormateado = NormalizarCuit(text);
            if (cuitFormateado == null) //es que no es valido.
            {
                MessageBox.Show("El CUIT, CUIL o DNI del cliente debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Simulación de búsqueda en una base de datos o servicio
            var clientesSimulados = new List<Cliente>
        {
            new Cliente { Cuit = "33-63761744-9", RazonSocial = "Empresa A" },
            new Cliente { Cuit = "30-64621216-9", RazonSocial = "Empresa B" },
            new Cliente { Cuit = "30-67337754-4", RazonSocial = "Empresa C" },
            new Cliente { Cuit = "33078369", RazonSocial = "José Perez" },
            new Cliente { Cuit = "9123456", RazonSocial = "Juan Gonzalez" }
        };

            var clienteEncontrado = clientesSimulados.FirstOrDefault(c => c.Cuit == cuitFormateado);
            if (clienteEncontrado == null)
            {
                MessageBox.Show($"No se encontró un cliente con CUIT, CUIL o DNI {cuitFormateado}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return clienteEncontrado;
        }

        public static string? NormalizarCuit(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return null;
            }

            // Dejar solo números
            string cuit = new string(texto.Where(char.IsDigit).ToArray());

            // Debe tener 11 dígitos

            if (!long.TryParse(cuit, out _))
            {
                return null;
            }

            if (cuit.Length == 11)
            {
                int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

                int suma = 0;

                for (int i = 0; i < 10; i++)
                {
                    suma += (cuit[i] - '0') * multiplicadores[i];
                }

                int resto = suma % 11;
                int digitoVerificador = 11 - resto;

                if (digitoVerificador == 11)
                {
                    digitoVerificador = 0;
                }
                else if (digitoVerificador == 10)
                {
                    digitoVerificador = 9;
                }

                if (digitoVerificador != (cuit[10] - '0'))
                {
                    return null;
                }
            }
            else if (cuit.Length != 7 && cuit.Length != 8)
            {
                return null;
            }
            else
            {
                return cuit;
            }

            // Formato XX-XXXXXXXX-X
            return $"{cuit[..2]}-{cuit.Substring(2, 8)}-{cuit[10]}";
        }
    }
}
