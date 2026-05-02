namespace TP_CAI_1C2026
{
    partial class EmisionFacturaFRM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            totalLBL = new Label();
            emitirFacturaBTN = new Button();
            cancelarBTN = new Button();
            guiasEntregadasPendientesLST = new ListView();
            colNGuia = new ColumnHeader();
            colFecha = new ColumnHeader();
            colMonto = new ColumnHeader();
            totalFacturarLBL = new Label();
            nombreClienteLBL = new Label();
            idClienteLBL = new Label();
            idClienteTXT = new TextBox();
            buscarClienteBTN = new Button();
            seleccionarGuiasLBL = new Label();
            SuspendLayout();
            // 
            // totalLBL
            // 
            totalLBL.AutoSize = true;
            totalLBL.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalLBL.Location = new Point(438, 302);
            totalLBL.Name = "totalLBL";
            totalLBL.Size = new Size(52, 21);
            totalLBL.TabIndex = 3;
            totalLBL.Text = "Total:";
            totalLBL.Click += totalFacturarLBL_Click;
            // 
            // emitirFacturaBTN
            // 
            emitirFacturaBTN.Location = new Point(354, 358);
            emitirFacturaBTN.Name = "emitirFacturaBTN";
            emitirFacturaBTN.Size = new Size(96, 23);
            emitirFacturaBTN.TabIndex = 4;
            emitirFacturaBTN.Text = "Emitir Factura";
            emitirFacturaBTN.UseVisualStyleBackColor = true;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(456, 358);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(96, 23);
            cancelarBTN.TabIndex = 5;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.UseVisualStyleBackColor = true;
            // 
            // guiasEntregadasPendientesLST
            // 
            guiasEntregadasPendientesLST.CheckBoxes = true;
            guiasEntregadasPendientesLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colFecha, colMonto });
            guiasEntregadasPendientesLST.FullRowSelect = true;
            guiasEntregadasPendientesLST.GridLines = true;
            guiasEntregadasPendientesLST.Location = new Point(12, 112);
            guiasEntregadasPendientesLST.Name = "guiasEntregadasPendientesLST";
            guiasEntregadasPendientesLST.Size = new Size(540, 178);
            guiasEntregadasPendientesLST.TabIndex = 1;
            guiasEntregadasPendientesLST.UseCompatibleStateImageBehavior = false;
            guiasEntregadasPendientesLST.View = View.Details;
            guiasEntregadasPendientesLST.SelectedIndexChanged += guiasEntregadasPendientesLST_SelectedIndexChanged_1;
            // 
            // colNGuia
            // 
            colNGuia.Text = "N° Guía";
            colNGuia.Width = 150;
            // 
            // colFecha
            // 
            colFecha.Text = "Fecha";
            colFecha.TextAlign = HorizontalAlignment.Center;
            colFecha.Width = 200;
            // 
            // colMonto
            // 
            colMonto.Text = "Monto";
            colMonto.TextAlign = HorizontalAlignment.Center;
            colMonto.Width = 200;
            // 
            // totalFacturarLBL
            // 
            totalFacturarLBL.AutoSize = true;
            totalFacturarLBL.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalFacturarLBL.Location = new Point(496, 302);
            totalFacturarLBL.Name = "totalFacturarLBL";
            totalFacturarLBL.Size = new Size(61, 21);
            totalFacturarLBL.TabIndex = 8;
            totalFacturarLBL.Text = "monto";
            // 
            // nombreClienteLBL
            // 
            nombreClienteLBL.AutoSize = true;
            nombreClienteLBL.BackColor = SystemColors.ActiveCaption;
            nombreClienteLBL.Location = new Point(123, 57);
            nombreClienteLBL.Name = "nombreClienteLBL";
            nombreClienteLBL.Size = new Size(110, 15);
            nombreClienteLBL.TabIndex = 12;
            nombreClienteLBL.Text = "Nombre del Cliente";
            // 
            // idClienteLBL
            // 
            idClienteLBL.Location = new Point(12, 20);
            idClienteLBL.Name = "idClienteLBL";
            idClienteLBL.Size = new Size(105, 23);
            idClienteLBL.TabIndex = 9;
            idClienteLBL.Text = "CUIT / DNI / CUIL:";
            idClienteLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // idClienteTXT
            // 
            idClienteTXT.Location = new Point(123, 20);
            idClienteTXT.MaxLength = 11;
            idClienteTXT.Name = "idClienteTXT";
            idClienteTXT.Size = new Size(345, 23);
            idClienteTXT.TabIndex = 10;
            // 
            // buscarClienteBTN
            // 
            buscarClienteBTN.Location = new Point(473, 18);
            buscarClienteBTN.Name = "buscarClienteBTN";
            buscarClienteBTN.Size = new Size(79, 27);
            buscarClienteBTN.TabIndex = 11;
            buscarClienteBTN.Text = "Buscar Cliente";
            // 
            // seleccionarGuiasLBL
            // 
            seleccionarGuiasLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            seleccionarGuiasLBL.ForeColor = SystemColors.HotTrack;
            seleccionarGuiasLBL.Location = new Point(12, 86);
            seleccionarGuiasLBL.Name = "seleccionarGuiasLBL";
            seleccionarGuiasLBL.Size = new Size(164, 23);
            seleccionarGuiasLBL.TabIndex = 13;
            seleccionarGuiasLBL.Text = "Seleccione Guías a Facturar";
            seleccionarGuiasLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // EmisionFacturaFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 391);
            Controls.Add(seleccionarGuiasLBL);
            Controls.Add(guiasEntregadasPendientesLST);
            Controls.Add(nombreClienteLBL);
            Controls.Add(idClienteLBL);
            Controls.Add(idClienteTXT);
            Controls.Add(buscarClienteBTN);
            Controls.Add(totalFacturarLBL);
            Controls.Add(cancelarBTN);
            Controls.Add(emitirFacturaBTN);
            Controls.Add(totalLBL);
            Name = "EmisionFacturaFRM";
            Text = "Emisión de Factura";
            Load += EmisionFacturaFRM_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label totalLBL;
        private Button emitirFacturaBTN;
        private Button cancelarBTN;
        private ListView guiasEntregadasPendientesLST;
        private ColumnHeader colNGuia;
        private ColumnHeader colFecha;
        private ColumnHeader colMonto;
        private Label totalFacturarLBL;
        private Label nombreClienteLBL;
        private Label idClienteLBL;
        private TextBox idClienteTXT;
        private Button buscarClienteBTN;
        private Label seleccionarGuiasLBL;
    }
}