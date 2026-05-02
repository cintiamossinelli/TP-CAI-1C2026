namespace TP_CAI_1C2026.Forms.UltimaMilla.RecepcionHDRAgencia
{
    partial class RecepcionHDRAgenciaFRM
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
            HDRnumCMB = new ComboBox();
            HDRnumLBL = new Label();
            SuspendLayout();
            // 
            // recibirHDRBTN
            // 
            recibirHDRBTN.Location = new Point(177, 315);
            recibirHDRBTN.Name = "recibirHDRBTN";
            recibirHDRBTN.Size = new Size(107, 32);
            recibirHDRBTN.TabIndex = 16;
            recibirHDRBTN.Text = "Recibir HDR";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(302, 315);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 17;
            cancelarBTN.Text = "Cancelar";
            // 
            // GuiasLST
            // 
            GuiasLST.Columns.AddRange(new ColumnHeader[] { TipoEncomiendaCol, NumGuiaCol });
            GuiasLST.GridLines = true;
            GuiasLST.Location = new Point(34, 76);
            GuiasLST.Name = "GuiasLST";
            GuiasLST.Size = new Size(348, 223);
            GuiasLST.TabIndex = 15;
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
            // HDRnumCMB
            // 
            HDRnumCMB.FormattingEnabled = true;
            HDRnumCMB.Location = new Point(160, 28);
            HDRnumCMB.Name = "HDRnumCMB";
            HDRnumCMB.Size = new Size(222, 28);
            HDRnumCMB.TabIndex = 14;
            // 
            // HDRnumLBL
            // 
            HDRnumLBL.AutoSize = true;
            HDRnumLBL.Location = new Point(34, 31);
            HDRnumLBL.Name = "HDRnumLBL";
            HDRnumLBL.Size = new Size(120, 20);
            HDRnumLBL.TabIndex = 13;
            HDRnumLBL.Text = "N° Hoja de Ruta:";
            // 
            // RecepcionHDRAgenciaFRM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 371);
            Controls.Add(recibirHDRBTN);
            Controls.Add(cancelarBTN);
            Controls.Add(GuiasLST);
            Controls.Add(HDRnumCMB);
            Controls.Add(HDRnumLBL);
            Name = "RecepcionHDRAgenciaFRM";
            Text = "Recepción de Hoja de Ruta en Agencia";
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
    }
}