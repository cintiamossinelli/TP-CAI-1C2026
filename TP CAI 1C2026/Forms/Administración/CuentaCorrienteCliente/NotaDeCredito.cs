using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Administración.CuentaCorrienteCliente
{
    internal class NotaDeCredito
    {
        public string Descripcion { get; set; }
        public string NumeroNotaCredito { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
    }
}
