using TP_CAI_1C2026.Forms.Administracion.CuentaCorrienteCliente;
using TP_CAI_1C2026.Forms.Administracion.ResultadoCostoVentas;
using TP_CAI_1C2026.Forms.Consultas.ConsultarTracking;
using TP_CAI_1C2026.Forms.Entregas.EntregaAgencia;
using TP_CAI_1C2026.Forms.Entregas.EntregaCD;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCD;
using TP_CAI_1C2026.Forms.UltimaMilla.AdmisionCD;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDRConfirmadas;
using TP_CAI_1C2026.Forms.Administracion.EmisionFactura;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega;
using TP_CAI_1C2026.Forms.UltimaMilla.RecepcionHDRAgencia;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDRRetiro;
using TP_CAI_1C2026.Forms.Troncal.RecepcionHDRTransporte;
using TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionAgencia;
using TP_CAI_1C2026.Forms.Troncal.DespachoHDRTransporte;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDR;

namespace TP_CAI_1C2026
{
    internal static class Program
    {
        public static int CdActual { get; set; } = 1;
        public static int AgenciaActual { get; set; } = 1;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new EmisionFacturaFRM());
        }
    }
}