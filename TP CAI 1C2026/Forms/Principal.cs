using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Administracion.CuentaCorrienteCliente;
using TP_CAI_1C2026.Forms.Administracion.EmisionFactura;
using TP_CAI_1C2026.Forms.Administracion.ResultadoCostoVentas;
using TP_CAI_1C2026.Forms.Almacen;
using TP_CAI_1C2026.Forms.Consultas.ConsultarTracking;
using TP_CAI_1C2026.Forms.Entregas.EntregaAgencia;
using TP_CAI_1C2026.Forms.Entregas.EntregaCD;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionAgencia;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCD;
using TP_CAI_1C2026.Forms.Troncal.DespachoHDRTransporte;
using TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte;
using TP_CAI_1C2026.Forms.Troncal.RecepcionHDRTransporte;
using TP_CAI_1C2026.Forms.UltimaMilla.AdmisionCD;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDRRetiro;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDR;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDRConfirmadas;
using TP_CAI_1C2026.Forms.UltimaMilla.RecepcionHDRAgencia;

namespace TP_CAI_1C2026.Forms
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            ConfigurarNavegacion();
            ConfigurarAccesos();
            Text = ObtenerTitulo();
        }

        private void ConfigurarAccesos()
        {
            bool esCd =
                Program.AccesoActual == TipoAcceso.CentroDeDistribucion;
            bool esAgencia =
                Program.AccesoActual == TipoAcceso.Agencia;
            bool esCallCenter =
                Program.AccesoActual == TipoAcceso.CallCenter;

            imposicionCDMenu.Enabled = esCd;
            imposicionAgenciaMenu.Enabled = esAgencia;
            imposicionCallCenterMenu.Enabled = esCallCenter;

            últimaMillaToolStripMenuItem.Enabled = !esCallCenter;
            admisionCDMenu.Enabled = esCd;
            emisionHDRRetiroMenu.Enabled = esCd;
            emisionHDREntregaMenu.Enabled = esCd;
            emisionResumenHDRMenu.Enabled = esCd;
            emisionResumenHDRConfirmadasMenu.Enabled = esCd;
            recepcionHDRAgenciaMenu.Enabled = esAgencia;

            troncalToolStripMenuItem.Enabled = esCd;

            entregasToolStripMenuItem.Enabled = !esCallCenter;
            entregaAgenciaMenu.Enabled = esAgencia;
            entregaCDMenu.Enabled = esCd;
        }

        private void ConfigurarNavegacion()
        {
            imposicionCDMenu.Click += (_, _) =>
                AbrirFormulario(new ImposicionCDFRM());
            imposicionAgenciaMenu.Click += (_, _) =>
                AbrirFormulario(new ImposicionAgenciaFRM());
            imposicionCallCenterMenu.Click += (_, _) =>
                AbrirFormulario(new ImposicionCallCenterFRM());

            admisionCDMenu.Click += (_, _) =>
                AbrirFormulario(new AdmisionCDFRM());
            emisionHDRRetiroMenu.Click += (_, _) =>
                AbrirFormulario(new EmisionHDRRetiroFRM());
            emisionHDREntregaMenu.Click += (_, _) =>
                AbrirFormulario(new EmisionHDREntregaFRM());
            emisionResumenHDRMenu.Click += (_, _) =>
                AbrirFormulario(new EmisionResumenHDRFRM());
            emisionResumenHDRConfirmadasMenu.Click += (_, _) =>
                AbrirFormulario(new EmisionResumenHDRConfirmadasFRM());
            recepcionHDRAgenciaMenu.Click += (_, _) =>
                AbrirFormulario(new RecepcionHDRAgenciaFRM());

            despachoHDRTransporteMenu.Click += (_, _) =>
                AbrirFormulario(new DespachoHDRTransporte());
            emisionHDRTransporteMenu.Click += (_, _) =>
                AbrirFormulario(new EmisionHDRTransporteFRM());
            recepcionHDRTransporteMenu.Click += (_, _) =>
                AbrirFormulario(new RecepcionHDRTransporteFRM());

            entregaAgenciaMenu.Click += (_, _) =>
                AbrirFormulario(new EntregaAgenciaFRM());
            entregaCDMenu.Click += (_, _) =>
                AbrirFormulario(new EntregaCDFRM());

            consultaTrackingMenu.Click += (_, _) =>
                AbrirFormulario(new ConsultarTrackingFRM());

            cuentaCorrienteClienteMenu.Click += (_, _) =>
                AbrirFormulario(new CuentaCorrienteClienteFRM());
            emisionFacturaMenu.Click += (_, _) =>
                AbrirFormulario(new EmisionFacturaFRM());
            resultadoCostoVentaMenu.Click += (_, _) =>
                AbrirFormulario(new ResultadoCostosVentasFRM());
        }

        private void AbrirFormulario(Form formulario)
        {
            using (formulario)
            {
                formulario.ShowDialog(this);
            }
        }

        private static string ObtenerTitulo()
        {
            return Program.AccesoActual switch
            {
                TipoAcceso.CentroDeDistribucion =>
                    "Principal - Centro de distribución: " + ObtenerNombreCd(),
                TipoAcceso.Agencia =>
                    "Principal - Agencia: " + ObtenerNombreAgencia(),
                TipoAcceso.CallCenter => "Principal - Call Center",
                _ => "Principal"
            };
        }

        private static string ObtenerNombreCd()
        {
            return CentroDeDistribucionAlmacen.CentrosDeDistribucion
                .FirstOrDefault(cd =>
                    cd.IdCentroDeDistribucion == Program.CdActual)
                ?.Nombre ?? Program.CdActual.ToString();
        }

        private static string ObtenerNombreAgencia()
        {
            return AgenciaAlmacen.Agencias
                .FirstOrDefault(agencia =>
                    agencia.IdAgencia == Program.AgenciaActual)
                ?.Nombre ?? Program.AgenciaActual.ToString();
        }

        private void cambiarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
