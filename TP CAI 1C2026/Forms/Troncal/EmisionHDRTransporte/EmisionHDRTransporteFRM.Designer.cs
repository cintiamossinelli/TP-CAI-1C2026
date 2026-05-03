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
            transporteGBX = new GroupBox();
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
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            fechaDTP = new DateTimePicker();
            fechaLBL = new Label();
            buscarFechaBTN = new Button();
            transporteLBL = new Label();
            buscarTransporteBTN = new Button();
            transporteCMB = new ComboBox();
            guiasGBX = new GroupBox();
            transporteGBX.SuspendLayout();
            guiasGBX.SuspendLayout();
            SuspendLayout();
            // 
            // CDdestinoLBL
            // 
            CDdestinoLBL.AutoSize = true;
            CDdestinoLBL.Location = new Point(39, 36);
            CDdestinoLBL.Name = "CDdestinoLBL";
            CDdestinoLBL.Size = new Size(216, 20);
            CDdestinoLBL.TabIndex = 0;
            CDdestinoLBL.Text = "Centro de Distribución Destino:";
            // 
            // CDdestinoCMB
            // 
            CDdestinoCMB.FormattingEnabled = true;
            CDdestinoCMB.Location = new Point(264, 33);
            CDdestinoCMB.Name = "CDdestinoCMB";
            CDdestinoCMB.Size = new Size(817, 28);
            CDdestinoCMB.TabIndex = 1;
            // 
            // GuiasLST
            // 
            GuiasLST.CheckBoxes = true;
            GuiasLST.Columns.AddRange(new ColumnHeader[] { TipoEncomiendaCol, DestinoCol, NumGuiaCol });
            GuiasLST.GridLines = true;
            GuiasLST.Location = new Point(14, 77);
            GuiasLST.Name = "GuiasLST";
            GuiasLST.Size = new Size(465, 296);
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
            transportesLST.Location = new Point(14, 81);
            transportesLST.Name = "transportesLST";
            transportesLST.Size = new Size(1042, 172);
            transportesLST.TabIndex = 11;
            transportesLST.UseCompatibleStateImageBehavior = false;
            transportesLST.View = View.Details;
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
            transporteGBX.Location = new Point(25, 77);
            transporteGBX.Margin = new Padding(3, 4, 3, 4);
            transporteGBX.Name = "transporteGBX";
            transporteGBX.Padding = new Padding(3, 4, 3, 4);
            transporteGBX.Size = new Size(1070, 273);
            transporteGBX.TabIndex = 12;
            transporteGBX.TabStop = false;
            transporteGBX.Text = "Transportes";
            // 
            // generarHDRBTN
            // 
            generarHDRBTN.Location = new Point(851, 783);
            generarHDRBTN.Name = "generarHDRBTN";
            generarHDRBTN.Size = new Size(107, 32);
            generarHDRBTN.TabIndex = 6;
            generarHDRBTN.Text = "Generar HDR";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(977, 783);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(107, 32);
            cancelarBTN.TabIndex = 13;
            cancelarBTN.Text = "Cancelar";
            // 
            // agregarBTN
            // 
            agregarBTN.Location = new Point(488, 161);
            agregarBTN.Name = "agregarBTN";
            agregarBTN.Size = new Size(109, 32);
            agregarBTN.TabIndex = 35;
            agregarBTN.Text = "Agregar >>>";
            // 
            // nGuiaLBL
            // 
            nGuiaLBL.Location = new Point(17, 33);
            nGuiaLBL.Name = "nGuiaLBL";
            nGuiaLBL.Size = new Size(66, 23);
            nGuiaLBL.TabIndex = 36;
            nGuiaLBL.Text = "Nº Guía:";
            nGuiaLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // quitarBTN
            // 
            quitarBTN.Location = new Point(488, 216);
            quitarBTN.Name = "quitarBTN";
            quitarBTN.Size = new Size(109, 32);
            quitarBTN.TabIndex = 34;
            quitarBTN.Text = "Quitar <<<";
            // 
            // nGuiaTXT
            // 
            nGuiaTXT.Location = new Point(89, 31);
            nGuiaTXT.MaxLength = 11;
            nGuiaTXT.Name = "nGuiaTXT";
            nGuiaTXT.Size = new Size(295, 27);
            nGuiaTXT.TabIndex = 37;
            // 
            // guiasAgregadasLST
            // 
            guiasAgregadasLST.CheckBoxes = true;
            guiasAgregadasLST.Columns.AddRange(new ColumnHeader[] { nguiaAgregadaCol, tipoEncomiendaAgregadaCol, lugarEntregaAgregadaCol });
            guiasAgregadasLST.FullRowSelect = true;
            guiasAgregadasLST.GridLines = true;
            guiasAgregadasLST.Location = new Point(603, 77);
            guiasAgregadasLST.Name = "guiasAgregadasLST";
            guiasAgregadasLST.Size = new Size(456, 296);
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
            buscarGuiaBTN.Location = new Point(402, 31);
            buscarGuiaBTN.Name = "buscarGuiaBTN";
            buscarGuiaBTN.Size = new Size(80, 27);
            buscarGuiaBTN.TabIndex = 38;
            buscarGuiaBTN.Text = "Buscar";
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
            // fechaDTP
            // 
            fechaDTP.Format = DateTimePickerFormat.Short;
            fechaDTP.Location = new Point(78, 37);
            fechaDTP.Name = "fechaDTP";
            fechaDTP.Size = new Size(137, 27);
            fechaDTP.TabIndex = 12;
            // 
            // fechaLBL
            // 
            fechaLBL.Location = new Point(6, 36);
            fechaLBL.Name = "fechaLBL";
            fechaLBL.Size = new Size(66, 23);
            fechaLBL.TabIndex = 42;
            fechaLBL.Text = "Fecha:";
            fechaLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buscarFechaBTN
            // 
            buscarFechaBTN.Location = new Point(230, 37);
            buscarFechaBTN.Name = "buscarFechaBTN";
            buscarFechaBTN.Size = new Size(80, 27);
            buscarFechaBTN.TabIndex = 42;
            buscarFechaBTN.Text = "Buscar";
            // 
            // transporteLBL
            // 
            transporteLBL.Location = new Point(368, 39);
            transporteLBL.Name = "transporteLBL";
            transporteLBL.Size = new Size(172, 23);
            transporteLBL.TabIndex = 42;
            transporteLBL.Text = "Empresa de Transporte:";
            transporteLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buscarTransporteBTN
            // 
            buscarTransporteBTN.Location = new Point(976, 37);
            buscarTransporteBTN.Name = "buscarTransporteBTN";
            buscarTransporteBTN.Size = new Size(80, 27);
            buscarTransporteBTN.TabIndex = 43;
            buscarTransporteBTN.Text = "Buscar";
            // 
            // transporteCMB
            // 
            transporteCMB.FormattingEnabled = true;
            transporteCMB.Location = new Point(551, 37);
            transporteCMB.Name = "transporteCMB";
            transporteCMB.Size = new Size(409, 28);
            transporteCMB.TabIndex = 42;
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
            guiasGBX.Location = new Point(25, 373);
            guiasGBX.Name = "guiasGBX";
            guiasGBX.Size = new Size(1070, 395);
            guiasGBX.TabIndex = 42;
            guiasGBX.TabStop = false;
            guiasGBX.Text = "Guías de encomienda a enviar";
            // 
            // EmisionHDRTransporteFRM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 833);
            Controls.Add(guiasGBX);
            Controls.Add(cancelarBTN);
            Controls.Add(transporteGBX);
            Controls.Add(generarHDRBTN);
            Controls.Add(CDdestinoCMB);
            Controls.Add(CDdestinoLBL);
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