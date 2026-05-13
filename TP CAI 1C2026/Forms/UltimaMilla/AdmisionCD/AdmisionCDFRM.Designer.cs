namespace TP_CAI_1C2026.Forms.UltimaMilla.AdmisionCD
{
    partial class AdmisionCDFRM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            nGuiaLBL = new Label();
            nGuiaTXT = new TextBox();
            buscarBTN = new Button();
            guiasLST = new ListView();
            colNGuia = new ColumnHeader();
            colTipoCaja = new ColumnHeader();
            admitirBTN = new Button();
            rechazarBTN = new Button();
            cancelarBTN = new Button();
            SuspendLayout();
            // 
            // nGuiaLBL
            // 
            nGuiaLBL.Location = new Point(16, 15);
            nGuiaLBL.Name = "nGuiaLBL";
            nGuiaLBL.Size = new Size(51, 23);
            nGuiaLBL.TabIndex = 0;
            nGuiaLBL.Text = "N° Guía:";
            nGuiaLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nGuiaTXT
            // 
            nGuiaTXT.Location = new Point(69, 16);
            nGuiaTXT.Name = "nGuiaTXT";
            nGuiaTXT.Size = new Size(363, 23);
            nGuiaTXT.TabIndex = 1;
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(438, 14);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(80, 27);
            buscarBTN.TabIndex = 2;
            buscarBTN.Text = "Buscar";
            buscarBTN.Click += buscarBTN_Click;
            // 
            // guiasLST
            // 
            guiasLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colTipoCaja });
            guiasLST.FullRowSelect = true;
            guiasLST.GridLines = true;
            guiasLST.Location = new Point(12, 55);
            guiasLST.Name = "guiasLST";
            guiasLST.Size = new Size(506, 200);
            guiasLST.TabIndex = 3;
            guiasLST.UseCompatibleStateImageBehavior = false;
            guiasLST.View = View.Details;
            // 
            // colNGuia
            // 
            colNGuia.Text = "N° Guía";
            colNGuia.Width = 200;
            // 
            // colTipoCaja
            // 
            colTipoCaja.Text = "Tipo de Caja";
            colTipoCaja.Width = 200;
            // 
            // admitirBTN
            // 
            admitirBTN.Location = new Point(12, 261);
            admitirBTN.Name = "admitirBTN";
            admitirBTN.Size = new Size(248, 32);
            admitirBTN.TabIndex = 4;
            admitirBTN.Text = "Admitir";
            admitirBTN.Click += admitirBTN_Click;
            // 
            // rechazarBTN
            // 
            rechazarBTN.Location = new Point(270, 261);
            rechazarBTN.Name = "rechazarBTN";
            rechazarBTN.Size = new Size(248, 32);
            rechazarBTN.TabIndex = 5;
            rechazarBTN.Text = "Rechazar";
            rechazarBTN.Click += rechazarBTN_Click;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(438, 315);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 6;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // AdmisionCDFRM
            // 
            ClientSize = new Size(530, 358);
            Controls.Add(nGuiaLBL);
            Controls.Add(nGuiaTXT);
            Controls.Add(buscarBTN);
            Controls.Add(guiasLST);
            Controls.Add(admitirBTN);
            Controls.Add(rechazarBTN);
            Controls.Add(cancelarBTN);
            Name = "AdmisionCDFRM";
            Text = "Admisión en Centro de Distribución";
            Load += AdmisionCDFRM_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label nGuiaLBL;
        private TextBox nGuiaTXT;
        private Button buscarBTN;
        private ListView guiasLST;
        private ColumnHeader colNGuia;
        private ColumnHeader colTipoCaja;
        private Button admitirBTN;
        private Button rechazarBTN;
        private Button cancelarBTN;
    }
}