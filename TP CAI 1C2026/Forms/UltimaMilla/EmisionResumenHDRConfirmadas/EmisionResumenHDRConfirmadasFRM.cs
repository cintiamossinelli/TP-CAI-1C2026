using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Linq;
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

        // Manejador del botón "Cancelar": cierra el formulario
        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            
            hdrEnTransitoLSVT.Items.Clear();
            dniFleteroTXT.Clear();
            nombreFleteroLBL.Text = "Nombre del Fletero";
            dniFleteroTXT.Focus();

        }

        private void buscarBTN_Click_1(object sender, EventArgs e)
        {

            var dniText = dniFleteroTXT.Text?.Trim() ?? string.Empty;

            if (!modelo.TryBuscarFletero(dniText, out var fletero, out string mensaje))
            {
                MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nombreFleteroLBL.Text = "Nombre del Fletero";
                dniFleteroTXT.Clear();
                dniFleteroTXT.Focus();
                return;
            }

            nombreFleteroLBL.Text = fletero.Nombre;
            var hdrs = modelo.ObtenerHDRPorFletero(int.Parse(dniText));

            hdrEnTransitoLSVT.Items.Clear();

            if (hdrs == null || hdrs.Count == 0)
            {
                MessageBox.Show($"El DNI {dniText} no tiene hojas de rutas en transito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dniFleteroTXT.Clear();
                nombreFleteroLBL.Text = "Nombre del Fletero";
                dniFleteroTXT.Focus();
                return;
            }

            foreach (var h in hdrs)
            {
                var item = new ListViewItem(h.NroHDR);
                item.SubItems.Add(h.Domicilio);
                item.SubItems.Add(h.CantEcomiendas.ToString());
                item.Checked = false;
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

            // Obtener DNI mostrado/en el textbox (se asume que ya fue validado al buscar)
            var dniText = dniFleteroTXT.Text?.Trim() ?? string.Empty;

            // Crear listas de HDRs a partir de los items del ListView
            var todasHdrs = new List<HDREnTransito>();
            foreach (ListViewItem it in hdrEnTransitoLSVT.Items)
            {
                if (it.Tag is HDREnTransito hd)
                    todasHdrs.Add(hd);
            }

            // Verificar que al menos una HDR pertenezca al DNI ingresado
            if (!modelo.HDRsPertenecenADni(todasHdrs, dniIngresado))
            {
                MessageBox.Show("El DNI ingresado no pertenece a las hojas de ruta mostradas. Por favor actualice el DNI del Fletero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hdrEnTransitoLSVT.Items.Clear();
                dniFleteroTXT.Clear();
                nombreFleteroLBL.Text = "Nombre del Fletero";
                dniFleteroTXT.Focus();
                return;
            }

            var seleccionadasHdrs = new List<HDREnTransito>();
            var noSeleccionadasHdrs = new List<HDREnTransito>();

            foreach (ListViewItem it in hdrEnTransitoLSVT.Items)
            {
                if (it.Tag is HDREnTransito hd)
                {
                    if (it.Checked)
                        seleccionadasHdrs.Add(hd);
                    else
                        noSeleccionadasHdrs.Add(hd);
                }
            }

            if (noSeleccionadasHdrs.Any(hdr =>
                hdr.TipoHDR == "Entrega" &&
                hdr.EsEntregaEnAgencia))
            {
                MessageBox.Show(
                    "Las HDR de entrega en agencia deben estar marcadas.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var resumenTexto = modelo.ConstruirResumen(seleccionadasHdrs, noSeleccionadasHdrs, dniText);
            var result = MessageBox.Show(resumenTexto, "Resumen HDR Confirmadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                modelo.ActualizarEstados(seleccionadasHdrs, noSeleccionadasHdrs, dniIngresado);

                hdrEnTransitoLSVT.Items.Clear();
                dniFleteroTXT.Clear();
                nombreFleteroLBL.Text = "Nombre del Fletero";
                dniFleteroTXT.Focus();
            }
        }
    }
}

