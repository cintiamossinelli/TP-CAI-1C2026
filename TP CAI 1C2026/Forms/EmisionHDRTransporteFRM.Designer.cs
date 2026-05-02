namespace TP_CAI_1C2026.Forms
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
            generarHDRBTN = new Button();
            cancelarBTN = new Button();
            transporteCMB = new ComboBox();
            transporteLBL = new Label();
            seleccionarLBL = new Label();
            SuspendLayout();
            // 
            // CDdestinoLBL
            // 
            CDdestinoLBL.AutoSize = true;
            CDdestinoLBL.Location = new Point(38, 39);
            CDdestinoLBL.Name = "CDdestinoLBL";
            CDdestinoLBL.Size = new Size(87, 20);
            CDdestinoLBL.TabIndex = 0;
            CDdestinoLBL.Text = "CD Destino:";
            // 
            // CDdestinoCMB
            // 
            CDdestinoCMB.FormattingEnabled = true;
            CDdestinoCMB.Location = new Point(140, 36);
            CDdestinoCMB.Name = "CDdestinoCMB";
            CDdestinoCMB.Size = new Size(455, 28);
            CDdestinoCMB.TabIndex = 1;
            // 
            // GuiasLST
            // 
            GuiasLST.CheckBoxes = true;
            GuiasLST.Columns.AddRange(new ColumnHeader[] { TipoEncomiendaCol, DestinoCol, NumGuiaCol });
            GuiasLST.GridLines = true;
            GuiasLST.Location = new Point(38, 137);
            GuiasLST.Name = "GuiasLST";
            GuiasLST.Size = new Size(557, 223);
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
            DestinoCol.Width = 300;
            // 
            // NumGuiaCol
            // 
            NumGuiaCol.DisplayIndex = 0;
            NumGuiaCol.Text = "N° Guía";
            NumGuiaCol.TextAlign = HorizontalAlignment.Center;
            NumGuiaCol.Width = 100;
            // 
            // generarHDRBTN
            // 
            generarHDRBTN.Location = new Point(383, 374);
            generarHDRBTN.Name = "generarHDRBTN";
            generarHDRBTN.Size = new Size(107, 32);
            generarHDRBTN.TabIndex = 6;
            generarHDRBTN.Text = "Generar HDR";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(515, 374);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 7;
            cancelarBTN.Text = "Cancelar";
            // 
            // transporteCMB
            // 
            transporteCMB.FormattingEnabled = true;
            transporteCMB.Location = new Point(140, 73);
            transporteCMB.Name = "transporteCMB";
            transporteCMB.Size = new Size(455, 28);
            transporteCMB.TabIndex = 9;
            // 
            // transporteLBL
            // 
            transporteLBL.AutoSize = true;
            transporteLBL.Location = new Point(38, 76);
            transporteLBL.Name = "transporteLBL";
            transporteLBL.Size = new Size(82, 20);
            transporteLBL.TabIndex = 8;
            transporteLBL.Text = "Transporte:";
            // 
            // seleccionarLBL
            // 
            seleccionarLBL.AutoSize = true;
            seleccionarLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            seleccionarLBL.ForeColor = SystemColors.HotTrack;
            seleccionarLBL.Location = new Point(38, 114);
            seleccionarLBL.Name = "seleccionarLBL";
            seleccionarLBL.Size = new Size(186, 20);
            seleccionarLBL.TabIndex = 10;
            seleccionarLBL.Text = "Seleccione guías a enviar:";
            // 
            // EmisionHDRTransporteFRM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 424);
            Controls.Add(seleccionarLBL);
            Controls.Add(transporteCMB);
            Controls.Add(transporteLBL);
            Controls.Add(generarHDRBTN);
            Controls.Add(cancelarBTN);
            Controls.Add(GuiasLST);
            Controls.Add(CDdestinoCMB);
            Controls.Add(CDdestinoLBL);
            Name = "EmisionHDRTransporteFRM";
            Text = "Emisión de Hoja de Ruta de Ómnibus";
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
        private Button generarHDRBTN;
        private Button cancelarBTN;
        private ComboBox transporteCMB;
        private Label transporteLBL;
        private Label seleccionarLBL;
    }
}