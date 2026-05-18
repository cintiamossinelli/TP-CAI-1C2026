using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Troncal.RecepcionHDRTransporte
{
    internal class Servicio
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public DateTime FechayHora { get; set; }
        public List<Guias> GuiasAsociadas { get; set; } = new List<Guias>();
    }
}
