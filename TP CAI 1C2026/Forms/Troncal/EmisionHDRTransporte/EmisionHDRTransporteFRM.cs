using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte
{
    public partial class EmisionHDRTransporteFRM : Form
    {
        private EmisionHDRTransporteModelo _modelo;

        public EmisionHDRTransporteFRM()
        {
            InitializeComponent();
            _modelo = new EmisionHDRTransporteModelo();
            CargarDatosIniciales();
            CDdestinoCMB.SelectedIndex = -1;
            transporteCMB.SelectedIndex = -1;
            // Inicialmente el GroupBox de Transportes visible para permitir ingresar filtros,
            // pero la lista de resultados permanece deshabilitada hasta ejecutar la búsqueda
            transporteGBX.Enabled = true;
            transportesLST.Enabled = false;
            guiasGBX.Enabled = false;

            // Wire up selection changed para habilitar la sección de guías cuando se seleccione un transporte
            transportesLST.SelectedIndexChanged += transportesLST_SelectedIndexChanged;
        }

        private void CargarDatosIniciales()
        {
            try
            {
                var centros = _modelo.ObtenerCentrosDeDistribucion();
                CDdestinoCMB.DisplayMember = "Nombre";
                CDdestinoCMB.ValueMember = "Id";
                CDdestinoCMB.DataSource = centros;

                var empresas = _modelo.ObtenerEmpresasTransporte();
                transporteCMB.DisplayMember = "Nombre";
                transporteCMB.ValueMember = "Id";
                transporteCMB.DataSource = empresas;

                // Las guías se cargarán cuando el usuario seleccione un transporte (ver caso de uso)
                // CargarGuiasDisponibles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando datos iniciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGuiasDisponibles()
        {
            GuiasLST.Items.Clear();
            var destino = CDdestinoCMB.SelectedItem as CentroDeDistribucion;
            if (destino == null) return;

            var guias = _modelo.ObtenerGuiasDisponibles()
                .Where(g => g.Destino.Id == destino.Id)
                .ToList();

            foreach (var g in guias)
            {
                var lvi = new ListViewItem(g.TipoEncomienda);
                lvi.SubItems.Add(g.DestinoTexto);
                lvi.SubItems.Add(g.NumeroGuia);
                lvi.Tag = g;
                GuiasLST.Items.Add(lvi);
            }
        }

        private void buscarFechaBTN_Click(object? sender, EventArgs e)
        {
            var destino = CDdestinoCMB.SelectedItem as CentroDeDistribucion;
            var empresa = transporteCMB.SelectedItem as EmpresaTransporte;
            var fecha = fechaDTP.Value.Date;

            //Validacion fecha correcta
            DateTime fechaControl = fechaDTP.Value.Date;
            DateTime hoy = DateTime.Today;

            if (fechaControl < hoy)
            {

                MessageBox.Show("La fecha  debe ser igual a hoy o posterior.");
                fechaDTP.Focus();
                return;
            }

            var transportes = _modelo.BuscarTransportes(fecha, empresa, destino);

            transportesLST.Items.Clear();
            foreach (var t in transportes)
            {
                var lvi = new ListViewItem(t.Fecha.ToShortDateString());
                lvi.SubItems.Add(t.HoraTexto);
                lvi.SubItems.Add(t.EmpresaTexto);
                lvi.SubItems.Add(t.DestinoTexto);
                lvi.Tag = t;
                transportesLST.Items.Add(lvi);
            }

            // Habilitar la lista de transportes si hay resultados
            transportesLST.Enabled = transportes.Any();
            if (!transportes.Any())
            {
                guiasGBX.Enabled = false;
            }
            
        }

        private void transportesLST_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Cuando el usuario selecciona un transporte, habilitar la sección de guías y cargar guías del CD destino
            if (transportesLST.SelectedItems.Count > 0)
            {
                guiasGBX.Enabled = true;
                CargarGuiasDisponibles();
            }
            else
            {
                guiasGBX.Enabled = false;
            }
        }

        private void buscarGuiaBTN_Click(object? sender, EventArgs e)
        {
            var destino = CDdestinoCMB.SelectedItem as CentroDeDistribucion;
            var numero = nGuiaTXT.Text ?? string.Empty;

            // Si no se ingresó texto, recargar todas las guías del CD
            if (string.IsNullOrWhiteSpace(numero))
            {
                CargarGuiasDisponibles();
                return;
            }

            var matches = _modelo.BuscarGuiasPorNumero(numero, destino);
            // Mostrar solo los resultados coincidentes en GuiasLST
            GuiasLST.Items.Clear();
            foreach (var g in matches)
            {
                var lvi = new ListViewItem(g.TipoEncomienda);
                lvi.SubItems.Add(g.DestinoTexto);
                lvi.SubItems.Add(g.NumeroGuia);
                lvi.Tag = g;
                GuiasLST.Items.Add(lvi);
            }
        }

        private void agregarBTN_Click(object? sender, EventArgs e)
        {
            // Mover guías seleccionadas de GuiasLST a guiasAgregadasLST usando el modelo
            var seleccionadas = GuiasLST.CheckedItems.Cast<ListViewItem>().Select(i => i.Tag as GuiaEncomienda).Where(g => g != null).ToList();

            var agregadas = _modelo.AgregarGuias(seleccionadas);
            if (!agregadas.Any())
            {
                // El mensaje se muestra desde el modelo cuando la colección está vacía
                return;
            }

            foreach (var g in agregadas)
            {
                // actualizar UI: quitar de GuiasLST y agregar a guiasAgregadasLST
                var toRemove = GuiasLST.Items.Cast<ListViewItem>().FirstOrDefault(i => i.SubItems[2].Text == g.NumeroGuia);
                if (toRemove != null) GuiasLST.Items.Remove(toRemove);

                var lvi = new ListViewItem(g.NumeroGuia);
                lvi.SubItems.Add(g.TipoEncomienda);
                lvi.SubItems.Add(g.DestinoTexto);
                lvi.Tag = g;
                guiasAgregadasLST.Items.Add(lvi);
            }

            // Limpiar el campo de búsqueda y volver a mostrar todas las guías del Centro seleccionado
            nGuiaTXT.Text = string.Empty;
            CargarGuiasDisponibles();
        }

        private void quitarBTN_Click(object? sender, EventArgs e)
        {
            // Preparar lista de guías a quitar desde checked o selected
            var seleccionadas = new List<GuiaEncomienda>();
            if (guiasAgregadasLST.CheckedItems.Count > 0)
            {
                seleccionadas.AddRange(guiasAgregadasLST.CheckedItems.Cast<ListViewItem>().Select(i => i.Tag as GuiaEncomienda).Where(g => g != null)!);
            }
            else
            {
                seleccionadas.AddRange(guiasAgregadasLST.SelectedItems.Cast<ListViewItem>().Select(i => i.Tag as GuiaEncomienda).Where(g => g != null)!);
            }

            var quitadas = _modelo.QuitarGuias(seleccionadas);
            if (!quitadas.Any())
            {
                // El modelo muestra el mensaje si la colección está vacía
                return;
            }

            // Actualizar UI: eliminar del listview derecho y volver a agregar al izquierdo
            foreach (var q in quitadas)
            {
                var toRemove = guiasAgregadasLST.Items.Cast<ListViewItem>().FirstOrDefault(i => (i.Tag as GuiaEncomienda)?.NumeroGuia == q.NumeroGuia);
                if (toRemove != null) guiasAgregadasLST.Items.Remove(toRemove);

                var lvi = new ListViewItem(q.TipoEncomienda);
                lvi.SubItems.Add(q.DestinoTexto);
                lvi.SubItems.Add(q.NumeroGuia);
                lvi.Tag = q;
                GuiasLST.Items.Add(lvi);
            }
        }

        private void generarHDRBTN_Click(object? sender, EventArgs e)
        {
            var destino = CDdestinoCMB.SelectedItem as CentroDeDistribucion;
            var transporte = transportesLST.SelectedItems.Cast<ListViewItem>().FirstOrDefault()?.Tag as Transporte;
            // Validar que el CD seleccionado coincida con los transportes y guías que están en los ListView
            var transportesEnLista = transportesLST.Items.Cast<ListViewItem>().Select(i => i.Tag as Transporte).Where(t => t != null).ToList();
            var guiasEnLista = guiasAgregadasLST.Items.Cast<ListViewItem>().Select(i => i.Tag as GuiaEncomienda).Where(g => g != null).ToList();

            if (!_modelo.ValidarCentrosEnListas(destino, transportesEnLista, guiasEnLista))
            {
                return;
            }

            var hdr = _modelo.GenerarHDR(destino, transporte);
            if (hdr != null)
            {
                MessageBox.Show($"HDR generado: {hdr.Id}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Después de mostrar el mensaje, limpiar todos los campos y dejar el formulario listo
                ResetForm();
            }
        }

        private void cancelarBTN_Click(object? sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            // Re-inicializar el modelo y recargar datos
            _modelo = new EmisionHDRTransporteModelo();
            CargarDatosIniciales();

            // Limpiar y resetear controles
            nGuiaTXT.Text = string.Empty;
            GuiasLST.Items.Clear();
            guiasAgregadasLST.Items.Clear();
            transportesLST.Items.Clear();

            // Dejar los combobox sin selección y fecha al día
            CDdestinoCMB.SelectedIndex = -1;
            transporteCMB.SelectedIndex = -1;
            fechaDTP.Value = DateTime.Today;

            // Estados iniciales de habilitación
            transporteGBX.Enabled = true;
            transportesLST.Enabled = false;
            guiasGBX.Enabled = false;
        }

        private void fechaDTP_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
