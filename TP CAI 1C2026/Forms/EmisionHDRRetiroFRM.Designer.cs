namespace TP_CAI_1C2026
{
    partial class EmisionHDRRetiroFRM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dniFleteroLBL = new Label();
            dniFleteroTXT = new TextBox();
            buscarFleteroTBN = new Button();
            nombreFleteroLBL = new Label();
            guiasLST = new ListView();
            colNGuia = new ColumnHeader();
            colTipoCaja = new ColumnHeader();
            colLugarRetiro = new ColumnHeader();
            generarHDRBTN = new Button();
            cancelarBTN = new Button();
            seleccionLBL = new Label();
            SuspendLayout();
            // 
            // dniFleteroLBL
            // 
            dniFleteroLBL.Location = new Point(13, 15);
            dniFleteroLBL.Name = "dniFleteroLBL";
            dniFleteroLBL.Size = new Size(70, 23);
            dniFleteroLBL.TabIndex = 0;
            dniFleteroLBL.Text = "DNI Fletero:";
            dniFleteroLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dniFleteroTXT
            // 
            dniFleteroTXT.Location = new Point(89, 16);
            dniFleteroTXT.MaxLength = 11;
            dniFleteroTXT.Name = "dniFleteroTXT";
            dniFleteroTXT.Size = new Size(150, 23);
            dniFleteroTXT.TabIndex = 1;
            // 
            // buscarFleteroTBN
            // 
            buscarFleteroTBN.Location = new Point(253, 14);
            buscarFleteroTBN.Name = "buscarFleteroTBN";
            buscarFleteroTBN.Size = new Size(80, 27);
            buscarFleteroTBN.TabIndex = 2;
            buscarFleteroTBN.Text = "Buscar";
            // 
            // nombreFleteroLBL
            // 
            nombreFleteroLBL.BackColor = SystemColors.ActiveCaption;
            nombreFleteroLBL.Location = new Point(348, 16);
            nombreFleteroLBL.Name = "nombreFleteroLBL";
            nombreFleteroLBL.Size = new Size(128, 23);
            nombreFleteroLBL.TabIndex = 3;
            nombreFleteroLBL.Text = "Nombre del Fletero";
            // 
            // guiasLST
            // 
            guiasLST.CheckBoxes = true;
            guiasLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colTipoCaja, colLugarRetiro });
            guiasLST.FullRowSelect = true;
            guiasLST.GridLines = true;
            guiasLST.Location = new Point(12, 80);
            guiasLST.Name = "guiasLST";
            guiasLST.Size = new Size(649, 330);
            guiasLST.TabIndex = 4;
            guiasLST.UseCompatibleStateImageBehavior = false;
            guiasLST.View = View.Details;
            // 
            // colNGuia
            // 
            colNGuia.Text = "N° Guía";
            colNGuia.Width = 120;
            // 
            // colTipoCaja
            // 
            colTipoCaja.Text = "Tipo de Caja";
            colTipoCaja.Width = 120;
            // 
            // colLugarRetiro
            // 
            colLugarRetiro.Text = "Lugar de Retiro";
            colLugarRetiro.Width = 380;
            // 
            // generarHDRBTN
            // 
            generarHDRBTN.Location = new Point(487, 434);
            generarHDRBTN.Name = "generarHDRBTN";
            generarHDRBTN.Size = new Size(90, 32);
            generarHDRBTN.TabIndex = 5;
            generarHDRBTN.Text = "Generar HDR";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(582, 434);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 6;
            cancelarBTN.Text = "Cancelar";
            // 
            // seleccionLBL
            // 
            seleccionLBL.AutoSize = true;
            seleccionLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            seleccionLBL.ForeColor = Color.Blue;
            seleccionLBL.Location = new Point(12, 62);
            seleccionLBL.Name = "seleccionLBL";
            seleccionLBL.Size = new Size(168, 15);
            seleccionLBL.TabIndex = 7;
            seleccionLBL.Text = "Seleccionar guías para retirar";
            // 
            // EmisionHDRRetiroFRM
            // 
            ClientSize = new Size(674, 477);
            Controls.Add(seleccionLBL);
            Controls.Add(dniFleteroLBL);
            Controls.Add(dniFleteroTXT);
            Controls.Add(buscarFleteroTBN);
            Controls.Add(nombreFleteroLBL);
            Controls.Add(guiasLST);
            Controls.Add(generarHDRBTN);
            Controls.Add(cancelarBTN);
            Name = "EmisionHDRRetiroFRM";
            Text = "Emisión de HDR de Retiro";
            Load += EmisionHDRRetiroFRM_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label dniFleteroLBL;
        private TextBox dniFleteroTXT;
        private Button buscarFleteroTBN;
        private Label nombreFleteroLBL;
        private ListView guiasLST;
        private ColumnHeader colNGuia;
        private ColumnHeader colTipoCaja;
        private ColumnHeader colLugarRetiro;
        private Button generarHDRBTN;
        private Button cancelarBTN;
        private Label seleccionLBL;
    }
}