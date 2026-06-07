using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class HDRRetiroEntidad
    {
        public int NroHDR { get; set; }
        public int DniFletero { get; set; }
        public DateTime Fecha { get; set; }
        public string Domicilio { get; set; }
        public int CantEncomiendas { get; set; }
        public List<string> Guias { get; set; }
        public EstadoHDREnum Estado { get; set; }
    }
}
