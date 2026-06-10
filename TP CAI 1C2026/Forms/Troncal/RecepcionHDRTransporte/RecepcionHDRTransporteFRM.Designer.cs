namespace TP_CAI_1C2026.Forms.Troncal.RecepcionHDRTransporte
{
    partial class RecepcionHDRTransporteFRM
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
            recibirHDRBTN = new Button();
            cancelarBTN = new Button();
            GuiasLST = new ListView();
            NumGuiaCol = new ColumnHeader();
            TipoEncomiendaCol = new ColumnHeader();
            DestinoCol = new ColumnHeader();
            servicioOmnibusCMB = new ComboBox();
            servicioOmnibusLBL = new Label();
            SuspendLayout();
            // 
            // recibirHDRBTN
            // 
            recibirHDRBTN.Location = new Point(345, 243);
            recibirHDRBTN.Margin = new Padding(3, 2, 3, 2);
            recibirHDRBTN.Name = "recibirHDRBTN";
            recibirHDRBTN.Size = new Size(94, 24);
            recibirHDRBTN.TabIndex = 11;
            recibirHDRBTN.Text = "Recibir HDR";
            recibirHDRBTN.Click += recibirHDRBTN_Click;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(454, 243);
            cancelarBTN.Margin = new Padding(3, 2, 3, 2);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(70, 24);
            cancelarBTN.TabIndex = 12;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // GuiasLST
            // 
            GuiasLST.Columns.AddRange(new ColumnHeader[] { NumGuiaCol, TipoEncomiendaCol, DestinoCol });
            GuiasLST.GridLines = true;
            GuiasLST.Location = new Point(38, 64);
            GuiasLST.Margin = new Padding(3, 2, 3, 2);
            GuiasLST.Name = "GuiasLST";
            GuiasLST.Size = new Size(486, 164);
            GuiasLST.TabIndex = 10;
            GuiasLST.UseCompatibleStateImageBehavior = false;
            GuiasLST.View = View.Details;
            // 
            // NumGuiaCol
            // 
            NumGuiaCol.Text = "N° Guía";
            NumGuiaCol.TextAlign = HorizontalAlignment.Center;
            NumGuiaCol.Width = 100;
            // 
            // TipoEncomiendaCol
            // 
            TipoEncomiendaCol.Text = "Tipo de Encomienda";
            TipoEncomiendaCol.TextAlign = HorizontalAlignment.Center;
            TipoEncomiendaCol.Width = 150;
            // 
            // DestinoCol
            // 
            DestinoCol.Text = "Destino";
            DestinoCol.TextAlign = HorizontalAlignment.Center;
            DestinoCol.Width = 300;
            // 
            // servicioOmnibusCMB
            // 
            servicioOmnibusCMB.FormattingEnabled = true;
            servicioOmnibusCMB.Location = new Point(99, 28);
            servicioOmnibusCMB.Margin = new Padding(3, 2, 3, 2);
            servicioOmnibusCMB.Name = "servicioOmnibusCMB";
            servicioOmnibusCMB.Size = new Size(425, 23);
            servicioOmnibusCMB.TabIndex = 9;
            servicioOmnibusCMB.SelectedIndexChanged += servicioOmnibusCMB_SelectedIndexChanged;
            // 
            // servicioOmnibusLBL
            // 
            servicioOmnibusLBL.AutoSize = true;
            servicioOmnibusLBL.Location = new Point(38, 30);
            servicioOmnibusLBL.Name = "servicioOmnibusLBL";
            servicioOmnibusLBL.Size = new Size(51, 15);
            servicioOmnibusLBL.TabIndex = 8;
            servicioOmnibusLBL.Text = "Servicio:";
            // 
            // RecepcionHDRTransporteFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 283);
            Controls.Add(recibirHDRBTN);
            Controls.Add(cancelarBTN);
            Controls.Add(GuiasLST);
            Controls.Add(servicioOmnibusCMB);
            Controls.Add(servicioOmnibusLBL);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RecepcionHDRTransporteFRM";
            Text = "Recepción de Hoja de Ruta de Ómnibus";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button recibirHDRBTN;
        private Button cancelarBTN;
        private ListView GuiasLST;
        private ColumnHeader TipoEncomiendaCol;
        private ColumnHeader NumGuiaCol;
        private ComboBox servicioOmnibusCMB;
        private Label servicioOmnibusLBL;
        private ColumnHeader DestinoCol;
    }
}