namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega
{
    partial class EmisionHDREntregaFRM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            generarBTN = new Button();
            fleteroGBX = new GroupBox();
            dniFleteroLBL = new Label();
            dniFleteroTXT = new TextBox();
            buscarFleteroTBN = new Button();
            nombreFleteroLBL = new Label();
            localidadCMB = new ComboBox();
            localidadLBL = new Label();
            buscarLocalidadBTN = new Button();
            agregarBTN = new Button();
            nGuiaLBL = new Label();
            quitarBTN = new Button();
            nGuiaTXT = new TextBox();
            guiasAgregadasLST = new ListView();
            nguiaAgregadaCol = new ColumnHeader();
            tipoCajaAgregadaCol = new ColumnHeader();
            lugarEntregaAgregadaCol = new ColumnHeader();
            buscarGuiaBTN = new Button();
            guiasSinAgregarLST = new ListView();
            colNGuia = new ColumnHeader();
            colTipoCaja = new ColumnHeader();
            colLugarEntrega = new ColumnHeader();
            cancelarBTN = new Button();
            groupBox1 = new GroupBox();
            fleteroGBX.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // generarBTN
            // 
            generarBTN.Location = new Point(769, 571);
            generarBTN.Name = "generarBTN";
            generarBTN.Size = new Size(107, 32);
            generarBTN.TabIndex = 33;
            generarBTN.Text = "Generar HDR";
            // 
            // fleteroGBX
            // 
            fleteroGBX.Controls.Add(dniFleteroLBL);
            fleteroGBX.Controls.Add(dniFleteroTXT);
            fleteroGBX.Controls.Add(buscarFleteroTBN);
            fleteroGBX.Controls.Add(nombreFleteroLBL);
            fleteroGBX.Location = new Point(28, 16);
            fleteroGBX.Name = "fleteroGBX";
            fleteroGBX.Size = new Size(973, 70);
            fleteroGBX.TabIndex = 32;
            fleteroGBX.TabStop = false;
            fleteroGBX.Text = "Fletero";
            // 
            // dniFleteroLBL
            // 
            dniFleteroLBL.Location = new Point(3, 29);
            dniFleteroLBL.Name = "dniFleteroLBL";
            dniFleteroLBL.Size = new Size(91, 23);
            dniFleteroLBL.TabIndex = 0;
            dniFleteroLBL.Text = "DNI:";
            dniFleteroLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dniFleteroTXT
            // 
            dniFleteroTXT.Location = new Point(100, 27);
            dniFleteroTXT.MaxLength = 11;
            dniFleteroTXT.Name = "dniFleteroTXT";
            dniFleteroTXT.Size = new Size(209, 27);
            dniFleteroTXT.TabIndex = 1;
            // 
            // buscarFleteroTBN
            // 
            buscarFleteroTBN.Location = new Point(326, 26);
            buscarFleteroTBN.Name = "buscarFleteroTBN";
            buscarFleteroTBN.Size = new Size(80, 27);
            buscarFleteroTBN.TabIndex = 2;
            buscarFleteroTBN.Text = "Buscar";
            // 
            // nombreFleteroLBL
            // 
            nombreFleteroLBL.BackColor = SystemColors.ActiveCaption;
            nombreFleteroLBL.Location = new Point(424, 29);
            nombreFleteroLBL.Name = "nombreFleteroLBL";
            nombreFleteroLBL.Size = new Size(533, 23);
            nombreFleteroLBL.TabIndex = 3;
            nombreFleteroLBL.Text = "Nombre del Fletero";
            // 
            // localidadCMB
            // 
            localidadCMB.FormattingEnabled = true;
            localidadCMB.Location = new Point(100, 66);
            localidadCMB.Name = "localidadCMB";
            localidadCMB.Size = new Size(209, 28);
            localidadCMB.TabIndex = 31;
            // 
            // localidadLBL
            // 
            localidadLBL.Location = new Point(14, 66);
            localidadLBL.Name = "localidadLBL";
            localidadLBL.Size = new Size(80, 23);
            localidadLBL.TabIndex = 29;
            localidadLBL.Text = "Localidad:";
            localidadLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buscarLocalidadBTN
            // 
            buscarLocalidadBTN.Location = new Point(326, 66);
            buscarLocalidadBTN.Name = "buscarLocalidadBTN";
            buscarLocalidadBTN.Size = new Size(80, 27);
            buscarLocalidadBTN.TabIndex = 30;
            buscarLocalidadBTN.Text = "Buscar";
            // 
            // agregarBTN
            // 
            agregarBTN.Location = new Point(452, 345);
            agregarBTN.Name = "agregarBTN";
            agregarBTN.Size = new Size(109, 32);
            agregarBTN.TabIndex = 25;
            agregarBTN.Text = "Agregar >>>";
            // 
            // nGuiaLBL
            // 
            nGuiaLBL.Location = new Point(28, 26);
            nGuiaLBL.Name = "nGuiaLBL";
            nGuiaLBL.Size = new Size(66, 23);
            nGuiaLBL.TabIndex = 26;
            nGuiaLBL.Text = "Nº Guía:";
            nGuiaLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // quitarBTN
            // 
            quitarBTN.Location = new Point(452, 400);
            quitarBTN.Name = "quitarBTN";
            quitarBTN.Size = new Size(109, 32);
            quitarBTN.TabIndex = 24;
            quitarBTN.Text = "Quitar <<<";
            // 
            // nGuiaTXT
            // 
            nGuiaTXT.Location = new Point(100, 24);
            nGuiaTXT.MaxLength = 11;
            nGuiaTXT.Name = "nGuiaTXT";
            nGuiaTXT.Size = new Size(209, 27);
            nGuiaTXT.TabIndex = 27;
            // 
            // guiasAgregadasLST
            // 
            guiasAgregadasLST.CheckBoxes = true;
            guiasAgregadasLST.Columns.AddRange(new ColumnHeader[] { nguiaAgregadaCol, tipoCajaAgregadaCol, lugarEntregaAgregadaCol });
            guiasAgregadasLST.FullRowSelect = true;
            guiasAgregadasLST.GridLines = true;
            guiasAgregadasLST.Location = new Point(569, 220);
            guiasAgregadasLST.Name = "guiasAgregadasLST";
            guiasAgregadasLST.Size = new Size(432, 337);
            guiasAgregadasLST.TabIndex = 23;
            guiasAgregadasLST.UseCompatibleStateImageBehavior = false;
            guiasAgregadasLST.View = View.Details;
            // 
            // nguiaAgregadaCol
            // 
            nguiaAgregadaCol.Text = "Nº Guía";
            nguiaAgregadaCol.Width = 120;
            // 
            // tipoCajaAgregadaCol
            // 
            tipoCajaAgregadaCol.Text = "Tipo de Caja";
            tipoCajaAgregadaCol.Width = 120;
            // 
            // lugarEntregaAgregadaCol
            // 
            lugarEntregaAgregadaCol.Text = "Lugar de Entrega";
            lugarEntregaAgregadaCol.Width = 300;
            // 
            // buscarGuiaBTN
            // 
            buscarGuiaBTN.Location = new Point(326, 26);
            buscarGuiaBTN.Name = "buscarGuiaBTN";
            buscarGuiaBTN.Size = new Size(80, 27);
            buscarGuiaBTN.TabIndex = 28;
            buscarGuiaBTN.Text = "Buscar";
            // 
            // guiasSinAgregarLST
            // 
            guiasSinAgregarLST.CheckBoxes = true;
            guiasSinAgregarLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colTipoCaja, colLugarEntrega });
            guiasSinAgregarLST.FullRowSelect = true;
            guiasSinAgregarLST.GridLines = true;
            guiasSinAgregarLST.Location = new Point(28, 220);
            guiasSinAgregarLST.Name = "guiasSinAgregarLST";
            guiasSinAgregarLST.Size = new Size(415, 337);
            guiasSinAgregarLST.TabIndex = 21;
            guiasSinAgregarLST.UseCompatibleStateImageBehavior = false;
            guiasSinAgregarLST.View = View.Details;
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
            // colLugarEntrega
            // 
            colLugarEntrega.Text = "Lugar de Entrega";
            colLugarEntrega.Width = 300;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(894, 571);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(107, 32);
            cancelarBTN.TabIndex = 22;
            cancelarBTN.Text = "Cancelar";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(localidadCMB);
            groupBox1.Controls.Add(localidadLBL);
            groupBox1.Controls.Add(buscarLocalidadBTN);
            groupBox1.Controls.Add(nGuiaLBL);
            groupBox1.Controls.Add(nGuiaTXT);
            groupBox1.Controls.Add(buscarGuiaBTN);
            groupBox1.Location = new Point(28, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(415, 107);
            groupBox1.TabIndex = 34;
            groupBox1.TabStop = false;
            // 
            // EmisionHDREntregaFRM
            // 
            ClientSize = new Size(1036, 621);
            Controls.Add(groupBox1);
            Controls.Add(generarBTN);
            Controls.Add(fleteroGBX);
            Controls.Add(agregarBTN);
            Controls.Add(quitarBTN);
            Controls.Add(guiasAgregadasLST);
            Controls.Add(guiasSinAgregarLST);
            Controls.Add(cancelarBTN);
            Name = "EmisionHDREntregaFRM";
            Text = "Emisión de HDR de Entrega";
            fleteroGBX.ResumeLayout(false);
            fleteroGBX.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        private Button generarBTN;
        private GroupBox fleteroGBX;
        private Label dniFleteroLBL;
        private TextBox dniFleteroTXT;
        private Button buscarFleteroTBN;
        private Label nombreFleteroLBL;
        private ComboBox localidadCMB;
        private Label localidadLBL;
        private Button buscarLocalidadBTN;
        private Button agregarBTN;
        private Label nGuiaLBL;
        private Button quitarBTN;
        private TextBox nGuiaTXT;
        private ListView guiasAgregadasLST;
        private ColumnHeader nguiaAgregadaCol;
        private ColumnHeader tipoCajaAgregadaCol;
        private ColumnHeader lugarEntregaAgregadaCol;
        private Button buscarGuiaBTN;
        private ListView guiasSinAgregarLST;
        private ColumnHeader colNGuia;
        private ColumnHeader colTipoCaja;
        private ColumnHeader colLugarEntrega;
        private Button cancelarBTN;
        private GroupBox groupBox1;
    }
}