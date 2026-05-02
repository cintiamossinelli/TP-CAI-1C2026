namespace TP_CAI_1C2026.Forms
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
            hdrEntregarLBL = new Label();
            hdrRetirarGBX = new GroupBox();
            hdrRetirarLST = new ListView();
            colNHdrRetirar = new ColumnHeader();
            colDomicilioRetirar = new ColumnHeader();
            colCantRetirar = new ColumnHeader();
            hdrRetirarLBL = new Label();
            generarResumenBTN = new Button();
            dniFleteroLBL = new Label();
            dniFleteroTXT = new TextBox();
            buscarFleteroBTN = new Button();
            nombreFleteroLBL = new Label();
            hdrEntregarGBX.SuspendLayout();
            hdrRetirarGBX.SuspendLayout();
            SuspendLayout();
            // 
            // fleteroLBL
            // 
            fleteroLBL.AutoSize = true;
            fleteroLBL.Location = new Point(15, 25);
            fleteroLBL.Name = "fleteroLBL";
            fleteroLBL.Size = new Size(0, 20);
            fleteroLBL.TabIndex = 0;
            fleteroLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // hdrEntregarGBX
            // 
            hdrEntregarGBX.Controls.Add(hdrEntregarLST);
            hdrEntregarGBX.Controls.Add(hdrEntregarLBL);
            hdrEntregarGBX.Enabled = false;
            hdrEntregarGBX.Location = new Point(12, 67);
            hdrEntregarGBX.Name = "hdrEntregarGBX";
            hdrEntregarGBX.Size = new Size(660, 218);
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
            hdrEntregarLST.Location = new Point(9, 61);
            hdrEntregarLST.Name = "hdrEntregarLST";
            hdrEntregarLST.Size = new Size(635, 150);
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
            // hdrEntregarLBL
            // 
            hdrEntregarLBL.AutoSize = true;
            hdrEntregarLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hdrEntregarLBL.ForeColor = Color.Green;
            hdrEntregarLBL.Location = new Point(9, 26);
            hdrEntregarLBL.Name = "hdrEntregarLBL";
            hdrEntregarLBL.Size = new Size(357, 20);
            hdrEntregarLBL.TabIndex = 0;
            hdrEntregarLBL.Text = "Seleccione HDR de entrega a incluir en el resumen";
            hdrEntregarLBL.Click += hdrEntregarLBL_Click;
            // 
            // hdrRetirarGBX
            // 
            hdrRetirarGBX.Controls.Add(hdrRetirarLST);
            hdrRetirarGBX.Controls.Add(hdrRetirarLBL);
            hdrRetirarGBX.Enabled = false;
            hdrRetirarGBX.Location = new Point(12, 291);
            hdrRetirarGBX.Name = "hdrRetirarGBX";
            hdrRetirarGBX.Size = new Size(660, 216);
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
            hdrRetirarLST.Location = new Point(9, 62);
            hdrRetirarLST.Name = "hdrRetirarLST";
            hdrRetirarLST.Size = new Size(635, 147);
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
            // hdrRetirarLBL
            // 
            hdrRetirarLBL.AutoSize = true;
            hdrRetirarLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hdrRetirarLBL.ForeColor = SystemColors.HotTrack;
            hdrRetirarLBL.Location = new Point(9, 25);
            hdrRetirarLBL.Name = "hdrRetirarLBL";
            hdrRetirarLBL.Size = new Size(342, 20);
            hdrRetirarLBL.TabIndex = 0;
            hdrRetirarLBL.Text = "Seleccione HDR de retiro a incluir en el resumen";
            // 
            // generarResumenBTN
            // 
            generarResumenBTN.Enabled = false;
            generarResumenBTN.Location = new Point(545, 513);
            generarResumenBTN.Name = "generarResumenBTN";
            generarResumenBTN.Size = new Size(111, 30);
            generarResumenBTN.TabIndex = 2;
            generarResumenBTN.Text = "Generar";
            generarResumenBTN.UseVisualStyleBackColor = true;
            // 
            // dniFleteroLBL
            // 
            dniFleteroLBL.AutoSize = true;
            dniFleteroLBL.Location = new Point(19, 18);
            dniFleteroLBL.Name = "dniFleteroLBL";
            dniFleteroLBL.Size = new Size(88, 20);
            dniFleteroLBL.TabIndex = 5;
            dniFleteroLBL.Text = "DNI Fletero:";
            dniFleteroLBL.TextAlign = ContentAlignment.MiddleRight;
            dniFleteroLBL.Click += label1_Click;
            // 
            // dniFleteroTXT
            // 
            dniFleteroTXT.Location = new Point(144, 15);
            dniFleteroTXT.Name = "dniFleteroTXT";
            dniFleteroTXT.Size = new Size(157, 27);
            dniFleteroTXT.TabIndex = 6;
            // 
            // buscarFleteroBTN
            // 
            buscarFleteroBTN.Location = new Point(326, 15);
            buscarFleteroBTN.Name = "buscarFleteroBTN";
            buscarFleteroBTN.Size = new Size(97, 29);
            buscarFleteroBTN.TabIndex = 7;
            buscarFleteroBTN.Text = "Buscar ";
            buscarFleteroBTN.UseVisualStyleBackColor = true;
            // 
            // nombreFleteroLBL
            // 
            nombreFleteroLBL.AutoSize = true;
            nombreFleteroLBL.BackColor = SystemColors.ActiveCaption;
            nombreFleteroLBL.Location = new Point(469, 22);
            nombreFleteroLBL.Name = "nombreFleteroLBL";
            nombreFleteroLBL.Size = new Size(139, 20);
            nombreFleteroLBL.TabIndex = 8;
            nombreFleteroLBL.Text = "Nombre del Fletero";
            // 
            // EmisionResumenHDRFRM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 556);
            Controls.Add(nombreFleteroLBL);
            Controls.Add(buscarFleteroBTN);
            Controls.Add(dniFleteroTXT);
            Controls.Add(dniFleteroLBL);
            Controls.Add(generarResumenBTN);
            Controls.Add(hdrRetirarGBX);
            Controls.Add(hdrEntregarGBX);
            Controls.Add(fleteroLBL);
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
        private Label hdrEntregarLBL;
        private ListView hdrEntregarLST;
        private ColumnHeader colNHdrEntregar;
        private ColumnHeader colDomicilioEntregar;
        private ColumnHeader colCantEntregar;
        private GroupBox hdrRetirarGBX;
        private Label hdrRetirarLBL;
        private Button generarResumenBTN;
        private ListView hdrRetirarLST;
        private ColumnHeader colNHdrRetirar;
        private ColumnHeader colDomicilioRetirar;
        private ColumnHeader colCantRetirar;
        private Label dniFleteroLBL;
        private TextBox dniFleteroTXT;
        private Button buscarFleteroBTN;
        private Label nombreFleteroLBL;
    }
}