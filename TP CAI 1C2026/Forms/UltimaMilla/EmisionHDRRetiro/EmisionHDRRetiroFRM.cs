namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDRRetiro
{
    public partial class EmisionHDRRetiroFRM : Form
    {
        private readonly EmisionHDRRetiroModelo modelo = new EmisionHDRRetiroModelo();
        private List<Guia> guiasAgregadas = new List<Guia>();
        private Fletero? fleteroSeleccionado = null;

        public EmisionHDRRetiroFRM()
        {
            InitializeComponent();
        }

        private void EmisionHDRRetiroFRM_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void buscarFleteroTBN_Click(object sender, EventArgs e)
        {
            fleteroSeleccionado = modelo.BuscarFletero(dniFleteroTXT.Text);
            if (fleteroSeleccionado == null)
                return;

            nombreFleteroLBL.Text = fleteroSeleccionado.Nombre;
            CargarGuiasPendientes();

            localidadCMB.Items.Clear();
            foreach (string localidad in modelo.ObtenerLocalidades())
                localidadCMB.Items.Add(localidad);
        }

        private void CargarGuiasPendientes()
        {
            guiasSinAgregarLST.Items.Clear();
            foreach (Guia guia in modelo.ObtenerGuiasPendientes())
            {
                if (!guiasAgregadas.Contains(guia))
                {
                    ListViewItem item = new ListViewItem(guia.NGuia);
                    item.SubItems.Add(guia.TipoCaja);
                    item.SubItems.Add(guia.LugarRetiro);
                    guiasSinAgregarLST.Items.Add(item);
                }
            }
        }

        private void buscarGuiaBTN_Click(object sender, EventArgs e)
        {
            Guia? guia = modelo.BuscarGuia(nGuiaTXT.Text);
            if (guia == null)
                return;

            guiasSinAgregarLST.Items.Clear();
            ListViewItem item = new ListViewItem(guia.NGuia);
            item.SubItems.Add(guia.TipoCaja);
            item.SubItems.Add(guia.LugarRetiro);
            guiasSinAgregarLST.Items.Add(item);
        }

        private void buscarLocalidadBTN_Click(object sender, EventArgs e)
        {
            if (localidadCMB.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una localidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            guiasSinAgregarLST.Items.Clear();
            foreach (Guia guia in modelo.ObtenerGuiasPendientes())
            {
                if (guia.LugarRetiro.Contains(localidadCMB.SelectedItem!.ToString()!) && !guiasAgregadas.Contains(guia))
                {
                    ListViewItem item = new ListViewItem(guia.NGuia);
                    item.SubItems.Add(guia.TipoCaja);
                    item.SubItems.Add(guia.LugarRetiro);
                    guiasSinAgregarLST.Items.Add(item);
                }
            }
        }

        private void agregarBTN_Click(object sender, EventArgs e)
        {
            List<string> guiasAgregar = new List<string>();

            foreach (ListViewItem item in guiasSinAgregarLST.CheckedItems)
                guiasAgregar.Add(item.Text);

            if (guiasAgregar.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una guía para agregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string nGuia in guiasAgregar)
            {
                Guia? guia = modelo.BuscarGuia(nGuia);
                if (guia != null && !guiasAgregadas.Contains(guia))
                    guiasAgregadas.Add(guia);
            }

            ActualizarListViewAgregadas();
            CargarGuiasPendientes();
        }

        private void quitarBTN_Click(object sender, EventArgs e)
        {
            List<string> guiasQuitar = new List<string>();

            foreach (ListViewItem item in guiasAgregadasLST.CheckedItems)
                guiasQuitar.Add(item.Text);

            if (guiasQuitar.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una guía para quitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string nGuia in guiasQuitar)
            {
                Guia? guia = guiasAgregadas.FirstOrDefault(g => g.NGuia == nGuia);
                if (guia != null)
                    guiasAgregadas.Remove(guia);
            }

            ActualizarListViewAgregadas();
            CargarGuiasPendientes();
        }

        private void generarBTN_Click(object sender, EventArgs e)
        {
            if (fleteroSeleccionado == null)
            {
                MessageBox.Show("Debe buscar y seleccionar un fletero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool resultado = modelo.GenerarHDR(fleteroSeleccionado, guiasAgregadas, out string mensajeExito, out string error);
            if (!resultado)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Operación cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
        }

        private void ActualizarListViewAgregadas()
        {
            guiasAgregadasLST.Items.Clear();
            foreach (Guia guia in guiasAgregadas)
            {
                ListViewItem item = new ListViewItem(guia.NGuia);
                item.SubItems.Add(guia.TipoCaja);
                item.SubItems.Add(guia.LugarRetiro);
                guiasAgregadasLST.Items.Add(item);
            }
        }

        private void LimpiarCampos()
        {
            dniFleteroTXT.Clear();
            nombreFleteroLBL.Text = "Nombre del Fletero";
            fleteroSeleccionado = null;
            guiasAgregadas.Clear();
            guiasSinAgregarLST.Items.Clear();
            guiasAgregadasLST.Items.Clear();
            nGuiaTXT.Clear();
            localidadCMB.Items.Clear();
            localidadCMB.SelectedIndex = -1;
        }

        private void dniFleteroLBL_Click(object sender, EventArgs e) { }
    }
}