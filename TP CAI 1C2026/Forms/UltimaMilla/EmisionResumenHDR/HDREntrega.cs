
namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDR
{
    public class HDREntrega
    {
        public int NroHojaRuta { get; set; }
        public string Domicilio { get; set; }
        public int CantEncomiendas { get; set; }
        public string DniFleteroAsignado { get; set; } // Para vincularlo al fletero

        public HDREntrega(int nro, string domicilio, int cant, string dniFletero)
        {
            NroHojaRuta = nro;
            Domicilio = domicilio;
            CantEncomiendas = cant;
            DniFleteroAsignado = dniFletero;
        }
    }
}