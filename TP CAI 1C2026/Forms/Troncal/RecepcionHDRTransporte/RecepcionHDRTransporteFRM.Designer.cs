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
            TipoEncomiendaCol = new ColumnHeader();
            NumGuiaCol = new ColumnHeader();
            DestinoCol = new ColumnHeader();
            HDRnumCMB = new ComboBox();
            HDRnumLBL = new Label();
            label1 = new Label();
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
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(454, 243);
            cancelarBTN.Margin = new Padding(3, 2, 3, 2);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(70, 24);
            cancelarBTN.TabIndex = 12;
            cancelarBTN.Text = "Cancelar";
            // 
            // GuiasLST
            // 
            GuiasLST.Columns.AddRange(new ColumnHeader[] { TipoEncomiendaCol, NumGuiaCol, DestinoCol });
            GuiasLST.GridLines = true;
            GuiasLST.Location = new Point(38, 64);
            GuiasLST.Margin = new Padding(3, 2, 3, 2);
            GuiasLST.Name = "GuiasLST";
            GuiasLST.Size = new Size(486, 164);
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
            HDRnumCMB.Location = new Point(134, 27);
            HDRnumCMB.Margin = new Padding(3, 2, 3, 2);
            HDRnumCMB.Name = "HDRnumCMB";
            HDRnumCMB.Size = new Size(376, 23);
            HDRnumCMB.TabIndex = 9;
            // 
            // HDRnumLBL
            // 
            HDRnumLBL.AutoSize = true;
            HDRnumLBL.Location = new Point(38, 30);
            HDRnumLBL.Name = "HDRnumLBL";
            HDRnumLBL.Size = new Size(90, 15);
            HDRnumLBL.TabIndex = 8;
            HDRnumLBL.Text = "Servicio (micro)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, 10);
            label1.Name = "label1";
            label1.Size = new Size(370, 15);
            label1.TabIndex = 13;
            label1.Text = "(lista todos los micros que están viniendo hacia el CD actual AHORA)";
            // 
            // RecepcionHDRTransporteFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 283);
            Controls.Add(label1);
            Controls.Add(recibirHDRBTN);
            Controls.Add(cancelarBTN);
            Controls.Add(GuiasLST);
            Controls.Add(HDRnumCMB);
            Controls.Add(HDRnumLBL);
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
        private ComboBox HDRnumCMB;
        private Label HDRnumLBL;
        private ColumnHeader DestinoCol;
        private Label label1;
    }
}