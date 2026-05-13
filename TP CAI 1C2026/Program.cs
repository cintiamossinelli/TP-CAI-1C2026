using TP_CAI_1C2026.Forms.Entregas.EntregaAgencia;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCD;
using TP_CAI_1C2026.Forms.UltimaMilla.AdmisionCD;

namespace TP_CAI_1C2026
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new EntregaAgenciaFRM());
        }
    }
}