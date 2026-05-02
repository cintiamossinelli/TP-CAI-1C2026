namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDR
{
    partial class EmisionResumenHDRFRM
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
            fleteroLBL = new Label();
            hdrEntregarGBX = new GroupBox();
            hdrEntregarLST = new ListView();
            colNHdrEntregar = new ColumnHeader();
            colDomicilioEntregar = new ColumnHeader();
            colCantEntregar = new ColumnHeader();
            hdrRetirarGBX = new GroupBox();
            hdrRetirarLST = new ListView();
            colNHdrRetirar = new ColumnHeader();
            colDomicilioRetirar = new ColumnHeader();
            colCantRetirar = new ColumnHeader();
            generarResumenBTN = new Button();
            dniFleteroLBL = new Label();
            dniFleteroTXT = new TextBox();
            buscarFleteroBTN = new Button();
            nombreFleteroLBL = new Label();
            hdrRetirarLBL = new Label();
            hdrEntregarLBL = new Label();
            hdrEntregarGBX.SuspendLayout();
            hdrRetirarGBX.SuspendLayout();
            SuspendLayout();
            // 
            // fleteroLBL
            // 
            fleteroLBL.AutoSize = true;
            fleteroLBL.Location = new Point(13, 19);
            fleteroLBL.Name = "fleteroLBL";
            fleteroLBL.Size = new Size(0, 15);
            fleteroLBL.TabIndex = 0;
            fleteroLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // hdrEntregarGBX
            // 
            hdrEntregarGBX.Controls.Add(hdrEntregarLST);
            hdrEntregarGBX.Controls.Add(hdrEntregarLBL);
            hdrEntregarGBX.Enabled = false;
            hdrEntregarGBX.Location = new Point(10, 50);
            hdrEntregarGBX.Margin = new Padding(3, 2, 3, 2);
            hdrEntregarGBX.Name = "hdrEntregarGBX";
            hdrEntregarGBX.Padding = new Padding(3, 2, 3, 2);
            hdrEntregarGBX.Size = new Size(578, 164);
            hdrEntregarGBX.TabIndex = 2;
            hdrEntregarGBX.TabStop = false;
            hdrEntregarGBX.Text = "HDR a Entregar";
            // 
            // hdrEntregarLST
            // 
            hdrEntregarLST.CheckBoxes = true;
            hdrEntregarLST.Columns.AddRange(new ColumnHeader[] { colNHdrEntregar, colDomicilioEntregar, colCantEntregar });
            hdrEntregarLST.FullRowSelect = true;
            hdrEntregarLST.GridLines = true;
            hdrEntregarLST.Location = new Point(8, 46);
            hdrEntregarLST.Margin = new Padding(3, 2, 3, 2);
            hdrEntregarLST.Name = "hdrEntregarLST";
            hdrEntregarLST.Size = new Size(556, 114);
            hdrEntregarLST.TabIndex = 1;
            hdrEntregarLST.UseCompatibleStateImageBehavior = false;
            hdrEntregarLST.View = View.Details;
            // 
            // colNHdrEntregar
            // 
            colNHdrEntregar.Text = "N° HDR";
            colNHdrEntregar.Width = 120;
            // 
            // colDomicilioEntregar
            // 
            colDomicilioEntregar.Text = "Domicilio / Agencia";
            colDomicilioEntregar.TextAlign = HorizontalAlignment.Center;
            colDomicilioEntregar.Width = 350;
            // 
            // colCantEntregar
            // 
            colCantEntregar.Text = "Cant. Encomiendas";
            colCantEntregar.TextAlign = HorizontalAlignment.Center;
            colCantEntregar.Width = 160;
            // 
            // hdrRetirarGBX
            // 
            hdrRetirarGBX.Controls.Add(hdrRetirarLST);
            hdrRetirarGBX.Controls.Add(hdrRetirarLBL);
            hdrRetirarGBX.Enabled = false;
            hdrRetirarGBX.Location = new Point(10, 218);
            hdrRetirarGBX.Margin = new Padding(3, 2, 3, 2);
            hdrRetirarGBX.Name = "hdrRetirarGBX";
            hdrRetirarGBX.Padding = new Padding(3, 2, 3, 2);
            hdrRetirarGBX.Size = new Size(578, 162);
            hdrRetirarGBX.TabIndex = 3;
            hdrRetirarGBX.TabStop = false;
            hdrRetirarGBX.Text = "HDR a Retirar";
            // 
            // hdrRetirarLST
            // 
            hdrRetirarLST.CheckBoxes = true;
            hdrRetirarLST.Columns.AddRange(new ColumnHeader[] { colNHdrRetirar, colDomicilioRetirar, colCantRetirar });
            hdrRetirarLST.FullRowSelect = true;
            hdrRetirarLST.GridLines = true;
            hdrRetirarLST.Location = new Point(8, 46);
            hdrRetirarLST.Margin = new Padding(3, 2, 3, 2);
            hdrRetirarLST.Name = "hdrRetirarLST";
            hdrRetirarLST.Size = new Size(556, 111);
            hdrRetirarLST.TabIndex = 1;
            hdrRetirarLST.UseCompatibleStateImageBehavior = false;
            hdrRetirarLST.View = View.Details;
            // 
            // colNHdrRetirar
            // 
            colNHdrRetirar.Text = "N° HDR";
            colNHdrRetirar.Width = 120;
            // 
            // colDomicilioRetirar
            // 
            colDomicilioRetirar.Text = "Domicilio / Agencia";
            colDomicilioRetirar.TextAlign = HorizontalAlignment.Center;
            colDomicilioRetirar.Width = 350;
            // 
            // colCantRetirar
            // 
            colCantRetirar.Text = "Cant. Encomiendas";
            colCantRetirar.TextAlign = HorizontalAlignment.Center;
            colCantRetirar.Width = 160;
            // 
            // generarResumenBTN
            // 
            generarResumenBTN.Enabled = false;
            generarResumenBTN.Location = new Point(477, 385);
            generarResumenBTN.Margin = new Padding(3, 2, 3, 2);
            generarResumenBTN.Name = "generarResumenBTN";
            generarResumenBTN.Size = new Size(97, 22);
            generarResumenBTN.TabIndex = 2;
            generarResumenBTN.Text = "Generar";
            generarResumenBTN.UseVisualStyleBackColor = true;
            // 
            // dniFleteroLBL
            // 
            dniFleteroLBL.AutoSize = true;
            dniFleteroLBL.Location = new Point(17, 14);
            dniFleteroLBL.Name = "dniFleteroLBL";
            dniFleteroLBL.Size = new Size(69, 15);
            dniFleteroLBL.TabIndex = 5;
            dniFleteroLBL.Text = "DNI Fletero:";
            dniFleteroLBL.TextAlign = ContentAlignment.MiddleRight;
            dniFleteroLBL.Click += label1_Click;
            // 
            // dniFleteroTXT
            // 
            dniFleteroTXT.Location = new Point(126, 11);
            dniFleteroTXT.Margin = new Padding(3, 2, 3, 2);
            dniFleteroTXT.Name = "dniFleteroTXT";
            dniFleteroTXT.Size = new Size(138, 23);
            dniFleteroTXT.TabIndex = 6;
            // 
            // buscarFleteroBTN
            // 
            buscarFleteroBTN.Location = new Point(285, 11);
            buscarFleteroBTN.Margin = new Padding(3, 2, 3, 2);
            buscarFleteroBTN.Name = "buscarFleteroBTN";
            buscarFleteroBTN.Size = new Size(85, 22);
            buscarFleteroBTN.TabIndex = 7;
            buscarFleteroBTN.Text = "Buscar ";
            buscarFleteroBTN.UseVisualStyleBackColor = true;
            // 
            // nombreFleteroLBL
            // 
            nombreFleteroLBL.AutoSize = true;
            nombreFleteroLBL.BackColor = SystemColors.ActiveCaption;
            nombreFleteroLBL.Location = new Point(410, 16);
            nombreFleteroLBL.Name = "nombreFleteroLBL";
            nombreFleteroLBL.Size = new Size(109, 15);
            nombreFleteroLBL.TabIndex = 8;
            nombreFleteroLBL.Text = "Nombre del Fletero";
            // 
            // hdrRetirarLBL
            // 
            hdrRetirarLBL.AutoSize = true;
            hdrRetirarLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hdrRetirarLBL.ForeColor = SystemColors.HotTrack;
            hdrRetirarLBL.Location = new Point(8, 19);
            hdrRetirarLBL.Name = "hdrRetirarLBL";
            hdrRetirarLBL.Size = new Size(276, 15);
            hdrRetirarLBL.TabIndex = 0;
            hdrRetirarLBL.Text = "Seleccione HDR de retiro a incluir en el resumen";
            // 
            // hdrEntregarLBL
            // 
            hdrEntregarLBL.AutoSize = true;
            hdrEntregarLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hdrEntregarLBL.ForeColor = Color.Green;
            hdrEntregarLBL.Location = new Point(8, 20);
            hdrEntregarLBL.Name = "hdrEntregarLBL";
            hdrEntregarLBL.Size = new Size(288, 15);
            hdrEntregarLBL.TabIndex = 0;
            hdrEntregarLBL.Text = "Seleccione HDR de entrega a incluir en el resumen";
            hdrEntregarLBL.Click += hdrEntregarLBL_Click;
            // 
            // EmisionResumenHDRFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 435);
            Controls.Add(nombreFleteroLBL);
            Controls.Add(buscarFleteroBTN);
            Controls.Add(dniFleteroTXT);
            Controls.Add(dniFleteroLBL);
            Controls.Add(generarResumenBTN);
            Controls.Add(hdrRetirarGBX);
            Controls.Add(hdrEntregarGBX);
            Controls.Add(fleteroLBL);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EmisionResumenHDRFRM";
            Text = "Emisión de Resumen de HDR";
            hdrEntregarGBX.ResumeLayout(false);
            hdrEntregarGBX.PerformLayout();
            hdrRetirarGBX.ResumeLayout(false);
            hdrRetirarGBX.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label fleteroLBL;
        private GroupBox hdrEntregarGBX;
        private ListView hdrEntregarLST;
        private ColumnHeader colNHdrEntregar;
        private ColumnHeader colDomicilioEntregar;
        private ColumnHeader colCantEntregar;
        private GroupBox hdrRetirarGBX;
        private Button generarResumenBTN;
        private ListView hdrRetirarLST;
        private ColumnHeader colNHdrRetirar;
        private ColumnHeader colDomicilioRetirar;
        private ColumnHeader colCantRetirar;
        private Label dniFleteroLBL;
        private TextBox dniFleteroTXT;
        private Button buscarFleteroBTN;
        private Label nombreFleteroLBL;
        private Label hdrEntregarLBL;
        private Label hdrRetirarLBL;
    }
}