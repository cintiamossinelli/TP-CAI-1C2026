using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDRConfirmadas
{
    internal class HDREnTransito
    {
        public string NroHDR { get; set; }
        public string Domicilio { get; set; }
        public int CantEcomiendas { get; set; }
        public int DniFletero { get; set; }
        public string Estado { get; set; }
        /// <summary>"Retiro" o "Entrega"</summary>
        public string TipoHDR { get; set; }
        public bool EsEntregaEnAgencia { get; set; }
    }
}
