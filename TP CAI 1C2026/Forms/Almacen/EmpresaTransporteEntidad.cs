using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class EmpresaTransporteEntidad
    {
        public int IdEmpresaTransporte { get; set; }
        public string Nombre { get; set; }
        public decimal TarifaMensual { get; set; }
        public int CapacidadEnXL { get; set; }
    }
}
