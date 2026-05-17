namespace TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte;

internal class GuiaEncomienda
{
    public string NumeroGuia { get; set; } = string.Empty;

    public string TipoEncomienda { get; set; } = string.Empty;

    public CentroDeDistribucion Destino { get; set; } = new();

    public string DestinoTexto
    {
        get { return Destino.Nombre; }
    }
}