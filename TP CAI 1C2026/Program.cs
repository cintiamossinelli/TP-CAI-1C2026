using System;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega;

namespace TP_CAI_1C2026
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new ImposicionCallCenterFRM());
        }
    }
}