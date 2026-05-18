using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Administración.EmisionFactura
{
    internal class Cliente
    {
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public List<GuiasAFacturar> GuiasPendientes { get; set; } = new List<GuiasAFacturar>();
    }
}
