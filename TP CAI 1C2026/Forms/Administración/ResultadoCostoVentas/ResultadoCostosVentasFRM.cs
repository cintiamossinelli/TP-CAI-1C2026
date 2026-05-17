using System;
using System.Collections.Generic;
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
        private readonly CultureInfo _currencyCulture;

        public ResultadoCostosVentasFRM()
        {
            InitializeComponent();
            // Clonar la cultura actual y forzar el símbolo de moneda a '$'
            _currencyCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            _currencyCulture.NumberFormat = (NumberFormatInfo)_currencyCulture.NumberFormat.Clone();
            _currencyCulture.NumberFormat.CurrencySymbol = "$";
            // Asegurar que el símbolo de moneda aparezca delante del número
            _currencyCulture.NumberFormat.CurrencyPositivePattern = 0; // $n
            _currencyCulture.NumberFormat.CurrencyNegativePattern = 0; // ($n)
        }

        private void ResultadoCostosVentasFRM_Load(object sender, EventArgs e)
        {

        }

        private void ResultadoCostosVentasFRM_Load_1(object sender, EventArgs e)
        {

        }

        private void buscarBTN_Click(object sender, EventArgs e)
        {
            // Obtener datos de prueba desde el modelo (se pueden reemplazar por la fuente real)
            if (!int.TryParse(mesTXT.Text, out var mes))
            {
                MessageBox.Show("Mes inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar rango del mes antes de chequear año para que el error de mes tenga prioridad
            if (mes < 1 || mes > 12)
            {
                MessageBox.Show("El mes debe ser un número entre 1 y 12.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(anioTXT.Text, out var anio))
            {
                MessageBox.Show("Año inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosPrueba = ResultadoCostosVentasModelo.ObtenerDatosPrueba(mes, anio);

            if (!ResultadoCostosVentasModelo.TryCrearDesdeInputs(mesTXT.Text, anioTXT.Text, datosPrueba, out var modelo, out var err))
            {
                MessageBox.Show(err, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Poblar listview
            resultadosLST.Items.Clear();
            foreach (var emp in modelo.Empresas)
            {
                var lvi = new ListViewItem(emp.EmpresaTransporte);
                lvi.SubItems.Add(emp.CantidadEnvios.ToString());
                lvi.SubItems.Add(emp.CostoTotal.ToString("C", _currencyCulture));
                lvi.SubItems.Add(emp.VentasTotales.ToString("C", _currencyCulture));
                lvi.SubItems.Add(emp.Resultado.ToString("C", _currencyCulture));
                resultadosLST.Items.Add(lvi);
            }

            totalCostosValorLBL.Text = modelo.TotalCostos.ToString("C", _currencyCulture);
            totalVentasValorLBL.Text = modelo.TotalVentas.ToString("C", _currencyCulture);
            resultadoTotalValorLBL.Text = modelo.ResultadoTotal.ToString("C", _currencyCulture);
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            // En lugar de cerrar, limpiar todos los campos y dejar el formulario listo para reusar
            ResetForm();
        }

        private void ResetForm()
        {
            // Limpiar inputs
            mesTXT.Text = string.Empty;
            anioTXT.Text = string.Empty;

            // Limpiar resultados
            resultadosLST.Items.Clear();

            // Resetear totales
            totalCostosValorLBL.Text = 0m.ToString("C", _currencyCulture);
            totalVentasValorLBL.Text = 0m.ToString("C", _currencyCulture);
            resultadoTotalValorLBL.Text = 0m.ToString("C", _currencyCulture);

            // Dejar el foco en el primer campo
            mesTXT.Focus();
        }

        // Permitir sólo dígitos y teclas de control
        private void mesTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void anioTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Evitar pegar texto no numérico con Ctrl+V
        private void mesTXT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                var tb = sender as TextBox;
                if (Clipboard.ContainsText())
                {
                    var txt = Clipboard.GetText();
                    if (!txt.All(char.IsDigit))
                    {
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }

        private void anioTXT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                var tb = sender as TextBox;
                if (Clipboard.ContainsText())
                {
                    var txt = Clipboard.GetText();
                    if (!txt.All(char.IsDigit))
                    {
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }
    }
}
