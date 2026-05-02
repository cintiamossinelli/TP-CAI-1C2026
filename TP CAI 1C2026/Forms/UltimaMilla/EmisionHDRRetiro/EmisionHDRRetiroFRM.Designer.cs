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
            guiasSinAgregarLST = new ListView();
            colNGuia = new ColumnHeader();
            colTipoCaja = new ColumnHeader();
            colLugarRetiro = new ColumnHeader();
            cancelarBTN = new Button();
            guiasAgregadasLST = new ListView();
            nguiaAgregadaCol = new ColumnHeader();
            tipoCajaAgregadaCol = new ColumnHeader();
            lugarRetiroAgregadaCol = new ColumnHeader();
            quitarBTN = new Button();
            agregarBTN = new Button();
            nGuiaLBL = new Label();
            nGuiaTXT = new TextBox();
            buscarGuiaBTN = new Button();
            localidadLBL = new Label();
            buscarLocalidadBTN = new Button();
            localidadCMB = new ComboBox();
            fleteroGBX = new GroupBox();
            generarBTN = new Button();
            fleteroGBX.SuspendLayout();
            SuspendLayout();
            // 
            // dniFleteroLBL
            // 
            dniFleteroLBL.Location = new Point(3, 29);
            dniFleteroLBL.Name = "dniFleteroLBL";
            dniFleteroLBL.Size = new Size(91, 23);
            dniFleteroLBL.TabIndex = 0;
            dniFleteroLBL.Text = "DNI Fletero:";
            dniFleteroLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dniFleteroTXT
            // 
            dniFleteroTXT.Location = new Point(100, 27);
            dniFleteroTXT.MaxLength = 11;
            dniFleteroTXT.Name = "dniFleteroTXT";
            dniFleteroTXT.Size = new Size(235, 27);
            dniFleteroTXT.TabIndex = 1;
            // 
            // buscarFleteroTBN
            // 
            buscarFleteroTBN.Location = new Point(351, 26);
            buscarFleteroTBN.Name = "buscarFleteroTBN";
            buscarFleteroTBN.Size = new Size(80, 27);
            buscarFleteroTBN.TabIndex = 2;
            buscarFleteroTBN.Text = "Buscar";
            // 
            // nombreFleteroLBL
            // 
            nombreFleteroLBL.BackColor = SystemColors.ActiveCaption;
            nombreFleteroLBL.Location = new Point(440, 29);
            nombreFleteroLBL.Name = "nombreFleteroLBL";
            nombreFleteroLBL.Size = new Size(517, 23);
            nombreFleteroLBL.TabIndex = 3;
            nombreFleteroLBL.Text = "Nombre del Fletero";
            // 
            // guiasSinAgregarLST
            // 
            guiasSinAgregarLST.CheckBoxes = true;
            guiasSinAgregarLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colTipoCaja, colLugarRetiro });
            guiasSinAgregarLST.FullRowSelect = true;
            guiasSinAgregarLST.GridLines = true;
            guiasSinAgregarLST.Location = new Point(18, 185);
            guiasSinAgregarLST.Name = "guiasSinAgregarLST";
            guiasSinAgregarLST.Size = new Size(425, 337);
            guiasSinAgregarLST.TabIndex = 4;
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
            // colLugarRetiro
            // 
            colLugarRetiro.Text = "Lugar de Retiro";
            colLugarRetiro.Width = 300;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(878, 536);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(107, 32);
            cancelarBTN.TabIndex = 6;
            cancelarBTN.Text = "Cancelar";
            // 
            // guiasAgregadasLST
            // 
            guiasAgregadasLST.CheckBoxes = true;
            guiasAgregadasLST.Columns.AddRange(new ColumnHeader[] { nguiaAgregadaCol, tipoCajaAgregadaCol, lugarRetiroAgregadaCol });
            guiasAgregadasLST.FullRowSelect = true;
            guiasAgregadasLST.GridLines = true;
            guiasAgregadasLST.Location = new Point(569, 185);
            guiasAgregadasLST.Name = "guiasAgregadasLST";
            guiasAgregadasLST.Size = new Size(416, 337);
            guiasAgregadasLST.TabIndex = 8;
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
            // lugarRetiroAgregadaCol
            // 
            lugarRetiroAgregadaCol.Text = "Lugar de Retiro";
            lugarRetiroAgregadaCol.Width = 300;
            // 
            // quitarBTN
            // 
            quitarBTN.Location = new Point(452, 365);
            quitarBTN.Name = "quitarBTN";
            quitarBTN.Size = new Size(109, 32);
            quitarBTN.TabIndex = 9;
            quitarBTN.Text = "Quitar <<<";
            // 
            // agregarBTN
            // 
            agregarBTN.Location = new Point(452, 310);
            agregarBTN.Name = "agregarBTN";
            agregarBTN.Size = new Size(109, 32);
            agregarBTN.TabIndex = 10;
            agregarBTN.Text = "Agregar >>>";
            // 
            // nGuiaLBL
            // 
            nGuiaLBL.Location = new Point(40, 103);
            nGuiaLBL.Name = "nGuiaLBL";
            nGuiaLBL.Size = new Size(66, 23);
            nGuiaLBL.TabIndex = 12;
            nGuiaLBL.Text = "Nº Guía:";
            nGuiaLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nGuiaTXT
            // 
            nGuiaTXT.Location = new Point(114, 99);
            nGuiaTXT.MaxLength = 11;
            nGuiaTXT.Name = "nGuiaTXT";
            nGuiaTXT.Size = new Size(233, 27);
            nGuiaTXT.TabIndex = 13;
            // 
            // buscarGuiaBTN
            // 
            buscarGuiaBTN.Location = new Point(363, 101);
            buscarGuiaBTN.Name = "buscarGuiaBTN";
            buscarGuiaBTN.Size = new Size(80, 27);
            buscarGuiaBTN.TabIndex = 14;
            buscarGuiaBTN.Text = "Buscar";
            // 
            // localidadLBL
            // 
            localidadLBL.Location = new Point(26, 144);
            localidadLBL.Name = "localidadLBL";
            localidadLBL.Size = new Size(80, 23);
            localidadLBL.TabIndex = 15;
            localidadLBL.Text = "Localidad:";
            localidadLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buscarLocalidadBTN
            // 
            buscarLocalidadBTN.Location = new Point(363, 143);
            buscarLocalidadBTN.Name = "buscarLocalidadBTN";
            buscarLocalidadBTN.Size = new Size(80, 27);
            buscarLocalidadBTN.TabIndex = 17;
            buscarLocalidadBTN.Text = "Buscar";
            // 
            // localidadCMB
            // 
            localidadCMB.FormattingEnabled = true;
            localidadCMB.Location = new Point(114, 144);
            localidadCMB.Name = "localidadCMB";
            localidadCMB.Size = new Size(233, 28);
            localidadCMB.TabIndex = 18;
            // 
            // fleteroGBX
            // 
            fleteroGBX.Controls.Add(dniFleteroLBL);
            fleteroGBX.Controls.Add(dniFleteroTXT);
            fleteroGBX.Controls.Add(buscarFleteroTBN);
            fleteroGBX.Controls.Add(nombreFleteroLBL);
            fleteroGBX.Location = new Point(12, 12);
            fleteroGBX.Name = "fleteroGBX";
            fleteroGBX.Size = new Size(989, 70);
            fleteroGBX.TabIndex = 19;
            fleteroGBX.TabStop = false;
            fleteroGBX.Text = "Fletero";
            // 
            // generarBTN
            // 
            generarBTN.Location = new Point(751, 536);
            generarBTN.Name = "generarBTN";
            generarBTN.Size = new Size(107, 32);
            generarBTN.TabIndex = 20;
            generarBTN.Text = "Generar HDR";
            // 
            // EmisionHDRRetiroFRM
            // 
            ClientSize = new Size(1016, 585);
            Controls.Add(generarBTN);
            Controls.Add(fleteroGBX);
            Controls.Add(localidadCMB);
            Controls.Add(localidadLBL);
            Controls.Add(buscarLocalidadBTN);
            Controls.Add(agregarBTN);
            Controls.Add(nGuiaLBL);
            Controls.Add(quitarBTN);
            Controls.Add(nGuiaTXT);
            Controls.Add(guiasAgregadasLST);
            Controls.Add(buscarGuiaBTN);
            Controls.Add(guiasSinAgregarLST);
            Controls.Add(cancelarBTN);
            Name = "EmisionHDRRetiroFRM";
            Text = "Emisión de HDR de Retiro";
            Load += EmisionHDRRetiroFRM_Load;
            fleteroGBX.ResumeLayout(false);
            fleteroGBX.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label dniFleteroLBL;
        private TextBox dniFleteroTXT;
        private Button buscarFleteroTBN;
        private Label nombreFleteroLBL;
        private ListView guiasSinAgregarLST;
        private ColumnHeader colNGuia;
        private ColumnHeader colTipoCaja;
        private ColumnHeader colLugarRetiro;
        private Button generarHDRBTN;
        private Button cancelarBTN;
        private ListView guiasAgregadasLST;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button quitarBTN;
        private Button agregarBTN;
        private Label nGuiaLBL;
        private TextBox nGuiaTXT;
        private Button buscarGuiaBTN;
        private Label localidadLBL;
        private Button buscarLocalidadBTN;
        private ComboBox localidadCMB;
        private GroupBox fleteroGBX;
        private Button generarBTN;
        private ColumnHeader nguiaAgregadaCol;
        private ColumnHeader tipoCajaAgregadaCol;
        private ColumnHeader lugarRetiroAgregadaCol;
    }
}