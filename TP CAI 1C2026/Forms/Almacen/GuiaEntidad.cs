using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using TP_CAI_1C2026.Forms.Consultas.ConsultarTracking;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class GuiaEntidad
    {
        public string NroGuia { get; set; }
        public string CuitDniCuilCliente { get; set; }
        public DateTime FechaImposicion { get; set; }
        public TipoImposicionEnum TipoImposicion { get; set; }
        public int IdCentroDeDistribucionImposicion { get; set; }
        public int IdAgenciaImposicion { get; set; }
        public string DireccionRetiroDomicilio { get; set; }
        public TipoEntregaEnum TipoEntrega { get; set; }
        public int IdCentroDeDistribucionEntrega { get; set; }
        public int IdAgenciaEntrega { get; set; }
        public string DireccionEntrega { get; set; }
        public string DniDestinatario { get; set; }
        public string NombreDestinatario { get; set; }
        public TipoTamañoEnvioEnum TipoCaja { get; set; }
        public decimal PrecioVenta { get; set; }
        public EstadoGuiaEnum Estado { get; set; }
        public List<HistorialGuia> Historial { get; set; }
        public List<GuiaComisionFletero> ComisionFletero { get; set; }
        public List<GuiaComisionAgencia> ComisionAgencia { get; set; }
        public int IntentosDeEntrega { get; set; }

    }
}
