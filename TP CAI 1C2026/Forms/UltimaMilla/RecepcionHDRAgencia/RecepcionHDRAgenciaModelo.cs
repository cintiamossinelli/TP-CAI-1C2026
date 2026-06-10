using System;
using System.Collections.Generic;
using System.Linq;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.UltimaMilla.RecepcionHDRAgencia
{
    internal class RecepcionHDRAgenciaModelo
    {
        // Estado seleccionado mantenido en el modelo
        internal HDR Seleccionada { get; set; }

        // Encomiendas pertenecientes al HDR seleccionado
        internal List<Encomienda> EncomiendasHDR { get; set; } = new List<Encomienda>();

        internal List<HDR> ObtenerHDRsPendientes()
        {
            return HDREntregaAlmacen.HDREntregas
                .Where(hdrEntidad =>
                    hdrEntidad.Estado == EstadoHDREnum.EntregadaAlFletero)
                .Select(hdrEntidad => new HDR
                {
                    NumeroHDR = hdrEntidad.NroHDR.ToString()
                })
                .ToList();
        }

        internal List<Encomienda> ObtenerEncomiendasHDR(HDR hdr)
        {
            if (hdr == null)
            {
                EncomiendasHDR = new List<Encomienda>();
                return EncomiendasHDR;
            }

            if (!int.TryParse(hdr.NumeroHDR, out int nroHDR))
            {
                EncomiendasHDR = new List<Encomienda>();
                return EncomiendasHDR;
            }

            var hdrEntidad = HDREntregaAlmacen.HDREntregas
                .FirstOrDefault(entidad => entidad.NroHDR == nroHDR);

            if (hdrEntidad == null || hdrEntidad.Guias == null)
            {
                EncomiendasHDR = new List<Encomienda>();
                return EncomiendasHDR;
            }

            var lista = hdrEntidad.Guias
                .Select(nroGuia => GuiaAlmacen.Guias
                    .FirstOrDefault(guiaEntidad =>
                        guiaEntidad.NroGuia == nroGuia))
                .Where(guiaEntidad => guiaEntidad != null)
                .Select(guiaEntidad => new Encomienda
                {
                    NumeroGuia = guiaEntidad!.NroGuia,
                    TipoEncomienda = guiaEntidad.TipoCaja.ToString()
                })
                .ToList();

            EncomiendasHDR = lista;
            return lista;
        }

        // Validación de selección de HDR (mover validaciones desde la UI al modelo)
        internal bool ValidarSeleccionHDR(HDR hdr, int selectedIndex, out string mensaje)
        {
            mensaje = string.Empty;
            if (hdr == null || selectedIndex == -1)
            {
                mensaje = "Debe seleccionar un HDR.";
                return false;
            }
            return true;
        }

        internal bool ConfirmarRecepcionHDR(HDR hdr)
        {
            if (hdr == null || !int.TryParse(hdr.NumeroHDR, out int nroHDR))
            {
                return false;
            }

            var hdrEntidad = HDREntregaAlmacen.HDREntregas
                .FirstOrDefault(entidad => entidad.NroHDR == nroHDR);

            if (hdrEntidad == null || hdrEntidad.Guias == null)
            {
                return false;
            }

            DateTime fechaActual = DateTime.Now;

            foreach (string nroGuia in hdrEntidad.Guias)
            {
                var guiaEntidad = GuiaAlmacen.Guias
                    .FirstOrDefault(guia => guia.NroGuia == nroGuia);

                if (guiaEntidad == null)
                {
                    continue;
                }

                guiaEntidad.Estado = EstadoGuiaEnum.PendienteDeEntrega;
                guiaEntidad.Historial ??= new List<HistorialGuia>();
                guiaEntidad.Historial.Add(new HistorialGuia
                {
                    Fecha = fechaActual,
                    Estado = EstadoGuiaEnum.DistribuidaEnAgencia
                });
                guiaEntidad.Historial.Add(new HistorialGuia
                {
                    Fecha = fechaActual,
                    Estado = EstadoGuiaEnum.PendienteDeEntrega
                });
            }

            hdrEntidad.Estado = EstadoHDREnum.PendienteRendicion;

            GuiaAlmacen.Guardar();
            HDREntregaAlmacen.Guardar();
            return true;
        }
    }
}
