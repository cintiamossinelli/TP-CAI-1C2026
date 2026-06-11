using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace TP_CAI_1C2026.Forms.Administracion.ResultadoCostoVentas
{
    public partial class ResultadoCostosVentasFRM : Form
    {
        private readonly ResultadoCostosVentasModelo modelo = new ResultadoCostosVentasModelo();

        public ResultadoCostosVentasFRM()
        {
            InitializeComponent();
        }

        private void ResultadoCostosVentasFRM_Load(object sender, EventArgs e)
        {

        }


        private void buscarBTN_Click(object sender, EventArgs e)
        {
            // Validar Mes
            if (!modelo.ValidarMes(mesTXT.Text, out string mensajeMes))
            {
                MessageBox.Show(mensajeMes, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mesTXT.Focus();
                return;
            }

            // Validar Año
            if (!modelo.ValidarAnio(anioTXT.Text, out string mensajeAnio))
            {
                MessageBox.Show(mensajeAnio, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                anioTXT.Focus();
                return;
            }

            // Si pasa validación, solicitar al modelo el resumen por empresa
            int mes = int.Parse(mesTXT.Text.Trim());
            int anio = int.Parse(anioTXT.Text.Trim());

            resultadosLST.Items.Clear();

            var resumen = modelo.ObtenerResumenPorEmpresa(mes, anio);
            var arCulture = new System.Globalization.CultureInfo("es-AR");

            if (resumen == null || resumen.Items == null || resumen.Items.Count == 0)
            {
                MessageBox.Show("No se encontraron envíos para el mes seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                totalCostosValorLBL.Text = 0m.ToString("C", arCulture);
                totalVentasValorLBL.Text = 0m.ToString("C", arCulture);
                resultadoTotalValorLBL.Text = 0m.ToString("C", arCulture);
                return;
            }

            foreach (var item in resumen.Items)
            {
                var lv = new ListViewItem(item.EmpresaTransporte);
                lv.SubItems.Add(item.Cantidad.ToString());
                lv.SubItems.Add(item.CostoTotal.ToString("C", arCulture));
                lv.SubItems.Add(item.VentasTotal.ToString("C", arCulture));
                lv.SubItems.Add(item.Resultado.ToString("C", arCulture));
                resultadosLST.Items.Add(lv);
            }

            totalCostosValorLBL.Text = resumen.TotalCostos.ToString("C", arCulture);
            totalVentasValorLBL.Text = resumen.TotalVentas.ToString("C", arCulture);
            resultadoTotalValorLBL.Text = resumen.TotalResultado.ToString("C", arCulture);
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            // Limpiar campos y resultados
            mesTXT.Text = string.Empty;
            anioTXT.Text = string.Empty;
            resultadosLST.Items.Clear();
            var arCulture = new System.Globalization.CultureInfo("es-AR");
            totalCostosValorLBL.Text = 0m.ToString("C", arCulture);
            totalVentasValorLBL.Text = 0m.ToString("C", arCulture);
            resultadoTotalValorLBL.Text = 0m.ToString("C", arCulture);
            mesTXT.Focus();
        }

        // Permitir solo dígitos y teclas de control (ej. backspace)
        private void mesTXT_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void anioTXT_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
