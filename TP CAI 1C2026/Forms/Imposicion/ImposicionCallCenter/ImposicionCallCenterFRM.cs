namespace TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter
{
    public partial class ImposicionCallCenterFRM : Form
    {
        private ImposicionCallCenterModelo modelo = new ImposicionCallCenterModelo();
        private List<Encomienda> encomiendas = new List<Encomienda>();
        private bool limpiando = false;

        public ImposicionCallCenterFRM()
        {
            InitializeComponent();
        }

        private void ImposicionCallCenterFRM_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void buscarClienteBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idClienteTXT.Text) || !long.TryParse(idClienteTXT.Text, out long id) || id <= 0)
            {
                MessageBox.Show("El dato ingresado debe ser numérico y positivo.", "Aviso");
                return;
            }

            Cliente? cliente = modelo.BuscarCliente(idClienteTXT.Text);

            if (cliente == null)
            {
                MessageBox.Show("No se encontró ningún cliente con ese dato ingresado.", "Aviso");
                return;
            }

            nombreClienteLBL.Text = cliente.Nombre;

            ciudadCMB.Items.Clear();
            foreach (string ciudad in modelo.ObtenerCiudades())
                ciudadCMB.Items.Add(ciudad);

            retiroGBX.Enabled = true;
        }

        private void ciudadCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            domicilioRemitenteTXT.Enabled = true;
        }

        private void domicilioRemitenteTXT_TextChanged(object sender, EventArgs e)
        {
            if (limpiando) return;
            if (!string.IsNullOrWhiteSpace(domicilioRemitenteTXT.Text))
                destinatarioGBX.Enabled = true;
        }

        private void cdRDB_CheckedChanged(object sender, EventArgs e)
        {
            destinoCDCMB.Items.Clear();
            foreach (string cd in modelo.ObtenerCDs())
                destinoCDCMB.Items.Add(cd);

            destinoCDCMB.Enabled = true;
            destinoAgenciaCMB.Enabled = false;
            destinoAgenciaCMB.SelectedIndex = -1;
            direccionDestinatarioTXT.Enabled = false;
            direccionDestinatarioTXT.Clear();

            ciudadDestinatarioCMB.SelectedIndex = -1;
            ciudadDestinatarioCMB.Enabled = false;
        }

        private void agenciaRDB_CheckedChanged(object sender, EventArgs e)
        {
            destinoAgenciaCMB.Items.Clear();
            foreach (string agencia in modelo.ObtenerAgencias())
                destinoAgenciaCMB.Items.Add(agencia);

            destinoAgenciaCMB.Enabled = true;
            destinoCDCMB.Enabled = false;
            destinoCDCMB.SelectedIndex = -1;
            direccionDestinatarioTXT.Enabled = false;
            direccionDestinatarioTXT.Clear();

            ciudadDestinatarioCMB.SelectedIndex = -1;
            ciudadDestinatarioCMB.Enabled = false;
        }

        private void domicilioRDB_CheckedChanged_2(object sender, EventArgs e)
        {
            direccionDestinatarioTXT.Enabled = true;
            destinoCDCMB.Enabled = false;
            destinoCDCMB.SelectedIndex = -1;
            destinoAgenciaCMB.Enabled = false;
            destinoAgenciaCMB.SelectedIndex = -1;
            ciudadDestinatarioCMB.Items.Clear();
            foreach (string ciudad in modelo.ObtenerCiudades())
                ciudadDestinatarioCMB.Items.Add(ciudad);
            ciudadDestinatarioCMB.Enabled = true;
        }

        private void destinoCDCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (destinoCDCMB.SelectedIndex != -1)
                dniDestinatarioTXT.Enabled = true;
        }

        private void destinoAgenciaCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (destinoAgenciaCMB.SelectedIndex != -1)
                dniDestinatarioTXT.Enabled = true;
        }

        private void direccionDestinatarioTXT_TextChanged(object sender, EventArgs e)
        {
            if (limpiando) return;
            if (!string.IsNullOrWhiteSpace(direccionDestinatarioTXT.Text))
                dniDestinatarioTXT.Enabled = true;
        }

        private void dniDestinatarioTXT_TextChanged(object sender, EventArgs e)
        {
            if (limpiando) return;
            if (!string.IsNullOrWhiteSpace(dniDestinatarioTXT.Text))
            {
                nombreDestinatarioTXT.Enabled = true;
                encomiendaGBX.Enabled = true;
            }
        }

        private void agregarBTN_Click(object sender, EventArgs e)
        {
            if (tipoCajaCMB.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de caja.", "Aviso");
                return;
            }

            bool resultado = modelo.AgregarEncomienda(
                tipoCajaCMB.SelectedItem.ToString()!,
                cantidadTXT.Text,
                encomiendas,
                out string error);

            if (!resultado)
            {
                MessageBox.Show(error, "Aviso");
                return;
            }

            ActualizarListView();
            tipoCajaCMB.SelectedIndex = -1;
            cantidadTXT.Clear();

            quitarItemBTN.Enabled = true;
            confirmarBTN.Enabled = true;
            cancelarBTN.Enabled = true;
        }

        private void quitarItemBTN_Click(object sender, EventArgs e)
        {
            if (encomiendaLST.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un item para quitar.", "Aviso");
                return;
            }

            int index = encomiendaLST.SelectedIndices[0];
            encomiendas.RemoveAt(index);
            ActualizarListView();
            MessageBox.Show("Se ha quitado el item seleccionado.", "Aviso");
        }

        private void confirmarBTN_Click(object sender, EventArgs e)
        {
            if (!cdRDB.Checked && !agenciaRDB.Checked && !domicilioRDB.Checked)
            {
                MessageBox.Show("Debe seleccionar una modalidad de entrega.", "Aviso");
                return;
            }

            bool resultado = modelo.Confirmar(
                dniDestinatarioTXT.Text,
                encomiendas,
                out string mensajeExito,
                out string error);

            if (!resultado)
            {
                MessageBox.Show(error, "Aviso");
                return;
            }

            MessageBox.Show(mensajeExito, "Operación exitosa");
            LimpiarCampos();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Operación cancelada.", "Aviso");
            LimpiarCampos();
        }

        private void ActualizarListView()
        {
            encomiendaLST.Items.Clear();
            foreach (Encomienda enc in encomiendas)
            {
                ListViewItem item = new ListViewItem(enc.TipoCaja);
                item.SubItems.Add(enc.Cantidad.ToString());
                encomiendaLST.Items.Add(item);
            }
        }

        private void LimpiarCampos()
        {
            limpiando = true;
            idClienteTXT.Clear();
            nombreClienteLBL.Text = "Nombre del Cliente";
            retiroGBX.Enabled = false;
            ciudadCMB.SelectedIndex = -1;
            domicilioRemitenteTXT.Clear();
            domicilioRemitenteTXT.Enabled = false;
            destinatarioGBX.Enabled = false;
            cdRDB.Checked = false;
            agenciaRDB.Checked = false;
            domicilioRDB.Checked = false;
            destinoCDCMB.SelectedIndex = -1;
            destinoCDCMB.Enabled = false;
            destinoAgenciaCMB.SelectedIndex = -1;
            destinoAgenciaCMB.Enabled = false;
            direccionDestinatarioTXT.Clear();
            direccionDestinatarioTXT.Enabled = false;
            ciudadDestinatarioCMB.SelectedIndex = -1;
            dniDestinatarioTXT.Clear();
            dniDestinatarioTXT.Enabled = false;
            nombreDestinatarioTXT.Clear();
            encomiendaGBX.Enabled = false;
            tipoCajaCMB.SelectedIndex = -1;
            cantidadTXT.Clear();
            encomiendas.Clear();
            encomiendaLST.Items.Clear();
            quitarItemBTN.Enabled = false;
            confirmarBTN.Enabled = false;
            cancelarBTN.Enabled = false;
            limpiando = false;
        }

        private void clienteGBX_Enter_1(object sender, EventArgs e) { }
        private void retiroGBX_Enter(object sender, EventArgs e) { }
        private void destinatarioGBX_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}