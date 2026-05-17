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
            servicioOmnibusBTN = new ComboBox();
            servicioOmnibusLBL = new Label();
            SuspendLayout();
            // 
            // recibirHDRBTN
            // 
            recibirHDRBTN.Location = new Point(394, 324);
            recibirHDRBTN.Name = "recibirHDRBTN";
            recibirHDRBTN.Size = new Size(107, 32);
            recibirHDRBTN.TabIndex = 11;
            recibirHDRBTN.Text = "Recibir HDR";
            recibirHDRBTN.Click += recibirHDRBTN_Click;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(519, 324);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 12;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // GuiasLST
            // 
            GuiasLST.Columns.AddRange(new ColumnHeader[] { NumGuiaCol, TipoEncomiendaCol, DestinoCol });
            GuiasLST.GridLines = true;
            GuiasLST.Location = new Point(43, 85);
            GuiasLST.Name = "GuiasLST";
            GuiasLST.Size = new Size(555, 217);
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
            // servicioOmnibusBTN
            // 
            servicioOmnibusBTN.FormattingEnabled = true;
            servicioOmnibusBTN.Location = new Point(113, 37);
            servicioOmnibusBTN.Name = "servicioOmnibusBTN";
            servicioOmnibusBTN.Size = new Size(485, 28);
            servicioOmnibusBTN.TabIndex = 9;
            servicioOmnibusBTN.SelectedIndexChanged += servicioOmnibusBTN_SelectedIndexChanged;
            // 
            // servicioOmnibusLBL
            // 
            servicioOmnibusLBL.AutoSize = true;
            servicioOmnibusLBL.Location = new Point(43, 40);
            servicioOmnibusLBL.Name = "servicioOmnibusLBL";
            servicioOmnibusLBL.Size = new Size(64, 20);
            servicioOmnibusLBL.TabIndex = 8;
            servicioOmnibusLBL.Text = "Servicio:";
            // 
            // RecepcionHDRTransporteFRM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 377);
            Controls.Add(recibirHDRBTN);
            Controls.Add(cancelarBTN);
            Controls.Add(GuiasLST);
            Controls.Add(servicioOmnibusBTN);
            Controls.Add(servicioOmnibusLBL);
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
        private ComboBox servicioOmnibusBTN;
        private Label servicioOmnibusLBL;
        private ColumnHeader DestinoCol;
    }
}