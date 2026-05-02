namespace TP_CAI_1C2026.Forms
{
    partial class EmisionHDRTransporteFRM
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
            CDdestinoLBL = new Label();
            CDdestinoCMB = new ComboBox();
            GuiasLST = new ListView();
            TipoEncomiendaCol = new ColumnHeader();
            DestinoCol = new ColumnHeader();
            NumGuiaCol = new ColumnHeader();
            generarHDRBTN = new Button();
            cancelarBTN = new Button();
            seleccionarLBL = new Label();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            groupBox1 = new GroupBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // CDdestinoLBL
            // 
            CDdestinoLBL.AutoSize = true;
            CDdestinoLBL.Location = new Point(33, 29);
            CDdestinoLBL.Name = "CDdestinoLBL";
            CDdestinoLBL.Size = new Size(69, 15);
            CDdestinoLBL.TabIndex = 0;
            CDdestinoLBL.Text = "CD Destino:";
            // 
            // CDdestinoCMB
            // 
            CDdestinoCMB.FormattingEnabled = true;
            CDdestinoCMB.Location = new Point(122, 27);
            CDdestinoCMB.Margin = new Padding(3, 2, 3, 2);
            CDdestinoCMB.Name = "CDdestinoCMB";
            CDdestinoCMB.Size = new Size(399, 23);
            CDdestinoCMB.TabIndex = 1;
            // 
            // GuiasLST
            // 
            GuiasLST.CheckBoxes = true;
            GuiasLST.Columns.AddRange(new ColumnHeader[] { TipoEncomiendaCol, DestinoCol, NumGuiaCol });
            GuiasLST.GridLines = true;
            GuiasLST.Location = new Point(33, 336);
            GuiasLST.Margin = new Padding(3, 2, 3, 2);
            GuiasLST.Name = "GuiasLST";
            GuiasLST.Size = new Size(488, 193);
            GuiasLST.TabIndex = 2;
            GuiasLST.UseCompatibleStateImageBehavior = false;
            GuiasLST.View = View.Details;
            // 
            // TipoEncomiendaCol
            // 
            TipoEncomiendaCol.DisplayIndex = 1;
            TipoEncomiendaCol.Text = "Tipo de Encomienda";
            TipoEncomiendaCol.TextAlign = HorizontalAlignment.Center;
            TipoEncomiendaCol.Width = 150;
            // 
            // DestinoCol
            // 
            DestinoCol.DisplayIndex = 2;
            DestinoCol.Text = "Destino";
            DestinoCol.TextAlign = HorizontalAlignment.Center;
            DestinoCol.Width = 300;
            // 
            // NumGuiaCol
            // 
            NumGuiaCol.DisplayIndex = 0;
            NumGuiaCol.Text = "N° Guía";
            NumGuiaCol.TextAlign = HorizontalAlignment.Center;
            NumGuiaCol.Width = 100;
            // 
            // generarHDRBTN
            // 
            generarHDRBTN.Location = new Point(335, 538);
            generarHDRBTN.Margin = new Padding(3, 2, 3, 2);
            generarHDRBTN.Name = "generarHDRBTN";
            generarHDRBTN.Size = new Size(94, 24);
            generarHDRBTN.TabIndex = 6;
            generarHDRBTN.Text = "Generar HDR";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(451, 538);
            cancelarBTN.Margin = new Padding(3, 2, 3, 2);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(70, 24);
            cancelarBTN.TabIndex = 7;
            cancelarBTN.Text = "Cancelar";
            // 
            // seleccionarLBL
            // 
            seleccionarLBL.AutoSize = true;
            seleccionarLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            seleccionarLBL.ForeColor = SystemColors.HotTrack;
            seleccionarLBL.Location = new Point(33, 311);
            seleccionarLBL.Name = "seleccionarLBL";
            seleccionarLBL.Size = new Size(148, 15);
            seleccionarLBL.TabIndex = 10;
            seleccionarLBL.Text = "Seleccione guías a enviar:";
            // 
            // listView1
            // 
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.GridLines = true;
            listView1.Location = new Point(10, 52);
            listView1.Margin = new Padding(3, 2, 3, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(488, 130);
            listView1.TabIndex = 11;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.DisplayIndex = 1;
            columnHeader1.Text = "Tipo de Encomienda";
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.DisplayIndex = 2;
            columnHeader2.Text = "Destino";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            columnHeader3.DisplayIndex = 0;
            columnHeader3.Text = "N° Guía";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 100;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(listView1);
            groupBox1.Location = new Point(23, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(508, 205);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Transportes";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 19);
            label1.Name = "label1";
            label1.Size = new Size(340, 15);
            label1.TabIndex = 0;
            label1.Text = "Filtros x empresa fecha, lista todos los que hay, selecciona UNO";
            // 
            // EmisionHDRTransporteFRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 576);
            Controls.Add(groupBox1);
            Controls.Add(seleccionarLBL);
            Controls.Add(generarHDRBTN);
            Controls.Add(cancelarBTN);
            Controls.Add(GuiasLST);
            Controls.Add(CDdestinoCMB);
            Controls.Add(CDdestinoLBL);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EmisionHDRTransporteFRM";
            Text = "Emisión de Hoja de Ruta de Ómnibus";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CDdestinoLBL;
        private ComboBox CDdestinoCMB;
        private ListView GuiasLST;
        private ColumnHeader TipoEncomiendaCol;
        private ColumnHeader DestinoCol;
        private ColumnHeader NumGuiaCol;
        private Button generarHDRBTN;
        private Button cancelarBTN;
        private Label seleccionarLBL;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private GroupBox groupBox1;
        private Label label1;
    }
}