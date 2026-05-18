using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Administración.CuentaCorrienteCliente
{
    internal class Recibo
    {
        public string Descripcion { get; set; }
        public string NumeroRecibo { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
    }
}
