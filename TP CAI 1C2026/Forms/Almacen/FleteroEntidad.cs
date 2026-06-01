using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class FleteroEntidad
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public int IdCentroDeDistribucion { get; set; }
        public List<ComisionFletero> Comisiones { get; set; }
    }
}
