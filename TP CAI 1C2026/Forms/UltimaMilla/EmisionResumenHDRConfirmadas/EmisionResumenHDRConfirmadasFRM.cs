using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDRConfirmadas
{
    public partial class EmisionResumenHDRConfirmadasFRM : Form
    {
        public EmisionResumenHDRConfirmadasFRM()
        {
            InitializeComponent();
            // Vincular el evento Click del botón GenerarResumenBTN al manejador
            GenerarResumenBTN.Click += GenerarResumenBTN_Click;
        }

        private void EmisionResumenHDRConfirmadasFRM_Load(object sender, EventArgs e)
        {

        }

        // Manejador del botón "Cancelar": cierra el formulario
        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void hdrEnTransitoLSVT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void hojasDeRutaEnTransitoLBL_Click(object sender, EventArgs e)
        {

        }

        private void dniFleteroLBL_Click(object sender, EventArgs e)
        {

        }

        private void buscarBTN_Click(object sender, EventArgs e)
        {
            // Obtener y validar texto de DNI desde el textbox
            var dniText = dniFleteroTXT.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(dniText))
            {
                MessageBox.Show("Ingrese DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentamos convertir el DNI a entero y validar longitud
            if (!int.TryParse(dniText, out int dniInt) || dniText.Length != 8)
            {
                MessageBox.Show("El DNI debe ser numérico y de 8 dígitos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var modelo = new EmisionResumenHDRConfirmadasModelo();

            // Buscar el fletero por DNI y mostrar su nombre
            var fletero = modelo.BuscarFletero(dniText);

            // Si no existe el fletero registrado, informar y no continuar
            if (fletero == null)
            {
                MessageBox.Show("No existe ningún fletero registrado con ese DNI.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nombreFleteroLBL.Text = "Nombre del Fletero";
                // Limpiar campo DNI y poner foco para corrección
                dniFleteroTXT.Clear();
                dniFleteroTXT.Focus();
                return;
            }

            // Mostrar nombre del fletero y obtener las HDRs asociadas
            nombreFleteroLBL.Text = fletero.Nombre;
            var hdrs = modelo.ObtenerHDRPorFletero(dniInt);

            // Limpiar elementos previos del ListView
            hdrEnTransitoLSVT.Items.Clear();

            // Si no hay HDRs asociadas mostrar mensaje informativo
            if (hdrs == null || hdrs.Count == 0)
            {
                // Mostrar mensaje solicitado por el usuario cuando no hay HDR en tránsito
                MessageBox.Show($"El DNI {dniText} no tiene hojas de rutas en transito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Limpiar campo DNI y label de fletero y poner foco para ingresar otro
                dniFleteroTXT.Clear();
                nombreFleteroLBL.Text = "Nombre del Fletero";
                dniFleteroTXT.Focus();
                return;
            }

            // Agregar cada HDR al ListView con checkbox habilitado por diseño
            foreach (var h in hdrs)
            {
                var item = new ListViewItem(h.NroHDR);
                item.SubItems.Add(h.Domicilio);
                item.SubItems.Add(h.CantEcomiendas);
                item.Checked = false; // por defecto no marcado
                hdrEnTransitoLSVT.Items.Add(item);
            }
        }

        // Al apretar "Generar Resumen de HDR Confirmadas" se deben tomar las HDR marcadas
        // y mostrar un MessageBox con las HDR seleccionadas (NroHDR, Domicilio, CantEcomiendas)
        // para el DNI ingresado. Si no hay seleccionadas, se muestra un mensaje de error.
        private void GenerarResumenBTN_Click(object? sender, EventArgs e)
        {
            // Si no se cargaron HDRs en el ListView (no se pulsó Buscar), avisar al usuario
            if (hdrEnTransitoLSVT.Items.Count == 0)
            {
                MessageBox.Show("Debe ingresar un DNI y presionar Buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Obtener DNI mostrado/en el textbox (se asume que ya fue validado al buscar)
            var dniText = dniFleteroTXT.Text?.Trim() ?? string.Empty;

            // Recolectar los ítems marcados en el ListView
            var seleccionadas = hdrEnTransitoLSVT.CheckedItems;

            // Si no hay ninguna seleccionada, avisar al usuario
            if (seleccionadas == null || seleccionadas.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una hoja de ruta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Construir el mensaje con las HDR seleccionadas
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Se confirmaron las siguientes Hojas de ruta para el DNI {dniText}:");
            sb.AppendLine();

            // Recorrer las seleccionadas y agregar sus datos al mensaje
            foreach (ListViewItem it in seleccionadas)
            {
                var nro = it.SubItems.Count > 0 ? it.SubItems[0].Text : string.Empty;
                var domicilio = it.SubItems.Count > 1 ? it.SubItems[1].Text : string.Empty;
                var cant = it.SubItems.Count > 2 ? it.SubItems[2].Text : string.Empty;

                sb.AppendLine($"- Nro HDR: {nro} | Domicilio: {domicilio} | Cant. Encomiendas: {cant}");
            }

            // Mostrar resumen al usuario
            MessageBox.Show(sb.ToString(), "Resumen HDR Confirmadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Al aceptar el resumen, limpiamos la pantalla para permitir ingresar un nuevo DNI.
            // Se limpia el ListView, el textbox de DNI y el label del nombre del fletero.
            hdrEnTransitoLSVT.Items.Clear();
            dniFleteroTXT.Clear();
            nombreFleteroLBL.Text = "Nombre del Fletero";
            dniFleteroTXT.Focus();
        }


    }
}
