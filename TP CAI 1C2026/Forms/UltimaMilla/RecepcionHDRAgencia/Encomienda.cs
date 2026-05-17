using System;

namespace TP_CAI_1C2026.Forms.UltimaMilla.RecepcionHDRAgencia
{
    internal class Encomienda
    {
        
        public string NumeroGuia { get; set; } = string.Empty;
        public string TipoEncomienda { get; set; } = string.Empty;

        
        public override string ToString() => $"{NumeroGuia} ({TipoEncomienda})";
    }
}
