using System.Data;

namespace TP_CAI_1C2026.Forms.Troncal.RecepcionHDRTransporte
{
    public partial class RecepcionHDRTransporteFRM : Form
    {
        private readonly RecepcionHDRTransporteModelo modelo = new RecepcionHDRTransporteModelo();

        public RecepcionHDRTransporteFRM()
        {
            InitializeComponent();
            servicioOmnibusCMB.DropDownStyle = ComboBoxStyle.DropDownList; //esto para que no se pueda escribir en el comboBox, solo seleccionar las opciones que tiene

            foreach (string descripcionServicio in modelo.ObtenerDescripcionesServicios())
            {
                servicioOmnibusCMB.Items.Add(descripcionServicio);
            }
        }

        private void servicioOmnibusCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GuiasLST.Items.Clear();

            if (servicioOmnibusCMB.SelectedIndex == -1)
            {
                return; //Si no hay nada seleccionado, sale sin hacer nada.
            }

            foreach (var guia in modelo.ObtenerGuiasDelServicio(servicioOmnibusCMB.SelectedIndex)) //Recorre una por una las guías que tiene ese servicio.
            {
                ListViewItem item = new ListViewItem(guia.Id); //Crea una fila en el ListView con el número de guía.
                item.SubItems.Add(guia.Tamaño); //Agrega el tipo de encomienda a esa fila.
                item.SubItems.Add(guia.destino); //Agrega el destino a esa fila.
                GuiasLST.Items.Add(item);
            }

        }

        private void recibirHDRBTN_Click(object sender, EventArgs e)
        {
            if (servicioOmnibusCMB.SelectedIndex == -1)
            { //pruebo que se haya seleccionado un servicio de transporte
                MessageBox.Show("Debe seleccionar un servicio de transporte.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                servicioOmnibusCMB.Focus();
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

            modelo.RecibirHDR(servicioOmnibusCMB.SelectedIndex);
            servicioOmnibusCMB.Items.Clear();
            foreach (string descripcionServicio in modelo.ObtenerDescripcionesServicios())
            {
                servicioOmnibusCMB.Items.Add(descripcionServicio);
            }
            GuiasLST.Items.Clear();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            servicioOmnibusCMB.SelectedIndex = -1; //Esto para que se deseleccione el servicio de transporte, y se borren las guías asociadas a ese servicio del ListView.
            GuiasLST.Items.Clear();

        }


        private void RecepcionHDRTransporteFRM_Load(object sender, EventArgs e)
        {

        }
    }
}
