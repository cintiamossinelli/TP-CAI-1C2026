using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP_CAI_1C2026.Forms.Administración.ResultadoCostoVentas;
using TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte;

namespace TP_CAI_1C2026.Forms.Administracion.ResultadoCostoVentas
{
    internal class ResultadoCostosVentasModelo
    {

        internal List<Empresa> ObtenerEmpresasTransporte()
        {
            return new List<Empresa>
            {
                new Empresa { Id = 1, EmpresaTransporte = "Flecha Bus"},
                new Empresa { Id = 2, EmpresaTransporte = "Chevallier"},
                new Empresa { Id = 3, EmpresaTransporte = "Andesmar"},
                new Empresa { Id = 4, EmpresaTransporte = "El Rosarino"},
                new Empresa { Id = 5, EmpresaTransporte = "Via Bariloche"},
                new Empresa { Id = 6, EmpresaTransporte = "Pullman"},
                new Empresa { Id = 7, EmpresaTransporte = "Plusmar"},
                new Empresa { Id = 8, EmpresaTransporte = "Crucero del Norte"},
                new Empresa { Id = 9, EmpresaTransporte = "Balut"},
                new Empresa { Id = 10, EmpresaTransporte = "El Rápido Argentino"},
                new Empresa { Id = 11, EmpresaTransporte = "Cata Internacional"},
                new Empresa { Id = 12, EmpresaTransporte = "La Veloz del Norte"},
                new Empresa { Id = 13, EmpresaTransporte = "Urquiza"},
                new Empresa { Id = 14, EmpresaTransporte = "Sierras de Córdoba"},
                new Empresa { Id = 15, EmpresaTransporte = "El Práctico"},
                new Empresa { Id = 16, EmpresaTransporte = "Mercobus"},
                new Empresa { Id = 17, EmpresaTransporte = "Dumascat"},
                new Empresa { Id = 18, EmpresaTransporte = "San Juan Mar del Plata"},
                new Empresa { Id = 19, EmpresaTransporte = "Tigre Iguazú"},
                new Empresa { Id = 20, EmpresaTransporte = "Empresa Argentina"},
            };
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

            if (anio < 2000 || anio > 3000)
            {
                mensaje = "El Año debe estar entre 2000 y 3000.";
                return false;
            }

            return true;
        }

