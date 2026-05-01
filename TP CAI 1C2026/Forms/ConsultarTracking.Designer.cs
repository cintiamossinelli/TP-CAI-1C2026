namespace TP_CAI_1C2026.Forms
{
    partial class ConsultarTracking
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
            guiaLBL = new Label();
            buscarBTN = new Button();
            guiaTXT = new TextBox();
            estadoEncomiendaLBL = new Label();
            estadoEncomiendaTXT = new TextBox();
            cancelarBTN = new Button();
            SuspendLayout();
            // 
            // guiaLBL
            // 
            guiaLBL.AutoSize = true;
            guiaLBL.Location = new Point(34, 50);
            guiaLBL.Name = "guiaLBL";
            guiaLBL.Size = new Size(31, 15);
            guiaLBL.TabIndex = 0;
            guiaLBL.Text = "Guía";
            guiaLBL.Click += label1_Click;
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(314, 65);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(93, 26);
            buscarBTN.TabIndex = 1;
            buscarBTN.Text = "Buscar";
            buscarBTN.UseVisualStyleBackColor = true;
            // 
            // guiaTXT
            // 
            guiaTXT.Location = new Point(34, 68);
            guiaTXT.Name = "guiaTXT";
            guiaTXT.Size = new Size(248, 23);
            guiaTXT.TabIndex = 2;
            // 
            // estadoEncomiendaLBL
            // 
            estadoEncomiendaLBL.AutoSize = true;
            estadoEncomiendaLBL.Location = new Point(34, 125);
            estadoEncomiendaLBL.Name = "estadoEncomiendaLBL";
            estadoEncomiendaLBL.Size = new Size(127, 15);
            estadoEncomiendaLBL.TabIndex = 3;
            estadoEncomiendaLBL.Text = "Estado de Encomienda";
            // 
            // estadoEncomiendaTXT
            // 
            estadoEncomiendaTXT.Location = new Point(34, 159);
            estadoEncomiendaTXT.Name = "estadoEncomiendaTXT";
            estadoEncomiendaTXT.Size = new Size(248, 23);
            estadoEncomiendaTXT.TabIndex = 4;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(314, 210);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(93, 26);
            cancelarBTN.TabIndex = 5;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.UseVisualStyleBackColor = true;
            // 
            // ConsultarTracking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 257);
            Controls.Add(cancelarBTN);
            Controls.Add(estadoEncomiendaTXT);
            Controls.Add(estadoEncomiendaLBL);
            Controls.Add(guiaTXT);
            Controls.Add(buscarBTN);
            Controls.Add(guiaLBL);
            Name = "ConsultarTracking";
            Text = "Consultar Tracking";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label guiaLBL;
        private Button buscarBTN;
        private TextBox guiaTXT;
        private Label estadoEncomiendaLBL;
        private TextBox estadoEncomiendaTXT;
        private Button cancelarBTN;
    }
}