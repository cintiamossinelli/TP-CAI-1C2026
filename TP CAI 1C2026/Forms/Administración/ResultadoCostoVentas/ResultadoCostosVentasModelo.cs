using System;
using System.Collections.Generic;
using System.Linq;
using TP_CAI_1C2026.Forms.Almacen;
using TP_CAI_1C2026.Forms.Administración.ResultadoCostoVentas;

namespace TP_CAI_1C2026.Forms.Administracion.ResultadoCostoVentas
{
    internal class ResultadoCostosVentasModelo
    {

        internal List<Empresa> ObtenerEmpresasTransporte()
        {
            return EmpresaTransporteAlmacen.EmpresasTransporte
                .Select(MapearEmpresa)
                .OrderBy(e => e.EmpresaTransporte)
                .ToList();
        }

        internal ResumenEmpresas ObtenerResumenPorEmpresa(int mes, int anio)
        {
            var envios = ObtenerEnvios()
                .Where(e => e.fechaEnvio.Month == mes && e.fechaEnvio.Year == anio)
                .ToList();

            var empresas = ObtenerEmpresasTransporte();

            var agrupado = envios
                .GroupBy(e => e.idEmpresaTransporte)
                .Select(g => new ResultadoEmpresa
                {
                    IdEmpresa = g.Key,
                    EmpresaTransporte = empresas.FirstOrDefault(em => em.Id == g.Key)?.EmpresaTransporte ?? ("ID " + g.Key),
                    Cantidad = g.Count(),
                    CostoTotal = g.Sum(x => x.costoEnvio),
                    VentasTotal = g.Sum(x => x.precioVenta)
                })
                .OrderByDescending(x => x.Cantidad)
                .ToList();

            var resumen = new ResumenEmpresas
            {
                Items = agrupado,
                TotalCostos = agrupado.Sum(x => x.CostoTotal),
                TotalVentas = agrupado.Sum(x => x.VentasTotal)
            };
            resumen.TotalResultado = resumen.TotalVentas - resumen.TotalCostos;

            return resumen;
        }

        // Validaciones de entrada para mes y año
        public bool ValidarMes(string mesTexto, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(mesTexto))
            {
                mensaje = "El campo Mes no puede estar vacío.";
                return false;
            }

            if (!int.TryParse(mesTexto.Trim(), out int mes))
            {
                mensaje = "El Mes debe ser un valor numérico entero.";
                return false;
            }

            if (mes < 1 || mes > 12)
            {
                mensaje = "El Mes debe estar entre 1 y 12.";
                return false;
            }

            return true;
        }

        public bool ValidarAnio(string anioTexto, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(anioTexto))
            {
                mensaje = "El campo Año no puede estar vacío.";
                return false;
            }

            if (!int.TryParse(anioTexto.Trim(), out int anio))
            {
                mensaje = "El Año debe ser un valor numérico entero.";
                return false;
            }

            if (anio > DateTime.Today.Year)
            {
                mensaje = "El año ingresado no puede ser mayor al año actual";
                return false;
            }

            if (anio < 2000)
            {
                mensaje = "El Año debe estar entre 2000 y 3000.";
                return false;
            }

            return true;
        }

        internal List<Envios> ObtenerEnvios()
        {
            var servicios = ServicioAlmacen.Servicios
                .ToDictionary(s => s.IdServicio);

            var guias = GuiaAlmacen.Guias
                .ToDictionary(g => g.NroGuia, StringComparer.OrdinalIgnoreCase);

            var empresas = EmpresaTransporteAlmacen.EmpresasTransporte
                .ToDictionary(e => e.IdEmpresaTransporte);

            var envios = new List<Envios>();

            foreach (var hdr in HDRTransporteAlmacen.HDRTransportes)
            {
                if (!servicios.TryGetValue(hdr.IdServicio, out var servicio)
                    || !empresas.ContainsKey(servicio.IdEmpresaTransporte)
                    || hdr.Guias == null)
                {
                    continue;
                }

                foreach (var numeroGuia in hdr.Guias)
                {
                    if (!guias.TryGetValue(numeroGuia, out var guia))
                    {
                        continue;
                    }

                    envios.Add(new Envios
                    {
                        numeroGuia = guia.NroGuia,
                        fechaEnvio = hdr.FechaEmision,
                        precioVenta = guia.PrecioVenta,
                        idEmpresaTransporte = servicio.IdEmpresaTransporte
                    });
                }
            }

            foreach (var grupo in envios.GroupBy(e => new
            {
                e.idEmpresaTransporte,
                e.fechaEnvio.Year,
                e.fechaEnvio.Month
            }))
            {
                var tarifaMensual = empresas[grupo.Key.idEmpresaTransporte].TarifaMensual;
                var enviosDelMes = grupo.ToList();
                var costoPorEnvio = decimal.Round(tarifaMensual / enviosDelMes.Count, 2);

                foreach (var envio in enviosDelMes)
                {
                    envio.costoEnvio = costoPorEnvio;
                }

                enviosDelMes[^1].costoEnvio += tarifaMensual - enviosDelMes.Sum(e => e.costoEnvio);
            }

            return envios;
        }

        private Empresa MapearEmpresa(EmpresaTransporteEntidad empresaEntidad)
        {
            return new Empresa
            {
                Id = empresaEntidad.IdEmpresaTransporte,
                EmpresaTransporte = empresaEntidad.Nombre
            };
        }

    }
}
