using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Administracion.CuentaCorrienteCliente
{
    internal class MovimientoCuentaCorriente
    {
        public string CuitDniCuil { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
    }
}
