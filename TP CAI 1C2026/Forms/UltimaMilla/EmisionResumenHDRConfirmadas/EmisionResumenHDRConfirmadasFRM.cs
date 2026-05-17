using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDRConfirmadas;

namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDRConfirmadas
{
    public partial class EmisionResumenHDRConfirmadasFRM : Form
    {
        private readonly EmisionResumenHDRConfirmadasModelo modelo = new EmisionResumenHDRConfirmadasModelo();
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
            
            hdrEnTransitoLSVT.Items.Clear();
            dniFleteroTXT.Clear();
            nombreFleteroLBL.Text = "Nombre del Fletero";
            dniFleteroTXT.Focus();

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

        private void buscarBTN_Click_1(object sender, EventArgs e)
        {
            // Obtener y validar texto de DNI desde el textbox
            var dniText = dniFleteroTXT.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(dniText))
            {
                MessageBox.Show("Ingrese DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Intentamos convertir el DNI a entero y validar longitud
            if (!int.TryParse(dniText, out int dniInt) || dniText.Length != 8)
            {
                MessageBox.Show("El DNI debe ser numérico y de 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Buscar el fletero por DNI y mostrar su nombre
            var fletero = modelo.BuscarFletero(dniText);

            // Si no existe el fletero registrado, informar y no continuar
            if (fletero == null)
            {
                MessageBox.Show("No existe ningún fletero registrado con ese DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                item.SubItems.Add(h.CantEcomiendas.ToString());
                item.Checked = false; // por defecto no marcado
                // Guardamos el objeto HDREnTransito en Tag para poder actualizar su Estado más tarde
                item.Tag = h;
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
                MessageBox.Show("Debe ingresar un DNI y presionar Buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validar que el DNI ingresado pertenezca a las HDRs mostradas en el ListView
            if (!int.TryParse(dniFleteroTXT.Text?.Trim() ?? string.Empty, out int dniIngresado))
            {
                MessageBox.Show("El DNI ingresado no es válido. Actualice el DNI del Fletero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Limpiar pantalla
                hdrEnTransitoLSVT.Items.Clear();
                dniFleteroTXT.Clear();
                nombreFleteroLBL.Text = "Nombre del Fletero";
                dniFleteroTXT.Focus();
                return;
            }

            // Comprobar que al menos un item mostrado pertenece al DNI ingresado
            bool pertenece = false;
            foreach (ListViewItem it in hdrEnTransitoLSVT.Items)
            {
                if (it.Tag is HDREnTransito hd && hd.DniFletero == dniIngresado)
                {
                    pertenece = true;
                    break;
                }
            }

            if (!pertenece)
            {
                MessageBox.Show("El DNI ingresado no pertenece a las hojas de ruta mostradas. Por favor actualice el DNI del Fletero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Limpiar pantalla
                hdrEnTransitoLSVT.Items.Clear();
                dniFleteroTXT.Clear();
                nombreFleteroLBL.Text = "Nombre del Fletero";
                dniFleteroTXT.Focus();
                return;
            }
            // Obtener DNI mostrado/en el textbox (se asume que ya fue validado al buscar)
            var dniText = dniFleteroTXT.Text?.Trim() ?? string.Empty;

            // Recolectar los ítems marcados en el ListView
            var seleccionadas = hdrEnTransitoLSVT.CheckedItems;

          
            // Construir el mensaje con las HDR seleccionadas
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Resumen Hojas de ruta para el DNI {dniText}:\n");
            sb.AppendLine("Confirmadas:");

            // Recorrer las seleccionadas y agregar sus datos al mensaje
            foreach (ListViewItem it in seleccionadas)
            {
                var nro = it.SubItems.Count > 0 ? it.SubItems[0].Text : string.Empty;
                var domicilio = it.SubItems.Count > 1 ? it.SubItems[1].Text : string.Empty;
                var cant = it.SubItems.Count > 2 ? it.SubItems[2].Text : string.Empty;

                sb.AppendLine($"- Nro HDR: {nro} | Domicilio: {domicilio} | Cant. Encomiendas: {cant}");
            }

            // Incluir también las HDR que están sin marcar bajo el título "Hojas de rutas admitidas"
            var noSeleccionadas = new List<ListViewItem>();
            foreach (ListViewItem it in hdrEnTransitoLSVT.Items)
            {
                if (!it.Checked)
                    noSeleccionadas.Add(it);
            }

            if (noSeleccionadas.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine("No Confirmadas:");
                foreach (var it in noSeleccionadas)
                {
                    var nro = it.SubItems.Count > 0 ? it.SubItems[0].Text : string.Empty;
                    var domicilio = it.SubItems.Count > 1 ? it.SubItems[1].Text : string.Empty;
                    var cant = it.SubItems.Count > 2 ? it.SubItems[2].Text : string.Empty;
                    sb.AppendLine($"- Nro HDR: {nro} | Domicilio: {domicilio} | Cant. Encomiendas: {cant}");
                }
            }

            // Mostrar resumen al usuario y obtener el resultado del MessageBox
            var result = MessageBox.Show(sb.ToString(), "Resumen HDR Confirmadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Si el usuario acepta (OK), actualizar el estado de las HDR en el modelo
            if (result == DialogResult.OK)
            {
                // Actualizar estados: los checados -> "Confirmada", los no checados -> "Admitida"
                foreach (ListViewItem it in hdrEnTransitoLSVT.Items)
                {
                    if (it.Tag is HDREnTransito hd)
                    {
                        if (it.Checked)
                        {
                            hd.Estado = "Confirmada";
                        }
                        else
                        {
                            hd.Estado = "No Confirmada";
                        }
                    }
                }

                // Limpiar la pantalla tras la confirmación
                hdrEnTransitoLSVT.Items.Clear();
                dniFleteroTXT.Clear();
                nombreFleteroLBL.Text = "Nombre del Fletero";
                dniFleteroTXT.Focus();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

