namespace TP_CAI_1C2026.Forms
{
    partial class CuentaCorrienteCliente
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
            nombreClienteLBL = new Label();
            idClienteLBL = new Label();
            idClienteTXT = new TextBox();
            buscarClienteBTN = new Button();
            CuentaCorrienteLST = new ListView();
            FechaCol = new ColumnHeader();
            NumeroCol = new ColumnHeader();
            ImporteCol = new ColumnHeader();
            SaldoCol = new ColumnHeader();
            salirBTN = new Button();
            SuspendLayout();
            // 
            // nombreClienteLBL
            // 
            nombreClienteLBL.AutoSize = true;
            nombreClienteLBL.BackColor = SystemColors.ActiveCaption;
            nombreClienteLBL.Location = new Point(130, 45);
            nombreClienteLBL.Name = "nombreClienteLBL";
            nombreClienteLBL.Size = new Size(110, 15);
            nombreClienteLBL.TabIndex = 7;
            nombreClienteLBL.Text = "Nombre del Cliente";
            // 
            // idClienteLBL
            // 
            idClienteLBL.Location = new Point(19, 22);
            idClienteLBL.Name = "idClienteLBL";
            idClienteLBL.Size = new Size(113, 17);
            idClienteLBL.TabIndex = 4;
            idClienteLBL.Text = "CUIT / DNI / CUIL:";
            idClienteLBL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // idClienteTXT
            // 
            idClienteTXT.Location = new Point(130, 20);
            idClienteTXT.Margin = new Padding(3, 2, 3, 2);
            idClienteTXT.MaxLength = 11;
            idClienteTXT.Name = "idClienteTXT";
            idClienteTXT.Size = new Size(140, 23);
            idClienteTXT.TabIndex = 5;
            // 
            // buscarClienteBTN
            // 
            buscarClienteBTN.Location = new Point(285, 20);
            buscarClienteBTN.Margin = new Padding(3, 2, 3, 2);
            buscarClienteBTN.Name = "buscarClienteBTN";
            buscarClienteBTN.Size = new Size(100, 20);
            buscarClienteBTN.TabIndex = 6;
            buscarClienteBTN.Text = "Buscar";
            // 
            // CuentaCorrienteLST
            // 
            CuentaCorrienteLST.Columns.AddRange(new ColumnHeader[] { FechaCol, NumeroCol, ImporteCol, SaldoCol });
            CuentaCorrienteLST.GridLines = true;
            CuentaCorrienteLST.Location = new Point(19, 71);
            CuentaCorrienteLST.Margin = new Padding(3, 2, 3, 2);
            CuentaCorrienteLST.Name = "CuentaCorrienteLST";
            CuentaCorrienteLST.Size = new Size(504, 219);
            CuentaCorrienteLST.TabIndex = 8;
            CuentaCorrienteLST.UseCompatibleStateImageBehavior = false;
            CuentaCorrienteLST.View = View.Details;
            // 
            // FechaCol
            // 
            FechaCol.Text = "Fecha";
            FechaCol.Width = 100;
            // 
            // NumeroCol
            // 
            NumeroCol.Text = "Número";
            NumeroCol.Width = 100;
            // 
            // ImporteCol
            // 
            ImporteCol.Text = "Importe";
            ImporteCol.TextAlign = HorizontalAlignment.Right;
            ImporteCol.Width = 100;
            // 
            // SaldoCol
            // 
            SaldoCol.Text = "Saldo";
            SaldoCol.TextAlign = HorizontalAlignment.Right;
            SaldoCol.Width = 100;
            // 
            // salirBTN
            // 
            salirBTN.Location = new Point(453, 303);
            salirBTN.Margin = new Padding(3, 2, 3, 2);
            salirBTN.Name = "salirBTN";
            salirBTN.Size = new Size(70, 24);
            salirBTN.TabIndex = 9;
            salirBTN.Text = "Salir";
            // 
            // CuentaCorrienteCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 356);
            Controls.Add(salirBTN);
            Controls.Add(CuentaCorrienteLST);
            Controls.Add(nombreClienteLBL);
            Controls.Add(idClienteLBL);
            Controls.Add(idClienteTXT);
            Controls.Add(buscarClienteBTN);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CuentaCorrienteCliente";
            Text = "Cuenta Corriente Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nombreClienteLBL;
        private Label idClienteLBL;
        private TextBox idClienteTXT;
        private Button buscarClienteBTN;
        private ListView CuentaCorrienteLST;
        private ColumnHeader FechaCol;
        private ColumnHeader NumeroCol;
        private ColumnHeader ImporteCol;
        private ColumnHeader SaldoCol;
        private Button salirBTN;
    }
}