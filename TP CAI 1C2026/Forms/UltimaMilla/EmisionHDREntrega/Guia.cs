// Guia.cs
namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega
{
    internal class Guia
    {
        public string NGuia { get; set; }
        public string TipoCaja { get; set; }
        public string LugarEntrega { get; set; }

        public Guia(string nGuia, string tipoCaja, string lugarEntrega)
        {
            NGuia = nGuia;
            TipoCaja = tipoCaja;
            LugarEntrega = lugarEntrega;
        }
    }
}
