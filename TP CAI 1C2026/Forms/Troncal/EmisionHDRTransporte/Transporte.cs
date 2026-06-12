namespace TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte;

internal class Transporte
{
    public int IdServicio { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public EmpresaTransporte Empresa { get; set; } = new();

    public CentroDeDistribucion Destino { get; set; } = new();

    public string HoraTexto
    {
        get { return Hora.ToString(@"hh\:mm"); }
    }

    public string EmpresaTexto
    {
        get { return Empresa.Nombre; }
    }

    public string DestinoTexto
    {
        get { return Destino.Nombre; }
    }
}
