using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TP_CAI_1C2026.Forms.UltimaMilla.RecepcionHDRAgencia
{
    public partial class RecepcionHDRAgenciaFRM : Form
    {
        private readonly RecepcionHDRAgenciaModelo modelo =
            new RecepcionHDRAgenciaModelo();

        private HDR hdrSeleccionada;

        private List<Encomienda> encomiendasHDR =
            new List<Encomienda>();

        public RecepcionHDRAgenciaFRM()
        {
            InitializeComponent();
        }

        private void RecepcionHDRAgenciaFRM_Load(
            object sender,
            EventArgs e)
        {
            CargarHDRs();

            GuiasLST.Items.Clear();
        }

        private void CargarHDRs()
        {
            var hdrs =
                modelo.ObtenerHDRsPendientes();

            HDRnumCMB.DataSource = hdrs;

            HDRnumCMB.DisplayMember =
                "NumeroHDR";

            HDRnumCMB.SelectedIndex = -1;
        }

        private void HDRnumCMB_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (HDRnumCMB.SelectedIndex == -1)
            {
                return;
            }

            hdrSeleccionada =
                (HDR)HDRnumCMB.SelectedItem;

            encomiendasHDR =
                modelo.ObtenerEncomiendasHDR(
                    hdrSeleccionada);

            CargarEncomiendas(encomiendasHDR);
        }

        private void CargarEncomiendas(
            List<Encomienda> encomiendas)
        {
            GuiasLST.Items.Clear();

            foreach (var encomienda in encomiendas)
            {
                ListViewItem item =
                    new ListViewItem(
                        encomienda.NumeroGuia);

                item.SubItems.Add(
                    encomienda.TipoEncomienda);

                GuiasLST.Items.Add(item);
            }
        }

        private void GuiasLST_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {

        }

        private void recibirHDRBTN_Click(
            object sender,
            EventArgs e)
        {
            if (hdrSeleccionada == null)
            {
                MessageBox.Show(
                    "Debe seleccionar un HDR.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

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

            modelo.RecepcionarHDR(
                hdrSeleccionada);

            MessageBox.Show(
                "HDR recepcionado correctamente.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarPantalla();
        }

        private void LimpiarPantalla()
        {
            HDRnumCMB.SelectedIndex = -1;

            GuiasLST.Items.Clear();

            hdrSeleccionada = null;

            encomiendasHDR.Clear();
        }

        private void cancelarBTN_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}
