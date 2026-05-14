namespace TP_CAI_1C2026.Forms.Consultas.ConsultarTracking;

internal class Guia
{
    public string NGuia { get; set; }
    public string CuitDniCuil { get; set; }
    public string Origen { get; set; }
    public string Destino { get; set; }
    public string TipoCaja { get; set; }
    public List<HistorialGuia> Historial { get; set; } = new List<HistorialGuia>();
}
