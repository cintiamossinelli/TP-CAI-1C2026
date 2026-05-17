using System;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega;
using TP_CAI_1C2026.UltimaMilla.EmisionResumenHDR;

namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDR
{
    public partial class EmisionResumenHDRFRM : Form
    {
        private FleteroNegocio negocio = new FleteroNegocio();
        private Fletero fleteroActual;

        public EmisionResumenHDRFRM()
        {
            InitializeComponent();
        }

        private void buscarFleteroTBN_Click(object sender, EventArgs e)
        {
            try
            {
                // Buscar fletero usando los controles reales
                fleteroActual = negocio.ValidarYBuscarFletero(dniFleteroTXT.Text);
                nombreFleteroLBL.Text = fleteroActual.Nombre;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dniFleteroTXT.Focus();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dniFleteroTXT.Clear();
                dniFleteroTXT.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void emitirResumenBTN_Click(object sender, EventArgs e)
        {
            if (fleteroActual == null)
            {
                MessageBox.Show("Debe seleccionar un fletero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea emitir el Resumen B.4 para este fletero?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.No) return;

            try
            {
                // Procesar emision usando las filas de tus listas/grillas reales
                negocio.ProcesarEmisionResumen(fleteroActual, hdrEntregarLST.Items.Count, hdrRetirarLST.Items.Count);
                MessageBox.Show("¡Resumen B.4 emitido con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarPantalla();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarPantalla()
        {
            // Limpieza general con los nombres de tu diseño
            dniFleteroTXT.Clear();
            nombreFleteroLBL.Text = "Nombre del Fletero";
            hdrEntregarLST.Items.Clear();
            hdrRetirarLST.Items.Clear();
            fleteroActual = null;
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            // 1. Limpiamos el cuadro de texto donde se escribe el DNI
            dniFleteroTXT.Clear(); // Cambiá "dniFleteroTXT" por el nombre real de tu TextBox

            // 2. Limpiamos la etiqueta que muestra el nombre del fletero encontrado
            nombreFleteroLBL.Text = ""; // Cambiá "nombreFleteroLBL" por tu Label de nombre

            // 3. Si tenés un desplegable o una grilla (ListView), los vaciamos también
            // tuListView.Items.Clear();
        }
    }
}