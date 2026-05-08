namespace TP_CAI_1C2026.Forms.Imposicion.ImposicionCD
{
    public partial class ImposicionCDFRM : Form
    {
        private readonly ImposicionCDModelo modelo = new ImposicionCDModelo();

        public ImposicionCDFRM()
        {
            InitializeComponent();
        }

        private void ImposicionCDFRM_Load(object sender, EventArgs e)
        {
            var tamañosEnvio = modelo.ObtenerTamañosEnvio();
            tipoCajaCMB.DisplayMember = "Letra";
            tipoCajaCMB.ValueMember = "Letra";
            tipoCajaCMB.DataSource = tamañosEnvio;

            List<CentroDeDistribucion> cds = modelo.ObtenerCDS();
            destinoCDCMB.Items.Clear();
            foreach (var c in cds)
            {
                destinoCDCMB.Items.Add(c);
            }
            destinoCDCMB.DisplayMember = "Nombre";
            destinoCDCMB.ValueMember = "Id";


            List<Ciudad> ciudades = modelo.ObtenerCiudades();
            ciudadAgenciaCMB.Items.Clear();
            foreach (var c in ciudades)
            {
                ciudadAgenciaCMB.Items.Add(c);
            }
            ciudadAgenciaCMB.DisplayMember = "Nombre";
            ciudadAgenciaCMB.ValueMember = "Id";
            ciudadAgenciaCMB.SelectedIndex = 0;
        }

        private void ciudadAgenciaCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ciudadAgenciaCMB.SelectedIndex == -1)
            {
                agenciaCMB.Items.Clear();
                return;
            }

            var ciudadSeleccionada = (Ciudad)ciudadAgenciaCMB.SelectedItem;
            var agencias = ciudadSeleccionada.Agencias;

            agenciaCMB.DisplayMember = "Nombre";
            agenciaCMB.ValueMember = "Id";
            agenciaCMB.DataSource = agencias;
        }

        private void agenciaRDB_CheckedChanged(object sender, EventArgs e)
        {
            ciudadAgenciaCMB.Enabled = agenciaRDB.Checked;
            agenciaCMB.Enabled = agenciaRDB.Checked;
        }

        private void cdRDB_CheckedChanged(object sender, EventArgs e)
        {
            destinoCDCMB.Enabled = cdRDB.Checked;
        }

        private void domicilioRDB_CheckedChanged(object sender, EventArgs e)
        {
            ciudadDestinatarioCMB.Enabled = domicilioRDB.Checked;
        }

        private void buscarClienteBTN_Click(object sender, EventArgs e)
        {
            var cliente = modelo.BuscarCliente(idClienteTXT.Text);
            if (cliente == null)
            {
                //salgo directo porque dejo que el modelo muestre el error.
                nombreClienteLBL.Text = string.Empty;
                return;
            }

            nombreClienteLBL.Text = cliente.RazonSocial;
        }

        private void agregarBTN_Click(object sender, EventArgs e)
        {
            var tamaño = (TamañoEnvio)tipoCajaCMB.SelectedItem;

            if (!int.TryParse(cantidadTXT.Text, out int cantidad))
            {
                MessageBox.Show("Ingrese un número entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var detalleEncomienda = modelo.AgregarCaja(tamaño, cantidad);
            if (detalleEncomienda != null) //agregarlo a la lista
            {
                var item = new ListViewItem();
                item.Text = detalleEncomienda.LetraTamaño;
                item.SubItems.AddRange(cantidad.ToString());
                item.Tag = detalleEncomienda;

                encomiendaLST.Items.Add(item);
            }
        }

        private void quitarItemBTN_Click(object sender, EventArgs e)
        {
            if (encomiendaLST.SelectedItems.Count != 1)
            {
                MessageBox.Show("Seleccione un (y solo un) item para quitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var item = encomiendaLST.SelectedItems[0];
            var detalleEncomienda = (DetalleEncomienda)item.Tag;

            if (modelo.EliminarDetalle(detalleEncomienda)) //el modelo puede devolver false si hay un error.
            {
                return;
            }

            encomiendaLST.Items.Remove(item);
        }
    }
}
