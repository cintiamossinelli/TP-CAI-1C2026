namespace TP_CAI_1C2026
{
    public partial class ImposicionCallCenterFRM : Form
    {
        private void destinatarioGBX_Enter(object sender, EventArgs e)
        {
            // Manejador vacío para evitar CS1061.
            // Añada aquí la lógica necesaria si quiere reaccionar al Enter del GroupBox.
        }
        public ImposicionCallCenterFRM()
        {
            InitializeComponent();
        }

        private void cdRDB_CheckedChanged(object sender, EventArgs e)
        {
            destinoCDCMB.Enabled = true;
            destinoAgenciaCMB.Enabled = false;
            destinoDomicilioTXT.Enabled = false;
            destinoAgenciaCMB.SelectedIndex = -1;
            destinoDomicilioTXT.Clear();
        }

        private void agenciaRDB_CheckedChanged(object sender, EventArgs e)
        {
            destinoCDCMB.Enabled = false;
            destinoAgenciaCMB.Enabled = true;
            destinoDomicilioTXT.Enabled = false;
            destinoCDCMB.SelectedIndex = -1;
            destinoDomicilioTXT.Clear();
        }

        private void domicilioRDB_CheckedChanged(object sender, EventArgs e)
        {
            destinoCDCMB.Enabled = false;
            destinoAgenciaCMB.Enabled = false;
            destinoDomicilioTXT.Enabled = true;
            destinoCDCMB.SelectedIndex = -1;
            destinoAgenciaCMB.SelectedIndex = -1;
        }

        private void agregarBTN_Click(object sender, EventArgs e)
        {
            if (tipoCajaCMB.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de caja.", "Aviso");
                return;
            }
            if (string.IsNullOrWhiteSpace(cantidadTXT.Text))
            {
                MessageBox.Show("Debe ingresar una cantidad.", "Aviso");
                return;
            }
            if (!int.TryParse(cantidadTXT.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un valor numérico, entero y positivo.", "Aviso");
                return;
            }

            ListViewItem item = new ListViewItem(tipoCajaCMB.SelectedItem?.ToString() ?? "");
            item.SubItems.Add(cantidadTXT.Text);
            encomiendaLST.Items.Add(item);

            tipoCajaCMB.SelectedIndex = -1;
            cantidadTXT.Clear();
        }

        private void quitarItemBTN_Click(object sender, EventArgs e)
        {
            if (encomiendaLST.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un item para quitar.", "Aviso");
                return;
            }
            encomiendaLST.Items.Remove(encomiendaLST.SelectedItems[0]);
            MessageBox.Show("Se ha quitado el item seleccionado.", "Aviso");
        }

        private void confirmarBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idClienteTXT.Text))
            {
                MessageBox.Show("El dato ingresado debe ser numérico y positivo.", "Aviso");
                return;
            }
            if (!cdRDB.Checked && !agenciaRDB.Checked && !domicilioRDB.Checked)
            {
                MessageBox.Show("Debe seleccionar una modalidad de entrega.", "Aviso");
                return;
            }
            if (string.IsNullOrWhiteSpace(dniDestinatarioTXT.Text))
            {
                MessageBox.Show("Debe ingresar el DNI del destinatario.", "Aviso");
                return;
            }
            if (!long.TryParse(dniDestinatarioTXT.Text, out _))
            {
                MessageBox.Show("El DNI debe ser numérico y positivo.", "Aviso");
                return;
            }
            if (encomiendaLST.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos una encomienda.", "Aviso");
                return;
            }

            MessageBox.Show("Operación exitosa. Guía generada correctamente.", "Éxito");
            LimpiarCampos();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Operación cancelada.", "Aviso");
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            idClienteTXT.Clear();
            ciudadCMB.SelectedIndex = -1;
            domicilioRemitenteTXT.Clear();
            cdRDB.Checked = false;
            agenciaRDB.Checked = false;
            domicilioRDB.Checked = false;
            destinoCDCMB.SelectedIndex = -1;
            destinoCDCMB.Enabled = false;
            destinoAgenciaCMB.SelectedIndex = -1;
            destinoAgenciaCMB.Enabled = false;
            destinoDomicilioTXT.Clear();
            destinoDomicilioTXT.Enabled = false;
            dniDestinatarioTXT.Clear();
            tipoCajaCMB.SelectedIndex = -1;
            cantidadTXT.Clear();
            encomiendaLST.Items.Clear();
        }

        // Added missing handler referenced by designer to fix CS1061
        private void dniDestinatarioLBL_Click(object sender, EventArgs e)
        {
            // Comportamiento razonable: pasar el foco al campo de texto del DNI
            dniDestinatarioTXT.Focus();
        }

        private void retiroGBX_Enter(object sender, EventArgs e)
        {
            // Intentionally left blank - required by designer event hookup
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void clienteGBX_Enter(object sender, EventArgs e)
        {

        }
    }
}
