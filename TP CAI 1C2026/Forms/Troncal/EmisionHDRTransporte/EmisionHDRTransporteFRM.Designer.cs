namespace TP_CAI_1C2026.Forms.Troncal.EmisionHDRTransporte
{
    partial class EmisionHDRTransporteFRM
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
            CDdestinoLBL = new Label();
            CDdestinoCMB = new ComboBox();
            GuiasLST = new ListView();
            TipoEncomiendaCol = new ColumnHeader();
            DestinoCol = new ColumnHeader();
            NumGuiaCol = new ColumnHeader();
            transportesLST = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            transporteGBX = new GroupBox();
            transporteCMB = new ComboBox();
            transporteLBL = new Label();
            buscarFechaBTN = new Button();
            buscarTransporteBTN = new Button();
            fechaLBL = new Label();
            fechaDTP = new DateTimePicker();
            generarHDRBTN = new Button();
            cancelarBTN = new Button();
            agregarBTN = new Button();
            nGuiaLBL = new Label();
            quitarBTN = new Button();
            nGuiaTXT = new TextBox();
            guiasAgregadasLST = new ListView();
            nguiaAgregadaCol = new ColumnHeader();
            tipoEncomiendaAgregadaCol = new ColumnHeader();
            lugarEntregaAgregadaCol = new ColumnHeader();
            buscarGuiaBTN = new Button();
            guiasGBX = new GroupBox();
            transporteGBX.SuspendLayout();
            guiasGBX.SuspendLayout();
            SuspendLayout();
            // 
            // CDdestinoLBL
            // 
            CDdestinoLBL.AutoSize = true;
            CDdestinoLBL.Location = new Point(34, 27);
            CDdestinoLBL.Name = "CDdestinoLBL";
            CDdestinoLBL.Size = new Size(172, 15);
            CDdestinoLBL.TabIndex = 0;
            CDdestinoLBL.Text = "Centro de Distribución Destino:";
            // 
            // CDdestinoCMB
            // 
            CDdestinoCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            CDdestinoCMB.FormattingEnabled = true;
            CDdestinoCMB.Location = new Point(231, 25);
            CDdestinoCMB.Margin = new Padding(3, 2, 3, 2);
            CDdestinoCMB.Name = "CDdestinoCMB";
            CDdestinoCMB.Size = new Size(715, 23);
            CDdestinoCMB.Sorted = true;
            CDdestinoCMB.TabIndex = 1;
            // 
            // GuiasLST
            // 
            GuiasLST.CheckBoxes = true;
            GuiasLST.Columns.AddRange(new ColumnHeader[] { TipoEncomiendaCol, DestinoCol, NumGuiaCol });
            GuiasLST.GridLines = true;
            GuiasLST.Location = new Point(12, 58);
            GuiasLST.Margin = new Padding(3, 2, 3, 2);
            GuiasLST.Name = "GuiasLST";
            GuiasLST.Size = new Size(407, 223);
            GuiasLST.TabIndex = 2;
            GuiasLST.UseCompatibleStateImageBehavior = false;
            GuiasLST.View = View.Details;
            // 
            // TipoEncomiendaCol
            // 
            TipoEncomiendaCol.DisplayIndex = 1;
            TipoEncomiendaCol.Text = "Tipo de Encomienda";
            TipoEncomiendaCol.TextAlign = HorizontalAlignment.Center;
            TipoEncomiendaCol.Width = 150;
            // 
            // DestinoCol
            // 
            DestinoCol.DisplayIndex = 2;
            DestinoCol.Text = "Destino";
            DestinoCol.TextAlign = HorizontalAlignment.Center;
            DestinoCol.Width = 200;
            // 
            // NumGuiaCol
            // 
            NumGuiaCol.DisplayIndex = 0;
            NumGuiaCol.Text = "N° Guía";
            NumGuiaCol.Width = 100;
            // 
            // transportesLST
            // 
            transportesLST.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            transportesLST.GridLines = true;
            transportesLST.Location = new Point(12, 61);
            transportesLST.Margin = new Padding(3, 2, 3, 2);
            transportesLST.Name = "transportesLST";
            transportesLST.Size = new Size(912, 130);
            transportesLST.TabIndex = 11;
            transportesLST.UseCompatibleStateImageBehavior = false;
            transportesLST.View = View.Details;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Fecha";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Hora";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Empresa";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 373;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Destino";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            columnHeader7.Width = 460;
            // 
            // transporteGBX
            // 
            transporteGBX.Controls.Add(transporteCMB);
            transporteGBX.Controls.Add(transporteLBL);
            transporteGBX.Controls.Add(buscarFechaBTN);
            transporteGBX.Controls.Add(buscarTransporteBTN);
            transporteGBX.Controls.Add(fechaLBL);
            transporteGBX.Controls.Add(fechaDTP);
            transporteGBX.Controls.Add(transportesLST);
            transporteGBX.Location = new Point(22, 58);
            transporteGBX.Name = "transporteGBX";
            transporteGBX.Size = new Size(936, 205);
            transporteGBX.TabIndex = 12;
            transporteGBX.TabStop = false;
            transporteGBX.Text = "Transportes";
            // 
            // transporteCMB
            // 
            transporteCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            transporteCMB.FormattingEnabled = true;
            transporteCMB.Location = new Point(482, 28);
            transporteCMB.Margin = new Padding(3, 2, 3, 2);
            transporteCMB.Name = "transporteCMB";
            transporteCMB.Size = new Size(358, 23);
            transporteCMB.Sorted = true;
            transporteCMB.TabIndex = 42;
            // 
            // transporteLBL
            // 
            transporteLBL.Location = new Point(322, 29);
            transporteLBL.Name = "transporteLBL";
            transporteLBL.Size = new Size(150, 17);
            transporteLBL.TabIndex = 42;
            transporteLBL.Text = "Empresa de Transporte:";
            transporteLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buscarFechaBTN
            // 
            buscarFechaBTN.Location = new Point(201, 28);
            buscarFechaBTN.Margin = new Padding(3, 2, 3, 2);
            buscarFechaBTN.Name = "buscarFechaBTN";
            buscarFechaBTN.Size = new Size(70, 20);
            buscarFechaBTN.TabIndex = 42;
            buscarFechaBTN.Text = "Buscar";
            buscarFechaBTN.Click += buscarFechaBTN_Click;
            // 
            // buscarTransporteBTN
            // 
            buscarTransporteBTN.Location = new Point(854, 28);
            buscarTransporteBTN.Margin = new Padding(3, 2, 3, 2);
            buscarTransporteBTN.Name = "buscarTransporteBTN";
            buscarTransporteBTN.Size = new Size(70, 20);
            buscarTransporteBTN.TabIndex = 43;
            buscarTransporteBTN.Text = "Buscar";
            buscarTransporteBTN.Click += buscarFechaBTN_Click;
            // 
            // fechaLBL
            // 
            fechaLBL.Location = new Point(5, 27);
            fechaLBL.Name = "fechaLBL";
            fechaLBL.Size = new Size(58, 17);
            fechaLBL.TabIndex = 42;
            fechaLBL.Text = "Fecha:";
            fechaLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fechaDTP
            // 
            fechaDTP.Format = DateTimePickerFormat.Short;
            fechaDTP.Location = new Point(68, 28);
            fechaDTP.Margin = new Padding(3, 2, 3, 2);
            fechaDTP.Name = "fechaDTP";
            fechaDTP.Size = new Size(120, 23);
            fechaDTP.TabIndex = 12;
            // 
            // generarHDRBTN
            // 
            generarHDRBTN.Location = new Point(745, 587);
            generarHDRBTN.Margin = new Padding(3, 2, 3, 2);
            generarHDRBTN.Name = "generarHDRBTN";
            generarHDRBTN.Size = new Size(94, 24);
            generarHDRBTN.TabIndex = 6;
            generarHDRBTN.Text = "Generar HDR";
            generarHDRBTN.Click += generarHDRBTN_Click;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(855, 587);
            cancelarBTN.Margin = new Padding(3, 2, 3, 2);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(94, 24);
            cancelarBTN.TabIndex = 13;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // agregarBTN
            // 
            agregarBTN.Location = new Point(427, 121);
            agregarBTN.Margin = new Padding(3, 2, 3, 2);
            agregarBTN.Name = "agregarBTN";
            agregarBTN.Size = new Size(95, 24);
            agregarBTN.TabIndex = 35;
            agregarBTN.Text = "Agregar >>>";
            agregarBTN.Click += agregarBTN_Click;
            // 
            // nGuiaLBL
            // 
            nGuiaLBL.Location = new Point(15, 25);
            nGuiaLBL.Name = "nGuiaLBL";
            nGuiaLBL.Size = new Size(58, 17);
            nGuiaLBL.TabIndex = 36;
            nGuiaLBL.Text = "Nº Guía:";
            nGuiaLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // quitarBTN
            // 
            quitarBTN.Location = new Point(427, 162);
            quitarBTN.Margin = new Padding(3, 2, 3, 2);
            quitarBTN.Name = "quitarBTN";
            quitarBTN.Size = new Size(95, 24);
            quitarBTN.TabIndex = 34;
            quitarBTN.Text = "Quitar <<<";
            quitarBTN.Click += quitarBTN_Click;
            // 
            // nGuiaTXT
            // 
            nGuiaTXT.Location = new Point(78, 23);
            nGuiaTXT.Margin = new Padding(3, 2, 3, 2);
            nGuiaTXT.MaxLength = 11;
            nGuiaTXT.Name = "nGuiaTXT";
            nGuiaTXT.Size = new Size(259, 23);
            nGuiaTXT.TabIndex = 37;
            // 
            // guiasAgregadasLST
            // 
            guiasAgregadasLST.CheckBoxes = true;
            guiasAgregadasLST.Columns.AddRange(new ColumnHeader[] { nguiaAgregadaCol, tipoEncomiendaAgregadaCol, lugarEntregaAgregadaCol });
            guiasAgregadasLST.FullRowSelect = true;
            guiasAgregadasLST.GridLines = true;
            guiasAgregadasLST.Location = new Point(528, 58);
            guiasAgregadasLST.Margin = new Padding(3, 2, 3, 2);
            guiasAgregadasLST.Name = "guiasAgregadasLST";
            guiasAgregadasLST.Size = new Size(396, 223);
            guiasAgregadasLST.TabIndex = 33;
            guiasAgregadasLST.UseCompatibleStateImageBehavior = false;
            guiasAgregadasLST.View = View.Details;
            // 
            // nguiaAgregadaCol
            // 
            nguiaAgregadaCol.Text = "Nº Guía";
            nguiaAgregadaCol.Width = 100;
            // 
            // tipoEncomiendaAgregadaCol
            // 
            tipoEncomiendaAgregadaCol.Text = "Tipo de Encomienda";
            tipoEncomiendaAgregadaCol.TextAlign = HorizontalAlignment.Center;
            tipoEncomiendaAgregadaCol.Width = 150;
            // 
            // lugarEntregaAgregadaCol
            // 
            lugarEntregaAgregadaCol.Text = "Destino";
            lugarEntregaAgregadaCol.TextAlign = HorizontalAlignment.Center;
            lugarEntregaAgregadaCol.Width = 200;
            // 
            // buscarGuiaBTN
            // 
            buscarGuiaBTN.Location = new Point(352, 23);
            buscarGuiaBTN.Margin = new Padding(3, 2, 3, 2);
            buscarGuiaBTN.Name = "buscarGuiaBTN";
            buscarGuiaBTN.Size = new Size(70, 20);
            buscarGuiaBTN.TabIndex = 38;
            buscarGuiaBTN.Text = "Buscar";
            buscarGuiaBTN.Click += buscarGuiaBTN_Click;
            // 
            // guiasGBX
            // 
            guiasGBX.Controls.Add(agregarBTN);
            guiasGBX.Controls.Add(nGuiaLBL);
            guiasGBX.Controls.Add(quitarBTN);
            guiasGBX.Controls.Add(nGuiaTXT);
            guiasGBX.Controls.Add(guiasAgregadasLST);
            guiasGBX.Controls.Add(buscarGuiaBTN);
            guiasGBX.Controls.Add(GuiasLST);
            guiasGBX.Location = new Point(22, 280);
            guiasGBX.Margin = new Padding(3, 2, 3, 2);
            guiasGBX.Name = "guiasGBX";
            guiasGBX.Padding = new Padding(3, 2, 3, 2);
            guiasGBX.Size = new Size(936, 296);
            guiasGBX.TabIndex = 42;
            guiasGBX.TabStop = false;
            guiasGBX.Text = "Guías de encomienda a enviar";
            // 
            // EmisionHDRTransporteFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 625);
            Controls.Add(guiasGBX);
            Controls.Add(cancelarBTN);
            Controls.Add(transporteGBX);
            Controls.Add(generarHDRBTN);
            Controls.Add(CDdestinoCMB);
            Controls.Add(CDdestinoLBL);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EmisionHDRTransporteFRM";
            Text = "Emisión de Hoja de Ruta de Ómnibus";
            transporteGBX.ResumeLayout(false);
            guiasGBX.ResumeLayout(false);
            guiasGBX.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CDdestinoLBL;
        private ComboBox CDdestinoCMB;
        private ListView GuiasLST;
        private ColumnHeader TipoEncomiendaCol;
        private ColumnHeader DestinoCol;
        private ColumnHeader NumGuiaCol;
        private ListView transportesLST;
        private GroupBox transporteGBX;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Button generarHDRBTN;
        private Button cancelarBTN;
        private Button agregarBTN;
        private Label nGuiaLBL;
        private Button quitarBTN;
        private TextBox nGuiaTXT;
        private ListView guiasAgregadasLST;
        private ColumnHeader nguiaAgregadaCol;
        private ColumnHeader tipoEncomiendaAgregadaCol;
        private ColumnHeader lugarEntregaAgregadaCol;
        private Button buscarGuiaBTN;
        private Label transporteLBL;
        private Button buscarFechaBTN;
        private Button buscarTransporteBTN;
        private Label fechaLBL;
        private DateTimePicker fechaDTP;
        private ComboBox transporteCMB;
        private GroupBox guiasGBX;
    }
}
