namespace TP_CAI_1C2026
{
    partial class ConsultarTrackingFRM
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
            guiaLBL = new Label();
            buscarBTN = new Button();
            guiaTXT = new TextBox();
            historialLBL = new Label();
            historialLST = new ListView();
            colEstado = new ColumnHeader();
            colTipoPaquete = new ColumnHeader();
            colIdCliente = new ColumnHeader();
            colDniAutorizado = new ColumnHeader();
            cancelarBTN = new Button();
            colNGuia = new ColumnHeader();
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
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(324, 37);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(93, 26);
            buscarBTN.TabIndex = 2;
            buscarBTN.Text = "Buscar";
            // 
            // guiaTXT
            // 
            guiaTXT.Location = new Point(22, 39);
            guiaTXT.Name = "guiaTXT";
            guiaTXT.Size = new Size(288, 23);
            guiaTXT.TabIndex = 1;
            // 
            // historialLBL
            // 
            historialLBL.AutoSize = true;
            historialLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            historialLBL.Location = new Point(22, 80);
            historialLBL.Name = "historialLBL";
            historialLBL.Size = new Size(104, 15);
            historialLBL.TabIndex = 5;
            historialLBL.Text = "Detalle de la Guía";
            // 
            // historialLST
            // 
            historialLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colEstado, colTipoPaquete, colIdCliente, colDniAutorizado });
            historialLST.FullRowSelect = true;
            historialLST.GridLines = true;
            historialLST.Location = new Point(22, 98);
            historialLST.Name = "historialLST";
            historialLST.Size = new Size(646, 214);
            historialLST.TabIndex = 6;
            historialLST.UseCompatibleStateImageBehavior = false;
            historialLST.View = View.Details;
            // 
            // colEstado
            // 
            colEstado.Text = "Estado de Encomienda";
            colEstado.Width = 135;
            // 
            // colTipoPaquete
            // 
            colTipoPaquete.Text = "Tipo de paquete";
            colTipoPaquete.Width = 100;
            // 
            // colIdCliente
            // 
            colIdCliente.Text = "CUIT/DNI/CUIL";
            colIdCliente.Width = 100;
            // 
            // colDniAutorizado
            // 
            colDniAutorizado.Text = "DNI autorizado a retirar";
            colDniAutorizado.Width = 150;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(499, 450);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(93, 26);
            cancelarBTN.TabIndex = 7;
            cancelarBTN.Text = "Cancelar";
            // 
            // colNGuia
            // 
            colNGuia.Text = "Fecha";
            colNGuia.Width = 135;
            // 
            // ConsultarTrackingFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 582);
            Controls.Add(guiaLBL);
            Controls.Add(guiaTXT);
            Controls.Add(buscarBTN);
            Controls.Add(historialLBL);
            Controls.Add(historialLST);
            Controls.Add(cancelarBTN);
            Name = "ConsultarTrackingFRM";
            Text = "Consultar Tracking";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label guiaLBL;
        private Button buscarBTN;
        private TextBox guiaTXT;
        private Label historialLBL;
        private ListView historialLST;
        private ColumnHeader colEstado;
        private ColumnHeader colTipoPaquete;
        private ColumnHeader colIdCliente;
        private ColumnHeader colDniAutorizado;
        private Button cancelarBTN;
        private ColumnHeader colNGuia;
    }
}