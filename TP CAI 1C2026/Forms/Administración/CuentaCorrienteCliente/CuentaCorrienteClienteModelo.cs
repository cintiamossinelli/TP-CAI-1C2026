using System;
using System.Collections.Generic;
using System.Linq;
using TP_CAI_1C2026.Forms.Almacen;

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
            if (cuitFormateado == null)
            {
                MessageBox.Show("El CUIT, CUIL o DNI del cliente debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var clienteEntidad = ClienteAlmacen.Clientes
                .FirstOrDefault(cliente => cliente.CuitDniCuilCliente == cuitFormateado);

            if (clienteEntidad == null)
            {
                MessageBox.Show($"No se encontró un cliente con CUIT, CUIL o DNI {cuitFormateado}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new Cliente
            {
                Cuit = clienteEntidad.CuitDniCuilCliente,
                RazonSocial = clienteEntidad.RazonSocial
            };
        }

        public static string? NormalizarCuit(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return null;
            }

            string cuit = new string(texto.Where(char.IsDigit).ToArray());

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

            return $"{cuit[..2]}-{cuit.Substring(2, 8)}-{cuit[10]}";
        }

        internal Cliente? ObtenerClientes(string identificador, DateTime fechaDesde, DateTime fechaHasta)
        {
            var cuitFormateado = NormalizarCuit(identificador);
            if (cuitFormateado == null)
            {
                return null;
            }

            var clienteEntidad = ClienteAlmacen.Clientes
                .FirstOrDefault(cliente => cliente.CuitDniCuilCliente == cuitFormateado);

            if (clienteEntidad == null)
            {
                return null;
            }

            var numerosFacturas = clienteEntidad.Factura ?? new List<string>();
            var numerosNotasDeCredito = clienteEntidad.NotasDeCredito ?? new List<string>();
            var numerosRecibos = clienteEntidad.Recibos ?? new List<string>();

            return new Cliente
            {
                Cuit = clienteEntidad.CuitDniCuilCliente,
                RazonSocial = clienteEntidad.RazonSocial,
                Factura = FacturaAlmacen.Facturas
                    .Where(factura =>
                        numerosFacturas.Contains(factura.NumeroFactura) &&
                        EstaDentroDelRango(factura.Fecha, fechaDesde, fechaHasta))
                    .Select(factura => new Facturas
                    {
                        Descripcion = factura.Descripcion,
                        NumeroFactura = factura.NumeroFactura,
                        Fecha = factura.Fecha,
                        Total = (float)factura.Total
                    })
                    .ToList(),
                NotasDeCredito = NotaDeCreditoAlmacen.NotasDeCredito
                    .Where(nota =>
                        numerosNotasDeCredito.Contains(nota.NumeroNotaDeCredito) &&
                        EstaDentroDelRango(nota.Fecha, fechaDesde, fechaHasta))
                    .Select(nota => new NotaDeCredito
                    {
                        Descripcion = nota.Descripcion,
                        NumeroNotaCredito = nota.NumeroNotaDeCredito,
                        Fecha = nota.Fecha,
                        Total = (float)nota.Total
                    })
                    .ToList(),
                Recibos = ReciboAlmacen.Recibos
                    .Where(recibo =>
                        numerosRecibos.Contains(recibo.NumeroRecibo) &&
                        EstaDentroDelRango(recibo.Fecha, fechaDesde, fechaHasta))
                    .Select(recibo => new Recibo
                    {
                        Descripcion = recibo.Descripcion,
                        NumeroRecibo = recibo.NumeroRecibo,
                        Fecha = recibo.Fecha,
                        Total = (float)recibo.Total
                    })
                    .ToList()
            };
        }

        internal decimal CalcularSaldo(Cliente cliente)
        {
            decimal totalFacturas = cliente.Factura.Sum(factura => Convert.ToDecimal(factura.Total));
            decimal totalNotasDeCredito = cliente.NotasDeCredito.Sum(nota => Convert.ToDecimal(nota.Total));
            decimal totalRecibos = cliente.Recibos.Sum(recibo => Convert.ToDecimal(recibo.Total));

            return totalFacturas - totalNotasDeCredito - totalRecibos;
        }

        private static bool EstaDentroDelRango(DateTime fecha, DateTime fechaDesde, DateTime fechaHasta)
        {
            return fecha.Date >= fechaDesde.Date && fecha.Date <= fechaHasta.Date;
        }
    }
}
