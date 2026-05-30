using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Administración.ResultadoCostoVentas
{
    internal class Envios
    {
        public string numeroGuia { get; set; }
        public DateTime fechaEnvio { get; set; }
        public decimal costoEnvio { get; set; }
        public decimal precioVenta { get; set; }
        public int idEmpresaTransporte { get; set; }
    }
}
