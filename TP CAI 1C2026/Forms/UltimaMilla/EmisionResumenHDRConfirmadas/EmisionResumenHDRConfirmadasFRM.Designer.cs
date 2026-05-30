namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDRConfirmadas
{
    partial class EmisionResumenHDRConfirmadasFRM
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
            cancelarBTN = new Button();
            hdrEnTransitoLSVT = new ListView();
            colNHDR = new ColumnHeader();
            colDomicilio = new ColumnHeader();
            colCantEncomiendas = new ColumnHeader();
            hojasDeRutaEnTransitoLBL = new Label();
            GenerarResumenBTN = new Button();
            buscarBTN = new Button();
            dniFleteroTXT = new TextBox();
            dniFleteroLBL = new Label();
            nombreFleteroLBL = new Label();
            LeyendaLBL = new Label();
            SuspendLayout();
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(564, 522);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(105, 38);
            cancelarBTN.TabIndex = 0;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.UseVisualStyleBackColor = true;
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // hdrEnTransitoLSVT
            // 
            hdrEnTransitoLSVT.CheckBoxes = true;
            hdrEnTransitoLSVT.Columns.AddRange(new ColumnHeader[] { colNHDR, colDomicilio, colCantEncomiendas });
            hdrEnTransitoLSVT.GridLines = true;
            hdrEnTransitoLSVT.Location = new Point(38, 111);
            hdrEnTransitoLSVT.Name = "hdrEnTransitoLSVT";
            hdrEnTransitoLSVT.Size = new Size(631, 405);
            hdrEnTransitoLSVT.TabIndex = 3;
            hdrEnTransitoLSVT.UseCompatibleStateImageBehavior = false;
            hdrEnTransitoLSVT.View = View.Details;
            // 
            // colNHDR
            // 
            colNHDR.Text = "N° HDR";
            colNHDR.Width = 90;
            // 
            // colDomicilio
            // 
            colDomicilio.Text = "Domicilio";
            colDomicilio.Width = 400;
            // 
            // colCantEncomiendas
            // 
            colCantEncomiendas.Text = "Cant. Encomiendas";
            colCantEncomiendas.TextAlign = HorizontalAlignment.Center;
            colCantEncomiendas.Width = 130;
            // 
            // hojasDeRutaEnTransitoLBL
            // 
            hojasDeRutaEnTransitoLBL.AutoSize = true;
            hojasDeRutaEnTransitoLBL.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            hojasDeRutaEnTransitoLBL.ForeColor = SystemColors.HotTrack;
            hojasDeRutaEnTransitoLBL.Location = new Point(38, 69);
            hojasDeRutaEnTransitoLBL.Name = "hojasDeRutaEnTransitoLBL";
            hojasDeRutaEnTransitoLBL.Size = new Size(182, 20);
            hojasDeRutaEnTransitoLBL.TabIndex = 4;
            hojasDeRutaEnTransitoLBL.Text = "Hojas de ruta en tránsito";
            // 
            // GenerarResumenBTN
            // 
            GenerarResumenBTN.Location = new Point(321, 522);
            GenerarResumenBTN.Name = "GenerarResumenBTN";
            GenerarResumenBTN.Size = new Size(223, 38);
            GenerarResumenBTN.TabIndex = 5;
            GenerarResumenBTN.Text = "Generar Resumen de HDR Confirmadas";
            GenerarResumenBTN.UseVisualStyleBackColor = true;
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(250, 29);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(114, 27);
            buscarBTN.TabIndex = 2;
            buscarBTN.Text = "Buscar";
            buscarBTN.Click += buscarBTN_Click_1;
            // 
            // dniFleteroTXT
            // 
            dniFleteroTXT.Location = new Point(114, 31);
            dniFleteroTXT.MaxLength = 11;
            dniFleteroTXT.Name = "dniFleteroTXT";
            dniFleteroTXT.Size = new Size(130, 23);
            dniFleteroTXT.TabIndex = 1;
            // 
            // dniFleteroLBL
            // 
            dniFleteroLBL.Location = new Point(29, 31);
            dniFleteroLBL.Name = "dniFleteroLBL";
            dniFleteroLBL.Size = new Size(83, 23);
            dniFleteroLBL.TabIndex = 0;
            dniFleteroLBL.Text = "DNI Fletero:";
            dniFleteroLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nombreFleteroLBL
            // 
            nombreFleteroLBL.AutoSize = true;
            nombreFleteroLBL.BackColor = SystemColors.ActiveCaption;
            nombreFleteroLBL.Location = new Point(378, 35);
            nombreFleteroLBL.Name = "nombreFleteroLBL";
            nombreFleteroLBL.Size = new Size(109, 15);
            nombreFleteroLBL.TabIndex = 3;
            nombreFleteroLBL.Text = "Nombre del Fletero";
            // 
            // LeyendaLBL
            // 
            LeyendaLBL.AutoSize = true;
            LeyendaLBL.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            LeyendaLBL.ForeColor = SystemColors.Desktop;
            LeyendaLBL.Location = new Point(38, 89);
            LeyendaLBL.Name = "LeyendaLBL";
            LeyendaLBL.Size = new Size(343, 13);
            LeyendaLBL.TabIndex = 6;
            LeyendaLBL.Text = "Las HDR no seleccionadas cambiarán a estado \"No Confirmadas\"";
            // 
            // EmisionResumenHDRConfirmadasFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 574);
            Controls.Add(LeyendaLBL);
            Controls.Add(nombreFleteroLBL);
            Controls.Add(dniFleteroLBL);
            Controls.Add(GenerarResumenBTN);
            Controls.Add(buscarBTN);
            Controls.Add(dniFleteroTXT);
            Controls.Add(hojasDeRutaEnTransitoLBL);
            Controls.Add(hdrEnTransitoLSVT);
            Controls.Add(cancelarBTN);
            Name = "EmisionResumenHDRConfirmadasFRM";
            Text = "Emisión Resumen HDR Confirmadas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelarBTN;
        private ListView hdrEnTransitoLSVT;
        private ColumnHeader colNHDR;
        private ColumnHeader colDomicilio;
        private ColumnHeader colCantEncomiendas;
        private Label hojasDeRutaEnTransitoLBL;
        private Button GenerarResumenBTN;
        private Button buscarBTN;
        private TextBox dniFleteroTXT;
        private Label dniFleteroLBL;
        private Label nombreFleteroLBL;
        private Label LeyendaLBL;
    }
}