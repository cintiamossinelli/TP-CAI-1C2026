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
            detalleGuiaLBL = new Label();
            historialLST = new ListView();
            colNGuia = new ColumnHeader();
            colEstado = new ColumnHeader();
            cancelarBTN = new Button();
            historialLBL = new Label();
            datosGuiaLBL = new Label();
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
            datosYdetalleGuiaGPB = new GroupBox();
            datosYdetalleGuiaGPB.SuspendLayout();
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
            buscarBTN.Location = new Point(364, 39);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(93, 26);
            buscarBTN.TabIndex = 2;
            buscarBTN.Text = "Buscar";
            // 
            // guiaTXT
            // 
            guiaTXT.Location = new Point(22, 39);
            guiaTXT.Name = "guiaTXT";
            guiaTXT.Size = new Size(318, 23);
            guiaTXT.TabIndex = 1;
            // 
            // detalleGuiaLBL
            // 
            detalleGuiaLBL.AutoSize = true;
            detalleGuiaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            detalleGuiaLBL.Location = new Point(6, 79);
            detalleGuiaLBL.Name = "detalleGuiaLBL";
            detalleGuiaLBL.Size = new Size(47, 15);
            detalleGuiaLBL.TabIndex = 5;
            detalleGuiaLBL.Text = "Detalle";
            // 
            // historialLST
            // 
            historialLST.Columns.AddRange(new ColumnHeader[] { colNGuia, colEstado });
            historialLST.FullRowSelect = true;
            historialLST.GridLines = true;
            historialLST.Location = new Point(22, 228);
            historialLST.Name = "historialLST";
            historialLST.Size = new Size(435, 114);
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
            cancelarBTN.Location = new Point(364, 348);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(93, 26);
            cancelarBTN.TabIndex = 7;
            cancelarBTN.Text = "Cancelar";
            // 
            // historialLBL
            // 
            historialLBL.AutoSize = true;
            historialLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            historialLBL.Location = new Point(22, 210);
            historialLBL.Name = "historialLBL";
            historialLBL.Size = new Size(53, 15);
            historialLBL.TabIndex = 9;
            historialLBL.Text = "Historial";
            // 
            // datosGuiaLBL
            // 
            datosGuiaLBL.AutoSize = true;
            datosGuiaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            datosGuiaLBL.Location = new Point(6, 12);
            datosGuiaLBL.Name = "datosGuiaLBL";
            datosGuiaLBL.Size = new Size(39, 15);
            datosGuiaLBL.TabIndex = 11;
            datosGuiaLBL.Text = "Datos";
            // 
            // cuitDniCuilLBL
            // 
            cuitDniCuilLBL.AutoSize = true;
            cuitDniCuilLBL.BackColor = SystemColors.ActiveCaption;
            cuitDniCuilLBL.Location = new Point(6, 42);
            cuitDniCuilLBL.Name = "cuitDniCuilLBL";
            cuitDniCuilLBL.Size = new Size(87, 15);
            cuitDniCuilLBL.TabIndex = 12;
            cuitDniCuilLBL.Text = "CUIT/DNI/CUIL";
            // 
            // origenLBL
            // 
            origenLBL.AutoSize = true;
            origenLBL.BackColor = SystemColors.ActiveCaption;
            origenLBL.Location = new Point(161, 42);
            origenLBL.Name = "origenLBL";
            origenLBL.Size = new Size(43, 15);
            origenLBL.TabIndex = 13;
            origenLBL.Text = "Origen";
            // 
            // destinoLBL
            // 
            destinoLBL.AutoSize = true;
            destinoLBL.BackColor = SystemColors.ActiveCaption;
            destinoLBL.Location = new Point(286, 42);
            destinoLBL.Name = "destinoLBL";
            destinoLBL.Size = new Size(47, 15);
            destinoLBL.TabIndex = 14;
            destinoLBL.Text = "Destino";
            // 
            // tipoCajaLBL
            // 
            tipoCajaLBL.AutoSize = true;
            tipoCajaLBL.BackColor = SystemColors.ActiveCaption;
            tipoCajaLBL.Location = new Point(7, 109);
            tipoCajaLBL.Name = "tipoCajaLBL";
            tipoCajaLBL.Size = new Size(72, 15);
            tipoCajaLBL.TabIndex = 15;
            tipoCajaLBL.Text = "Tipo de Caja";
            // 
            // cantidadLBL
            // 
            cantidadLBL.AutoSize = true;
            cantidadLBL.BackColor = SystemColors.ActiveCaption;
            cantidadLBL.Location = new Point(159, 109);
            cantidadLBL.Name = "cantidadLBL";
            cantidadLBL.Size = new Size(55, 15);
            cantidadLBL.TabIndex = 16;
            cantidadLBL.Text = "Cantidad";
            // 
            // tipoDeCajaLBL
            // 
            tipoDeCajaLBL.AutoSize = true;
            tipoDeCajaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tipoDeCajaLBL.Location = new Point(6, 94);
            tipoDeCajaLBL.Name = "tipoDeCajaLBL";
            tipoDeCajaLBL.Size = new Size(73, 15);
            tipoDeCajaLBL.TabIndex = 19;
            tipoDeCajaLBL.Text = "Tipo de Caja";
            // 
            // cantidadCajaLBL
            // 
            cantidadCajaLBL.AutoSize = true;
            cantidadCajaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cantidadCajaLBL.Location = new Point(159, 94);
            cantidadCajaLBL.Name = "cantidadCajaLBL";
            cantidadCajaLBL.Size = new Size(55, 15);
            cantidadCajaLBL.TabIndex = 20;
            cantidadCajaLBL.Text = "Cantidad";
            // 
            // dniCuitCuilLBL
            // 
            dniCuitCuilLBL.AutoSize = true;
            dniCuitCuilLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dniCuitCuilLBL.Location = new Point(6, 27);
            dniCuitCuilLBL.Name = "dniCuitCuilLBL";
            dniCuitCuilLBL.Size = new Size(92, 15);
            dniCuitCuilLBL.TabIndex = 21;
            dniCuitCuilLBL.Text = "CUIT/DNI/CUIL";
            // 
            // origenGuiaLBL
            // 
            origenGuiaLBL.AutoSize = true;
            origenGuiaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            origenGuiaLBL.Location = new Point(159, 27);
            origenGuiaLBL.Name = "origenGuiaLBL";
            origenGuiaLBL.Size = new Size(45, 15);
            origenGuiaLBL.TabIndex = 22;
            origenGuiaLBL.Text = "Origen";
            // 
            // destinoGuiaLBL
            // 
            destinoGuiaLBL.AutoSize = true;
            destinoGuiaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            destinoGuiaLBL.Location = new Point(286, 27);
            destinoGuiaLBL.Name = "destinoGuiaLBL";
            destinoGuiaLBL.Size = new Size(50, 15);
            destinoGuiaLBL.TabIndex = 23;
            destinoGuiaLBL.Text = "Destino";
            // 
            // datosYdetalleGuiaGPB
            // 
            datosYdetalleGuiaGPB.Controls.Add(destinoGuiaLBL);
            datosYdetalleGuiaGPB.Controls.Add(origenGuiaLBL);
            datosYdetalleGuiaGPB.Controls.Add(dniCuitCuilLBL);
            datosYdetalleGuiaGPB.Controls.Add(cantidadCajaLBL);
            datosYdetalleGuiaGPB.Controls.Add(tipoDeCajaLBL);
            datosYdetalleGuiaGPB.Controls.Add(cantidadLBL);
            datosYdetalleGuiaGPB.Controls.Add(tipoCajaLBL);
            datosYdetalleGuiaGPB.Controls.Add(destinoLBL);
            datosYdetalleGuiaGPB.Controls.Add(origenLBL);
            datosYdetalleGuiaGPB.Controls.Add(cuitDniCuilLBL);
            datosYdetalleGuiaGPB.Controls.Add(datosGuiaLBL);
            datosYdetalleGuiaGPB.Controls.Add(detalleGuiaLBL);
            datosYdetalleGuiaGPB.Location = new Point(22, 68);
            datosYdetalleGuiaGPB.Name = "datosYdetalleGuiaGPB";
            datosYdetalleGuiaGPB.Size = new Size(435, 142);
            datosYdetalleGuiaGPB.TabIndex = 24;
            datosYdetalleGuiaGPB.TabStop = false;
            // 
            // ConsultarTrackingFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 386);
            Controls.Add(datosYdetalleGuiaGPB);
            Controls.Add(historialLBL);
            Controls.Add(guiaLBL);
            Controls.Add(guiaTXT);
            Controls.Add(buscarBTN);
            Controls.Add(historialLST);
            Controls.Add(cancelarBTN);
            Name = "ConsultarTrackingFRM";
            Text = "Consultar Tracking";
            datosYdetalleGuiaGPB.ResumeLayout(false);
            datosYdetalleGuiaGPB.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label guiaLBL;
        private Button buscarBTN;
        private TextBox guiaTXT;
        private Label detalleGuiaLBL;
        private ListView historialLST;
        private ColumnHeader colEstado;
        private Button cancelarBTN;
        private ColumnHeader colNGuia;
        private Label historialLBL;
        private Label datosGuiaLBL;
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
        private GroupBox datosYdetalleGuiaGPB;
    }
}