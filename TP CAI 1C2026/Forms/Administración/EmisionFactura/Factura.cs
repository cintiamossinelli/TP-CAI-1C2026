using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP_CAI_1C2026.Forms.Administración.EmisionFactura
{
    internal class Factura
    {
        public string Numero { get; set; }

        public Cliente Cliente { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public List<GuiasAFacturar> Guias { get; set; }
    }
}