        internal List<Envios> ObtenerEnvios()
        {
            return new List<Envios>
            {
                new Envios { numeroGuia = "AG-1-1", fechaEnvio = new DateTime(2025,1,2), costoEnvio = 1000, precioVenta = 1500, idEmpresaTransporte = 1 },
                new Envios { numeroGuia = "CD-1-2", fechaEnvio = new DateTime(2025,1,15), costoEnvio = 2000, precioVenta = 2500, idEmpresaTransporte = 2 },
                new Envios { numeroGuia = "AG-56-1", fechaEnvio = new DateTime(2025,3,15), costoEnvio = 5500, precioVenta = 9500, idEmpresaTransporte = 16 },
                new Envios { numeroGuia = "AG-39-2", fechaEnvio = new DateTime(2025,10,13), costoEnvio = 22500, precioVenta = 28000, idEmpresaTransporte = 8 },
                new Envios { numeroGuia = "CC-1-3", fechaEnvio = new DateTime(2025,8,2), costoEnvio = 31500, precioVenta = 38000, idEmpresaTransporte = 1 },
                new Envios { numeroGuia = "CD-18-4", fechaEnvio = new DateTime(2025,8,7), costoEnvio = 8000, precioVenta = 24500, idEmpresaTransporte = 5 },
                new Envios { numeroGuia = "CC-1-5", fechaEnvio = new DateTime(2025,2,16), costoEnvio = 26500, precioVenta = 36000, idEmpresaTransporte = 2 },
                new Envios { numeroGuia = "AG-90-6", fechaEnvio = new DateTime(2025,4,20), costoEnvio = 5500, precioVenta = 15000, idEmpresaTransporte = 9 },
                new Envios { numeroGuia = "CD-34-7", fechaEnvio = new DateTime(2025,3,21), costoEnvio = 38500, precioVenta = 41500, idEmpresaTransporte = 5 },
                new Envios { numeroGuia = "CD-46-8", fechaEnvio = new DateTime(2026,5,3), costoEnvio = 11000, precioVenta = 17500, idEmpresaTransporte = 17 },
                new Envios { numeroGuia = "AG-8-9", fechaEnvio = new DateTime(2025,5,29), costoEnvio = 6500, precioVenta = 19000, idEmpresaTransporte = 3 },
                new Envios { numeroGuia = "CD-48-10", fechaEnvio = new DateTime(2026,5,19), costoEnvio = 32500, precioVenta = 51000, idEmpresaTransporte = 5 },
                new Envios { numeroGuia = "CD-27-11", fechaEnvio = new DateTime(2026,5,28), costoEnvio = 18000, precioVenta = 32000, idEmpresaTransporte = 14 },
                new Envios { numeroGuia = "CD-48-12", fechaEnvio = new DateTime(2025,9,16), costoEnvio = 17000, precioVenta = 28500, idEmpresaTransporte = 11 },
                new Envios { numeroGuia = "AG-6-13", fechaEnvio = new DateTime(2025,11,12), costoEnvio = 6500, precioVenta = 12500, idEmpresaTransporte = 2 },
                new Envios { numeroGuia = "AG-99-14", fechaEnvio = new DateTime(2026,1,24), costoEnvio = 19500, precioVenta = 23000, idEmpresaTransporte = 15 },
                new Envios { numeroGuia = "AG-38-15", fechaEnvio = new DateTime(2025,7,25), costoEnvio = 28500, precioVenta = 42500, idEmpresaTransporte = 3 },
                new Envios { numeroGuia = "CC-1-16", fechaEnvio = new DateTime(2025,6,10), costoEnvio = 21000, precioVenta = 37000, idEmpresaTransporte = 15 },
                new Envios { numeroGuia = "CC-1-17", fechaEnvio = new DateTime(2025,1,2), costoEnvio = 18000, precioVenta = 32500, idEmpresaTransporte = 5 },
                new Envios { numeroGuia = "CC-1-21", fechaEnvio = new DateTime(2026,3,5), costoEnvio = 39500, precioVenta = 45500, idEmpresaTransporte = 14 },
                new Envios { numeroGuia = "CC-1-22", fechaEnvio = new DateTime(2025,5,29), costoEnvio = 14500, precioVenta = 31500, idEmpresaTransporte = 11 },
                new Envios { numeroGuia = "CC-1-23", fechaEnvio = new DateTime(2026,1,10), costoEnvio = 31500, precioVenta = 51500, idEmpresaTransporte = 9 },
                new Envios { numeroGuia = "CD-46-24", fechaEnvio = new DateTime(2026,4,24), costoEnvio = 17000, precioVenta = 21000, idEmpresaTransporte = 2 },
                new Envios { numeroGuia = "CC-1-25", fechaEnvio = new DateTime(2026,3,14), costoEnvio = 6000, precioVenta = 12000, idEmpresaTransporte = 9 },
                new Envios { numeroGuia = "AG-87-26", fechaEnvio = new DateTime(2025,9,24), costoEnvio = 28000, precioVenta = 34000, idEmpresaTransporte = 5 },
                new Envios { numeroGuia = "CC-1-27", fechaEnvio = new DateTime(2026,5,20), costoEnvio = 25000, precioVenta = 29500, idEmpresaTransporte = 4 },
                new Envios { numeroGuia = "AG-27-28", fechaEnvio = new DateTime(2025,10,9), costoEnvio = 36500, precioVenta = 48500, idEmpresaTransporte = 16 },
                new Envios { numeroGuia = "CD-35-29", fechaEnvio = new DateTime(2025,3,30), costoEnvio = 23500, precioVenta = 41500, idEmpresaTransporte = 8 },
                new Envios { numeroGuia = "CD-14-30", fechaEnvio = new DateTime(2025,7,19), costoEnvio = 17500, precioVenta = 34500, idEmpresaTransporte = 8 },
                new Envios { numeroGuia = "CD-2-31", fechaEnvio = new DateTime(2025,11,28), costoEnvio = 25000, precioVenta = 42000, idEmpresaTransporte = 9 },
                new Envios { numeroGuia = "AG-89-32", fechaEnvio = new DateTime(2025,3,20), costoEnvio = 19500, precioVenta = 33000, idEmpresaTransporte = 15 },
                new Envios { numeroGuia = "AG-34-33", fechaEnvio = new DateTime(2025,5,8), costoEnvio = 12500, precioVenta = 27000, idEmpresaTransporte = 17 },
                new Envios { numeroGuia = "AG-54-34", fechaEnvio = new DateTime(2025,12,26), costoEnvio = 29500, precioVenta = 49500, idEmpresaTransporte = 8 },
                new Envios { numeroGuia = "CD-47-35", fechaEnvio = new DateTime(2025,6,14), costoEnvio = 29000, precioVenta = 42500, idEmpresaTransporte = 5 },
                new Envios { numeroGuia = "CD-26-36", fechaEnvio = new DateTime(2026,1,9), costoEnvio = 30000, precioVenta = 49500, idEmpresaTransporte = 17 },
                new Envios { numeroGuia = "CC-1-37", fechaEnvio = new DateTime(2025,6,21), costoEnvio = 22500, precioVenta = 37000, idEmpresaTransporte = 11 },
                new Envios { numeroGuia = "CC-1-38", fechaEnvio = new DateTime(2025,4,27), costoEnvio = 32500, precioVenta = 44500, idEmpresaTransporte = 20 },
                new Envios { numeroGuia = "AG-85-39", fechaEnvio = new DateTime(2026,1,26), costoEnvio = 9000, precioVenta = 14000, idEmpresaTransporte = 5 },
                new Envios { numeroGuia = "CD-41-41", fechaEnvio = new DateTime(2026,2,19), costoEnvio = 40000, precioVenta = 49500, idEmpresaTransporte = 13 },
                new Envios { numeroGuia = "CD-32-42", fechaEnvio = new DateTime(2025,12,1), costoEnvio = 33500, precioVenta = 50500, idEmpresaTransporte = 11 },
                new Envios { numeroGuia = "CC-1-43", fechaEnvio = new DateTime(2025,6,11), costoEnvio = 16500, precioVenta = 26500, idEmpresaTransporte = 1 },
                new Envios { numeroGuia = "CD-8-44", fechaEnvio = new DateTime(2025,6,5), costoEnvio = 32000, precioVenta = 37000, idEmpresaTransporte = 14 },
                new Envios { numeroGuia = "CC-1-45", fechaEnvio = new DateTime(2025,12,12), costoEnvio = 28500, precioVenta = 41500, idEmpresaTransporte = 10 },
                new Envios { numeroGuia = "CD-20-46", fechaEnvio = new DateTime(2025,12,23), costoEnvio = 6000, precioVenta = 17000, idEmpresaTransporte = 5 },
                new Envios { numeroGuia = "AG-19-47", fechaEnvio = new DateTime(2025,8,14), costoEnvio = 15500, precioVenta = 27000, idEmpresaTransporte = 16 },
                new Envios { numeroGuia = "CC-1-48", fechaEnvio = new DateTime(2025,9,3), costoEnvio = 30000, precioVenta = 46500, idEmpresaTransporte = 3 },
                new Envios { numeroGuia = "CD-26-49", fechaEnvio = new DateTime(2026,3,6), costoEnvio = 18500, precioVenta = 38000, idEmpresaTransporte = 8 },
                new Envios { numeroGuia = "CD-2-50", fechaEnvio = new DateTime(2025,1,23), costoEnvio = 28000, precioVenta = 32500, idEmpresaTransporte = 19 },
                new Envios { numeroGuia = "CC-1-51", fechaEnvio = new DateTime(2026,5,3), costoEnvio = 37500, precioVenta = 45500, idEmpresaTransporte = 17 },
                new Envios { numeroGuia = "CD-22-52", fechaEnvio = new DateTime(2025,11,24), costoEnvio = 39000, precioVenta = 45500, idEmpresaTransporte = 18 },
                new Envios { numeroGuia = "CC-1-53", fechaEnvio = new DateTime(2025,10,16), costoEnvio = 20500, precioVenta = 35500, idEmpresaTransporte = 7 },
                new Envios { numeroGuia = "CD-2-54", fechaEnvio = new DateTime(2025,12,24), costoEnvio = 13000, precioVenta = 28500, idEmpresaTransporte = 8 },
                new Envios { numeroGuia = "CC-1-59", fechaEnvio = new DateTime(2026,1,6), costoEnvio = 14500, precioVenta = 19500, idEmpresaTransporte = 12 },
                new Envios { numeroGuia = "CC-1-60", fechaEnvio = new DateTime(2025,3,24), costoEnvio = 19000, precioVenta = 23000, idEmpresaTransporte = 8 },
                new Envios { numeroGuia = "AG-99-61", fechaEnvio = new DateTime(2025,3,30), costoEnvio = 33500, precioVenta = 52000, idEmpresaTransporte = 18 },
                new Envios { numeroGuia = "CC-1-62", fechaEnvio = new DateTime(2025,10,17), costoEnvio = 14500, precioVenta = 33500, idEmpresaTransporte = 4 },
                new Envios { numeroGuia = "AG-22-63", fechaEnvio = new DateTime(2026,4,11), costoEnvio = 27500, precioVenta = 31500, idEmpresaTransporte = 8 },
                new Envios { numeroGuia = "CC-1-68", fechaEnvio = new DateTime(2025,2,28), costoEnvio = 14000, precioVenta = 34000, idEmpresaTransporte = 4 },
                new Envios { numeroGuia = "CC-1-69", fechaEnvio = new DateTime(2025,8,6), costoEnvio = 35000, precioVenta = 39500, idEmpresaTransporte = 11 },
                new Envios { numeroGuia = "AG-16-70", fechaEnvio = new DateTime(2025,1,24), costoEnvio = 13500, precioVenta = 17000, idEmpresaTransporte = 13 },
                new Envios { numeroGuia = "CD-8-71", fechaEnvio = new DateTime(2025,10,8), costoEnvio = 13000, precioVenta = 28000, idEmpresaTransporte = 14 },
                new Envios { numeroGuia = "CD-40-72", fechaEnvio = new DateTime(2025,8,3), costoEnvio = 36500, precioVenta = 47500, idEmpresaTransporte = 8 },
                new Envios { numeroGuia = "AG-16-73", fechaEnvio = new DateTime(2026,3,16), costoEnvio = 12000, precioVenta = 28500, idEmpresaTransporte = 18 },
                new Envios { numeroGuia = "AG-21-74", fechaEnvio = new DateTime(2025,6,4), costoEnvio = 12000, precioVenta = 31500, idEmpresaTransporte = 18 },
                new Envios { numeroGuia = "CC-1-80", fechaEnvio = new DateTime(2025,2,10), costoEnvio = 38500, precioVenta = 57000, idEmpresaTransporte = 19 },
                new Envios { numeroGuia = "CD-24-81", fechaEnvio = new DateTime(2025,6,22), costoEnvio = 13500, precioVenta = 28000, idEmpresaTransporte = 11 },
                new Envios { numeroGuia = "CD-29-82", fechaEnvio = new DateTime(2025,6,11), costoEnvio = 18500, precioVenta = 31500, idEmpresaTransporte = 14 },
                new Envios { numeroGuia = "AG-1-83", fechaEnvio = new DateTime(2025,4,15), costoEnvio = 13500, precioVenta = 27000, idEmpresaTransporte = 3 },
                new Envios { numeroGuia = "CD-6-84", fechaEnvio = new DateTime(2026,4,13), costoEnvio = 35000, precioVenta = 47000, idEmpresaTransporte = 11 },
                new Envios { numeroGuia = "AG-26-85", fechaEnvio = new DateTime(2026,4,5), costoEnvio = 27000, precioVenta = 38500, idEmpresaTransporte = 19 },
                new Envios { numeroGuia = "CD-19-86", fechaEnvio = new DateTime(2025,12,25), costoEnvio = 36000, precioVenta = 53000, idEmpresaTransporte = 9 },
                new Envios { numeroGuia = "CD-10-87", fechaEnvio = new DateTime(2025,12,18), costoEnvio = 25500, precioVenta = 36500, idEmpresaTransporte = 2 },
                new Envios { numeroGuia = "CD-40-88", fechaEnvio = new DateTime(2026,2,15), costoEnvio = 25500, precioVenta = 28500, idEmpresaTransporte = 9 },
                new Envios { numeroGuia = "CC-1-89", fechaEnvio = new DateTime(2026,2,5), costoEnvio = 24500, precioVenta = 32500, idEmpresaTransporte = 6 },
                new Envios { numeroGuia = "CC-1-90", fechaEnvio = new DateTime(2026,5,29), costoEnvio = 8500, precioVenta = 14000, idEmpresaTransporte = 7 },
                new Envios { numeroGuia = "CC-1-91", fechaEnvio = new DateTime(2025,4,3), costoEnvio = 7000, precioVenta = 10000, idEmpresaTransporte = 13 },
                new Envios { numeroGuia = "CC-1-92", fechaEnvio = new DateTime(2025,7,24), costoEnvio = 34500, precioVenta = 37000, idEmpresaTransporte = 7 },
                new Envios { numeroGuia = "CC-1-93", fechaEnvio = new DateTime(2025,7,24), costoEnvio = 16000, precioVenta = 30500, idEmpresaTransporte = 1 },
                new Envios { numeroGuia = "AG-79-94", fechaEnvio = new DateTime(2026,2,12), costoEnvio = 30500, precioVenta = 36500, idEmpresaTransporte = 8 },
                new Envios { numeroGuia = "CC-1-95", fechaEnvio = new DateTime(2025,7,22), costoEnvio = 33500, precioVenta = 51500, idEmpresaTransporte = 10 },
                new Envios { numeroGuia = "CC-1-96", fechaEnvio = new DateTime(2025,4,5), costoEnvio = 20000, precioVenta = 37500, idEmpresaTransporte = 4 },
                new Envios { numeroGuia = "CD-49-97", fechaEnvio = new DateTime(2025,12,25), costoEnvio = 21500, precioVenta = 31000, idEmpresaTransporte = 12 },
                new Envios { numeroGuia = "CD-7-98", fechaEnvio = new DateTime(2025,9,27), costoEnvio = 26500, precioVenta = 39000, idEmpresaTransporte = 9 },
                new Envios { numeroGuia = "AG-45-99", fechaEnvio = new DateTime(2026,4,25), costoEnvio = 39000, precioVenta = 50000, idEmpresaTransporte = 18 },
                new Envios { numeroGuia = "AG-8-100", fechaEnvio = new DateTime(2025,10,15), costoEnvio = 28500, precioVenta = 36000, idEmpresaTransporte = 17 },
            };
        }


    }
}
