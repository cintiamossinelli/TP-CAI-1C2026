namespace TP_CAI_1C2026
{
    partial class RendicionDelFleteroFRM
    {
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dniFleteroLBL = new Label();
            dniFleteroTXT = new TextBox();
            buscarGuiasBTN = new Button();
            encomiendasEntrantesLBL = new Label();
            detalleGuiaLBL = new Label();
            encomiendasEntrantesLST = new ListView();
            colNGuiaEntrante = new ColumnHeader();
            colEstadoEntrante = new ColumnHeader();
            colTipoPaqueteEntrante = new ColumnHeader();
            colIdClienteEntrante = new ColumnHeader();
            colDniAutorizadoEntrante = new ColumnHeader();
            encomiendasEntregadasLBL = new Label();
            encomiendasEntregadasLST = new ListView();
            colNGuiaEntregada = new ColumnHeader();
            colEstadoEntregada = new ColumnHeader();
            colTipoPaqueteEntregada = new ColumnHeader();
            colIdClienteEntregada = new ColumnHeader();
            colDniAutorizadoEntregada = new ColumnHeader();
            detalleGuiaEntregadasLBL = new Label();
            salirBTN = new Button();
            SuspendLayout();
            // 
            // dniFleteroLBL
            // 
            dniFleteroLBL.AutoSize = true;
            dniFleteroLBL.Location = new Point(12, 9);
            dniFleteroLBL.Name = "dniFleteroLBL";
            dniFleteroLBL.Size = new Size(85, 15);
            dniFleteroLBL.TabIndex = 0;
            dniFleteroLBL.Text = "DNI del Fletero";
            // 
            // dniFleteroTXT
            // 
            dniFleteroTXT.Location = new Point(12, 27);
            dniFleteroTXT.Name = "dniFleteroTXT";
            dniFleteroTXT.Size = new Size(148, 23);
            dniFleteroTXT.TabIndex = 1;
            // 
            // buscarGuiasBTN
            // 
            buscarGuiasBTN.Location = new Point(169, 27);
            buscarGuiasBTN.Name = "buscarGuiasBTN";
            buscarGuiasBTN.Size = new Size(126, 23);
            buscarGuiasBTN.TabIndex = 2;
            buscarGuiasBTN.Text = "Buscar Guías";
            buscarGuiasBTN.UseVisualStyleBackColor = true;
            // 
            // encomiendasEntrantesLBL
            // 
            encomiendasEntrantesLBL.AutoSize = true;
            encomiendasEntrantesLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            encomiendasEntrantesLBL.ForeColor = Color.MidnightBlue;
            encomiendasEntrantesLBL.Location = new Point(12, 70);
            encomiendasEntrantesLBL.Name = "encomiendasEntrantesLBL";
            encomiendasEntrantesLBL.Size = new Size(136, 15);
            encomiendasEntrantesLBL.TabIndex = 3;
            encomiendasEntrantesLBL.Text = "Encomiendas entrantes";
            encomiendasEntrantesLBL.Click += detalleGuiaEntregadasLBL_Click;
            // 
            // detalleGuiaLBL
            // 
            detalleGuiaLBL.AutoSize = true;
            detalleGuiaLBL.Location = new Point(12, 95);
            detalleGuiaLBL.Name = "detalleGuiaLBL";
            detalleGuiaLBL.Size = new Size(89, 15);
            detalleGuiaLBL.TabIndex = 4;
            detalleGuiaLBL.Text = "Detallle de Guía";
            detalleGuiaLBL.Click += detalleGuiaLBL_Click;
            // 
            // encomiendasEntrantesLST
            // 
            encomiendasEntrantesLST.Columns.AddRange(new ColumnHeader[] { colNGuiaEntrante, colEstadoEntrante, colEstadoEntrante, colIdClienteEntrante, colDniAutorizadoEntrante });
            encomiendasEntrantesLST.GridLines = true;
            encomiendasEntrantesLST.Location = new Point(12, 113);
            encomiendasEntrantesLST.Name = "encomiendasEntrantesLST";
            encomiendasEntrantesLST.Size = new Size(579, 115);
            encomiendasEntrantesLST.TabIndex = 5;
            encomiendasEntrantesLST.UseCompatibleStateImageBehavior = false;
            encomiendasEntrantesLST.View = View.Details;
            encomiendasEntrantesLST.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // colNGuiaEntrante
            // 
            colNGuiaEntrante.Text = "N° Guía";
            colNGuiaEntrante.Width = 100;
            // 
            // colEstadoEntrante
            // 
            colEstadoEntrante.Text = "Estado de Encomienda";
            colEstadoEntrante.Width = 135;
            // 
            // colTipoPaqueteEntrante
            // 
            colTipoPaqueteEntrante.Text = "Tipo de paquete";
            colTipoPaqueteEntrante.Width = 100;
            // 
            // colIdClienteEntrante
            // 
            colIdClienteEntrante.Text = "CUIT/DNI/CUIL";
            colIdClienteEntrante.Width = 100;
            // 
            // colDniAutorizadoEntrante
            // 
            colDniAutorizadoEntrante.Text = "DNI autorizado a retirar";
            colDniAutorizadoEntrante.Width = 150;
            // 
            // encomiendasEntregadasLBL
            // 
            encomiendasEntregadasLBL.AutoSize = true;
            encomiendasEntregadasLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            encomiendasEntregadasLBL.ForeColor = Color.Green;
            encomiendasEntregadasLBL.Location = new Point(12, 255);
            encomiendasEntregadasLBL.Name = "encomiendasEntregadasLBL";
            encomiendasEntregadasLBL.Size = new Size(144, 15);
            encomiendasEntregadasLBL.TabIndex = 6;
            encomiendasEntregadasLBL.Text = "Encomiendas entregadas";
            // 
            // encomiendasEntregadasLST
            // 
            encomiendasEntregadasLST.Columns.AddRange(new ColumnHeader[] { colNGuiaEntregada, colEstadoEntregada, colTipoPaqueteEntregada, colIdClienteEntregada, colDniAutorizadoEntregada });
            encomiendasEntregadasLST.GridLines = true;
            encomiendasEntregadasLST.Location = new Point(12, 300);
            encomiendasEntregadasLST.Name = "encomiendasEntregadasLST";
            encomiendasEntregadasLST.Size = new Size(579, 115);
            encomiendasEntregadasLST.TabIndex = 7;
            encomiendasEntregadasLST.UseCompatibleStateImageBehavior = false;
            encomiendasEntregadasLST.View = View.Details;
            // 
            // colNGuiaEntregada
            // 
            colNGuiaEntregada.Text = "N° Guía";
            colNGuiaEntregada.Width = 100;
            // 
            // colEstadoEntregada
            // 
            colEstadoEntregada.Text = "Estado de Encomienda";
            colEstadoEntregada.Width = 135;
            // 
            // colTipoPaqueteEntregada
            // 
            colTipoPaqueteEntregada.Text = "Tipo de paquete";
            colTipoPaqueteEntregada.Width = 100;
            // 
            // colIdClienteEntregada
            // 
            colIdClienteEntregada.Text = "CUIT/DNI/CUIL";
            colIdClienteEntregada.Width = 100;
            // 
            // colDniAutorizadoEntregada
            // 
            colDniAutorizadoEntregada.Text = "DNI autorizado a retirar";
            colDniAutorizadoEntregada.Width = 150;
            // 
            // detalleGuiaEntregadasLBL
            // 
            detalleGuiaEntregadasLBL.AutoSize = true;
            detalleGuiaEntregadasLBL.Location = new Point(12, 282);
            detalleGuiaEntregadasLBL.Name = "detalleGuiaEntregadasLBL";
            detalleGuiaEntregadasLBL.Size = new Size(89, 15);
            detalleGuiaEntregadasLBL.TabIndex = 8;
            detalleGuiaEntregadasLBL.Text = "Detallle de Guía";
            // 
            // salirBTN
            // 
            salirBTN.Location = new Point(465, 442);
            salirBTN.Name = "salirBTN";
            salirBTN.Size = new Size(126, 23);
            salirBTN.TabIndex = 9;
            salirBTN.Text = "Salir";
            salirBTN.UseVisualStyleBackColor = true;
            // 
            // RendiciónDelFletero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 477);
            Controls.Add(salirBTN);
            Controls.Add(detalleGuiaEntregadasLBL);
            Controls.Add(encomiendasEntregadasLST);
            Controls.Add(encomiendasEntregadasLBL);
            Controls.Add(encomiendasEntrantesLST);
            Controls.Add(detalleGuiaLBL);
            Controls.Add(encomiendasEntrantesLBL);
            Controls.Add(buscarGuiasBTN);
            Controls.Add(dniFleteroTXT);
            Controls.Add(dniFleteroLBL);
            Name = "RendiciónDelFletero";
            Text = "Rendicion del Fletero";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label dniFleteroLBL;
        private TextBox dniFleteroTXT;
        private Button buscarGuiasBTN;
        private Label encomiendasEntrantesLBL;
        private Label detalleGuiaLBL;
        private ListView encomiendasEntrantesLST;
        private ColumnHeader colNGuiaEntrante;
        private ColumnHeader colEstadoEntrante;
        private ColumnHeader colTipoPaqueteEntrante;
        private ColumnHeader colIdClienteEntrante;
        private ColumnHeader colDniAutorizadoEntrante;
        private Label encomiendasEntregadasLBL;
        private ListView encomiendasEntregadasLST;
        private ColumnHeader colNGuiaEntregada;
        private ColumnHeader colEstadoEntregada;
        private ColumnHeader colTipoPaqueteEntregada;
        private ColumnHeader colIdClienteEntregada;
        private ColumnHeader colDniAutorizadoEntregada;
        private Label detalleGuiaEntregadasLBL;
        private Button salirBTN;
    }
}