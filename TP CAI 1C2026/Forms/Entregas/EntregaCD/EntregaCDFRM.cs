namespace TP_CAI_1C2026.Forms.Entregas.EntregaCD
{
    public partial class EntregaCDFRM : Form
    {
        private readonly EntregaCDModelo modelo = new EntregaCDModelo();

        public EntregaCDFRM()
        {
            InitializeComponent();
        }

        private void EntregaCDFRM_Load_1(object sender, EventArgs e)
        {
            guiasLST.Items.Clear();
        }

        private void buscarBTN_Click(object sender, EventArgs e)
        {
            var destinatario = modelo.BuscarDestinatario(dniTXT.Text, out string errorBuscar);
            if (destinatario == null)
            {
                MessageBox.Show(errorBuscar, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var guias = modelo.ObtenerGuiasPorDestinatario(dniTXT.Text);
            guiasLST.Items.Clear();

            foreach (var guia in guias)
            {
                var item = new ListViewItem(guia.NGuia);
                item.SubItems.Add(guia.Estado);
                item.SubItems.Add(guia.TipoPaquete);
                item.Tag = guia;
                guiasLST.Items.Add(item);
            }
        }

        private void retirarBTN_Click(object sender, EventArgs e)
        {
            var guiasSeleccionadas = new List<Guia>();

            foreach (ListViewItem item in guiasLST.CheckedItems)
                guiasSeleccionadas.Add((Guia)item.Tag);

            bool resultado = modelo.RegistrarEntrega(guiasSeleccionadas, out string errorRegistrar);
            if (!resultado)
            {
                MessageBox.Show(errorRegistrar, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string resumen = "Entrega registrada correctamente.\n\nGuías entregadas:\n";
            foreach (var guia in guiasSeleccionadas)
                resumen += $"- {guia.NGuia} | {guia.TipoPaquete}\n";

            MessageBox.Show(resumen, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            guiasLST.Items.Clear();
            dniTXT.Clear();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Operación cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            guiasLST.Items.Clear();
            dniTXT.Clear();
        }
    }
}
