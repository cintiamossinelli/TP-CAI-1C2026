using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.Administración.EmisionFactura
{
    internal class EmisionFacturaModelo
    {
        private List<GuiasAFacturar> guiasActuales = new();

        internal List<GuiasAFacturar> GuiasActuales => guiasActuales;

        internal Cliente? BuscarCliente(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show(
                    "El CUIT, CUIL o DNI del cliente no puede estar vacío.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }

            string? cuitFormateado =
                NormalizarCuit(text);

            if (cuitFormateado == null)
            {
                MessageBox.Show(
                    "El CUIT, CUIL o DNI del cliente debe ser un número válido.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }

            ClienteEntidad? entidad =
                ClienteAlmacen.Clientes
                .FirstOrDefault(c =>
                    c.CuitDniCuilCliente == cuitFormateado);

            if (entidad == null)
            {
                MessageBox.Show(
                    $"No se encontró un cliente con CUIT, CUIL o DNI {cuitFormateado}.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }

            return new Cliente
            {
                Cuit = entidad.CuitDniCuilCliente,
                RazonSocial = entidad.RazonSocial
            };
        }

        public static string? NormalizarCuit(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return null;
            }

            string cuit =
                new string(
                    texto.Where(char.IsDigit)
                    .ToArray());

            if (!long.TryParse(cuit, out _))
            {
                return null;
            }

            if (cuit.Length == 11)
            {
                int[] multiplicadores =
                {
                    5,4,3,2,7,6,5,4,3,2
                };

                int suma = 0;

                for (int i = 0; i < 10; i++)
                {
                    suma +=
                        (cuit[i] - '0')
                        * multiplicadores[i];
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

            if (cuit.Length == 7 ||
                cuit.Length == 8)
            {
                return cuit;
            }

            return null;
        }

        internal List<GuiasAFacturar> ObtenerGuiasPendientes(
            string cuitCliente)
        {
            guiasActuales =
                GuiaAlmacen.Guias
                .Where(g =>
                    g.CuitDniCuilCliente == cuitCliente
                    &&
                    (
                        g.Estado == EstadoGuiaEnum.NoEntregada
                        ||
                        g.Estado == EstadoGuiaEnum.Entregada
                        ||
                        g.Estado == EstadoGuiaEnum.NoRetirada
                    ))
                .Select(g =>
                    new GuiasAFacturar
                    {
                        Id = g.NroGuia,
                        Fecha = g.FechaImposicion,
                        Monto = g.PrecioVenta
                    })
                .ToList();

            return guiasActuales;
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
            decimal total =
                CalcularTotal(guias);

            Factura factura =
                new Factura
                {
                    Numero =
                        GenerarNumeroFactura(cliente),

                    Cliente = cliente,

                    Fecha = DateTime.Now,

                    Total = total,

                    Guias = guias
                };

            FacturaAlmacen.Agregar(
                new FacturaEntidad
                {
                    NumeroFactura =
                        factura.Numero,

                    Fecha =
                        factura.Fecha,

                    Total =
                        factura.Total,

                    Descripcion =
                        "Factura",

                    Guias =
                        guias
                        .Select(g => g.Id)
                        .ToList()
                });

            ClienteEntidad? clienteEntidad =
                ClienteAlmacen.Clientes
                .FirstOrDefault(c =>
                    c.CuitDniCuilCliente ==
                    cliente.Cuit);

            if (clienteEntidad != null)
            {
                clienteEntidad.Factura ??=
                    new List<string>();

                clienteEntidad.Factura.Add(
                    factura.Numero);

                ClienteAlmacen.Guardar();
            }

            foreach (GuiasAFacturar guia in guias)
            {
                GuiaEntidad? guiaEntidad =
                    GuiaAlmacen.Guias
                    .FirstOrDefault(g =>
                        g.NroGuia ==
                        guia.Id);

                if (guiaEntidad == null)
                {
                    continue;
                }

                guiaEntidad.Estado =
                    EstadoGuiaEnum.Facturada;

                guiaEntidad.Historial ??=
                    new List<HistorialGuia>();

                guiaEntidad.Historial.Add(
                    new HistorialGuia
                    {
                        Fecha =
                            DateTime.Now,

                        Estado =
                            EstadoGuiaEnum.Facturada
                    });
            }

            GuiaAlmacen.Guardar();

            return factura;
        }

        private string GenerarNumeroFactura(
            Cliente cliente)
        {
            string letra =
                cliente.Cuit.Contains("-")
                    ? "A"
                    : "B";

            int ultimoNumero =
                FacturaAlmacen.Facturas
                .Where(f =>
                    f.NumeroFactura.StartsWith(
                        letra + "-"))
                .Select(f =>
                {
                    string[] partes =
                        f.NumeroFactura.Split('-');

                    return int.Parse(
                        partes[2]);
                })
                .DefaultIfEmpty(0)
                .Max();

            int nuevoNumero =
                ultimoNumero + 1;

            return
                $"{letra}-0001-{nuevoNumero:D8}";
        }
    }
}