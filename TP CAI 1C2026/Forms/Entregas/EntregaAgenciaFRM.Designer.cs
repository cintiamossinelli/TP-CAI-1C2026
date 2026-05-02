namespace TP_CAI_1C2026
{
    partial class EntregaAgenciaFRM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dniLBL = new Label();
            dniTXT = new TextBox();
            buscarBTN = new Button();
            guiasGBX = new GroupBox();
            guiasLST = new ListView();
            colNGuia = new ColumnHeader();
            colEstado = new ColumnHeader();
            colTipoPaquete = new ColumnHeader();
            retirarBTN = new Button();
            cancelarBTN = new Button();
            guiasGBX.SuspendLayout();
            SuspendLayout();
            // 
            // dniLBL
            // 
            dniLBL.Location = new Point(20, 18);
            dniLBL.Name = "dniLBL";
            dniLBL.Size = new Size(96, 23);
            dniLBL.TabIndex = 0;
            dniLBL.Text = "DNI Destinatario:";
            dniLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dniTXT
            // 
            dniTXT.Location = new Point(120, 18);
            dniTXT.MaxLength = 11;
            dniTXT.Name = "dniTXT";
            dniTXT.Size = new Size(180, 23);
            dniTXT.TabIndex = 1;
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(306, 16);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(80, 27);
            buscarBTN.TabIndex = 2;
            buscarBTN.Text = "Buscar";
            // 
            // guiasGBX
            // 
            guiasGBX.Controls.Add(guiasLST);
            guiasGBX.Location = new Point(12, 55);
            guiasGBX.Name = "guiasGBX";
            guiasGBX.Size = new Size(587, 300);
            guiasGBX.TabIndex = 3;
            guiasGBX.TabStop = false;
            guiasGBX.Text = "Guías Asociadas";
            // 
            // guiasLST
            // 
            guiasLST.CheckBoxes = true;
            guiasLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colEstado, colTipoPaquete });
            guiasLST.FullRowSelect = true;
            guiasLST.GridLines = true;
            guiasLST.Location = new Point(10, 25);
            guiasLST.Name = "guiasLST";
            guiasLST.Size = new Size(566, 260);
            guiasLST.TabIndex = 0;
            guiasLST.UseCompatibleStateImageBehavior = false;
            guiasLST.View = View.Details;
            // 
            // colNGuia
            // 
            colNGuia.Text = "N° Guía";
            colNGuia.Width = 150;
            // 
            // colEstado
            // 
            colEstado.Text = "Estado";
            colEstado.Width = 200;
            // 
            // colTipoPaquete
            // 
            colTipoPaquete.Text = "Tipo de Paquete";
            colTipoPaquete.Width = 200;
            // 
            // retirarBTN
            // 
            retirarBTN.Location = new Point(433, 376);
            retirarBTN.Name = "retirarBTN";
            retirarBTN.Size = new Size(80, 32);
            retirarBTN.TabIndex = 4;
            retirarBTN.Text = "Retirar";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(519, 376);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 5;
            cancelarBTN.Text = "Cancelar";
            // 
            // EntregaAgenciaFRM
            // 
            ClientSize = new Size(612, 420);
            Controls.Add(dniLBL);
            Controls.Add(dniTXT);
            Controls.Add(buscarBTN);
            Controls.Add(guiasGBX);
            Controls.Add(retirarBTN);
            Controls.Add(cancelarBTN);
            Name = "EntregaAgenciaFRM";
            Text = "Entrega de Encomienda - Agencia";
            guiasGBX.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label dniLBL;
        private TextBox dniTXT;
        private Button buscarBTN;
        private GroupBox guiasGBX;
        private ListView guiasLST;
        private ColumnHeader colNGuia;
        private ColumnHeader colEstado;
        private ColumnHeader colTipoPaquete;
        private Button retirarBTN;
        private Button cancelarBTN;
    }
}