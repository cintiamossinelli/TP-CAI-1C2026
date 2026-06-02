using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    public enum EstadoGuiaEnum
    {
        ImpuestaEnCallCenter = 1,
        ImpuestaEnAgencia = 2,
        ImpuestaEnCD = 3,
        PendienteDeRetiro = 4,
        Rendida = 5,
        PendienteDeAdmision = 6,
        Rechazada = 7,
        Admitida = 8,
        PendienteDeTransporte = 9,
        PendienteDeRecepcion = 10,
        EnDestino = 11,
        PendienteDeDistribucion = 12,
        DistribuidaEnAgencia = 13,
        DistribuidaEnDomicilio = 14,
        PendienteDeEntrega = 15,
        NoEntregada = 16,
        Entregada = 17,
        Facturada = 18
    }
}
