using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Administración.CuentaCorrienteCliente
{
    internal class Cliente
    {
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }

        public List<Facturas> Factura { get; set; } = new List<Facturas>();

        public List<NotaDeCredito> NotasDeCredito { get; set; } = new List<NotaDeCredito>();

        public List<Recibo> Recibos { get; set; } = new List<Recibo>();

    }
}
