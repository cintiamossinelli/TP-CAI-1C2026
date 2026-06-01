using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class HDRTransporteEntidad
    {
        public int NroHDR { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaEmision { get; set; }
        public int IdCentroDeDistribucionOrigen { get; set; }
        public int IdCentroDeDistribucionDestino { get; set; }
        public List<string> Guias { get; set; }
    }
}
