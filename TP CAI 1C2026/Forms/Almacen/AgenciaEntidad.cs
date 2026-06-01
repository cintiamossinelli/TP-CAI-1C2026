using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class AgenciaEntidad
    {
        public int IdAgencia { get; set; }
        public string Nombre { get; set; }
        public List<ComisionAgencia> Comisiones { get; set; }
    }
}
