namespace TP_CAI_1C2026.Forms
{
    partial class AdmisionCDFRM
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
            selecGuiasAdmLBL = new Label();
            historialLST = new ListView();
            colNGuia = new ColumnHeader();
            colTipoEncomienda = new ColumnHeader();
            admitirBTN = new Button();
            cancelarBTN = new Button();
            SuspendLayout();
            // 
            // selecGuiasAdmLBL
            // 
            selecGuiasAdmLBL.AutoSize = true;
            selecGuiasAdmLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selecGuiasAdmLBL.ForeColor = SystemColors.HotTrack;
            selecGuiasAdmLBL.Location = new Point(12, 18);
            selecGuiasAdmLBL.Name = "selecGuiasAdmLBL";
            selecGuiasAdmLBL.Size = new Size(154, 15);
            selecGuiasAdmLBL.TabIndex = 5;
            selecGuiasAdmLBL.Text = "Seleccione Guías a Admitir";
            // 
            // historialLST
            // 
            historialLST.CheckBoxes = true;
            historialLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colTipoEncomienda });
            historialLST.FullRowSelect = true;
            historialLST.GridLines = true;
            historialLST.Location = new Point(12, 45);
            historialLST.Name = "historialLST";
            historialLST.Size = new Size(472, 261);
            historialLST.TabIndex = 7;
            historialLST.UseCompatibleStateImageBehavior = false;
            historialLST.View = View.Details;
            // 
            // colNGuia
            // 
            colNGuia.Text = "N° Guía";
            colNGuia.Width = 100;
            // 
            // colTipoEncomienda
            // 
            colTipoEncomienda.Text = "Tipo de Encomienda";
            colTipoEncomienda.Width = 120;
            // 
            // admitirBTN
            // 
            admitirBTN.Location = new Point(249, 323);
            admitirBTN.Name = "admitirBTN";
            admitirBTN.Size = new Size(109, 30);
            admitirBTN.TabIndex = 8;
            admitirBTN.Text = "Admitir";
            admitirBTN.UseVisualStyleBackColor = true;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(375, 323);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(109, 30);
            cancelarBTN.TabIndex = 9;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.UseVisualStyleBackColor = true;
            // 
            // AdmisionCDFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 365);
            Controls.Add(cancelarBTN);
            Controls.Add(admitirBTN);
            Controls.Add(historialLST);
            Controls.Add(selecGuiasAdmLBL);
            Name = "AdmisionCDFRM";
            Text = "Admisión en Centro de Distribución";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label selecGuiasAdmLBL;
        private ListView historialLST;
        private ColumnHeader colNGuia;
        private ColumnHeader colTipoEncomienda;
        private Button admitirBTN;
        private Button cancelarBTN;
    }
}