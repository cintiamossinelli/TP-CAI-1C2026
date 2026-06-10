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
            recibirHDRBTN.Location = new Point(221, 394);
            recibirHDRBTN.Margin = new Padding(4);
            recibirHDRBTN.Name = "recibirHDRBTN";
            recibirHDRBTN.Size = new Size(134, 40);
            recibirHDRBTN.TabIndex = 16;
            recibirHDRBTN.Text = "Recibir HDR";
            recibirHDRBTN.Click += recibirHDRBTN_Click;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(378, 394);
            cancelarBTN.Margin = new Padding(4);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(100, 40);
            cancelarBTN.TabIndex = 17;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // GuiasLST
            // 
            GuiasLST.Columns.AddRange(new ColumnHeader[] { NumGuiaCol, TipoEncomiendaCol });
            GuiasLST.GridLines = true;
            GuiasLST.Location = new Point(42, 95);
            GuiasLST.Margin = new Padding(4);
            GuiasLST.Name = "GuiasLST";
            GuiasLST.Size = new Size(434, 278);
            GuiasLST.TabIndex = 15;
            GuiasLST.UseCompatibleStateImageBehavior = false;
            GuiasLST.View = View.Details;
            //GuiasLST.SelectedIndexChanged += GuiasLST_SelectedIndexChanged;
            //GuiasLST.Click += GuiasLST_SelectedIndexChanged;
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
            HDRnumCMB.Location = new Point(200, 35);
            HDRnumCMB.Margin = new Padding(4);
            HDRnumCMB.Name = "HDRnumCMB";
            HDRnumCMB.Size = new Size(276, 33);
            HDRnumCMB.TabIndex = 14;
            HDRnumCMB.SelectedIndexChanged += HDRnumCMB_SelectedIndexChanged;
            HDRnumCMB.Click += HDRnumCMB_SelectedIndexChanged;
            // 
            // HDRnumLBL
            // 
            HDRnumLBL.AutoSize = true;
            HDRnumLBL.Location = new Point(42, 39);
            HDRnumLBL.Margin = new Padding(4, 0, 4, 0);
            HDRnumLBL.Name = "HDRnumLBL";
            HDRnumLBL.Size = new Size(144, 25);
            HDRnumLBL.TabIndex = 13;
            HDRnumLBL.Text = "N° Hoja de Ruta:";
            // 
            // RecepcionHDRAgenciaFRM
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 464);
            Controls.Add(recibirHDRBTN);
            Controls.Add(cancelarBTN);
            Controls.Add(GuiasLST);
            Controls.Add(HDRnumCMB);
            Controls.Add(HDRnumLBL);
            Margin = new Padding(4);
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