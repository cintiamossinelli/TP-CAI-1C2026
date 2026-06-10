/* CÓDIGO ANTERIOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.Administración.EmisionFactura
{
    internal class EmisionFacturaModelo
    {
        private List<GuiasAFacturar> guiasActuales = new List<GuiasAFacturar>();
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

        internal List<Cliente> ObtenerGuiasPendientes()
        {
            // Simulación de guías pendientes
            return new List<Cliente>
            {
                new Cliente { Cuit = "33-63761744-9", RazonSocial = "Empresa A", GuiasPendientes = new List<GuiasAFacturar>
                {
                    new GuiasAFacturar { Id = "AG-3-56", Fecha = DateTime.Now.AddDays(-10), Monto = 1000 },
                    new GuiasAFacturar { Id = "AG-3-57", Fecha = DateTime.Now.AddDays(-5), Monto = 1500 }
                }
                },
                new Cliente { Cuit = "30-64621216-9", RazonSocial = "Empresa B", GuiasPendientes = new List<GuiasAFacturar>
                {
                    new GuiasAFacturar { Id = "CD-2-111", Fecha = DateTime.Now.AddDays(-8), Monto = 2000 }
                }
                },
                new Cliente { Cuit = "30-67337754-4", RazonSocial = "Empresa C", GuiasPendientes = new List<GuiasAFacturar>
                {
                    new GuiasAFacturar { Id = "AG-3-1", Fecha = DateTime.Now.AddDays(-12), Monto = 2500 },
                    new GuiasAFacturar { Id = "AG-3-2", Fecha = DateTime.Now.AddDays(-3), Monto = 3000 }
                }
                },
                new Cliente { Cuit = "33078369", RazonSocial = "José Perez", GuiasPendientes = new List<GuiasAFacturar>
                {
                    new GuiasAFacturar { Id = "AG-4-3", Fecha = DateTime.Now.AddDays(-15), Monto = 500 },
                    new GuiasAFacturar { Id = "AG-4-15", Fecha = DateTime.Now.AddDays(-2), Monto = 800 }
                }
                },
                new Cliente { Cuit = "9123456", RazonSocial = "Juan Gonzalez", GuiasPendientes = new List<GuiasAFacturar>
                {
                    new GuiasAFacturar { Id = "CC-3-21", Fecha = DateTime.Now.AddDays(-18), Monto = 550 },
                    new GuiasAFacturar { Id = "CC-3-22", Fecha = DateTime.Now.AddDays(-6), Monto = 1800 },
                    new GuiasAFacturar { Id = "CC-3-37", Fecha = DateTime.Now.AddDays(-1), Monto = 1200 }
                }
                }
            };
        }

        // Nueva firma sugerida:
        internal List<GuiasAFacturar> ObtenerGuiasPendientes(string cuitCliente)
        {
            // buscar en la lista simulada y devolver solo las GuiasPendientes del cliente indicado
            var guiasPendientes = ObtenerGuiasPendientes();

            var cliente = guiasPendientes.FirstOrDefault(c => c.Cuit == cuitCliente);

            // Guardar en el estado interno las guías actuales según lo solicitado por el profesor
            guiasActuales = cliente?.GuiasPendientes ?? new List<GuiasAFacturar>();
            return guiasActuales;
        }

        // Nueva versión:
        internal List<GuiasAFacturar> ObtenerGuiasPendientes(string cuitCliente)
        {
            guiasActuales =
                GuiaAlmacen.Guias
                .Where(g =>
                    g.CuitDniCuilCliente == cuitCliente
                    &&
                    (
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


        // Exponer las guías actuales que el modelo mantiene
        internal List<GuiasAFacturar> GuiasActuales => guiasActuales;

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

        private static int _contadorFactura = 0;

        private string GenerarNumeroFactura()
        {
            // Incrementar de forma segura el contador
            _contadorFactura++;
            // Formatear número como A-0004-0001, A-0004-0002, etc.
            // Ahora la parte final tiene 8 dígitos: A-0004-00000007
            return $"A-0004-{_contadorFactura:D8}";
        }

        //Nueva versión GenerarFactura()
        private string GenerarNumeroFactura(Cliente cliente)
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

                    return int.Parse(partes[2]);
                })
                .DefaultIfEmpty(0)
                .Max();

            return
                $"{letra}-0001-{(ultimoNumero + 1):D8}";
        }

    }
}*/

//CÓDIGO NUEVO
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