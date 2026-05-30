using System.Data;

namespace TP_CAI_1C2026.Forms.Troncal.RecepcionHDRTransporte
{
    public partial class RecepcionHDRTransporteFRM : Form
    {
        private readonly RecepcionHDRTransporteModelo modelo = new RecepcionHDRTransporteModelo();

        public RecepcionHDRTransporteFRM()
        {
            InitializeComponent();
            servicioOmnibusBTN.DropDownStyle = ComboBoxStyle.DropDownList; //esto para que no se pueda escribir en el comboBox, solo seleccionar las opciones que tiene
            // Cargar solo los servicios cuya fecha (sin considerar hora) esté entre hoy y los últimos 10 días
            var fechaHoy = DateTime.Today;
            var fechaLimite = fechaHoy.AddDays(-10);
            var servicios = modelo.ObtenerServicios()
                .Where(s => s.FechayHora.Date <= fechaHoy && s.FechayHora.Date >= fechaLimite)
                .OrderByDescending(s => s.FechayHora)
                .ToList();

            foreach (var servicio in servicios)
            {
                servicioOmnibusBTN.Items.Add(servicio.Empresa + " - " + servicio.FechayHora.ToString("dd/MM/yyyy HH:mm"));
            }
        }

        private void servicioOmnibusBTN_SelectedIndexChanged(object sender, EventArgs e)
        {
            GuiasLST.Items.Clear();

            if (servicioOmnibusBTN.SelectedIndex == -1)
            {
                return; //Si no hay nada seleccionado, sale sin hacer nada.
            }

            var fechaHoy = DateTime.Today;
            var fechaLimite = fechaHoy.AddDays(-10);
            var servicios = modelo.ObtenerServicios()
                .Where(s => s.FechayHora.Date <= fechaHoy && s.FechayHora.Date >= fechaLimite)
                .OrderByDescending(s => s.FechayHora)
                .ToList();

            Servicio servicioSeleccionado = servicios[servicioOmnibusBTN.SelectedIndex];

            foreach (var guia in servicioSeleccionado.GuiasAsociadas) //Recorre una por una las guías que tiene ese servicio.
            {
                ListViewItem item = new ListViewItem(guia.Id); //Crea una fila en el ListView con el número de guía.
                item.SubItems.Add(guia.Tamaño); //Agrega el tipo de encomienda a esa fila.
                item.SubItems.Add(guia.destino); //Agrega el destino a esa fila.
                GuiasLST.Items.Add(item);
            }

        }

        private void recibirHDRBTN_Click(object sender, EventArgs e)
        {
            if (servicioOmnibusBTN.SelectedIndex == -1)
            { //pruebo que se haya seleccionado un servicio de transporte
                MessageBox.Show("Debe seleccionar un servicio de transporte.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                servicioOmnibusBTN.Focus();
                return;
            }

            //Un doble chequeo para asegurarme que el usuario no confirme la recepción sin haber seleccionado un servicio o sin haber guías asociadas al servicio seleccionado
            DialogResult confirmacion = MessageBox.Show(
            "¿Está seguro que desea confirmar la recepción de " + GuiasLST.Items.Count + " guía/s para el servicio seleccionado?",
            "Confirmar recepción",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (confirmacion == DialogResult.No)
            {
                return;
            }
            servicioOmnibusBTN.SelectedIndex = -1;
            GuiasLST.Items.Clear();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            servicioOmnibusBTN.SelectedIndex = -1; //Esto para que se deseleccione el servicio de transporte, y se borren las guías asociadas a ese servicio del ListView.
            GuiasLST.Items.Clear();

        }


        private void RecepcionHDRTransporteFRM_Load(object sender, EventArgs e)
        {

        }
    }
}
