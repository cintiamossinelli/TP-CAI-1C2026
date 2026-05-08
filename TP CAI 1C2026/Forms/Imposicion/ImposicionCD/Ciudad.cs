namespace TP_CAI_1C2026.Forms.Imposicion.ImposicionCD;

internal class Ciudad
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Agencia> Agencias { get; set; } = new List<Agencia>();
}
