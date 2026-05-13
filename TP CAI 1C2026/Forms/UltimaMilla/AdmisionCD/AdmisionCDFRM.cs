using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP_CAI_1C2026.Forms.UltimaMilla.AdmisionCD
{
    public partial class AdmisionCDFRM : Form
    {
        private readonly AdmisionCDModelo modelo = new AdmisionCDModelo();
        public AdmisionCDFRM()
        {
            InitializeComponent();
        }

        private void buscarBTN_Click(object sender, EventArgs e)
        {
            var guia = modelo.BuscarGuias(nGuiaTXT.Text);

            if (guia == null)
            {
                // El modelo ya mostró el error, limpio el campo y salgo
                nGuiaTXT.Text = string.Empty;
                return;
            }

            // Verificar si la guía ya está en la lista
            bool existe = guiasLST.Items.Cast<ListViewItem>().Any(i => string.Equals(i.Text, guia.Id, StringComparison.OrdinalIgnoreCase));
            if (existe)
            {
                MessageBox.Show("La guía ya ha sido agregada previamente en la lista a admitir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nGuiaTXT.Text = string.Empty;
                return;
            }

            // Agrego la guía encontrada a la lista
            var item = new ListViewItem(guia.Id);
            item.SubItems.Add(guia.Tamaño);
            item.Tag = guia;
            guiasLST.Items.Add(item);



            // Limpio el campo de texto después de agregar
            nGuiaTXT.Text = string.Empty;

        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void admitirBTN_Click(object sender, EventArgs e)
        {
            if (guiasLST.Items.Count == 0)
            {
                MessageBox.Show("No hay guías para admitir. Por favor, agregue al menos una guía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Las guías han sido admitidas exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                guiasLST.Items.Clear();
            }
        }

        private void rechazarBTN_Click(object sender, EventArgs e)
        {
            if (guiasLST.Items.Count == 0)
            {
                MessageBox.Show("No hay guías para rechazar. Por favor, agregue al menos una guía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Las guías han sido rechazadas exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                guiasLST.Items.Clear();
            }
        }

        private void AdmisionCDFRM_Load(object sender, EventArgs e)
        {

        }
    }
}
