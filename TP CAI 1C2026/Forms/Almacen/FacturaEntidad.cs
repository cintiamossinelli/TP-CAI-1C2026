using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class FacturaEntidad
    {
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Descripcion { get; set; }
        public List<string> Guias { get; set; }
    }
}
