namespace TP_CAI_1C2026.Forms
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
            TipoEncomiendaCol = new ColumnHeader();
            NumGuiaCol = new ColumnHeader();
            DestinoCol = new ColumnHeader();
            HDRnumCMB = new ComboBox();
            HDRnumLBL = new Label();
            SuspendLayout();
            // 
            // recibirHDRBTN
            // 
            recibirHDRBTN.Location = new Point(394, 324);
            recibirHDRBTN.Name = "recibirHDRBTN";
            recibirHDRBTN.Size = new Size(107, 32);
            recibirHDRBTN.TabIndex = 11;
            recibirHDRBTN.Text = "Recibir HDR";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(519, 324);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 12;
            cancelarBTN.Text = "Cancelar";
            // 
            // GuiasLST
            // 
            GuiasLST.Columns.AddRange(new ColumnHeader[] { TipoEncomiendaCol, NumGuiaCol, DestinoCol });
            GuiasLST.GridLines = true;
            GuiasLST.Location = new Point(44, 85);
            GuiasLST.Name = "GuiasLST";
            GuiasLST.Size = new Size(555, 223);
            GuiasLST.TabIndex = 10;
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
            // NumGuiaCol
            // 
            NumGuiaCol.DisplayIndex = 0;
            NumGuiaCol.Text = "N° Guía";
            NumGuiaCol.TextAlign = HorizontalAlignment.Center;
            NumGuiaCol.Width = 100;
            // 
            // DestinoCol
            // 
            DestinoCol.Text = "Destino";
            DestinoCol.TextAlign = HorizontalAlignment.Center;
            DestinoCol.Width = 300;
            // 
            // HDRnumCMB
            // 
            HDRnumCMB.FormattingEnabled = true;
            HDRnumCMB.Location = new Point(170, 37);
            HDRnumCMB.Name = "HDRnumCMB";
            HDRnumCMB.Size = new Size(429, 28);
            HDRnumCMB.TabIndex = 9;
            // 
            // HDRnumLBL
            // 
            HDRnumLBL.AutoSize = true;
            HDRnumLBL.Location = new Point(44, 40);
            HDRnumLBL.Name = "HDRnumLBL";
            HDRnumLBL.Size = new Size(120, 20);
            HDRnumLBL.TabIndex = 8;
            HDRnumLBL.Text = "N° Hoja de Ruta:";
            // 
            // RecepcionHDRTransporteFRM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 377);
            Controls.Add(recibirHDRBTN);
            Controls.Add(cancelarBTN);
            Controls.Add(GuiasLST);
            Controls.Add(HDRnumCMB);
            Controls.Add(HDRnumLBL);
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
        private ComboBox HDRnumCMB;
        private Label HDRnumLBL;
        private ColumnHeader DestinoCol;
    }
}