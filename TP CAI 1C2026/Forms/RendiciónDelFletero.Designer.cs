namespace TP_CAI_1C2026.Forms
{
    partial class RendiciónDelFletero
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
            textBox1 = new TextBox();
            buscarGuiasBTN = new Button();
            encomiendasEntrantesLBL = new Label();
            detalleGuiaLBL = new Label();
            encomiendasEntrantesLVW = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            encomiendasEntregadasLBL = new Label();
            encomiendasEntregadasLVW = new ListView();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            label1 = new Label();
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
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 23);
            textBox1.TabIndex = 1;
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
            encomiendasEntrantesLBL.Click += label1_Click;
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
            // encomiendasEntrantesLVW
            // 
            encomiendasEntrantesLVW.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            encomiendasEntrantesLVW.GridLines = true;
            encomiendasEntrantesLVW.Location = new Point(12, 113);
            encomiendasEntrantesLVW.Name = "encomiendasEntrantesLVW";
            encomiendasEntrantesLVW.Size = new Size(579, 115);
            encomiendasEntrantesLVW.TabIndex = 5;
            encomiendasEntrantesLVW.UseCompatibleStateImageBehavior = false;
            encomiendasEntrantesLVW.View = View.Details;
            encomiendasEntrantesLVW.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "N° Guía";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Estado de Encomienda";
            columnHeader2.Width = 135;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Tipo de paquete";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "CUIT/DNI/CUIL";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "DNI autorizado a retirar";
            columnHeader5.Width = 150;
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
            // encomiendasEntregadasLVW
            // 
            encomiendasEntregadasLVW.Columns.AddRange(new ColumnHeader[] { columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            encomiendasEntregadasLVW.GridLines = true;
            encomiendasEntregadasLVW.Location = new Point(12, 300);
            encomiendasEntregadasLVW.Name = "encomiendasEntregadasLVW";
            encomiendasEntregadasLVW.Size = new Size(579, 115);
            encomiendasEntregadasLVW.TabIndex = 7;
            encomiendasEntregadasLVW.UseCompatibleStateImageBehavior = false;
            encomiendasEntregadasLVW.View = View.Details;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "N° Guía";
            columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Estado de Encomienda";
            columnHeader7.Width = 135;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Tipo de paquete";
            columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "CUIT/DNI/CUIL";
            columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "DNI autorizado a retirar";
            columnHeader10.Width = 150;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 282);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 8;
            label1.Text = "Detallle de Guía";
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
            Controls.Add(label1);
            Controls.Add(encomiendasEntregadasLVW);
            Controls.Add(encomiendasEntregadasLBL);
            Controls.Add(encomiendasEntrantesLVW);
            Controls.Add(detalleGuiaLBL);
            Controls.Add(encomiendasEntrantesLBL);
            Controls.Add(buscarGuiasBTN);
            Controls.Add(textBox1);
            Controls.Add(dniFleteroLBL);
            Name = "RendiciónDelFletero";
            Text = "Rendicion del Fletero";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label dniFleteroLBL;
        private TextBox textBox1;
        private Button buscarGuiasBTN;
        private Label encomiendasEntrantesLBL;
        private Label detalleGuiaLBL;
        private ListView encomiendasEntrantesLVW;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Label encomiendasEntregadasLBL;
        private ListView encomiendasEntregadasLVW;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Label label1;
        private Button salirBTN;
    }
}