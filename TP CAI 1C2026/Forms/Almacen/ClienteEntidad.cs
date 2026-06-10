using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class ClienteEntidad
    {
        public string CuitDniCuilCliente { get; set; }
        public string RazonSocial { get; set; }
        public List<string> Factura { get; set; }
        [JsonPropertyName("NotaDeCredito")]
        public List<string> NotasDeCredito { get; set; }
        public List<string> Recibos { get; set; }
        public List<PrecioBasico> Tarifario {  get; set; }
    }
}
