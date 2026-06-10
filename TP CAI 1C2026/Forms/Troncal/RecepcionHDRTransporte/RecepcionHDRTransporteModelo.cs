using System;
using System.Collections.Generic;
using System.Linq;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.Troncal.RecepcionHDRTransporte
{
    internal class RecepcionHDRTransporteModelo
    {
        private List<Servicio> servicios = new List<Servicio>();

        internal List<string> ObtenerDescripcionesServicios()
        {
            servicios = ObtenerServicios();

            return servicios
                .Select(servicio =>
                    servicio.Empresa + " - " +
                    servicio.FechayHora.ToString("dd/MM/yyyy HH:mm"))
                .ToList();
        }

        internal List<Guias> ObtenerGuiasDelServicio(int indiceServicio)
        {
            if (indiceServicio < 0 || indiceServicio >= servicios.Count)
            {
                return new List<Guias>();
            }

            return servicios[indiceServicio].GuiasAsociadas;
        }

        internal void RecibirHDR(int indiceServicio)
        {
            if (indiceServicio < 0 || indiceServicio >= servicios.Count)
            {
                return;
            }

            DateTime fechaActual = DateTime.Now;

            foreach (Guias guia in servicios[indiceServicio].GuiasAsociadas)
            {
                var guiaEntidad = GuiaAlmacen.Guias
                    .FirstOrDefault(entidad => entidad.NroGuia == guia.Id);

                if (guiaEntidad == null)
                {
                    continue;
                }

                guiaEntidad.Historial ??= new List<HistorialGuia>();
                guiaEntidad.Historial.Add(new HistorialGuia
                {
                    Fecha = fechaActual,
                    Estado = EstadoGuiaEnum.EnDestino
                });

                if (guiaEntidad.TipoEntrega == TipoEntregaEnum.CD)
                {
                    guiaEntidad.Estado = EstadoGuiaEnum.PendienteDeEntrega;
                    guiaEntidad.Historial.Add(new HistorialGuia
                    {
                        Fecha = fechaActual,
                        Estado = EstadoGuiaEnum.PendienteDeEntrega
                    });
                }
                else
                {
                    guiaEntidad.Estado = EstadoGuiaEnum.EnDestino;
                }
            }

            GuiaAlmacen.Guardar();
        }

        internal List<Servicio> ObtenerServicios()
        {
            var resultado = new List<Servicio>();
            DateTime fechaActual = DateTime.Today;
            DateTime fechaDesde = fechaActual.AddDays(-5);

            var hdrsRecientes = HDRTransporteAlmacen.HDRTransportes
                .Where(hdr =>
                    hdr.FechaEmision.Date >= fechaDesde &&
                    hdr.FechaEmision.Date <= fechaActual &&
                    TieneTodasLasGuiasPendientesDeRecepcion(hdr));

            foreach (var hdrEntidad in hdrsRecientes)
            {
                var servicioEntidad = ServicioAlmacen.Servicios
                    .FirstOrDefault(servicio =>
                        servicio.IdServicio == hdrEntidad.IdServicio);

                if (servicioEntidad == null || servicioEntidad.Paradas == null)
                {
                    continue;
                }

                var empresaEntidad = EmpresaTransporteAlmacen.EmpresasTransporte
                    .FirstOrDefault(empresa =>
                        empresa.IdEmpresaTransporte == servicioEntidad.IdEmpresaTransporte);

                List<Guias> guiasAsociadas = ObtenerGuias(hdrEntidad);

                foreach (var paradaEntidad in servicioEntidad.Paradas)
                {
                    resultado.Add(new Servicio
                    {
                        Id = servicioEntidad.IdServicio,
                        Empresa = empresaEntidad?.Nombre ?? "Empresa sin identificar",
                        FechayHora = paradaEntidad.Fecha,
                        GuiasAsociadas = guiasAsociadas
                    });
                }
            }

            return resultado
                .OrderByDescending(servicio => servicio.FechayHora)
                .ToList();
        }

        private static bool TieneTodasLasGuiasPendientesDeRecepcion(
            HDRTransporteEntidad hdrEntidad)
        {
            if (hdrEntidad.Guias == null || hdrEntidad.Guias.Count == 0)
            {
                return false;
            }

            return hdrEntidad.Guias.All(nroGuia =>
                GuiaAlmacen.Guias.Any(guia =>
                    guia.NroGuia == nroGuia &&
                    guia.Estado == EstadoGuiaEnum.PendienteDeRecepcion));
        }

        private static List<Guias> ObtenerGuias(HDRTransporteEntidad hdrEntidad)
        {
            var resultado = new List<Guias>();

            if (hdrEntidad.Guias == null)
            {
                return resultado;
            }

            foreach (string nroGuia in hdrEntidad.Guias)
            {
                var guiaEntidad = GuiaAlmacen.Guias
                    .FirstOrDefault(guia => guia.NroGuia == nroGuia);

                if (guiaEntidad == null)
                {
                    resultado.Add(new Guias
                    {
                        Id = nroGuia,
                        Tamaño = "Sin datos",
                        destino = "Sin datos"
                    });
                    continue;
                }

                resultado.Add(new Guias
                {
                    Id = guiaEntidad.NroGuia,
                    Tamaño = guiaEntidad.TipoCaja.ToString(),
                    destino = ObtenerDestino(guiaEntidad)
                });
            }

            return resultado;
        }

        private static string ObtenerDestino(GuiaEntidad guiaEntidad)
        {
            if (!string.IsNullOrWhiteSpace(guiaEntidad.DireccionEntrega))
            {
                return guiaEntidad.DireccionEntrega;
            }

            if (guiaEntidad.IdAgenciaEntrega > 0)
            {
                return $"Agencia {guiaEntidad.IdAgenciaEntrega}";
            }

            if (guiaEntidad.IdCentroDeDistribucionEntrega > 0)
            {
                return CentroDeDistribucionAlmacen.CentrosDeDistribucion
                    .FirstOrDefault(centro =>
                        centro.IdCentroDeDistribucion ==
                        guiaEntidad.IdCentroDeDistribucionEntrega)?
                    .Nombre ?? $"CD {guiaEntidad.IdCentroDeDistribucionEntrega}";
            }

            return "Sin destino";
        }
    }
}
