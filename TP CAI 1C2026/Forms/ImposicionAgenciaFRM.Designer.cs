namespace TP_CAI_1C2026
{
    partial class ImposicionAgenciaFRM
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
            idClienteLBL = new Label();
            idClienteTXT = new TextBox();
            buscarClienteBTN = new Button();
            destinatarioGBX = new GroupBox();
            cdRDB = new RadioButton();
            agenciaRDB = new RadioButton();
            domicilioRDB = new RadioButton();
            destinoCDCMB = new ComboBox();
            destinoAgenciaCMB = new ComboBox();
            destinoDomicilioTXT = new TextBox();
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
            destinatarioGBX.SuspendLayout();
            encomiendaGBX.SuspendLayout();
            SuspendLayout();
            // 
            // clienteGBX
            // 
            clienteGBX.Controls.Add(idClienteLBL);
            clienteGBX.Controls.Add(idClienteTXT);
            clienteGBX.Controls.Add(buscarClienteBTN);
            clienteGBX.Location = new Point(12, 12);
            clienteGBX.Name = "clienteGBX";
            clienteGBX.Size = new Size(649, 60);
            clienteGBX.TabIndex = 0;
            clienteGBX.TabStop = false;
            clienteGBX.Text = "Cliente";
            // 
            // idClienteLBL
            // 
            idClienteLBL.Location = new Point(10, 25);
            idClienteLBL.Name = "idClienteLBL";
            idClienteLBL.Size = new Size(120, 23);
            idClienteLBL.TabIndex = 0;
            idClienteLBL.Text = "CUIT / DNI / CUIL:";
            idClienteLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // idClienteTXT
            // 
            idClienteTXT.Location = new Point(135, 23);
            idClienteTXT.MaxLength = 11;
            idClienteTXT.Name = "idClienteTXT";
            idClienteTXT.Size = new Size(180, 23);
            idClienteTXT.TabIndex = 1;
            // 
            // buscarClienteBTN
            // 
            buscarClienteBTN.Location = new Point(321, 21);
            buscarClienteBTN.Name = "buscarClienteBTN";
            buscarClienteBTN.Size = new Size(110, 27);
            buscarClienteBTN.TabIndex = 2;
            buscarClienteBTN.Text = "Buscar Cliente";
            // 
            // destinatarioGBX
            // 
            destinatarioGBX.Controls.Add(cdRDB);
            destinatarioGBX.Controls.Add(agenciaRDB);
            destinatarioGBX.Controls.Add(domicilioRDB);
            destinatarioGBX.Controls.Add(destinoCDCMB);
            destinatarioGBX.Controls.Add(destinoAgenciaCMB);
            destinatarioGBX.Controls.Add(destinoDomicilioTXT);
            destinatarioGBX.Controls.Add(dniDestinatarioLBL);
            destinatarioGBX.Controls.Add(dniDestinatarioTXT);
            destinatarioGBX.Location = new Point(12, 85);
            destinatarioGBX.Name = "destinatarioGBX";
            destinatarioGBX.Size = new Size(649, 213);
            destinatarioGBX.TabIndex = 1;
            destinatarioGBX.TabStop = false;
            destinatarioGBX.Text = "Destinatario";
            // 
            // cdRDB
            // 
            cdRDB.Location = new Point(10, 28);
            cdRDB.Name = "cdRDB";
            cdRDB.Size = new Size(41, 23);
            cdRDB.TabIndex = 0;
            cdRDB.Text = "CD";
            // 
            // agenciaRDB
            // 
            agenciaRDB.Location = new Point(330, 28);
            agenciaRDB.Name = "agenciaRDB";
            agenciaRDB.Size = new Size(70, 23);
            agenciaRDB.TabIndex = 1;
            agenciaRDB.Text = "Agencia";
            // 
            // domicilioRDB
            // 
            domicilioRDB.Location = new Point(10, 86);
            domicilioRDB.Name = "domicilioRDB";
            domicilioRDB.Size = new Size(85, 23);
            domicilioRDB.TabIndex = 2;
            domicilioRDB.Text = "Domicilio";
            // 
            // destinoCDCMB
            // 
            destinoCDCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            destinoCDCMB.Enabled = false;
            destinoCDCMB.Location = new Point(330, 57);
            destinoCDCMB.Name = "destinoCDCMB";
            destinoCDCMB.Size = new Size(305, 23);
            destinoCDCMB.TabIndex = 4;
            // 
            // destinoAgenciaCMB
            // 
            destinoAgenciaCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            destinoAgenciaCMB.Enabled = false;
            destinoAgenciaCMB.Location = new Point(10, 57);
            destinoAgenciaCMB.Name = "destinoAgenciaCMB";
            destinoAgenciaCMB.Size = new Size(305, 23);
            destinoAgenciaCMB.TabIndex = 6;
            // 
            // destinoDomicilioTXT
            // 
            destinoDomicilioTXT.Enabled = false;
            destinoDomicilioTXT.Location = new Point(10, 115);
            destinoDomicilioTXT.Name = "destinoDomicilioTXT";
            destinoDomicilioTXT.Size = new Size(625, 23);
            destinoDomicilioTXT.TabIndex = 8;
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
            dniDestinatarioTXT.Size = new Size(184, 23);
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
            encomiendaGBX.Location = new Point(12, 310);
            encomiendaGBX.Name = "encomiendaGBX";
            encomiendaGBX.Size = new Size(649, 248);
            encomiendaGBX.TabIndex = 2;
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
            tipoCajaCMB.Size = new Size(150, 23);
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
            cantidadTXT.Size = new Size(140, 23);
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
            confirmarBTN.Location = new Point(495, 590);
            confirmarBTN.Name = "confirmarBTN";
            confirmarBTN.Size = new Size(80, 32);
            confirmarBTN.TabIndex = 3;
            confirmarBTN.Text = "Confirmar";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(581, 590);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(80, 32);
            cancelarBTN.TabIndex = 4;
            cancelarBTN.Text = "Cancelar";
            // 
            // ImposicionAgenciaFRM
            // 
            ClientSize = new Size(675, 640);
            Controls.Add(clienteGBX);
            Controls.Add(destinatarioGBX);
            Controls.Add(encomiendaGBX);
            Controls.Add(confirmarBTN);
            Controls.Add(cancelarBTN);
            Name = "ImposicionAgenciaFRM";
            Text = "Imposición de Encomienda - Agencia";
            clienteGBX.ResumeLayout(false);
            clienteGBX.PerformLayout();
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

        private GroupBox destinatarioGBX;
        private RadioButton cdRDB;
        private RadioButton agenciaRDB;
        private RadioButton domicilioRDB;
        private ComboBox destinoCDCMB;
        private ComboBox destinoAgenciaCMB;
        private TextBox destinoDomicilioTXT;
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
    }
}