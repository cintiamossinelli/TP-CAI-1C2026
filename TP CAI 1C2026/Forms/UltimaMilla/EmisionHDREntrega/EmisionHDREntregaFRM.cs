// EmisionHDREntregaFRM.cs
namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega
{
    public partial class EmisionHDREntregaFRM : Form
    {
        private EmisionHDREntregaModelo modelo = new EmisionHDREntregaModelo();
        private List<Guia> guiasAgregadas = new List<Guia>();
        private Fletero? fleteroSeleccionado = null;
        private bool limpiando = false;

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
            if (string.IsNullOrWhiteSpace(dniFleteroTXT.Text) || !int.TryParse(dniFleteroTXT.Text, out _) || dniFleteroTXT.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe ser numérico, positivo y de 8 dígitos.", "Aviso");
                return;
            }

            fleteroSeleccionado = modelo.BuscarFletero(dniFleteroTXT.Text);

            if (fleteroSeleccionado == null)
            {
                MessageBox.Show("No se encontró ningún fletero con ese DNI.", "Aviso");
                return;
            }

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
                    item.SubItems.Add(guia.LugarEntrega);
                    guiasSinAgregarLST.Items.Add(item);
                }
            }
        }

        private void buscarGuiaBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nGuiaTXT.Text))
            {
                MessageBox.Show("Debe ingresar un número de guía.", "Aviso");
                return;
            }

            Guia? guia = modelo.BuscarGuia(nGuiaTXT.Text);

            if (guia == null)
            {
                MessageBox.Show("No se encontró ninguna guía con ese número.", "Aviso");
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
                MessageBox.Show("Debe seleccionar una localidad.", "Aviso");
                return;
            }

            guiasSinAgregarLST.Items.Clear();
            foreach (Guia guia in modelo.ObtenerGuiasPendientes())
            {
                if (guia.LugarEntrega.Contains(localidadCMB.SelectedItem!.ToString()!) && !guiasAgregadas.Contains(guia))
                {
                    ListViewItem item = new ListViewItem(guia.NGuia);
                    item.SubItems.Add(guia.TipoCaja);
                    item.SubItems.Add(guia.LugarEntrega);
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
                MessageBox.Show("Debe seleccionar al menos una guía para agregar.", "Aviso");
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
                MessageBox.Show("Debe seleccionar al menos una guía para quitar.", "Aviso");
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
                MessageBox.Show("Debe buscar y seleccionar un fletero.", "Aviso");
                return;
            }

            bool resultado = modelo.GenerarHDR(fleteroSeleccionado, guiasAgregadas, out string mensajeExito, out string error);

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

        private void ActualizarListViewAgregadas()
        {
            guiasAgregadasLST.Items.Clear();
            foreach (Guia guia in guiasAgregadas)
            {
                ListViewItem item = new ListViewItem(guia.NGuia);
                item.SubItems.Add(guia.TipoCaja);
                item.SubItems.Add(guia.LugarEntrega);
                guiasAgregadasLST.Items.Add(item);
            }
        }

        private void LimpiarCampos()
        {
            limpiando = true;
            dniFleteroTXT.Clear();
            nombreFleteroLBL.Text = "Nombre del Fletero";
            fleteroSeleccionado = null;
            guiasAgregadas.Clear();
            guiasSinAgregarLST.Items.Clear();
            guiasAgregadasLST.Items.Clear();
            nGuiaTXT.Clear();
            localidadCMB.SelectedIndex = -1;
            limpiando = false;
        }
    }
}
