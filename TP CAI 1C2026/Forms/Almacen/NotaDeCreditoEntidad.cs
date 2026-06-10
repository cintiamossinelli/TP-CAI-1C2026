using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class NotaDeCreditoEntidad
    {
        [JsonPropertyName("NumeroNotaCredito")]
        public string NumeroNotaDeCredito { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Descripcion { get; set; }
    }
}
