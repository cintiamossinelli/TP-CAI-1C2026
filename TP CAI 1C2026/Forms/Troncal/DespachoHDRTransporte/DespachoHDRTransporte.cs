using System;
using System.Windows.Forms;

namespace TP_CAI_1C2026.Forms.Troncal.DespachoHDRTransporte
{
    public partial class DespachoHDRTransporte : Form
    {
        public DespachoHDRTransporte()
        {
            InitializeComponent();
        }

        private void HDRnumCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si el usuario deselecciona o queda vacío, limpiamos la grilla y salimos
            if (HDRnumCMB.SelectedIndex == -1)
            {
                listView1.Items.Clear();
                return;
            }

            // --- MODO SIMULACIÓN PARA PROBAR TU PANTALLA ---
            listView1.Items.Clear(); // Limpiamos lo que haya antes

            // Creamos 3 encomiendas ficticias 
            ListViewItem item1 = new ListViewItem("G-00124"); // N° Guía
            item1.SubItems.Add("Caja Mediana");              // Tipo Encomienda
            item1.SubItems.Add("Córdoba Centro");            // Destino

            ListViewItem item2 = new ListViewItem("G-00125");
            item2.SubItems.Add("Sobres Documentos");
            item2.SubItems.Add("Rosario Terminal");

            ListViewItem item3 = new ListViewItem("G-00341");
            item3.SubItems.Add("Pack Bidones");
            item3.SubItems.Add("Mendoza Capital");

            // Las subimos a la lista visual
            listView1.Items.Add(item1);
            listView1.Items.Add(item2);
            listView1.Items.Add(item3);

            // OBLIGAMOS A LA PANTALLA A REFRESCARSE
            listView1.Refresh();
            // ------------------------------------------------
        }

        private void despacharHDRBTN_Click(object sender, EventArgs e)
        {
            // 1. Validar que hayan seleccionado una Hoja de Ruta en el combo
            if (HDRnumCMB.SelectedIndex == -1 || string.IsNullOrEmpty(HDRnumCMB.Text))
            {
                MessageBox.Show("Por favor, seleccione un número de Hoja de Ruta (HDR) para despachar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HDRnumCMB.Focus();
                return;
            }

            // 2. Validar que la Hoja de Ruta seleccionada tenga encomiendas en la lista
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("No se puede despachar una Hoja de Ruta sin encomiendas asignadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Pedir confirmación al usuario antes de proceder
            DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea confirmar el despacho de la HDR {HDRnumCMB.Text}?", "Confirmar Despacho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("¡Hoja de Ruta despachada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiamos todo para la próxima
                HDRnumCMB.SelectedIndex = -1;
                listView1.Items.Clear();
            }
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            // 1. Limpiamos el cuadro desplegable (vuelve a quedar en blanco)
            HDRnumCMB.SelectedIndex = -1;

            // 2. Vaciamos la tabla de encomiendas
            listView1.Items.Clear();
        }
    }
}