namespace TP_CAI_1C2026
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
            desdeLBL = new Label();
            desdeDTP = new DateTimePicker();
            hastaLBL = new Label();
            hastaDTP = new DateTimePicker();
            buscarBTN = new Button();
            resultadosLST = new ListView();
            colCliente = new ColumnHeader();
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
            totalCostosPanel.SuspendLayout();
            totalVentasPanel.SuspendLayout();
            resultadoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // desdeLBL
            // 
            desdeLBL.Location = new Point(12, 18);
            desdeLBL.Name = "desdeLBL";
            desdeLBL.Size = new Size(55, 23);
            desdeLBL.TabIndex = 0;
            desdeLBL.Text = "Desde:";
            desdeLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // desdeDTP
            // 
            desdeDTP.Format = DateTimePickerFormat.Short;
            desdeDTP.Location = new Point(72, 16);
            desdeDTP.Name = "desdeDTP";
            desdeDTP.Size = new Size(130, 23);
            desdeDTP.TabIndex = 1;
            // 
            // hastaLBL
            // 
            hastaLBL.Location = new Point(215, 18);
            hastaLBL.Name = "hastaLBL";
            hastaLBL.Size = new Size(45, 23);
            hastaLBL.TabIndex = 2;
            hastaLBL.Text = "Hasta:";
            hastaLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // hastaDTP
            // 
            hastaDTP.Format = DateTimePickerFormat.Short;
            hastaDTP.Location = new Point(265, 16);
            hastaDTP.Name = "hastaDTP";
            hastaDTP.Size = new Size(130, 23);
            hastaDTP.TabIndex = 3;
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(423, 14);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(80, 27);
            buscarBTN.TabIndex = 4;
            buscarBTN.Text = "Buscar";
            // 
            // resultadosLST
            // 
            resultadosLST.Columns.AddRange(new ColumnHeader[] { colCliente, colEnvios, colCostoTotal, colVentasTotal, colResultado });
            resultadosLST.FullRowSelect = true;
            resultadosLST.GridLines = true;
            resultadosLST.Location = new Point(12, 55);
            resultadosLST.Name = "resultadosLST";
            resultadosLST.Size = new Size(760, 300);
            resultadosLST.TabIndex = 5;
            resultadosLST.UseCompatibleStateImageBehavior = false;
            resultadosLST.View = View.Details;
            // 
            // colCliente
            // 
            colCliente.Text = "Cliente";
            colCliente.Width = 200;
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
            // 
            // ResultadoCostosVentasFRM
            // 
            ClientSize = new Size(784, 490);
            Controls.Add(desdeLBL);
            Controls.Add(desdeDTP);
            Controls.Add(hastaLBL);
            Controls.Add(hastaDTP);
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
        }

        private Label desdeLBL;
        private DateTimePicker desdeDTP;
        private Label hastaLBL;
        private DateTimePicker hastaDTP;
        private Button buscarBTN;
        private ListView resultadosLST;
        private ColumnHeader colCliente;
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
    }
}