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
            fechaGuia = new ColumnHeader();
            colEstado = new ColumnHeader();
            cancelarBTN = new Button();
            historialLBL = new Label();
            cuitDniCuilLBL = new Label();
            origenLBL = new Label();
            destinoLBL = new Label();
            tipoCajaLBL = new Label();
            tipoDeCajaLBL = new Label();
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
            guiaLBL.Location = new Point(28, 28);
            guiaLBL.Name = "guiaLBL";
            guiaLBL.Size = new Size(34, 15);
            guiaLBL.TabIndex = 0;
            guiaLBL.Text = "Guía:";
            // 
            // buscarBTN
            // 
            buscarBTN.Location = new Point(364, 25);
            buscarBTN.Name = "buscarBTN";
            buscarBTN.Size = new Size(93, 26);
            buscarBTN.TabIndex = 2;
            buscarBTN.Text = "Buscar";
            buscarBTN.Click += buscarBTN_Click;
            // 
            // guiaTXT
            // 
            guiaTXT.Location = new Point(70, 26);
            guiaTXT.MaxLength = 15;
            guiaTXT.Name = "guiaTXT";
            guiaTXT.Size = new Size(280, 23);
            guiaTXT.TabIndex = 1;
            // 
            // historialLST
            // 
            historialLST.Columns.AddRange(new ColumnHeader[] { fechaGuia, colEstado });
            historialLST.FullRowSelect = true;
            historialLST.GridLines = true;
            historialLST.Location = new Point(22, 256);
            historialLST.Name = "historialLST";
            historialLST.Size = new Size(435, 184);
            historialLST.TabIndex = 6;
            historialLST.UseCompatibleStateImageBehavior = false;
            historialLST.View = View.Details;
            // 
            // fechaGuia
            // 
            fechaGuia.Text = "Fecha";
            fechaGuia.Width = 135;
            // 
            // colEstado
            // 
            colEstado.Text = "Estado de Encomienda";
            colEstado.Width = 135;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(364, 451);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(93, 26);
            cancelarBTN.TabIndex = 7;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // historialLBL
            // 
            historialLBL.AutoSize = true;
            historialLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            historialLBL.Location = new Point(22, 238);
            historialLBL.Name = "historialLBL";
            historialLBL.Size = new Size(53, 15);
            historialLBL.TabIndex = 9;
            historialLBL.Text = "Historial";
            // 
            // cuitDniCuilLBL
            // 
            cuitDniCuilLBL.BackColor = SystemColors.ActiveCaption;
            cuitDniCuilLBL.Location = new Point(125, 20);
            cuitDniCuilLBL.Name = "cuitDniCuilLBL";
            cuitDniCuilLBL.Size = new Size(297, 20);
            cuitDniCuilLBL.TabIndex = 12;
            cuitDniCuilLBL.Text = "CUIT/DNI/CUIL";
            // 
            // origenLBL
            // 
            origenLBL.BackColor = SystemColors.ActiveCaption;
            origenLBL.Location = new Point(125, 45);
            origenLBL.Name = "origenLBL";
            origenLBL.Size = new Size(297, 20);
            origenLBL.TabIndex = 13;
            origenLBL.Text = "Origen";
            // 
            // destinoLBL
            // 
            destinoLBL.BackColor = SystemColors.ActiveCaption;
            destinoLBL.Location = new Point(125, 71);
            destinoLBL.Name = "destinoLBL";
            destinoLBL.Size = new Size(297, 20);
            destinoLBL.TabIndex = 14;
            destinoLBL.Text = "Destino";
            // 
            // tipoCajaLBL
            // 
            tipoCajaLBL.BackColor = SystemColors.ActiveCaption;
            tipoCajaLBL.Location = new Point(125, 25);
            tipoCajaLBL.Name = "tipoCajaLBL";
            tipoCajaLBL.Size = new Size(297, 20);
            tipoCajaLBL.TabIndex = 15;
            tipoCajaLBL.Text = "Tipo de Caja";
            // 
            // tipoDeCajaLBL
            // 
            tipoDeCajaLBL.AutoSize = true;
            tipoDeCajaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tipoDeCajaLBL.Location = new Point(34, 25);
            tipoDeCajaLBL.Name = "tipoDeCajaLBL";
            tipoDeCajaLBL.Size = new Size(76, 15);
            tipoDeCajaLBL.TabIndex = 19;
            tipoDeCajaLBL.Text = "Tipo de Caja:";
            // 
            // dniCuitCuilLBL
            // 
            dniCuitCuilLBL.AutoSize = true;
            dniCuitCuilLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dniCuitCuilLBL.Location = new Point(13, 25);
            dniCuitCuilLBL.Name = "dniCuitCuilLBL";
            dniCuitCuilLBL.Size = new Size(95, 15);
            dniCuitCuilLBL.TabIndex = 21;
            dniCuitCuilLBL.Text = "CUIT/DNI/CUIL:";
            // 
            // origenGuiaLBL
            // 
            origenGuiaLBL.AutoSize = true;
            origenGuiaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            origenGuiaLBL.Location = new Point(67, 45);
            origenGuiaLBL.Name = "origenGuiaLBL";
            origenGuiaLBL.Size = new Size(48, 15);
            origenGuiaLBL.TabIndex = 22;
            origenGuiaLBL.Text = "Origen:";
            // 
            // destinoGuiaLBL
            // 
            destinoGuiaLBL.AutoSize = true;
            destinoGuiaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            destinoGuiaLBL.Location = new Point(61, 71);
            destinoGuiaLBL.Name = "destinoGuiaLBL";
            destinoGuiaLBL.Size = new Size(53, 15);
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
            datosYdetalleGuiaGBX.Location = new Point(22, 57);
            datosYdetalleGuiaGBX.Name = "datosYdetalleGuiaGBX";
            datosYdetalleGuiaGBX.Size = new Size(435, 104);
            datosYdetalleGuiaGBX.TabIndex = 24;
            datosYdetalleGuiaGBX.TabStop = false;
            datosYdetalleGuiaGBX.Text = "Datos";
            // 
            // detalleGBX
            // 
            detalleGBX.Controls.Add(tipoDeCajaLBL);
            detalleGBX.Controls.Add(tipoCajaLBL);
            detalleGBX.Location = new Point(22, 166);
            detalleGBX.Margin = new Padding(3, 2, 3, 2);
            detalleGBX.Name = "detalleGBX";
            detalleGBX.Padding = new Padding(3, 2, 3, 2);
            detalleGBX.Size = new Size(435, 63);
            detalleGBX.TabIndex = 25;
            detalleGBX.TabStop = false;
            detalleGBX.Text = "Detalle";
            // 
            // ConsultarTrackingFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 493);
            Controls.Add(detalleGBX);
            Controls.Add(datosYdetalleGuiaGBX);
            Controls.Add(historialLBL);
            Controls.Add(guiaLBL);
            Controls.Add(guiaTXT);
            Controls.Add(buscarBTN);
            Controls.Add(historialLST);
            Controls.Add(cancelarBTN);
            Name = "ConsultarTrackingFRM";
            Text = "Consulta de Estado de la Guía";
            Load += ConsultarTrackingFRM_Load;
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
        private ColumnHeader fechaGuia;
        private Label historialLBL;
        private Label cuitDniCuilLBL;
        private Label origenLBL;
        private Label destinoLBL;
        private Label tipoCajaLBL;
        private Label tipoDeCajaLBL;
        private Label dniCuitCuilLBL;
        private Label origenGuiaLBL;
        private Label destinoGuiaLBL;
        private GroupBox datosYdetalleGuiaGBX;
        private GroupBox detalleGBX;
    }
}