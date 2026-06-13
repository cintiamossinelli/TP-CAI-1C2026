namespace TP_CAI_1C2026.Forms.Troncal.DespachoHDRTransporte
{
    public partial class DespachoHDRTransporte : Form
    {
        private readonly DespachoHDRTransporteModelo modelo = new DespachoHDRTransporteModelo();

        public DespachoHDRTransporte()
        {
            InitializeComponent();
            HDRnumCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            HDRnumCMB.DisplayMember = nameof(Servicio.Descripcion);
            CargarServiciosDisponibles();
        }

        private void CargarServiciosDisponibles()
        {
            var fechaHoy = DateTime.Today;
            var fechaLimite = fechaHoy.AddDays(10);

            HDRnumCMB.DataSource = null;
            HDRnumCMB.DataSource = modelo.ObtenerServiciosDisponibles(fechaHoy, fechaLimite);
            HDRnumCMB.DisplayMember = nameof(Servicio.Descripcion);
            HDRnumCMB.SelectedIndex = -1;
            listView1.Items.Clear();
        }

        private void HDRnumCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            if (HDRnumCMB.SelectedItem is not Servicio servicioSeleccionado)
            {
                return;
            }

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

            if (HDRnumCMB.SelectedItem is not Servicio servicioSeleccionado
                || !modelo.DespacharServicio(servicioSeleccionado))
            {
                MessageBox.Show(
                    "La hoja de ruta seleccionada no corresponde al Centro de Distribución logueado o ya no está disponible.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                CargarServiciosDisponibles();
                return;
            }

            MessageBox.Show("Se han despachado las guía/s con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarServiciosDisponibles();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            HDRnumCMB.SelectedIndex = -1;
            listView1.Items.Clear();
        }
    }
}
