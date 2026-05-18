namespace TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte;

internal class HDRTransporte
{
    public int Id { get; set; }

    public DateTime FechaEmision { get; set; }

    public CentroDeDistribucion Destino { get; set; } = new();

    public Transporte Transporte { get; set; } = new();

    public List<GuiaEncomienda> Guias { get; set; } = new();
}