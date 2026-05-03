using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TP_CAI_1C2026.Forms.Administracion.EmisionFactura
{
    partial class EmisionFacturaFRM
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
            idClienteLBL = new Label();
            idClienteTXT = new TextBox();
            buscarClienteBTN = new Button();
            nombreClienteLBL = new Label();
            guiasEntregadasPendientesLST = new ListView();
            colNGuia = new ColumnHeader();
            colFecha = new ColumnHeader();
            colMonto = new ColumnHeader();
            totalLBL = new Label();
            totalFacturarLBL = new Label();
            emitirFacturaBTN = new Button();
            cancelarBTN = new Button();
            SuspendLayout();
            // 
            // idClienteLBL
            // 
            idClienteLBL.Location = new Point(12, 20);
            idClienteLBL.Name = "idClienteLBL";
            idClienteLBL.Size = new Size(105, 23);
            idClienteLBL.TabIndex = 0;
            idClienteLBL.Text = "CUIT / DNI / CUIL:";
            idClienteLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // idClienteTXT
            // 
            idClienteTXT.Location = new Point(123, 18);
            idClienteTXT.MaxLength = 11;
            idClienteTXT.Name = "idClienteTXT";
            idClienteTXT.Size = new Size(130, 23);
            idClienteTXT.TabIndex = 1;
            // 
            // buscarClienteBTN
            // 
            buscarClienteBTN.Location = new Point(259, 16);
            buscarClienteBTN.Name = "buscarClienteBTN";
            buscarClienteBTN.Size = new Size(65, 27);
            buscarClienteBTN.TabIndex = 2;
            buscarClienteBTN.Text = "Buscar Cliente";
            // 
            // nombreClienteLBL
            // 
            nombreClienteLBL.BackColor = SystemColors.ActiveCaption;
            nombreClienteLBL.Location = new Point(330, 18);
            nombreClienteLBL.Name = "nombreClienteLBL";
            nombreClienteLBL.Size = new Size(222, 25);
            nombreClienteLBL.TabIndex = 3;
            nombreClienteLBL.Text = "Nombre del Cliente";
            // 
            // guiasEntregadasPendientesLST
            // 
            guiasEntregadasPendientesLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colFecha, colMonto });
            guiasEntregadasPendientesLST.FullRowSelect = true;
            guiasEntregadasPendientesLST.GridLines = true;
            guiasEntregadasPendientesLST.Location = new Point(12, 60);
            guiasEntregadasPendientesLST.Name = "guiasEntregadasPendientesLST";
            guiasEntregadasPendientesLST.Size = new Size(540, 210);
            guiasEntregadasPendientesLST.TabIndex = 4;
            guiasEntregadasPendientesLST.UseCompatibleStateImageBehavior = false;
            guiasEntregadasPendientesLST.View = View.Details;
            // 
            // colNGuia
            // 
            colNGuia.Text = "N° Guía";
            colNGuia.Width = 150;
            // 
            // colFecha
            // 
            colFecha.Text = "Fecha";
            colFecha.TextAlign = HorizontalAlignment.Center;
            colFecha.Width = 200;
            // 
            // colMonto
            // 
            colMonto.Text = "Monto";
            colMonto.TextAlign = HorizontalAlignment.Center;
            colMonto.Width = 200;
            // 
            // totalLBL
            // 
            totalLBL.AutoSize = true;
            totalLBL.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            totalLBL.Location = new Point(438, 285);
            totalLBL.Name = "totalLBL";
            totalLBL.Size = new Size(52, 21);
            totalLBL.TabIndex = 5;
            totalLBL.Text = "Total:";
            // 
            // totalFacturarLBL
            // 
            totalFacturarLBL.AutoSize = true;
            totalFacturarLBL.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            totalFacturarLBL.Location = new Point(496, 285);
            totalFacturarLBL.Name = "totalFacturarLBL";
            totalFacturarLBL.Size = new Size(54, 21);
            totalFacturarLBL.TabIndex = 6;
            totalFacturarLBL.Text = "$ 0,00";
            // 
            // emitirFacturaBTN
            // 
            emitirFacturaBTN.Location = new Point(354, 335);
            emitirFacturaBTN.Name = "emitirFacturaBTN";
            emitirFacturaBTN.Size = new Size(96, 32);
            emitirFacturaBTN.TabIndex = 7;
            emitirFacturaBTN.Text = "Emitir Factura";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(456, 335);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(96, 32);
            cancelarBTN.TabIndex = 8;
            cancelarBTN.Text = "Cancelar";
            // 
            // EmisionFacturaFRM
            // 
            ClientSize = new Size(566, 382);
            Controls.Add(idClienteLBL);
            Controls.Add(idClienteTXT);
            Controls.Add(buscarClienteBTN);
            Controls.Add(nombreClienteLBL);
            Controls.Add(guiasEntregadasPendientesLST);
            Controls.Add(totalLBL);
            Controls.Add(totalFacturarLBL);
            Controls.Add(emitirFacturaBTN);
            Controls.Add(cancelarBTN);
            Name = "EmisionFacturaFRM";
            Text = "Emisión de Factura";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label idClienteLBL;
        private TextBox idClienteTXT;
        private Button buscarClienteBTN;
        private Label nombreClienteLBL;
        private ListView guiasEntregadasPendientesLST;
        private ColumnHeader colNGuia;
        private ColumnHeader colFecha;
        private ColumnHeader colMonto;
        private Label totalLBL;
        private Label totalFacturarLBL;
        private Button emitirFacturaBTN;
        private Button cancelarBTN;
    }
}