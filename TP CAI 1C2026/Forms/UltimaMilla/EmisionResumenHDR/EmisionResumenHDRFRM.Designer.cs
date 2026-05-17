namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDR
{
    partial class EmisionResumenHDRFRM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dniFleteroLBL = new Label();
            dniFleteroTXT = new TextBox();
            buscarFleteroBTN = new Button();
            nombreFleteroLBL = new Label();
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
            cancelarBTN = new Button();
            hdrEntregarGBX.SuspendLayout();
            hdrRetirarGBX.SuspendLayout();
            SuspendLayout();
            // 
            // dniFleteroLBL
            // 
            dniFleteroLBL.Location = new Point(12, 18);
            dniFleteroLBL.Name = "dniFleteroLBL";
            dniFleteroLBL.Size = new Size(80, 23);
            dniFleteroLBL.TabIndex = 0;
            dniFleteroLBL.Text = "DNI Fletero:";
            dniFleteroLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dniFleteroTXT
            // 
            dniFleteroTXT.Location = new Point(97, 16);
            dniFleteroTXT.MaxLength = 11;
            dniFleteroTXT.Name = "dniFleteroTXT";
            dniFleteroTXT.Size = new Size(150, 23);
            dniFleteroTXT.TabIndex = 1;
            // 
            // buscarFleteroBTN
            // 
            buscarFleteroBTN.Location = new Point(253, 14);
            buscarFleteroBTN.Name = "buscarFleteroBTN";
            buscarFleteroBTN.Size = new Size(80, 27);
            buscarFleteroBTN.TabIndex = 2;
            buscarFleteroBTN.Text = "Buscar";
            buscarFleteroBTN.Click += buscarFleteroTBN_Click;
            // 
            // nombreFleteroLBL
            // 
            nombreFleteroLBL.BackColor = SystemColors.ActiveCaption;
            nombreFleteroLBL.Location = new Point(339, 16);
            nombreFleteroLBL.Name = "nombreFleteroLBL";
            nombreFleteroLBL.Size = new Size(340, 25);
            nombreFleteroLBL.TabIndex = 3;
            nombreFleteroLBL.Text = "Nombre del Fletero";
            // 
            // hdrEntregarGBX
            // 
            hdrEntregarGBX.Controls.Add(hdrEntregarLST);
            hdrEntregarGBX.Location = new Point(12, 57);
            hdrEntregarGBX.Name = "hdrEntregarGBX";
            hdrEntregarGBX.Size = new Size(681, 220);
            hdrEntregarGBX.TabIndex = 4;
            hdrEntregarGBX.TabStop = false;
            hdrEntregarGBX.Text = "HDR a Entregar";
            // 
            // hdrEntregarLST
            // 
            hdrEntregarLST.Columns.AddRange(new ColumnHeader[] { colNHdrEntregar, colDomicilioEntregar, colCantEntregar });
            hdrEntregarLST.FullRowSelect = true;
            hdrEntregarLST.GridLines = true;
            hdrEntregarLST.Location = new Point(10, 25);
            hdrEntregarLST.Name = "hdrEntregarLST";
            hdrEntregarLST.Size = new Size(657, 183);
            hdrEntregarLST.TabIndex = 0;
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
            colDomicilioEntregar.Width = 350;
            // 
            // colCantEntregar
            // 
            colCantEntregar.Text = "Cant. Encomiendas";
            colCantEntregar.Width = 160;
            // 
            // hdrRetirarGBX
            // 
            hdrRetirarGBX.Controls.Add(hdrRetirarLST);
            hdrRetirarGBX.Location = new Point(12, 287);
            hdrRetirarGBX.Name = "hdrRetirarGBX";
            hdrRetirarGBX.Size = new Size(681, 220);
            hdrRetirarGBX.TabIndex = 5;
            hdrRetirarGBX.TabStop = false;
            hdrRetirarGBX.Text = "HDR a Retirar";
            // 
            // hdrRetirarLST
            // 
            hdrRetirarLST.Columns.AddRange(new ColumnHeader[] { colNHdrRetirar, colDomicilioRetirar, colCantRetirar });
            hdrRetirarLST.FullRowSelect = true;
            hdrRetirarLST.GridLines = true;
            hdrRetirarLST.Location = new Point(10, 25);
            hdrRetirarLST.Name = "hdrRetirarLST";
            hdrRetirarLST.Size = new Size(657, 183);
            hdrRetirarLST.TabIndex = 0;
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
            colDomicilioRetirar.Width = 350;
            // 
            // colCantRetirar
            // 
            colCantRetirar.Text = "Cant. Encomiendas";
            colCantRetirar.Width = 160;
            // 
            // generarResumenBTN
            // 
            generarResumenBTN.Location = new Point(508, 522);
            generarResumenBTN.Name = "generarResumenBTN";
            generarResumenBTN.Size = new Size(80, 32);
            generarResumenBTN.TabIndex = 6;
            generarResumenBTN.Text = "Generar";
            generarResumenBTN.Click += emitirResumenBTN_Click;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(603, 522);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 7;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // EmisionResumenHDRFRM
            // 
            ClientSize = new Size(706, 565);
            Controls.Add(dniFleteroLBL);
            Controls.Add(dniFleteroTXT);
            Controls.Add(buscarFleteroBTN);
            Controls.Add(nombreFleteroLBL);
            Controls.Add(hdrEntregarGBX);
            Controls.Add(hdrRetirarGBX);
            Controls.Add(generarResumenBTN);
            Controls.Add(cancelarBTN);
            Name = "EmisionResumenHDRFRM";
            Text = "Emisión de Resumen de HDR";
            hdrEntregarGBX.ResumeLayout(false);
            hdrRetirarGBX.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label dniFleteroLBL;
        private TextBox dniFleteroTXT;
        private Button buscarFleteroBTN;
        private Label nombreFleteroLBL;
        private GroupBox hdrEntregarGBX;
        private ListView hdrEntregarLST;
        private ColumnHeader colNHdrEntregar;
        private ColumnHeader colDomicilioEntregar;
        private ColumnHeader colCantEntregar;
        private GroupBox hdrRetirarGBX;
        private ListView hdrRetirarLST;
        private ColumnHeader colNHdrRetirar;
        private ColumnHeader colDomicilioRetirar;
        private ColumnHeader colCantRetirar;
        private Button generarResumenBTN;
        private Button cancelarBTN;
    }
}