using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class PrecioBasico
    {
        public TipoTamañoEnvioEnum TamañoEncomienda { get; set; }
        public int CiudadOrigen { get; set; }
        public int CiudadDestino { get; set; }
        public decimal Importe { get; set; }
    }
}
