using System;
using System.Collections.Generic;
using System.Linq;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.Troncal.DespachoHDRTransporte
{
    internal class DespachoHDRTransporteModelo
    {
        internal List<Servicio> ObtenerServicios()
        {
            var resultado = new List<Servicio>();

            foreach (var hdr in HDRTransporteAlmacen.HDRTransportes)
            {
                var guiasHDR = GuiaAlmacen.Guias
                    .Where(g => hdr.Guias.Contains(g.NroGuia))
                    .ToList();

                if (guiasHDR.Count == 0
                    || guiasHDR.Count != hdr.Guias.Count
                    || guiasHDR.Any(g => g.Estado != EstadoGuiaEnum.PendienteDeTransporte))
                {
                    continue;
                }

                var servicioEntidad = ServicioAlmacen.Servicios
                    .FirstOrDefault(s => s.IdServicio == hdr.IdServicio);

                if (servicioEntidad == null)
                {
                    continue;
                }

                var empresaEntidad = EmpresaTransporteAlmacen.EmpresasTransporte
                    .FirstOrDefault(e => e.IdEmpresaTransporte == servicioEntidad.IdEmpresaTransporte);

                var servicio = new Servicio
                {
                    Id = hdr.NroHDR,
                    Empresa = empresaEntidad?.Nombre ?? "Empresa sin identificar",
                    FechayHora = servicioEntidad.Paradas != null && servicioEntidad.Paradas.Count > 0
                        ? servicioEntidad.Paradas[0].Fecha
                        : DateTime.MinValue,
                    GuiasAsociadas = new List<Guias>()
                };

                foreach (var nroGuia in hdr.Guias)
                {
                    var guiaEntidad = GuiaAlmacen.Guias
                        .FirstOrDefault(g => g.NroGuia == nroGuia);

                    if (guiaEntidad == null)
                    {
                        servicio.GuiasAsociadas.Add(new Guias
                        {
                            Id = nroGuia,
                            Tamaño = "Sin datos",
                            destino = "Sin datos"
                        });

                        continue;
                    }

                    servicio.GuiasAsociadas.Add(new Guias
                    {
                        Id = guiaEntidad.NroGuia,
                        Tamaño = guiaEntidad.TipoCaja.ToString(),
                        destino = ObtenerDestino(guiaEntidad)
                    });
                }

                resultado.Add(servicio);
            }

            return resultado;
        }

        internal List<Servicio> ObtenerServiciosDisponibles(DateTime fechaDesde, DateTime fechaHasta)
        {
            return ObtenerServicios()
                .Where(s => s.FechayHora.Date >= fechaDesde.Date
                    && s.FechayHora.Date <= fechaHasta.Date)
                .OrderBy(s => s.FechayHora)
                .ToList();
        }

        internal void DespacharGuias(List<string> numerosGuias)
        {
            var fechaActual = DateTime.Now;

            foreach (var nroGuia in numerosGuias)
            {
                var guia = GuiaAlmacen.Guias
                    .FirstOrDefault(g => g.NroGuia == nroGuia);

                if (guia != null)
                {
                    guia.Estado = EstadoGuiaEnum.PendienteDeRecepcion;
                    guia.Historial ??= new List<HistorialGuia>();
                    guia.Historial.Add(new HistorialGuia
                    {
                        Fecha = fechaActual,
                        Estado = EstadoGuiaEnum.PendienteDeRecepcion
                    });
                }
            }

            GuiaAlmacen.Guardar();
        }

        private string ObtenerDestino(GuiaEntidad guia)
        {
            if (!string.IsNullOrWhiteSpace(guia.DireccionEntrega))
            {
                return guia.DireccionEntrega;
            }

            if (guia.IdAgenciaEntrega > 0)
            {
                return $"Agencia {guia.IdAgenciaEntrega}";
            }

            if (guia.IdCentroDeDistribucionEntrega > 0)
            {
                return $"CD {guia.IdCentroDeDistribucionEntrega}";
            }

            return "Sin destino";
        }
    }
}
