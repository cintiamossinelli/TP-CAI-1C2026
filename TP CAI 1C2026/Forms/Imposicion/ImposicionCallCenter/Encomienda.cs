namespace TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter
{
    internal class Encomienda
    {
        public string TipoCaja { get; set; }
        public int Cantidad { get; set; }

        public Encomienda(string tipoCaja, int cantidad)
        {
            TipoCaja = tipoCaja;
            Cantidad = cantidad;
        }
    }
}
