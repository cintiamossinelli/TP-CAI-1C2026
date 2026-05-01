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
            salirBTN = new Button();
            mostrarEstadoLBL = new Label();
            SuspendLayout();
            // 
            // guiaLBL
            // 
            guiaLBL.AutoSize = true;
            guiaLBL.Location = new Point(22, 21);
            guiaLBL.Name = "guiaLBL";
            guiaLBL.Size = new Size(31, 15);
            guiaLBL.TabIndex = 0;
            guiaLBL.Text = "Guía";
            guiaLBL.Click += label1_Click;
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(324, 39);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(93, 26);
            buscarBTN.TabIndex = 1;
            buscarBTN.Text = "Buscar";
            buscarBTN.UseVisualStyleBackColor = true;
            // 
            // guiaTXT
            // 
            guiaTXT.Location = new Point(22, 39);
            guiaTXT.Name = "guiaTXT";
            guiaTXT.Size = new Size(288, 23);
            guiaTXT.TabIndex = 2;
            // 
            // estadoEncomiendaLBL
            // 
            estadoEncomiendaLBL.AutoSize = true;
            estadoEncomiendaLBL.Location = new Point(22, 91);
            estadoEncomiendaLBL.Name = "estadoEncomiendaLBL";
            estadoEncomiendaLBL.Size = new Size(127, 15);
            estadoEncomiendaLBL.TabIndex = 3;
            estadoEncomiendaLBL.Text = "Estado de Encomienda";
            // 
            // salirBTN
            // 
            salirBTN.Location = new Point(324, 154);
            salirBTN.Name = "salirBTN";
            salirBTN.Size = new Size(93, 26);
            salirBTN.TabIndex = 5;
            salirBTN.Text = "Salir";
            salirBTN.UseVisualStyleBackColor = true;
            // 
            // mostrarEstadoLBL
            // 
            mostrarEstadoLBL.AutoSize = true;
            mostrarEstadoLBL.BackColor = SystemColors.ActiveCaption;
            mostrarEstadoLBL.Location = new Point(22, 127);
            mostrarEstadoLBL.Name = "mostrarEstadoLBL";
            mostrarEstadoLBL.Size = new Size(127, 15);
            mostrarEstadoLBL.TabIndex = 6;
            mostrarEstadoLBL.Text = "Estado de Encomienda";
            // 
            // ConsultarTracking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 195);
            Controls.Add(mostrarEstadoLBL);
            Controls.Add(salirBTN);
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
        private Button salirBTN;
        private Label mostrarEstadoLBL;
    }
}