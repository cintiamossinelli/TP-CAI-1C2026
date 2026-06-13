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
            Servicio servicioSeleccionado = servicios[indiceServicio];

            if (servicioSeleccionado.IdCentroDeDistribucionDestino != Program.CdActual)
            {
                MessageBox.Show(
                    "La Hoja de Ruta de Transporte debe tener como destino el CD logueado.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            foreach (Guias guia in servicioSeleccionado.GuiasAsociadas)
            {
                var guiaEntidad = GuiaAlmacen.Guias
                    .FirstOrDefault(entidad => entidad.NroGuia == guia.Id);

                if (guiaEntidad == null)
                {
                    continue;
                }

                guiaEntidad.Historial ??= new List<HistorialGuia>();

                if (!TieneMismoCentroDeDistribucionDestino(
                    guiaEntidad,
                    servicioSeleccionado.IdCentroDeDistribucionDestino))
                {
                    guiaEntidad.Estado = EstadoGuiaEnum.Admitida;
                    guiaEntidad.Historial.Add(new HistorialGuia
                    {
                        Fecha = fechaActual,
                        Estado = EstadoGuiaEnum.Admitida
                    });
                    continue;
                }

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
                    hdr.IdCentroDeDistribucionDestino == Program.CdActual &&
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

                var paradaDestino = servicioEntidad.Paradas
                    .FirstOrDefault(parada =>
                        parada.IdCentroDeDistribucion ==
                        hdrEntidad.IdCentroDeDistribucionDestino);

                if (paradaDestino == null)
                {
                    continue;
                }

                List<Guias> guiasAsociadas = ObtenerGuias(hdrEntidad);

                resultado.Add(new Servicio
                {
                    Id = servicioEntidad.IdServicio,
                    IdCentroDeDistribucionDestino =
                        hdrEntidad.IdCentroDeDistribucionDestino,
                    Empresa = empresaEntidad?.Nombre ?? "Empresa sin identificar",
                    FechayHora = paradaDestino.Fecha,
                    GuiasAsociadas = guiasAsociadas
                });
            }

            return resultado
                .OrderByDescending(servicio => servicio.FechayHora)
                .ToList();
        }

        private static bool TieneMismoCentroDeDistribucionDestino(
            GuiaEntidad guiaEntidad,
            int idCentroDeDistribucionDestinoHDR)
        {
            if (guiaEntidad.IdCentroDeDistribucionEntrega > 0)
            {
                return guiaEntidad.IdCentroDeDistribucionEntrega ==
                    idCentroDeDistribucionDestinoHDR;
            }

            if (guiaEntidad.IdAgenciaEntrega > 0)
            {
                var ciudadAgencia = CiudadAlmacen.Ciudades
                    .FirstOrDefault(ciudad =>
                        ciudad.Agencias != null &&
                        ciudad.Agencias.Contains(guiaEntidad.IdAgenciaEntrega));

                return ciudadAgencia?.IdCentroDeDistribucion ==
                    idCentroDeDistribucionDestinoHDR;
            }

            return false;
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
