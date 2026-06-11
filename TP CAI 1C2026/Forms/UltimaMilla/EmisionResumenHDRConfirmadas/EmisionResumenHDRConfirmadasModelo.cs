using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDRConfirmadas
{
    internal class EmisionResumenHDRConfirmadasModelo
    {
        // ── Búsqueda de fletero ───────────────────────────────────────

        internal bool TryBuscarFletero(string dniText, out Fletero? fletero, out string mensaje)
        {
            mensaje = string.Empty;
            fletero = null;

            if (string.IsNullOrWhiteSpace(dniText))
            {
                mensaje = "Ingrese DNI.";
                return false;
            }

            if (!int.TryParse(dniText, out int dniInt) || dniText.Length != 8)
            {
                mensaje = "El DNI debe ser numérico y de 8 dígitos.";
                return false;
            }

            fletero = BuscarFletero(dniText);
            if (fletero == null)
            {
                mensaje = "No existe ningún fletero registrado con ese DNI.";
                return false;
            }

            return true;
        }

        internal Fletero? BuscarFletero(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return null;

            if (!int.TryParse(dni, out int dniInt) || dniInt <= 0 || dni.Length != 8)
                return null;

            FleteroEntidad? entidad = FleteroAlmacen.Fleteros
                .FirstOrDefault(f => f.DNI == dniInt);

            if (entidad == null)
                return null;

            return new Fletero { Dni = entidad.DNI, Nombre = entidad.Nombre };
        }

        // ── Obtención de HDRs pendientes ─────────────────────────────

        internal List<HDREnTransito> ObtenerHDRPorFletero(int dniFletero)
        {
            var hdrsEntrega = HDREntregaAlmacen.HDREntregas
                .Where(h => h.DniFletero == dniFletero &&
                            h.Estado == EstadoHDREnum.PendienteRendicion)
                .Select(h => new HDREnTransito
                {
                    NroHDR = $"ENT{h.NroHDR}",
                    Domicilio = h.Domicilio,
                    CantEcomiendas = h.CantEncomiendas,
                    DniFletero = h.DniFletero,
                    Estado = h.Estado.ToString(),
                    TipoHDR = "Entrega"
                });

            var hdrsRetiro = HDRRetiroAlmacen.HDRRetiros
                .Where(h => h.DniFletero == dniFletero &&
                            h.Estado == EstadoHDREnum.PendienteRendicion)
                .Select(h => new HDREnTransito
                {
                    NroHDR = $"RET{h.NroHDR}",
                    Domicilio = h.Domicilio,
                    CantEcomiendas = h.CantEncomiendas,
                    DniFletero = h.DniFletero,
                    Estado = h.Estado.ToString(),
                    TipoHDR = "Retiro"
                });

            return hdrsEntrega.Concat(hdrsRetiro).ToList();
        }

        // ── Validaciones auxiliares del form ─────────────────────────

        internal bool HDRsPertenecenADni(IEnumerable<HDREnTransito> hdrsList, int dni)
        {
            if (hdrsList == null) return false;
            return hdrsList.Any(h => h.DniFletero == dni);
        }

        // ── Construcción del resumen para mostrar antes de confirmar ─

        internal string ConstruirResumen(
            IEnumerable<HDREnTransito> seleccionadas,
            IEnumerable<HDREnTransito> noSeleccionadas,
            string dniText)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Resumen Hojas de ruta para el DNI {dniText}:\n");
            sb.AppendLine("Confirmadas:");

            foreach (var h in seleccionadas)
                sb.AppendLine($"- Nro HDR: {h.NroHDR} | Domicilio: {h.Domicilio} | Cant. Encomiendas: {h.CantEcomiendas}");

            if (noSeleccionadas != null && noSeleccionadas.Any())
            {
                sb.AppendLine();
                sb.AppendLine("No Confirmadas:");
                foreach (var h in noSeleccionadas)
                    sb.AppendLine($"- Nro HDR: {h.NroHDR} | Domicilio: {h.Domicilio} | Cant. Encomiendas: {h.CantEcomiendas}");
            }

            return sb.ToString();
        }

        // ── Lógica de negocio principal ───────────────────────────────

        /// Aplica todas las reglas de negocio para las HDRs confirmadas y no confirmadas,
        /// actualiza guías y HDRs en los almacenes y persiste los cambios.
   
        internal void ActualizarEstados(
            List<HDREnTransito> confirmadas,
            List<HDREnTransito> noConfirmadas,
            int dniFletero)
        {
            FleteroEntidad? fletero = FleteroAlmacen.Fleteros
                .FirstOrDefault(f => f.DNI == dniFletero);

            foreach (var hdr in confirmadas)
                ProcesarHDR(hdr, confirmada: true, fletero);

            foreach (var hdr in noConfirmadas)
                ProcesarHDR(hdr, confirmada: false, fletero);

            GuiaAlmacen.Guardar();
            HDRRetiroAlmacen.Guardar();
            HDREntregaAlmacen.Guardar();
        }

        // ── Helpers privados ─────────────────────────────────────────

        private void ProcesarHDR(HDREnTransito hdr, bool confirmada, FleteroEntidad? fletero)
        {
            if (!TryObtenerNumeroHDR(hdr, out int nroHDR))
                return;

            if (hdr.TipoHDR == "Retiro")
            {
                HDRRetiroEntidad? entidad = HDRRetiroAlmacen.HDRRetiros
                    .FirstOrDefault(h => h.NroHDR == nroHDR);
                if (entidad == null) return;

                foreach (string nroGuia in entidad.Guias)
                {
                    GuiaEntidad? guia = GuiaAlmacen.Guias
                        .FirstOrDefault(g => g.NroGuia == nroGuia);
                    if (guia == null) continue;
                    ProcesarGuiaRetiro(guia, confirmada, fletero);
                }

                entidad.Estado = EstadoHDREnum.Rendida;
            }
            else // "Entrega"
            {
                HDREntregaEntidad? entidad = HDREntregaAlmacen.HDREntregas
                    .FirstOrDefault(h => h.NroHDR == nroHDR);
                if (entidad == null) return;

                foreach (string nroGuia in entidad.Guias)
                {
                    GuiaEntidad? guia = GuiaAlmacen.Guias
                        .FirstOrDefault(g => g.NroGuia == nroGuia);
                    if (guia == null) continue;
                    ProcesarGuiaEntrega(guia, confirmada, fletero);
                }

                entidad.Estado = EstadoHDREnum.Rendida;
            }
        }

        private bool TryObtenerNumeroHDR(HDREnTransito hdr, out int nroHDR)
        {
            string numeroHDR = hdr.NroHDR;

            if (hdr.TipoHDR == "Entrega" && numeroHDR.StartsWith("ENT"))
                numeroHDR = numeroHDR.Substring(3);

            if (hdr.TipoHDR == "Retiro" && numeroHDR.StartsWith("RET"))
                numeroHDR = numeroHDR.Substring(3);

            return int.TryParse(numeroHDR, out nroHDR);
        }

        private void ProcesarGuiaRetiro(
            GuiaEntidad guia,
            bool confirmada,
            FleteroEntidad? fletero)
        {
            guia.Historial ??= new List<HistorialGuia>();

            // Agencia: siempre retira. Domicilio: depende de si está confirmada.
            bool retira = guia.TipoImposicion == TipoImposicionEnum.Agencia || confirmada;

            if (retira)
            {
                // Pasa por Rendida(5) y queda en PendienteDeAdmision(6)
                guia.Historial.Add(new HistorialGuia
                {
                    Fecha = DateTime.Now,
                    Estado = EstadoGuiaEnum.Rendida
                });
                guia.Historial.Add(new HistorialGuia
                {
                    Fecha = DateTime.Now,
                    Estado = EstadoGuiaEnum.PendienteDeAdmision
                });
                guia.Estado = EstadoGuiaEnum.PendienteDeAdmision;
                AgregarComisionFletero(guia, fletero);
            }
            else
            {
                // No retira (solo puede ocurrir con imposición en domicilio)
                guia.Historial.Add(new HistorialGuia
                {
                    Fecha = DateTime.Now,
                    Estado = EstadoGuiaEnum.NoRetirada
                });
                guia.Estado = EstadoGuiaEnum.NoRetirada;
                AgregarComisionFletero(guia, fletero);
            }
        }

        private void ProcesarGuiaEntrega(
            GuiaEntidad guia,
            bool confirmada,
            FleteroEntidad? fletero)
        {
            guia.Historial ??= new List<HistorialGuia>();

            if (guia.TipoEntrega == TipoEntregaEnum.Agencia)
            {
                // La guía queda en estado 12; solo la HDR cambia.
                // Se genera comisión al fletero por haber llevado la encomienda a la agencia.
                AgregarComisionFletero(guia, fletero);
                return;
            }

            // TipoEntrega = ADomicilio
            if (confirmada)
            {
                // Entregó: DistribuidaEnDomicilio(14) → Entregada(17)
                guia.Historial.Add(new HistorialGuia
                {
                    Fecha = DateTime.Now,
                    Estado = EstadoGuiaEnum.DistribuidaEnDomicilio
                });
                guia.Historial.Add(new HistorialGuia
                {
                    Fecha = DateTime.Now,
                    Estado = EstadoGuiaEnum.Entregada
                });
                guia.Estado = EstadoGuiaEnum.Entregada;
                AgregarComisionFletero(guia, fletero);
            }
            else
            {
                // No entregó
                guia.IntentosDeEntrega++;
                guia.Historial.Add(new HistorialGuia
                {
                    Fecha = DateTime.Now,
                    Estado = EstadoGuiaEnum.NoEntregada
                });

                if (guia.IntentosDeEntrega >= 2)
                {
                    // Segundo intento fallido: la guía muere en NoEntregada(16)
                    guia.Estado = EstadoGuiaEnum.NoEntregada;
                    AgregarComisionFletero(guia, fletero);
                }
                else
                {
                    // Primer intento fallido: vuelve a PendienteDeDistribucion(12)
                    guia.Historial.Add(new HistorialGuia
                    {
                        Fecha = DateTime.Now,
                        Estado = EstadoGuiaEnum.PendienteDeDistribucion
                    });
                    guia.Estado = EstadoGuiaEnum.PendienteDeDistribucion;
                }
            }
        }

        private void AgregarComisionFletero(GuiaEntidad guia, FleteroEntidad? fletero)
        {
            if (fletero == null) return;

            ComisionFletero? comision = fletero.Comisiones
                ?.FirstOrDefault(c => c.TamañoEncomienda == guia.TipoCaja);
            if (comision == null) return;

            guia.ComisionFletero ??= new List<GuiaComisionFletero>();
            guia.ComisionFletero.Add(new GuiaComisionFletero
            {
                DniFletero = fletero.DNI,
                Importe = comision.Importe
            });
        }
    }
}
