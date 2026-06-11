namespace TP_CAI_1C2026.Forms.Administracion.ResultadoCostoVentas
{
    partial class ResultadoCostosVentasFRM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mesLBL = new Label();
            mesTXT = new TextBox();
            anioLBL = new Label();
            anioTXT = new TextBox();
            buscarBTN = new Button();
            resultadosLST = new ListView();
            colEmpresaTransporte = new ColumnHeader();
            colEnvios = new ColumnHeader();
            colCostoTotal = new ColumnHeader();
            colVentasTotal = new ColumnHeader();
            colResultado = new ColumnHeader();
            totalCostosPanel = new Panel();
            totalCostosLBL = new Label();
            totalCostosValorLBL = new Label();
            totalVentasPanel = new Panel();
            totalVentasLBL = new Label();
            totalVentasValorLBL = new Label();
            resultadoPanel = new Panel();
            resultadoTotalLBL = new Label();
            resultadoTotalValorLBL = new Label();
            cancelarBTN = new Button();
            avisoMesLBL = new Label();
            totalCostosPanel.SuspendLayout();
            totalVentasPanel.SuspendLayout();
            resultadoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mesLBL
            // 
            mesLBL.Location = new Point(12, 17);
            mesLBL.Name = "mesLBL";
            mesLBL.Size = new Size(34, 23);
            mesLBL.TabIndex = 0;
            mesLBL.Text = "Mes:";
            mesLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // mesTXT
            // 
            mesTXT.Location = new Point(49, 16);
            mesTXT.MaxLength = 2;
            mesTXT.Name = "mesTXT";
            mesTXT.KeyPress += mesTXT_KeyPress;
            mesTXT.Size = new Size(141, 23);
            mesTXT.TabIndex = 1;
            // 
            // anioLBL
            // 
            anioLBL.Location = new Point(196, 17);
            anioLBL.Name = "anioLBL";
            anioLBL.Size = new Size(40, 23);
            anioLBL.TabIndex = 2;
            anioLBL.Text = "Año:";
            anioLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // anioTXT
            // 
            anioTXT.Location = new Point(242, 15);
            anioTXT.MaxLength = 4;
            anioTXT.Name = "anioTXT";
            anioTXT.KeyPress += anioTXT_KeyPress;
            anioTXT.Size = new Size(141, 23);
            anioTXT.TabIndex = 3;
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(407, 12);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(100, 27);
            buscarBTN.TabIndex = 4;
            buscarBTN.Text = "Buscar";
            buscarBTN.Click += buscarBTN_Click;
            // 
            // resultadosLST
            // 
            resultadosLST.Columns.AddRange(new ColumnHeader[] { colEmpresaTransporte, colEnvios, colCostoTotal, colVentasTotal, colResultado });
            resultadosLST.FullRowSelect = true;
            resultadosLST.GridLines = true;
            resultadosLST.Location = new Point(12, 58);
            resultadosLST.Name = "resultadosLST";
            resultadosLST.Size = new Size(760, 300);
            resultadosLST.TabIndex = 5;
            resultadosLST.UseCompatibleStateImageBehavior = false;
            resultadosLST.View = View.Details;
            // 
            // colEmpresaTransporte
            // 
            colEmpresaTransporte.Text = "Empresa de Transporte";
            colEmpresaTransporte.Width = 200;
            // 
            // colEnvios
            // 
            colEnvios.Text = "Cant. Envíos";
            colEnvios.Width = 100;
            // 
            // colCostoTotal
            // 
            colCostoTotal.Text = "Costo Total";
            colCostoTotal.Width = 150;
            // 
            // colVentasTotal
            // 
            colVentasTotal.Text = "Ventas Total";
            colVentasTotal.Width = 150;
            // 
            // colResultado
            // 
            colResultado.Text = "Resultado";
            colResultado.Width = 150;
            // 
            // totalCostosPanel
            // 
            totalCostosPanel.BorderStyle = BorderStyle.FixedSingle;
            totalCostosPanel.Controls.Add(totalCostosLBL);
            totalCostosPanel.Controls.Add(totalCostosValorLBL);
            totalCostosPanel.Location = new Point(12, 370);
            totalCostosPanel.Name = "totalCostosPanel";
            totalCostosPanel.Size = new Size(230, 55);
            totalCostosPanel.TabIndex = 6;
            // 
            // totalCostosLBL
            // 
            totalCostosLBL.Location = new Point(5, 5);
            totalCostosLBL.Name = "totalCostosLBL";
            totalCostosLBL.Size = new Size(220, 20);
            totalCostosLBL.TabIndex = 0;
            totalCostosLBL.Text = "Total Costos";
            totalCostosLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // totalCostosValorLBL
            // 
            totalCostosValorLBL.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            totalCostosValorLBL.Location = new Point(5, 25);
            totalCostosValorLBL.Name = "totalCostosValorLBL";
            totalCostosValorLBL.Size = new Size(220, 25);
            totalCostosValorLBL.TabIndex = 1;
            totalCostosValorLBL.Text = "$ 0,00";
            totalCostosValorLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // totalVentasPanel
            // 
            totalVentasPanel.BorderStyle = BorderStyle.FixedSingle;
            totalVentasPanel.Controls.Add(totalVentasLBL);
            totalVentasPanel.Controls.Add(totalVentasValorLBL);
            totalVentasPanel.Location = new Point(277, 370);
            totalVentasPanel.Name = "totalVentasPanel";
            totalVentasPanel.Size = new Size(230, 55);
            totalVentasPanel.TabIndex = 7;
            // 
            // totalVentasLBL
            // 
            totalVentasLBL.Location = new Point(5, 5);
            totalVentasLBL.Name = "totalVentasLBL";
            totalVentasLBL.Size = new Size(220, 20);
            totalVentasLBL.TabIndex = 0;
            totalVentasLBL.Text = "Total Ventas";
            totalVentasLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // totalVentasValorLBL
            // 
            totalVentasValorLBL.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            totalVentasValorLBL.Location = new Point(5, 25);
            totalVentasValorLBL.Name = "totalVentasValorLBL";
            totalVentasValorLBL.Size = new Size(220, 25);
            totalVentasValorLBL.TabIndex = 1;
            totalVentasValorLBL.Text = "$ 0,00";
            totalVentasValorLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // resultadoPanel
            // 
            resultadoPanel.BorderStyle = BorderStyle.FixedSingle;
            resultadoPanel.Controls.Add(resultadoTotalLBL);
            resultadoPanel.Controls.Add(resultadoTotalValorLBL);
            resultadoPanel.Location = new Point(542, 370);
            resultadoPanel.Name = "resultadoPanel";
            resultadoPanel.Size = new Size(230, 55);
            resultadoPanel.TabIndex = 8;
            // 
            // resultadoTotalLBL
            // 
            resultadoTotalLBL.Location = new Point(5, 5);
            resultadoTotalLBL.Name = "resultadoTotalLBL";
            resultadoTotalLBL.Size = new Size(220, 20);
            resultadoTotalLBL.TabIndex = 0;
            resultadoTotalLBL.Text = "Resultado";
            resultadoTotalLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // resultadoTotalValorLBL
            // 
            resultadoTotalValorLBL.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            resultadoTotalValorLBL.Location = new Point(5, 25);
            resultadoTotalValorLBL.Name = "resultadoTotalValorLBL";
            resultadoTotalValorLBL.Size = new Size(220, 25);
            resultadoTotalValorLBL.TabIndex = 1;
            resultadoTotalValorLBL.Text = "$ 0,00";
            resultadoTotalValorLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(692, 440);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 9;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // avisoMesLBL
            // 
            avisoMesLBL.AutoSize = true;
            avisoMesLBL.Location = new Point(10, 39);
            avisoMesLBL.Name = "avisoMesLBL";
            avisoMesLBL.Size = new Size(190, 15);
            avisoMesLBL.TabIndex = 10;
            avisoMesLBL.Text = "(Debe ingresar el mes en números)";
            // 
            // ResultadoCostosVentasFRM
            // 
            ClientSize = new Size(784, 490);
            Controls.Add(avisoMesLBL);
            Controls.Add(mesLBL);
            Controls.Add(mesTXT);
            Controls.Add(anioLBL);
            Controls.Add(anioTXT);
            Controls.Add(buscarBTN);
            Controls.Add(resultadosLST);
            Controls.Add(totalCostosPanel);
            Controls.Add(totalVentasPanel);
            Controls.Add(resultadoPanel);
            Controls.Add(cancelarBTN);
            Name = "ResultadoCostosVentasFRM";
            Text = "Resultado de Costos vs Ventas";
            totalCostosPanel.ResumeLayout(false);
            totalVentasPanel.ResumeLayout(false);
            resultadoPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label mesLBL;
        private TextBox mesTXT;
        private Label anioLBL;
        private TextBox anioTXT;
        private Button buscarBTN;
        private ListView resultadosLST;
        private ColumnHeader colEmpresaTransporte;
        private ColumnHeader colEnvios;
        private ColumnHeader colCostoTotal;
        private ColumnHeader colVentasTotal;
        private ColumnHeader colResultado;
        private Panel totalCostosPanel;
        private Label totalCostosLBL;
        private Label totalCostosValorLBL;
        private Panel totalVentasPanel;
        private Label totalVentasLBL;
        private Label totalVentasValorLBL;
        private Panel resultadoPanel;
        private Label resultadoTotalLBL;
        private Label resultadoTotalValorLBL;
        private Button cancelarBTN;
        private Label avisoMesLBL;
    }
}