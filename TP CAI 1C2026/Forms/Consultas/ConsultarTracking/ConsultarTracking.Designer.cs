namespace TP_CAI_1C2026.Forms.Consultas.ConsultarTracking
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
            historialLST = new ListView();
            colNGuia = new ColumnHeader();
            colEstado = new ColumnHeader();
            cancelarBTN = new Button();
            historialLBL = new Label();
            cuitDniCuilLBL = new Label();
            origenLBL = new Label();
            destinoLBL = new Label();
            tipoCajaLBL = new Label();
            cantidadLBL = new Label();
            tipoDeCajaLBL = new Label();
            cantidadCajaLBL = new Label();
            dniCuitCuilLBL = new Label();
            origenGuiaLBL = new Label();
            destinoGuiaLBL = new Label();
            datosYdetalleGuiaGBX = new GroupBox();
            detalleGBX = new GroupBox();
            datosYdetalleGuiaGBX.SuspendLayout();
            detalleGBX.SuspendLayout();
            SuspendLayout();
            // 
            // guiaLBL
            // 
            guiaLBL.AutoSize = true;
            guiaLBL.Location = new Point(32, 37);
            guiaLBL.Name = "guiaLBL";
            guiaLBL.Size = new Size(42, 20);
            guiaLBL.TabIndex = 0;
            guiaLBL.Text = "Guía:";
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(416, 30);
            buscarBTN.Margin = new Padding(3, 4, 3, 4);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(106, 35);
            buscarBTN.TabIndex = 2;
            buscarBTN.Text = "Buscar";
            // 
            // guiaTXT
            // 
            guiaTXT.Location = new Point(80, 34);
            guiaTXT.Margin = new Padding(3, 4, 3, 4);
            guiaTXT.Name = "guiaTXT";
            guiaTXT.Size = new Size(320, 27);
            guiaTXT.TabIndex = 1;
            // 
            // historialLST
            // 
            historialLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colEstado });
            historialLST.FullRowSelect = true;
            historialLST.GridLines = true;
            historialLST.Location = new Point(25, 369);
            historialLST.Margin = new Padding(3, 4, 3, 4);
            historialLST.Name = "historialLST";
            historialLST.Size = new Size(497, 244);
            historialLST.TabIndex = 6;
            historialLST.UseCompatibleStateImageBehavior = false;
            historialLST.View = View.Details;
            // 
            // colNGuia
            // 
            colNGuia.Text = "Fecha";
            colNGuia.Width = 135;
            // 
            // colEstado
            // 
            colEstado.Text = "Estado de Encomienda";
            colEstado.Width = 135;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(416, 629);
            cancelarBTN.Margin = new Padding(3, 4, 3, 4);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(106, 35);
            cancelarBTN.TabIndex = 7;
            cancelarBTN.Text = "Cancelar";
            // 
            // historialLBL
            // 
            historialLBL.AutoSize = true;
            historialLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            historialLBL.Location = new Point(25, 345);
            historialLBL.Name = "historialLBL";
            historialLBL.Size = new Size(68, 20);
            historialLBL.TabIndex = 9;
            historialLBL.Text = "Historial";
            // 
            // cuitDniCuilLBL
            // 
            cuitDniCuilLBL.BackColor = SystemColors.ActiveCaption;
            cuitDniCuilLBL.Location = new Point(143, 26);
            cuitDniCuilLBL.Name = "cuitDniCuilLBL";
            cuitDniCuilLBL.Size = new Size(339, 27);
            cuitDniCuilLBL.TabIndex = 12;
            cuitDniCuilLBL.Text = "CUIT/DNI/CUIL";
            // 
            // origenLBL
            // 
            origenLBL.BackColor = SystemColors.ActiveCaption;
            origenLBL.Location = new Point(143, 60);
            origenLBL.Name = "origenLBL";
            origenLBL.Size = new Size(339, 27);
            origenLBL.TabIndex = 13;
            origenLBL.Text = "Origen";
            // 
            // destinoLBL
            // 
            destinoLBL.BackColor = SystemColors.ActiveCaption;
            destinoLBL.Location = new Point(143, 95);
            destinoLBL.Name = "destinoLBL";
            destinoLBL.Size = new Size(339, 27);
            destinoLBL.TabIndex = 14;
            destinoLBL.Text = "Destino";
            // 
            // tipoCajaLBL
            // 
            tipoCajaLBL.BackColor = SystemColors.ActiveCaption;
            tipoCajaLBL.Location = new Point(143, 33);
            tipoCajaLBL.Name = "tipoCajaLBL";
            tipoCajaLBL.Size = new Size(339, 27);
            tipoCajaLBL.TabIndex = 15;
            tipoCajaLBL.Text = "Tipo de Caja";
            // 
            // cantidadLBL
            // 
            cantidadLBL.BackColor = SystemColors.ActiveCaption;
            cantidadLBL.Location = new Point(143, 71);
            cantidadLBL.Name = "cantidadLBL";
            cantidadLBL.Size = new Size(339, 27);
            cantidadLBL.TabIndex = 16;
            cantidadLBL.Text = "Cantidad";
            // 
            // tipoDeCajaLBL
            // 
            tipoDeCajaLBL.AutoSize = true;
            tipoDeCajaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tipoDeCajaLBL.Location = new Point(39, 33);
            tipoDeCajaLBL.Name = "tipoDeCajaLBL";
            tipoDeCajaLBL.Size = new Size(98, 20);
            tipoDeCajaLBL.TabIndex = 19;
            tipoDeCajaLBL.Text = "Tipo de Caja:";
            // 
            // cantidadCajaLBL
            // 
            cantidadCajaLBL.AutoSize = true;
            cantidadCajaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cantidadCajaLBL.Location = new Point(62, 71);
            cantidadCajaLBL.Name = "cantidadCajaLBL";
            cantidadCajaLBL.Size = new Size(75, 20);
            cantidadCajaLBL.TabIndex = 20;
            cantidadCajaLBL.Text = "Cantidad:";
            // 
            // dniCuitCuilLBL
            // 
            dniCuitCuilLBL.AutoSize = true;
            dniCuitCuilLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dniCuitCuilLBL.Location = new Point(15, 33);
            dniCuitCuilLBL.Name = "dniCuitCuilLBL";
            dniCuitCuilLBL.Size = new Size(122, 20);
            dniCuitCuilLBL.TabIndex = 21;
            dniCuitCuilLBL.Text = "CUIT/DNI/CUIL:";
            // 
            // origenGuiaLBL
            // 
            origenGuiaLBL.AutoSize = true;
            origenGuiaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            origenGuiaLBL.Location = new Point(77, 60);
            origenGuiaLBL.Name = "origenGuiaLBL";
            origenGuiaLBL.Size = new Size(60, 20);
            origenGuiaLBL.TabIndex = 22;
            origenGuiaLBL.Text = "Origen:";
            // 
            // destinoGuiaLBL
            // 
            destinoGuiaLBL.AutoSize = true;
            destinoGuiaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            destinoGuiaLBL.Location = new Point(70, 95);
            destinoGuiaLBL.Name = "destinoGuiaLBL";
            destinoGuiaLBL.Size = new Size(67, 20);
            destinoGuiaLBL.TabIndex = 23;
            destinoGuiaLBL.Text = "Destino:";
            // 
            // datosYdetalleGuiaGBX
            // 
            datosYdetalleGuiaGBX.Controls.Add(destinoGuiaLBL);
            datosYdetalleGuiaGBX.Controls.Add(origenGuiaLBL);
            datosYdetalleGuiaGBX.Controls.Add(dniCuitCuilLBL);
            datosYdetalleGuiaGBX.Controls.Add(destinoLBL);
            datosYdetalleGuiaGBX.Controls.Add(cuitDniCuilLBL);
            datosYdetalleGuiaGBX.Controls.Add(origenLBL);
            datosYdetalleGuiaGBX.Location = new Point(25, 76);
            datosYdetalleGuiaGBX.Margin = new Padding(3, 4, 3, 4);
            datosYdetalleGuiaGBX.Name = "datosYdetalleGuiaGBX";
            datosYdetalleGuiaGBX.Padding = new Padding(3, 4, 3, 4);
            datosYdetalleGuiaGBX.Size = new Size(497, 138);
            datosYdetalleGuiaGBX.TabIndex = 24;
            datosYdetalleGuiaGBX.TabStop = false;
            datosYdetalleGuiaGBX.Text = "Datos";
            // 
            // detalleGBX
            // 
            detalleGBX.Controls.Add(cantidadCajaLBL);
            detalleGBX.Controls.Add(tipoDeCajaLBL);
            detalleGBX.Controls.Add(cantidadLBL);
            detalleGBX.Controls.Add(tipoCajaLBL);
            detalleGBX.Location = new Point(25, 221);
            detalleGBX.Name = "detalleGBX";
            detalleGBX.Size = new Size(497, 110);
            detalleGBX.TabIndex = 25;
            detalleGBX.TabStop = false;
            detalleGBX.Text = "Detalle";
            // 
            // ConsultarTrackingFRM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 679);
            Controls.Add(detalleGBX);
            Controls.Add(datosYdetalleGuiaGBX);
            Controls.Add(historialLBL);
            Controls.Add(guiaLBL);
            Controls.Add(guiaTXT);
            Controls.Add(buscarBTN);
            Controls.Add(historialLST);
            Controls.Add(cancelarBTN);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ConsultarTrackingFRM";
            Text = "Consultar Tracking";
            datosYdetalleGuiaGBX.ResumeLayout(false);
            datosYdetalleGuiaGBX.PerformLayout();
            detalleGBX.ResumeLayout(false);
            detalleGBX.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label guiaLBL;
        private Button buscarBTN;
        private TextBox guiaTXT;
        private ListView historialLST;
        private ColumnHeader colEstado;
        private Button cancelarBTN;
        private ColumnHeader colNGuia;
        private Label historialLBL;
        private Label cuitDniCuilLBL;
        private Label origenLBL;
        private Label destinoLBL;
        private Label tipoCajaLBL;
        private Label cantidadLBL;
        private Label tipoDeCajaLBL;
        private Label cantidadCajaLBL;
        private Label dniCuitCuilLBL;
        private Label origenGuiaLBL;
        private Label destinoGuiaLBL;
        private GroupBox datosYdetalleGuiaGBX;
        private GroupBox detalleGBX;
    }
}