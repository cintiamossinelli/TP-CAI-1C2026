using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TP_CAI_1C2026.Forms.Administracion.CuentaCorrienteCliente
{
    partial class CuentaCorrienteClienteFRM
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
            desdeLBL = new Label();
            desdeDTP = new DateTimePicker();
            hastaLBL = new Label();
            hastaDTP = new DateTimePicker();
            buscarBTN = new Button();
            cuentaCorrienteLST = new ListView();
            colFecha = new ColumnHeader();
            colDescripcion = new ColumnHeader();
            colImporte = new ColumnHeader();
            cancelarBTN = new Button();
            calculoSaldoLBL = new Label();
            saldoLBL = new Label();
            SuspendLayout();
            // 
            // idClienteLBL
            // 
            idClienteLBL.Location = new Point(16, 17);
            idClienteLBL.Name = "idClienteLBL";
            idClienteLBL.Size = new Size(103, 23);
            idClienteLBL.TabIndex = 0;
            idClienteLBL.Text = "CUIT / DNI / CUIL:";
            idClienteLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // idClienteTXT
            // 
            idClienteTXT.Location = new Point(124, 16);
            idClienteTXT.MaxLength = 13;
            idClienteTXT.Name = "idClienteTXT";
            idClienteTXT.Size = new Size(150, 23);
            idClienteTXT.TabIndex = 1;
            // 
            // buscarClienteBTN
            // 
            buscarClienteBTN.Location = new Point(280, 14);
            buscarClienteBTN.Name = "buscarClienteBTN";
            buscarClienteBTN.Size = new Size(99, 27);
            buscarClienteBTN.TabIndex = 2;
            buscarClienteBTN.Text = "Buscar Cliente";
            buscarClienteBTN.Click += buscarClienteBTN_Click;
            // 
            // nombreClienteLBL
            // 
            nombreClienteLBL.BackColor = SystemColors.ActiveCaption;
            nombreClienteLBL.Location = new Point(385, 15);
            nombreClienteLBL.Name = "nombreClienteLBL";
            nombreClienteLBL.Size = new Size(172, 25);
            nombreClienteLBL.TabIndex = 3;
            nombreClienteLBL.Text = "Nombre del Cliente";
            // 
            // desdeLBL
            // 
            desdeLBL.Location = new Point(16, 74);
            desdeLBL.Name = "desdeLBL";
            desdeLBL.Size = new Size(42, 23);
            desdeLBL.TabIndex = 4;
            desdeLBL.Text = "Desde:";
            desdeLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // desdeDTP
            // 
            desdeDTP.Format = DateTimePickerFormat.Short;
            desdeDTP.Location = new Point(64, 72);
            desdeDTP.Name = "desdeDTP";
            desdeDTP.Size = new Size(130, 23);
            desdeDTP.TabIndex = 5;
            // 
            // hastaLBL
            // 
            hastaLBL.Location = new Point(198, 74);
            hastaLBL.Name = "hastaLBL";
            hastaLBL.Size = new Size(45, 23);
            hastaLBL.TabIndex = 6;
            hastaLBL.Text = "Hasta:";
            hastaLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // hastaDTP
            // 
            hastaDTP.Format = DateTimePickerFormat.Short;
            hastaDTP.Location = new Point(249, 72);
            hastaDTP.Name = "hastaDTP";
            hastaDTP.Size = new Size(130, 23);
            hastaDTP.TabIndex = 7;
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(385, 70);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(92, 27);
            buscarBTN.TabIndex = 8;
            buscarBTN.Text = "Buscar";
            buscarBTN.Click += buscarBTN_Click;
            // 
            // cuentaCorrienteLST
            // 
            cuentaCorrienteLST.Columns.AddRange(new ColumnHeader[] { colFecha, colDescripcion, colImporte });
            cuentaCorrienteLST.FullRowSelect = true;
            cuentaCorrienteLST.GridLines = true;
            cuentaCorrienteLST.Location = new Point(12, 103);
            cuentaCorrienteLST.Name = "cuentaCorrienteLST";
            cuentaCorrienteLST.Size = new Size(535, 250);
            cuentaCorrienteLST.TabIndex = 9;
            cuentaCorrienteLST.UseCompatibleStateImageBehavior = false;
            cuentaCorrienteLST.View = View.Details;
            // 
            // colFecha
            // 
            colFecha.Text = "Fecha";
            colFecha.Width = 100;
            // 
            // colDescripcion
            // 
            colDescripcion.Text = "Descripción";
            colDescripcion.Width = 280;
            // 
            // colImporte
            // 
            colImporte.Text = "Importe";
            colImporte.TextAlign = HorizontalAlignment.Right;
            colImporte.Width = 150;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(477, 386);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 10;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // calculoSaldoLBL
            // 
            calculoSaldoLBL.BackColor = SystemColors.ActiveCaption;
            calculoSaldoLBL.Font = new System.Drawing.Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            calculoSaldoLBL.Location = new Point(375, 356);
            calculoSaldoLBL.Name = "calculoSaldoLBL";
            calculoSaldoLBL.Size = new Size(172, 25);
            calculoSaldoLBL.TabIndex = 11;
            calculoSaldoLBL.Text = "$ 0,00";
            calculoSaldoLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // saldoLBL
            // 
            saldoLBL.Font = new System.Drawing.Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saldoLBL.Location = new Point(305, 358);
            saldoLBL.Name = "saldoLBL";
            saldoLBL.Size = new Size(64, 23);
            saldoLBL.TabIndex = 12;
            saldoLBL.Text = "Saldo:";
            saldoLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CuentaCorrienteClienteFRM
            // 
            ClientSize = new Size(569, 430);
            Controls.Add(saldoLBL);
            Controls.Add(calculoSaldoLBL);
            Controls.Add(idClienteLBL);
            Controls.Add(idClienteTXT);
            Controls.Add(buscarClienteBTN);
            Controls.Add(nombreClienteLBL);
            Controls.Add(desdeLBL);
            Controls.Add(desdeDTP);
            Controls.Add(hastaLBL);
            Controls.Add(hastaDTP);
            Controls.Add(buscarBTN);
            Controls.Add(cuentaCorrienteLST);
            Controls.Add(cancelarBTN);
            Name = "CuentaCorrienteClienteFRM";
            Text = "Cuenta Corriente Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label idClienteLBL;
        private TextBox idClienteTXT;
        private Button buscarClienteBTN;
        private Label nombreClienteLBL;
        private Label desdeLBL;
        private DateTimePicker desdeDTP;
        private Label hastaLBL;
        private DateTimePicker hastaDTP;
        private Button buscarBTN;
        private ListView cuentaCorrienteLST;
        private ColumnHeader colFecha;
        private ColumnHeader colDescripcion;
        private ColumnHeader colImporte;
        private Button cancelarBTN;
        private Label calculoSaldoLBL;
        private Label saldoLBL;
    }
}