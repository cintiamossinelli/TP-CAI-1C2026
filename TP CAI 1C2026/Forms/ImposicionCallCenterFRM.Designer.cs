namespace TP_CAI_1C2026
{
    partial class ImposicionCallCenterFRM
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            clienteGBX = new GroupBox();
            nombreClienteLBL = new Label();
            idClienteLBL = new Label();
            idClienteTXT = new TextBox();
            buscarClienteBTN = new Button();
            retiroGBX = new GroupBox();
            ciudadLBL = new Label();
            ciudadCMB = new ComboBox();
            domicilioRemitenteLBL = new Label();
            domicilioRemitenteTXT = new TextBox();
            destinatarioGBX = new GroupBox();
            direccionDestinatarioLBL = new Label();
            ciudadDestinatarioLBL = new Label();
            ciudadDestinatarioCMB = new ComboBox();
            nombreDestinatarioTXT = new TextBox();
            nombreDestinatarioLBL = new Label();
            cdRDB = new RadioButton();
            agenciaRDB = new RadioButton();
            domicilioRDB = new RadioButton();
            destinoCDCMB = new ComboBox();
            destinoAgenciaCMB = new ComboBox();
            direccionDestinatarioTXT = new TextBox();
            dniDestinatarioLBL = new Label();
            dniDestinatarioTXT = new TextBox();
            encomiendaGBX = new GroupBox();
            tipoCajaLBL = new Label();
            tipoCajaCMB = new ComboBox();
            cantidadLBL = new Label();
            cantidadTXT = new TextBox();
            agregarBTN = new Button();
            encomiendaLST = new ListView();
            colTipo = new ColumnHeader();
            colCantidad = new ColumnHeader();
            quitarItemBTN = new Button();
            confirmarBTN = new Button();
            cancelarBTN = new Button();
            clienteGBX.SuspendLayout();
            retiroGBX.SuspendLayout();
            destinatarioGBX.SuspendLayout();
            encomiendaGBX.SuspendLayout();
            SuspendLayout();
            // 
            // clienteGBX
            // 
            clienteGBX.Controls.Add(nombreClienteLBL);
            clienteGBX.Controls.Add(idClienteLBL);
            clienteGBX.Controls.Add(idClienteTXT);
            clienteGBX.Controls.Add(buscarClienteBTN);
            clienteGBX.Location = new Point(12, 12);
            clienteGBX.Name = "clienteGBX";
            clienteGBX.Size = new Size(649, 88);
            clienteGBX.TabIndex = 0;
            clienteGBX.TabStop = false;
            clienteGBX.Text = "Cliente";
            clienteGBX.Enter += clienteGBX_Enter_1;
            // 
            // nombreClienteLBL
            // 
            nombreClienteLBL.AutoSize = true;
            nombreClienteLBL.BackColor = SystemColors.ActiveCaption;
            nombreClienteLBL.Location = new Point(135, 55);
            nombreClienteLBL.Name = "nombreClienteLBL";
            nombreClienteLBL.Size = new Size(139, 20);
            nombreClienteLBL.TabIndex = 3;
            nombreClienteLBL.Text = "Nombre del Cliente";
            nombreClienteLBL.Click += label1_Click;
            // 
            // idClienteLBL
            // 
            idClienteLBL.Location = new Point(0, 25);
            idClienteLBL.Name = "idClienteLBL";
            idClienteLBL.Size = new Size(130, 23);
            idClienteLBL.TabIndex = 0;
            idClienteLBL.Text = "CUIT / DNI / CUIL:";
            idClienteLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // idClienteTXT
            // 
            idClienteTXT.Location = new Point(135, 22);
            idClienteTXT.MaxLength = 11;
            idClienteTXT.Name = "idClienteTXT";
            idClienteTXT.Size = new Size(380, 27);
            idClienteTXT.TabIndex = 1;
            // 
            // buscarClienteBTN
            // 
            buscarClienteBTN.Location = new Point(521, 21);
            buscarClienteBTN.Name = "buscarClienteBTN";
            buscarClienteBTN.Size = new Size(114, 27);
            buscarClienteBTN.TabIndex = 2;
            buscarClienteBTN.Text = "Buscar";
            // 
            // retiroGBX
            // 
            retiroGBX.Controls.Add(ciudadLBL);
            retiroGBX.Controls.Add(ciudadCMB);
            retiroGBX.Controls.Add(domicilioRemitenteLBL);
            retiroGBX.Controls.Add(domicilioRemitenteTXT);
            retiroGBX.Location = new Point(12, 106);
            retiroGBX.Name = "retiroGBX";
            retiroGBX.Size = new Size(649, 95);
            retiroGBX.TabIndex = 1;
            retiroGBX.TabStop = false;
            retiroGBX.Text = "Datos de Retiro";
            retiroGBX.Enter += retiroGBX_Enter;
            // 
            // ciudadLBL
            // 
            ciudadLBL.Location = new Point(10, 25);
            ciudadLBL.Name = "ciudadLBL";
            ciudadLBL.Size = new Size(120, 23);
            ciudadLBL.TabIndex = 0;
            ciudadLBL.Text = "Ciudad:";
            ciudadLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ciudadCMB
            // 
            ciudadCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            ciudadCMB.Location = new Point(135, 23);
            ciudadCMB.Name = "ciudadCMB";
            ciudadCMB.Size = new Size(500, 28);
            ciudadCMB.TabIndex = 1;
            // 
            // domicilioRemitenteLBL
            // 
            domicilioRemitenteLBL.Location = new Point(10, 54);
            domicilioRemitenteLBL.Name = "domicilioRemitenteLBL";
            domicilioRemitenteLBL.Size = new Size(120, 23);
            domicilioRemitenteLBL.TabIndex = 2;
            domicilioRemitenteLBL.Text = "Domicilio Remitente:";
            domicilioRemitenteLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // domicilioRemitenteTXT
            // 
            domicilioRemitenteTXT.Location = new Point(135, 52);
            domicilioRemitenteTXT.Name = "domicilioRemitenteTXT";
            domicilioRemitenteTXT.Size = new Size(500, 27);
            domicilioRemitenteTXT.TabIndex = 3;
            // 
            // destinatarioGBX
            // 
            destinatarioGBX.Controls.Add(direccionDestinatarioLBL);
            destinatarioGBX.Controls.Add(ciudadDestinatarioLBL);
            destinatarioGBX.Controls.Add(ciudadDestinatarioCMB);
            destinatarioGBX.Controls.Add(nombreDestinatarioTXT);
            destinatarioGBX.Controls.Add(nombreDestinatarioLBL);
            destinatarioGBX.Controls.Add(cdRDB);
            destinatarioGBX.Controls.Add(agenciaRDB);
            destinatarioGBX.Controls.Add(domicilioRDB);
            destinatarioGBX.Controls.Add(destinoCDCMB);
            destinatarioGBX.Controls.Add(destinoAgenciaCMB);
            destinatarioGBX.Controls.Add(direccionDestinatarioTXT);
            destinatarioGBX.Controls.Add(dniDestinatarioLBL);
            destinatarioGBX.Controls.Add(dniDestinatarioTXT);
            destinatarioGBX.Location = new Point(12, 207);
            destinatarioGBX.Name = "destinatarioGBX";
            destinatarioGBX.Size = new Size(649, 257);
            destinatarioGBX.TabIndex = 2;
            destinatarioGBX.TabStop = false;
            destinatarioGBX.Text = "Destinatario";
            destinatarioGBX.Enter += destinatarioGBX_Enter;
            // 
            // direccionDestinatarioLBL
            // 
            direccionDestinatarioLBL.Location = new Point(133, 125);
            direccionDestinatarioLBL.Name = "direccionDestinatarioLBL";
            direccionDestinatarioLBL.Size = new Size(66, 23);
            direccionDestinatarioLBL.TabIndex = 15;
            direccionDestinatarioLBL.Text = "Dirección:";
            direccionDestinatarioLBL.TextAlign = ContentAlignment.MiddleRight;
            direccionDestinatarioLBL.Click += label2_Click;
            // 
            // ciudadDestinatarioLBL
            // 
            ciudadDestinatarioLBL.Location = new Point(149, 90);
            ciudadDestinatarioLBL.Name = "ciudadDestinatarioLBL";
            ciudadDestinatarioLBL.Size = new Size(50, 23);
            ciudadDestinatarioLBL.TabIndex = 13;
            ciudadDestinatarioLBL.Text = "Ciudad:";
            ciudadDestinatarioLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ciudadDestinatarioCMB
            // 
            ciudadDestinatarioCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            ciudadDestinatarioCMB.Location = new Point(205, 91);
            ciudadDestinatarioCMB.Name = "ciudadDestinatarioCMB";
            ciudadDestinatarioCMB.Size = new Size(430, 28);
            ciudadDestinatarioCMB.TabIndex = 14;
            // 
            // nombreDestinatarioTXT
            // 
            nombreDestinatarioTXT.Enabled = false;
            nombreDestinatarioTXT.Location = new Point(135, 194);
            nombreDestinatarioTXT.MaxLength = 11;
            nombreDestinatarioTXT.Name = "nombreDestinatarioTXT";
            nombreDestinatarioTXT.Size = new Size(500, 27);
            nombreDestinatarioTXT.TabIndex = 12;
            // 
            // nombreDestinatarioLBL
            // 
            nombreDestinatarioLBL.Location = new Point(9, 189);
            nombreDestinatarioLBL.Name = "nombreDestinatarioLBL";
            nombreDestinatarioLBL.Size = new Size(120, 31);
            nombreDestinatarioLBL.TabIndex = 11;
            nombreDestinatarioLBL.Text = "Nombre Destinatario:";
            nombreDestinatarioLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cdRDB
            // 
            cdRDB.Location = new Point(43, 22);
            cdRDB.Name = "cdRDB";
            cdRDB.Size = new Size(41, 23);
            cdRDB.TabIndex = 0;
            cdRDB.Text = "CD";
            // 
            // agenciaRDB
            // 
            agenciaRDB.Location = new Point(43, 56);
            agenciaRDB.Name = "agenciaRDB";
            agenciaRDB.Size = new Size(70, 23);
            agenciaRDB.TabIndex = 1;
            agenciaRDB.Text = "Agencia";
            // 
            // domicilioRDB
            // 
            domicilioRDB.Location = new Point(43, 88);
            domicilioRDB.Name = "domicilioRDB";
            domicilioRDB.Size = new Size(87, 26);
            domicilioRDB.TabIndex = 2;
            domicilioRDB.Text = "A domicilio";
            domicilioRDB.CheckedChanged += domicilioRDB_CheckedChanged_2;
            // 
            // destinoCDCMB
            // 
            destinoCDCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            destinoCDCMB.Enabled = false;
            destinoCDCMB.Location = new Point(135, 56);
            destinoCDCMB.Name = "destinoCDCMB";
            destinoCDCMB.Size = new Size(500, 28);
            destinoCDCMB.TabIndex = 4;
            // 
            // destinoAgenciaCMB
            // 
            destinoAgenciaCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            destinoAgenciaCMB.Enabled = false;
            destinoAgenciaCMB.Location = new Point(135, 22);
            destinoAgenciaCMB.Name = "destinoAgenciaCMB";
            destinoAgenciaCMB.Size = new Size(500, 28);
            destinoAgenciaCMB.TabIndex = 6;
            // 
            // direccionDestinatarioTXT
            // 
            direccionDestinatarioTXT.Enabled = false;
            direccionDestinatarioTXT.Location = new Point(205, 125);
            direccionDestinatarioTXT.Name = "direccionDestinatarioTXT";
            direccionDestinatarioTXT.Size = new Size(430, 27);
            direccionDestinatarioTXT.TabIndex = 8;
            // 
            // dniDestinatarioLBL
            // 
            dniDestinatarioLBL.Location = new Point(32, 160);
            dniDestinatarioLBL.Name = "dniDestinatarioLBL";
            dniDestinatarioLBL.Size = new Size(97, 23);
            dniDestinatarioLBL.TabIndex = 9;
            dniDestinatarioLBL.Text = "DNI Destinatario:";
            dniDestinatarioLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dniDestinatarioTXT
            // 
            dniDestinatarioTXT.Enabled = false;
            dniDestinatarioTXT.Location = new Point(135, 160);
            dniDestinatarioTXT.MaxLength = 11;
            dniDestinatarioTXT.Name = "dniDestinatarioTXT";
            dniDestinatarioTXT.Size = new Size(500, 27);
            dniDestinatarioTXT.TabIndex = 10;
            // 
            // encomiendaGBX
            // 
            encomiendaGBX.Controls.Add(tipoCajaLBL);
            encomiendaGBX.Controls.Add(tipoCajaCMB);
            encomiendaGBX.Controls.Add(cantidadLBL);
            encomiendaGBX.Controls.Add(cantidadTXT);
            encomiendaGBX.Controls.Add(agregarBTN);
            encomiendaGBX.Controls.Add(encomiendaLST);
            encomiendaGBX.Controls.Add(quitarItemBTN);
            encomiendaGBX.Location = new Point(12, 470);
            encomiendaGBX.Name = "encomiendaGBX";
            encomiendaGBX.Size = new Size(649, 244);
            encomiendaGBX.TabIndex = 3;
            encomiendaGBX.TabStop = false;
            encomiendaGBX.Text = "Detalle de Encomienda";
            // 
            // tipoCajaLBL
            // 
            tipoCajaLBL.Location = new Point(10, 34);
            tipoCajaLBL.Name = "tipoCajaLBL";
            tipoCajaLBL.Size = new Size(120, 23);
            tipoCajaLBL.TabIndex = 0;
            tipoCajaLBL.Text = "Tipo de Caja:";
            tipoCajaLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tipoCajaCMB
            // 
            tipoCajaCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            tipoCajaCMB.Items.AddRange(new object[] { "S", "M", "L", "XL" });
            tipoCajaCMB.Location = new Point(135, 35);
            tipoCajaCMB.Name = "tipoCajaCMB";
            tipoCajaCMB.Size = new Size(150, 28);
            tipoCajaCMB.TabIndex = 1;
            // 
            // cantidadLBL
            // 
            cantidadLBL.Location = new Point(249, 36);
            cantidadLBL.Name = "cantidadLBL";
            cantidadLBL.Size = new Size(120, 23);
            cantidadLBL.TabIndex = 2;
            cantidadLBL.Text = "Cantidad:";
            cantidadLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cantidadTXT
            // 
            cantidadTXT.Location = new Point(375, 36);
            cantidadTXT.Name = "cantidadTXT";
            cantidadTXT.Size = new Size(140, 27);
            cantidadTXT.TabIndex = 3;
            // 
            // agregarBTN
            // 
            agregarBTN.Location = new Point(555, 32);
            agregarBTN.Name = "agregarBTN";
            agregarBTN.Size = new Size(80, 27);
            agregarBTN.TabIndex = 4;
            agregarBTN.Text = "Agregar";
            // 
            // encomiendaLST
            // 
            encomiendaLST.Columns.AddRange(new ColumnHeader[] { colTipo, colCantidad });
            encomiendaLST.FullRowSelect = true;
            encomiendaLST.GridLines = true;
            encomiendaLST.Location = new Point(10, 65);
            encomiendaLST.Name = "encomiendaLST";
            encomiendaLST.Size = new Size(625, 135);
            encomiendaLST.TabIndex = 5;
            encomiendaLST.UseCompatibleStateImageBehavior = false;
            encomiendaLST.View = View.Details;
            // 
            // colTipo
            // 
            colTipo.Text = "Tipo de Caja";
            colTipo.Width = 200;
            // 
            // colCantidad
            // 
            colCantidad.Text = "Cantidad";
            colCantidad.Width = 200;
            // 
            // quitarItemBTN
            // 
            quitarItemBTN.Location = new Point(555, 206);
            quitarItemBTN.Name = "quitarItemBTN";
            quitarItemBTN.Size = new Size(80, 27);
            quitarItemBTN.TabIndex = 6;
            quitarItemBTN.Text = "Quitar Item";
            // 
            // confirmarBTN
            // 
            confirmarBTN.Location = new Point(486, 749);
            confirmarBTN.Name = "confirmarBTN";
            confirmarBTN.Size = new Size(80, 32);
            confirmarBTN.TabIndex = 4;
            confirmarBTN.Text = "Confirmar";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(581, 749);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 5;
            cancelarBTN.Text = "Cancelar";
            // 
            // ImposicionCallCenterFRM
            // 
            ClientSize = new Size(674, 796);
            Controls.Add(clienteGBX);
            Controls.Add(retiroGBX);
            Controls.Add(destinatarioGBX);
            Controls.Add(encomiendaGBX);
            Controls.Add(confirmarBTN);
            Controls.Add(cancelarBTN);
            Name = "ImposicionCallCenterFRM";
            Text = "Imposición de Encomienda - Call Center";
            clienteGBX.ResumeLayout(false);
            clienteGBX.PerformLayout();
            retiroGBX.ResumeLayout(false);
            retiroGBX.PerformLayout();
            destinatarioGBX.ResumeLayout(false);
            destinatarioGBX.PerformLayout();
            encomiendaGBX.ResumeLayout(false);
            encomiendaGBX.PerformLayout();
            ResumeLayout(false);
        }

        private GroupBox clienteGBX;
        private Label idClienteLBL;
        private TextBox idClienteTXT;
        private Button buscarClienteBTN;

        private GroupBox retiroGBX;
        private Label ciudadLBL;
        private ComboBox ciudadCMB;
        private Label domicilioRemitenteLBL;
        private TextBox domicilioRemitenteTXT;

        private GroupBox destinatarioGBX;
        private RadioButton cdRDB;
        private RadioButton agenciaRDB;
        private RadioButton domicilioRDB;
        private ComboBox destinoCDCMB;
        private ComboBox destinoAgenciaCMB;
        private TextBox direccionDestinatarioTXT;
        private Label dniDestinatarioLBL;
        private TextBox dniDestinatarioTXT;

        private GroupBox encomiendaGBX;
        private Label tipoCajaLBL;
        private ComboBox tipoCajaCMB;
        private Label cantidadLBL;
        private TextBox cantidadTXT;
        private Button agregarBTN;
        private ListView encomiendaLST;
        private ColumnHeader colTipo;
        private ColumnHeader colCantidad;
        private Button quitarItemBTN;

        private Button confirmarBTN;
        private Button cancelarBTN;
        private Label nombreClienteLBL;
        private TextBox nombreDestinatarioTXT;
        private Label nombreDestinatarioLBL;
        private ComboBox ciudadDestinatarioCMB;
        private Label ciudadDestinatarioLBL;
        private Label direccionDestinatarioLBL;
    }
}