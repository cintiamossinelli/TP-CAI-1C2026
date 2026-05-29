namespace TP_CAI_1C2026.Forms.Troncal.DespachoHDRTransporte
{
    public partial class DespachoHDRTransporte : Form
    {
        private readonly DespachoHDRTransporteModelo modelo = new DespachoHDRTransporteModelo();

        public DespachoHDRTransporte()
        {
            InitializeComponent();
            HDRnumCMB.DropDownStyle = ComboBoxStyle.DropDownList; //solo selección

            // Cargar servicios entre hoy y los próximos 10 días
            var fechaHoy = DateTime.Today;
            var fechaLimite = fechaHoy.AddDays(+10);
            var servicios = modelo.ObtenerServicios()
                .Where(s => s.FechayHora.Date >= fechaHoy && s.FechayHora.Date <= fechaLimite)
                .OrderBy(s => s.FechayHora)
                .ToList();

            HDRnumCMB.Items.Clear();
            foreach (var servicio in servicios)
            {
                HDRnumCMB.Items.Add(servicio.Empresa + " - " + servicio.FechayHora.ToString("dd/MM/yyyy HH:mm"));
            }
        }

        private void HDRnumCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            var fechaHoy = DateTime.Today;
            var fechaLimite = fechaHoy.AddDays(+10);

            var servicios = modelo.ObtenerServicios()
                .Where(s => s.FechayHora.Date >= fechaHoy && s.FechayHora.Date <= fechaLimite)
                .OrderBy(s => s.FechayHora)
                .ToList();

            // Verificación defensiva
            if (HDRnumCMB.SelectedIndex < 0 || HDRnumCMB.SelectedIndex >= servicios.Count)
            {
                return;
            }

            Servicio servicioSeleccionado = servicios[HDRnumCMB.SelectedIndex];

            foreach (var guia in servicioSeleccionado.GuiasAsociadas)
            {
                ListViewItem item = new ListViewItem(guia.Id);
                item.SubItems.Add(guia.Tamaño);
                item.SubItems.Add(guia.destino);
                listView1.Items.Add(item);
            }
        }

        private void despacharHDRBTN_Click(object sender, EventArgs e)
        {
            if (HDRnumCMB.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un servicio de transporte.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HDRnumCMB.Focus();
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea despachar " + listView1.Items.Count + " guía/s para el servicio seleccionado?",
                "Confirmar recepción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.No)
            {
                return;
            }

            MessageBox.Show("Se han despachado las guía/s con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            HDRnumCMB.SelectedIndex = -1;
            listView1.Items.Clear();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            HDRnumCMB.SelectedIndex = -1;
            listView1.Items.Clear();
        }
    }
}