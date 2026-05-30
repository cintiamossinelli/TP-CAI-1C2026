using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Administración.ResultadoCostoVentas
{
    internal class ResultadoEmpresa
    {
        public int IdEmpresa { get; set; }
        public string EmpresaTransporte { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal VentasTotal { get; set; }
        public decimal Resultado => VentasTotal - CostoTotal;
    }
}
