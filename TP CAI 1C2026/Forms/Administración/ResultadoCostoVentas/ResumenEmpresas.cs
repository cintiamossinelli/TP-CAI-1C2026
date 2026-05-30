using System;
using System.Collections.Generic;
using System.Text;
using static TP_CAI_1C2026.Forms.Administracion.ResultadoCostoVentas.ResultadoCostosVentasModelo;

namespace TP_CAI_1C2026.Forms.Administración.ResultadoCostoVentas
{
    internal class ResumenEmpresas
    {
        public List<ResultadoEmpresa> Items { get; set; } = new List<ResultadoEmpresa>();
        public decimal TotalCostos { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal TotalResultado { get; set; }
    }
}
