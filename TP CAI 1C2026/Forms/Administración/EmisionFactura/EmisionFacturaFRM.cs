using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Administración.EmisionFactura;

namespace TP_CAI_1C2026.Forms.Administracion.EmisionFactura
{
    public partial class EmisionFacturaFRM : Form
    {
        // Instancia del modelo
        private readonly EmisionFacturaModelo modelo = new EmisionFacturaModelo();
        // Cliente actual seleccionado
        private Cliente clienteActual;
        // Guías pendientes actuales
        //private List<GuiasAFacturar> guiasActuales = new List<GuiasAFacturar>();
        // Constructor
        public EmisionFacturaFRM()
        {
            InitializeComponent();
        }
        // Evento de carga del formulario
        private void EmisionFacturaFRM_Load(object sender, EventArgs e)
        {
            guiasEntregadasPendientesLST.Items.Clear();

            totalFacturarLBL.Text = "0,00";

            nombreClienteLBL.Text = string.Empty;
        }
        // Evento del botón de búsqueda de cliente
        private void buscarClienteBTN_Click(object sender, EventArgs e)
        {
            // Busco el cliente y valido el CUIT
            var cliente = modelo.BuscarCliente(idClienteTXT.Text);

            if (cliente == null)
            {
                nombreClienteLBL.Text = string.Empty;

                guiasEntregadasPendientesLST.Items.Clear();

                totalFacturarLBL.Text = "0,00";

                return;
            }

            clienteActual = cliente;

            nombreClienteLBL.Text = cliente.RazonSocial;

            // Obtengo guías pendientes
            //var clientesConGuias = modelo.ObtenerGuiasPendientes(); // devuelve List<Cliente>
            //var clienteConGuias = clientesConGuias.FirstOrDefault(c => c.Cuit == clienteActual.Cuit);
            var guiasActuales = modelo.ObtenerGuiasPendientes(clienteActual.Cuit);

            if (guiasActuales == null ||
                !guiasActuales.Any())
            {
                MessageBox.Show(
                    "El cliente no posee guías pendientes de facturación.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                guiasEntregadasPendientesLST.Items.Clear();

                totalFacturarLBL.Text = "0,00";

                return;
            }

            // Cargo la grilla
            CargarGuias(guiasActuales);

            // Calculo total
            var total =
                modelo.CalcularTotal(guiasActuales);

            totalFacturarLBL.Text =
                total.ToString("N2");
        }
        // Evento del botón de emisión de factura
        private void emitirBTN_Click(object sender, EventArgs e)
        {
            if (modelo.GuiasActuales == null ||
                !modelo.GuiasActuales.Any())
            {
                MessageBox.Show(
                    "No existen guías pendientes para facturar.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            // Confirmación de emisión
            var confirmacion = MessageBox.Show(
                "¿Desea emitir la factura?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.No)
            {
                return;
            }
            // Emisión de la factura
            var factura =
                modelo.EmitirFactura(
                    clienteActual,
                    modelo.GuiasActuales);

            MessageBox.Show(
                $"Factura {factura.Numero} emitida correctamente.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarPantalla();
        }
        // Evento del botón de cancelación
        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            idClienteTXT.Clear();
            nombreClienteLBL.Text = string.Empty;
            guiasEntregadasPendientesLST.Items.Clear();
            totalFacturarLBL.Text = "0,00";
            idClienteTXT.Focus();
        }
        // Método para cargar las guías en la lista
        private void CargarGuias(
        List<GuiasAFacturar> guias)
        {
            guiasEntregadasPendientesLST.Items.Clear();

            foreach (var guia in guias)
            {
                ListViewItem item =
                    new ListViewItem(guia.Id);

                item.SubItems.Add(
                    guia.Fecha.ToShortDateString());

                item.SubItems.Add(
                    guia.Monto.ToString("N2"));

                guiasEntregadasPendientesLST.Items.Add(item);
            }
        }
        // Método para limpiar la pantalla después de emitir la factura
        private void LimpiarPantalla()
        {
            idClienteTXT.Clear();

            nombreClienteLBL.Text = string.Empty;

            totalFacturarLBL.Text = "0,00";

            guiasEntregadasPendientesLST.Items.Clear();

            clienteActual = null;

            modelo.GuiasActuales.Clear();
        }
    }
}
