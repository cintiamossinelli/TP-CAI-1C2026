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
        internal List<Cliente> ObtenerClientes()
        {
            // Simulación de obtención de clientes con facturas (una por mes),
            // notas de crédito parciales y recibos parciales.
            return new List<Cliente>
            {
                // Empresa A: facturas Enero-Junio 2026 (días 1..5), algunas NC y recibos parciales
                new Cliente
                {
                    Cuit = "33-63761744-9",
                    RazonSocial = "Empresa A",
                    Factura = new List<Facturas>
                    {
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00001001", Fecha = new DateTime(2026, 1,  1), Total = 120000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00001002", Fecha = new DateTime(2026, 2,  2), Total = 135000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00001003", Fecha = new DateTime(2026, 3,  3), Total = 140000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00001004", Fecha = new DateTime(2026, 4,  4), Total = 160000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00001005", Fecha = new DateTime(2026, 5,  5), Total = 150000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0002-00001006", Fecha = new DateTime(2025, 12, 1), Total = 170000 },
                    },
                    NotasDeCredito = new List<NotaDeCredito>
                    {
                        // NC parciales para algunas facturas
                        new() { Descripcion="Nota de Crédito", NumeroNotaCredito = "A 0001-00001002", Fecha = new DateTime(2026, 2, 15), Total = 35000 },
                        new() { Descripcion="Nota de Crédito", NumeroNotaCredito = "A 0001-00001004", Fecha = new DateTime(2026, 4, 10), Total = 40000 },
                    },
                    Recibos = new List<Recibo>
                    {
                        // Pagos parciales (no cubren totales)
                        new() { Descripcion="Recibo", NumeroRecibo = "R 0001-00001001", Fecha = new DateTime(2026, 1, 20), Total = 60000 },
                        new() { Descripcion="Recibo", NumeroRecibo = "R 0001-00001003", Fecha = new DateTime(2026, 3, 20), Total = 70000 },
                        new() { Descripcion="Recibo", NumeroRecibo = "R 0001-00001005", Fecha = new DateTime(2026, 5, 25), Total = 50000 }
                    }
                },

                // Empresa B: facturas Marzo-Agosto 2026, una nota de crédito y recibos parciales
                new Cliente
                {
                    Cuit = "30-64621216-9",
                    RazonSocial = "Empresa B",
                    Factura = new List<Facturas>
                    {
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00002001", Fecha = new DateTime(2026, 1, 3), Total = 80000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00002002", Fecha = new DateTime(2026, 2, 2), Total = 90000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00002003", Fecha = new DateTime(2026, 3, 3), Total = 95000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00002004", Fecha = new DateTime(2026, 4, 4), Total = 110000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00002005", Fecha = new DateTime(2026, 5, 5), Total = 200000 },
                       
                    },
                    NotasDeCredito = new List<NotaDeCredito>
                    {
                        new() { Descripcion="Nota de Crédito", NumeroNotaCredito = "A 0002-00002003", Fecha = new DateTime(2026,5,12), Total = 15000 } // parcial
                    },
                    Recibos = new List<Recibo>
                    {
                        new() { Descripcion="Recibo", NumeroRecibo = "R 0002-00002001", Fecha = new DateTime(2026,3,20), Total = 40000 },
                        new() { Descripcion="Recibo", NumeroRecibo = "R 0002-00002004", Fecha = new DateTime(2026,5,18), Total = 50000 }
                    }
                },

                // Empresa C: facturas Abril-Septiembre 2026, sin notas de crédito, un recibo
                new Cliente
                {
                    Cuit = "30-67337754-4",
                    RazonSocial = "Empresa C",
                    Factura = new List<Facturas>
                    {
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00003001", Fecha = new DateTime(2026,1,5), Total = 60000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00003002", Fecha = new DateTime(2026,2,2), Total = 62000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00003003", Fecha = new DateTime(2026,3,3), Total = 63000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00003004", Fecha = new DateTime(2026,4,4), Total = 65000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00003005", Fecha = new DateTime(2026,5,5), Total = 67000 },
                        
                    },
                    NotasDeCredito = new List<NotaDeCredito>(), // ninguna
                    Recibos = new List<Recibo>
                    {
                        new() { Descripcion="Recibo", NumeroRecibo = "R 0003-00003002", Fecha = new DateTime(2026,5,20), Total = 30000 }
                    }
                },

                // José Perez: facturas mensuales Feb-Jul 2026, una NC pequeña, recibos parciales
                new Cliente
                {
                    Cuit = "33078369",
                    RazonSocial = "José Perez",
                    Factura = new List<Facturas>
                    {
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00004001", Fecha = new DateTime(2026,2,4), Total = 20000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00004002", Fecha = new DateTime(2026,2,2), Total = 25000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00004003", Fecha = new DateTime(2026,3,3), Total = 22000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00004004", Fecha = new DateTime(2026,4,4), Total = 24000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00004005", Fecha = new DateTime(2026,5,2), Total = 25000 },
                        
                    },
                    NotasDeCredito = new List<NotaDeCredito>
                    {
                        new() { Descripcion="Nota de Crédito", NumeroNotaCredito = "A 0004-00004003", Fecha = new DateTime(2026,4,15), Total = 5000 }
                    },
                    Recibos = new List<Recibo>
                    {
                        new() { Descripcion="Recibo", NumeroRecibo = "R 0004-00004002", Fecha = new DateTime(2026,3,18), Total = 10000 },
                        new() { Descripcion="Recibo", NumeroRecibo = "R 0004-00004005", Fecha = new DateTime(2026,4,28), Total = 15000 }
                    }
                },

                // Juan Gonzalez: facturas mensuales Mayo-Oct 2026, algunas NC y un recibo
                new Cliente
                {
                    Cuit = "9123456",
                    RazonSocial = "Juan Gonzalez",
                    Factura = new List<Facturas>
                    {
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00005001", Fecha = new DateTime(2026,2,1), Total = 45000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00005002", Fecha = new DateTime(2026,3,2), Total = 47000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00005003", Fecha = new DateTime(2026,4,3), Total = 49000 },
                        new() { Descripcion="Factura", NumeroFactura = "A 0001-00005004", Fecha = new DateTime(2026,5,19), Total = 51000 },
                       
                    },
                    NotasDeCredito = new List<NotaDeCredito>
                    {
                        new() { Descripcion="Nota de Crédito", NumeroNotaCredito = "NC 0005-00005002", Fecha = new DateTime(2026,6,12), Total = 7000 },
                        new() { Descripcion="Nota de Crédito", NumeroNotaCredito = "NC 0005-00005005", Fecha = new DateTime(2026,9,10), Total = 10000 }
                    },
                    Recibos = new List<Recibo>
                    {
                        new() { Descripcion="Recibo", NumeroRecibo = "R 0005-00005001", Fecha = new DateTime(2026,5,22), Total = 20000 }
                    }
                }
            };
        }
    }
}
