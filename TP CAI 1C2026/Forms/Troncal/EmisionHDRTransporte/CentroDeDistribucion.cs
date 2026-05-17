namespace TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte;

internal class CentroDeDistribucion
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public override string ToString()
    {
        return Nombre;
    }
}