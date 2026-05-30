using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TP_CAI_1C2026.Forms.UltimaMilla.RecepcionHDRAgencia
{
    public partial class RecepcionHDRAgenciaFRM : Form
    {
        private readonly RecepcionHDRAgenciaModelo modelo = new RecepcionHDRAgenciaModelo();

        // El estado seleccionado y las encomiendas ahora se mantienen en el modelo

        public RecepcionHDRAgenciaFRM()
        {
            InitializeComponent();
            this.Load += RecepcionHDRAgenciaFRM_Load;
        }

        private void RecepcionHDRAgenciaFRM_Load(object sender,EventArgs e)
        {
            CargarHDRs();
            GuiasLST.Items.Clear();
        }

        private void CargarHDRs()
        {
            var hdrs = modelo.ObtenerHDRsPendientes();

            HDRnumCMB.DataSource = hdrs;

            HDRnumCMB.DisplayMember = "NumeroHDR";

            HDRnumCMB.SelectedIndex = -1;
        }

        private void HDRnumCMB_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (HDRnumCMB.SelectedIndex == -1)
            {
                return;
            }

            modelo.Seleccionada = (HDR)HDRnumCMB.SelectedItem;
            modelo.ObtenerEncomiendasHDR(modelo.Seleccionada);
            CargarEncomiendas(modelo.EncomiendasHDR);
        }

        private void CargarEncomiendas(List<Encomienda> encomiendas)
        {
            GuiasLST.Items.Clear();

            foreach (var encomienda in encomiendas)
            {
                ListViewItem item =new ListViewItem(encomienda.NumeroGuia);
                item.SubItems.Add(encomienda.TipoEncomienda);
                GuiasLST.Items.Add(item);
            }
        }

        private void GuiasLST_SelectedIndexChanged(object sender,EventArgs e)
        {

        }

        private void recibirHDRBTN_Click(object sender,EventArgs e)
        {
            if (!modelo.ValidarSeleccionHDR(modelo.Seleccionada, HDRnumCMB.SelectedIndex, out string mensajeValidacion))
            {
                MessageBox.Show(mensajeValidacion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Desea confirmar la recepción del HDR?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.No)
            {
                return;
            }

            var ok = modelo.ConfirmarRecepcionHDR(modelo.Seleccionada);
            if (ok)
            {
                MessageBox.Show("HDR recepcionado correctamente.","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);

                LimpiarPantalla();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al procesar la recepción del HDR.","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void LimpiarPantalla()
        {
            HDRnumCMB.SelectedIndex = -1;
            GuiasLST.Items.Clear();
            modelo.Seleccionada = null;
            modelo.EncomiendasHDR.Clear();
        }

        private void cancelarBTN_Click(object sender,EventArgs e)
        {
            HDRnumCMB.SelectedIndex = -1;
            GuiasLST.Items.Clear();
        }
    }
}
