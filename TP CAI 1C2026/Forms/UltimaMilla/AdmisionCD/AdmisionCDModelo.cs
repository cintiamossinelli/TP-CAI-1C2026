using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.UltimaMilla.AdmisionCD
{
    internal class AdmisionCDModelo
    {

        private List<GuiasImpuestas> guiasAgregadas = new List<GuiasImpuestas>();
        internal GuiasImpuestas? BuscarGuias(string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    MessageBox.Show("El número de guía no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                var guiaEncontrada = guiasAgregadas.FirstOrDefault(g =>
                    string.Equals(g.Id, text, StringComparison.OrdinalIgnoreCase));

                if (guiaEncontrada == null)
                {
                    var guiaEntidad = GuiaAlmacen.Guias.FirstOrDefault(g =>
                        string.Equals(g.NroGuia, text, StringComparison.OrdinalIgnoreCase));

                    if (guiaEntidad == null)
                    {
                        MessageBox.Show($"No se encontró una guía con el número {text}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    guiaEncontrada = new GuiasImpuestas
                    {
                        Id = guiaEntidad.NroGuia,
                        Tamaño = guiaEntidad.TipoCaja.ToString(),
                        Estado = guiaEntidad.Estado.ToString()
                    };
                }

                if (!string.Equals(guiaEncontrada.Estado,EstadoGuiaEnum.PendienteDeAdmision.ToString(),StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"La guía con el número {text} no está en estado 'Pendiente de admisión'.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return null;
                }

                if (!guiasAgregadas.Contains(guiaEncontrada))
                {
                    guiasAgregadas.Add(guiaEncontrada);
                }

                return guiaEncontrada;
            }

        internal bool ValidarHayGuiasParaAdmitir(IEnumerable<GuiasImpuestas> guias)
        {
            if (guias == null || !guias.Any())
            {
                MessageBox.Show("No hay guías para admitir. Por favor, agregue al menos una guía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        internal bool ValidarHayGuiasParaRechazar(IEnumerable<GuiasImpuestas> guias)
        {
            if (guias == null || !guias.Any())
            {
                MessageBox.Show("No hay guías para rechazar. Por favor, agregue al menos una guía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        internal void AdmitirGuias(IEnumerable<GuiasImpuestas> guias)
        {
            if (guias == null)
            {
                return;
            }

            DateTime fechaActual = DateTime.Now;

            foreach (var g in guias)
            {
                if (g == null)
                {
                    continue;
                }

                var guiaEntidad = GuiaAlmacen.Guias.FirstOrDefault(guia =>
                    string.Equals(guia.NroGuia, g.Id, StringComparison.OrdinalIgnoreCase));

                if (guiaEntidad == null)
                {
                    continue;
                }

                guiaEntidad.PrecioVenta = CalcularPrecioVenta(guiaEntidad);
                guiaEntidad.Historial ??= new List<HistorialGuia>();
                guiaEntidad.Historial.Add(new HistorialGuia
                {
                    Fecha = fechaActual,
                    Estado = EstadoGuiaEnum.Admitida
                });

                bool destinoLocal =
                    guiaEntidad.TipoImposicion == TipoImposicionEnum.EnDomicilio
                        ? EsDestinoDelCentroDeImposicion(guiaEntidad)
                        : EsMismaCiudadOrigenYDestino(guiaEntidad);

                if (destinoLocal)
                {
                    guiaEntidad.Historial.Add(new HistorialGuia
                    {
                        Fecha = fechaActual,
                        Estado = EstadoGuiaEnum.EnDestino
                    });

                    if ((guiaEntidad.TipoImposicion == TipoImposicionEnum.Agencia ||
                         guiaEntidad.TipoImposicion == TipoImposicionEnum.EnDomicilio) &&
                        guiaEntidad.TipoEntrega == TipoEntregaEnum.CD)
                    {
                        guiaEntidad.Estado = EstadoGuiaEnum.PendienteDeEntrega;
                        guiaEntidad.Historial.Add(new HistorialGuia
                        {
                            Fecha = fechaActual,
                            Estado = EstadoGuiaEnum.PendienteDeEntrega
                        });
                        g.Estado = EstadoGuiaEnum.PendienteDeEntrega.ToString();
                    }
                    else
                    {
                        guiaEntidad.Estado = EstadoGuiaEnum.EnDestino;
                        g.Estado = EstadoGuiaEnum.EnDestino.ToString();
                    }
                }
                else
                {
                    guiaEntidad.Estado = EstadoGuiaEnum.Admitida;
                    g.Estado = "Admitida";
                }
            }

            GuiaAlmacen.Guardar();
        }

        private static bool EsDestinoDelCentroDeImposicion(GuiaEntidad guia)
        {
            if (guia.IdCentroDeDistribucionImposicion <= 0)
            {
                return false;
            }

            if (guia.TipoEntrega == TipoEntregaEnum.CD ||
                guia.TipoEntrega == TipoEntregaEnum.ADomicilio)
            {
                return guia.IdCentroDeDistribucionImposicion ==
                    guia.IdCentroDeDistribucionEntrega;
            }

            if (guia.TipoEntrega == TipoEntregaEnum.Agencia)
            {
                int? idCentroDeDistribucionAgencia = CiudadAlmacen.Ciudades
                    .FirstOrDefault(ciudad =>
                        ciudad.Agencias != null &&
                        ciudad.Agencias.Contains(guia.IdAgenciaEntrega))?
                    .IdCentroDeDistribucion;

                return idCentroDeDistribucionAgencia ==
                    guia.IdCentroDeDistribucionImposicion;
            }

            return false;
        }

        private static decimal CalcularPrecioVenta(GuiaEntidad guia)
        {
            decimal precioBase = ClienteAlmacen.Clientes
                .FirstOrDefault(cliente =>
                    cliente.CuitDniCuilCliente == guia.CuitDniCuilCliente)?
                .Tarifario
                .FirstOrDefault(precio =>
                    precio.TamañoEncomienda == guia.TipoCaja)?
                .Importe ?? 0;

            decimal tarifasExtra = 0;

            if (guia.TipoImposicion == TipoImposicionEnum.EnDomicilio)
            {
                tarifasExtra += ObtenerTarifaExtra((TipoExtraEnum)1);
            }

            if (guia.TipoEntrega == TipoEntregaEnum.ADomicilio)
            {
                tarifasExtra += ObtenerTarifaExtra((TipoExtraEnum)2);
            }

            if (guia.TipoEntrega == TipoEntregaEnum.Agencia)
            {
                tarifasExtra += ObtenerTarifaExtra((TipoExtraEnum)3);
            }

            return precioBase + tarifasExtra;
        }

        private static decimal ObtenerTarifaExtra(TipoExtraEnum tipoTarifa)
        {
            return TarifaExtraAlmacen.Tarifas
                .FirstOrDefault(tarifa => tarifa.Tarifa == tipoTarifa)?
                .Precio ?? 0;
        }

        internal void RechazarGuias(IEnumerable<GuiasImpuestas> guias)
        {
            if (guias == null)
            {
                return;
            }

            DateTime fechaActual = DateTime.Now;

            foreach (var g in guias)
            {
                if (g == null)
                {
                    continue;
                }

                var guiaEntidad = GuiaAlmacen.Guias.FirstOrDefault(guia =>
                    string.Equals(guia.NroGuia, g.Id, StringComparison.OrdinalIgnoreCase));

                if (guiaEntidad == null)
                {
                    continue;
                }

                guiaEntidad.Estado = EstadoGuiaEnum.Rechazada;
                guiaEntidad.Historial ??= new List<HistorialGuia>();
                guiaEntidad.Historial.Add(new HistorialGuia
                {
                    Fecha = fechaActual,
                    Estado = EstadoGuiaEnum.Rechazada
                });
                g.Estado = "Rechazada";
            }

            GuiaAlmacen.Guardar();
        }

        private static bool EsMismaCiudadOrigenYDestino(GuiaEntidad guia)
        {
            int? idCiudadOrigen = ObtenerIdCiudadOrigen(guia);
            int? idCiudadDestino = ObtenerIdCiudadDestino(guia);

            return idCiudadOrigen.HasValue &&
                   idCiudadDestino.HasValue &&
                   idCiudadOrigen.Value == idCiudadDestino.Value;
        }

        private static int? ObtenerIdCiudadOrigen(GuiaEntidad guia)
        {
            if (guia.IdCentroDeDistribucionImposicion > 0)
            {
                return CiudadAlmacen.Ciudades.FirstOrDefault(ciudad =>ciudad.IdCentroDeDistribucion == guia.IdCentroDeDistribucionImposicion)?.IdCiudad;
            }

            if (guia.IdAgenciaImposicion > 0)
            {
                return CiudadAlmacen.Ciudades.FirstOrDefault(ciudad =>ciudad.Agencias.Contains(guia.IdAgenciaImposicion))?.IdCiudad;
            }

            return null;
        }

        private static int? ObtenerIdCiudadDestino(GuiaEntidad guia)
        {
            if (guia.IdCentroDeDistribucionEntrega > 0)
            {
                return CiudadAlmacen.Ciudades.FirstOrDefault(ciudad =>ciudad.IdCentroDeDistribucion == guia.IdCentroDeDistribucionEntrega)?.IdCiudad;
            }

            if (guia.IdAgenciaEntrega > 0)
            {
                return CiudadAlmacen.Ciudades.FirstOrDefault(ciudad =>ciudad.Agencias.Contains(guia.IdAgenciaEntrega))?.IdCiudad;
            }

            return null;
        }
    }
}
