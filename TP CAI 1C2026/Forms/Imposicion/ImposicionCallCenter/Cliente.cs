namespace TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter
{
    internal class Cliente
    {
        public long Id { get; set; }
        public string Nombre { get; set; }

        public Cliente(long id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}