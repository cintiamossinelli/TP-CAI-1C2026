namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega
{
    public partial class EmisionHDREntregaFRM : Form
    {
        private readonly EmisionHDREntregaModelo modelo = new EmisionHDREntregaModelo();

        public EmisionHDREntregaFRM()
        {
            InitializeComponent();
        }

        private void EmisionHDREntregaFRM_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void buscarFleteroTBN_Click(object sender, EventArgs e)
        {
            var fleteroSeleccionado = modelo.BuscarFletero(dniFleteroTXT.Text, out string errorFletero);
            if (fleteroSeleccionado == null)
            {
                MessageBox.Show(errorFletero, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nombreFleteroLBL.Text = fleteroSeleccionado.Nombre;
            CargarGuiasPendientes();

            localidadCMB.Items.Clear();
            foreach (string localidad in modelo.ObtenerLocalidades())
                localidadCMB.Items.Add(localidad);

            string localidadFletero = modelo.ObtenerLocalidadFletero();
            int idx = localidadCMB.Items.IndexOf(localidadFletero);
            if (idx >= 0)
                localidadCMB.SelectedIndex = idx;
        }

        private void CargarGuiasPendientes()
        {
            guiasSinAgregarLST.Items.Clear();
            foreach (Guia guia in modelo.ObtenerGuiasPendientes())
            {
                ListViewItem item = new ListViewItem(guia.NGuia);
                item.SubItems.Add(guia.TipoCaja);
                item.SubItems.Add(guia.LugarEntrega);
                guiasSinAgregarLST.Items.Add(item);
            }
        }

        private void buscarGuiaBTN_Click(object sender, EventArgs e)
        {
            Guia? guia = modelo.BuscarGuia(nGuiaTXT.Text, out string errorGuia);
            if (guia == null)
            {
                MessageBox.Show(errorGuia, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            guiasSinAgregarLST.Items.Clear();
            ListViewItem item = new ListViewItem(guia.NGuia);
            item.SubItems.Add(guia.TipoCaja);
            item.SubItems.Add(guia.LugarEntrega);
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
            string localidad = localidadCMB.SelectedItem!.ToString()!;

            foreach (Guia guia in
                modelo.ObtenerGuiasPendientesPorLocalidad(localidad))
            {
                ListViewItem item = new ListViewItem(guia.NGuia);
                item.SubItems.Add(guia.TipoCaja);
                item.SubItems.Add(guia.LugarEntrega);
                guiasSinAgregarLST.Items.Add(item);
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
                modelo.AgregarGuia(nGuia);

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
                Guia? guia = modelo.guiasAgregadas.FirstOrDefault(g => g.NGuia == nGuia);
                if (guia != null)
                    modelo.guiasAgregadas.Remove(guia);
            }

            ActualizarListViewAgregadas();
            CargarGuiasPendientes();
        }

        private void generarBTN_Click(object sender, EventArgs e)
        {
            bool resultado = modelo.GenerarHDR(out string mensajeExito, out string error);
            if (!resultado)
            {
                if (!string.IsNullOrEmpty(error))
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
            foreach (Guia guia in modelo.guiasAgregadas)
            {
                ListViewItem item = new ListViewItem(guia.NGuia);
                item.SubItems.Add(guia.TipoCaja);
                item.SubItems.Add(guia.LugarEntrega);
                guiasAgregadasLST.Items.Add(item);
            }
        }

        private void LimpiarCampos()
        {
            modelo.Limpiar();
            dniFleteroTXT.Clear();
            nombreFleteroLBL.Text = "Nombre del Fletero";
            guiasSinAgregarLST.Items.Clear();
            guiasAgregadasLST.Items.Clear();
            nGuiaTXT.Clear();
            localidadCMB.Items.Clear();
            localidadCMB.SelectedIndex = -1;
        }
    }
}
