namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDRRetiro
{
    partial class EmisionHDRRetiroFRM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dniFleteroLBL = new Label();
            dniFleteroTXT = new TextBox();
            buscarFleteroTBN = new Button();
            nombreFleteroLBL = new Label();
            guiasLST = new ListView();
            colNGuia = new ColumnHeader();
            colTipoCaja = new ColumnHeader();
            colLugarRetiro = new ColumnHeader();
            generarHDRBTN = new Button();
            cancelarBTN = new Button();
            seleccionLBL = new Label();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            SuspendLayout();
            // 
            // dniFleteroLBL
            // 
            dniFleteroLBL.Location = new Point(13, 15);
            dniFleteroLBL.Name = "dniFleteroLBL";
            dniFleteroLBL.Size = new Size(70, 23);
            dniFleteroLBL.TabIndex = 0;
            dniFleteroLBL.Text = "DNI Fletero:";
            dniFleteroLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dniFleteroTXT
            // 
            dniFleteroTXT.Location = new Point(89, 16);
            dniFleteroTXT.MaxLength = 11;
            dniFleteroTXT.Name = "dniFleteroTXT";
            dniFleteroTXT.Size = new Size(150, 23);
            dniFleteroTXT.TabIndex = 1;
            // 
            // buscarFleteroTBN
            // 
            buscarFleteroTBN.Location = new Point(253, 14);
            buscarFleteroTBN.Name = "buscarFleteroTBN";
            buscarFleteroTBN.Size = new Size(80, 27);
            buscarFleteroTBN.TabIndex = 2;
            buscarFleteroTBN.Text = "Buscar";
            // 
            // nombreFleteroLBL
            // 
            nombreFleteroLBL.BackColor = SystemColors.ActiveCaption;
            nombreFleteroLBL.Location = new Point(348, 16);
            nombreFleteroLBL.Name = "nombreFleteroLBL";
            nombreFleteroLBL.Size = new Size(128, 23);
            nombreFleteroLBL.TabIndex = 3;
            nombreFleteroLBL.Text = "Nombre del Fletero";
            // 
            // guiasLST
            // 
            guiasLST.CheckBoxes = true;
            guiasLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colTipoCaja, colLugarRetiro });
            guiasLST.FullRowSelect = true;
            guiasLST.GridLines = true;
            guiasLST.Location = new Point(12, 185);
            guiasLST.Name = "guiasLST";
            guiasLST.Size = new Size(415, 337);
            guiasLST.TabIndex = 4;
            guiasLST.UseCompatibleStateImageBehavior = false;
            guiasLST.View = View.Details;
            // 
            // colNGuia
            // 
            colNGuia.Text = "N° Guía";
            colNGuia.Width = 120;
            // 
            // colTipoCaja
            // 
            colTipoCaja.Text = "Tipo de Caja";
            colTipoCaja.Width = 120;
            // 
            // colLugarRetiro
            // 
            colLugarRetiro.Text = "Lugar de Retiro";
            colLugarRetiro.Width = 380;
            // 
            // generarHDRBTN
            // 
            generarHDRBTN.Location = new Point(774, 528);
            generarHDRBTN.Name = "generarHDRBTN";
            generarHDRBTN.Size = new Size(90, 32);
            generarHDRBTN.TabIndex = 5;
            generarHDRBTN.Text = "Generar HDR";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(869, 528);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 6;
            cancelarBTN.Text = "Cancelar";
            // 
            // seleccionLBL
            // 
            seleccionLBL.AutoSize = true;
            seleccionLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            seleccionLBL.ForeColor = Color.Blue;
            seleccionLBL.Location = new Point(12, 62);
            seleccionLBL.Name = "seleccionLBL";
            seleccionLBL.Size = new Size(168, 15);
            seleccionLBL.TabIndex = 7;
            seleccionLBL.Text = "Seleccionar guías para retirar";
            // 
            // listView1
            // 
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(529, 192);
            listView1.Name = "listView1";
            listView1.Size = new Size(432, 330);
            listView1.TabIndex = 8;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "N° Guía";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Tipo de Caja";
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Lugar de Retiro";
            columnHeader3.Width = 380;
            // 
            // button1
            // 
            button1.Location = new Point(433, 361);
            button1.Name = "button1";
            button1.Size = new Size(90, 32);
            button1.TabIndex = 9;
            button1.Text = "Quitar <<<";
            // 
            // button2
            // 
            button2.Location = new Point(433, 323);
            button2.Name = "button2";
            button2.Size = new Size(90, 32);
            button2.TabIndex = 10;
            button2.Text = "Agregar >>>";
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(17, 79);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(410, 100);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // EmisionHDRRetiroFRM
            // 
            ClientSize = new Size(982, 585);
            Controls.Add(groupBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(seleccionLBL);
            Controls.Add(dniFleteroLBL);
            Controls.Add(dniFleteroTXT);
            Controls.Add(buscarFleteroTBN);
            Controls.Add(nombreFleteroLBL);
            Controls.Add(guiasLST);
            Controls.Add(generarHDRBTN);
            Controls.Add(cancelarBTN);
            Name = "EmisionHDRRetiroFRM";
            Text = "Emisión de HDR de Retiro";
            Load += EmisionHDRRetiroFRM_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label dniFleteroLBL;
        private TextBox dniFleteroTXT;
        private Button buscarFleteroTBN;
        private Label nombreFleteroLBL;
        private ListView guiasLST;
        private ColumnHeader colNGuia;
        private ColumnHeader colTipoCaja;
        private ColumnHeader colLugarRetiro;
        private Button generarHDRBTN;
        private Button cancelarBTN;
        private Label seleccionLBL;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
    }
}