using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Administracion.ResultadoCostoVentas
{
    internal class Empresa
    {
        public string EmpresaTransporte { get; set; }
        public int CantidadEnvios { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal VentasTotales { get; set; }
        public decimal Resultado { get { return VentasTotales - CostoTotal; } }
    }
}
