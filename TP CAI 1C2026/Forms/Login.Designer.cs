namespace TP_CAI_1C2026.Forms
{
    partial class Login
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
            cdRDB = new RadioButton();
            agenciaRDB = new RadioButton();
            callcenterRDB = new RadioButton();
            cdCMB = new ComboBox();
            agenciaCMB = new ComboBox();
            confirmarBTN = new Button();
            SuspendLayout();
            // 
            // cdRDB
            // 
            cdRDB.AutoSize = true;
            cdRDB.Location = new Point(33, 37);
            cdRDB.Name = "cdRDB";
            cdRDB.Size = new Size(41, 19);
            cdRDB.TabIndex = 0;
            cdRDB.TabStop = true;
            cdRDB.Text = "CD";
            cdRDB.UseVisualStyleBackColor = true;
            // 
            // agenciaRDB
            // 
            agenciaRDB.AutoSize = true;
            agenciaRDB.Location = new Point(33, 77);
            agenciaRDB.Name = "agenciaRDB";
            agenciaRDB.Size = new Size(68, 19);
            agenciaRDB.TabIndex = 1;
            agenciaRDB.TabStop = true;
            agenciaRDB.Text = "Agencia";
            agenciaRDB.UseVisualStyleBackColor = true;
            // 
            // callcenterRDB
            // 
            callcenterRDB.AutoSize = true;
            callcenterRDB.Location = new Point(33, 114);
            callcenterRDB.Name = "callcenterRDB";
            callcenterRDB.Size = new Size(83, 19);
            callcenterRDB.TabIndex = 2;
            callcenterRDB.TabStop = true;
            callcenterRDB.Text = "Call Center";
            callcenterRDB.UseVisualStyleBackColor = true;
            // 
            // cdCMB
            // 
            cdCMB.FormattingEnabled = true;
            cdCMB.Location = new Point(133, 33);
            cdCMB.Name = "cdCMB";
            cdCMB.Size = new Size(195, 23);
            cdCMB.TabIndex = 3;
            // 
            // agenciaCMB
            // 
            agenciaCMB.FormattingEnabled = true;
            agenciaCMB.Location = new Point(133, 73);
            agenciaCMB.Name = "agenciaCMB";
            agenciaCMB.Size = new Size(195, 23);
            agenciaCMB.TabIndex = 4;
            // 
            // confirmarBTN
            // 
            confirmarBTN.Location = new Point(96, 158);
            confirmarBTN.Name = "confirmarBTN";
            confirmarBTN.Size = new Size(180, 25);
            confirmarBTN.TabIndex = 5;
            confirmarBTN.Text = "Confirmar";
            confirmarBTN.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 211);
            Controls.Add(confirmarBTN);
            Controls.Add(agenciaCMB);
            Controls.Add(cdCMB);
            Controls.Add(callcenterRDB);
            Controls.Add(agenciaRDB);
            Controls.Add(cdRDB);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton cdRDB;
        private RadioButton agenciaRDB;
        private RadioButton callcenterRDB;
        private ComboBox cdCMB;
        private ComboBox agenciaCMB;
        private Button confirmarBTN;
    }
}
