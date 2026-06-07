using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    public enum EstadoHDREnum
    {
        Emitida = 1,
        EntregadaAlFletero = 2,
        Rendida = 3,
        PendienteRendicion = 4 // Estado nuevo agregado, acordarse que en realidad es el estado anterior a Rendida
    }
}
