using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TP_CAI_1C2026.Forms.Troncal.DespachoHDRTransporte
{
    partial class DespachoHDRTransporte
    {
        private void InitializeComponent()
        {
            servicioOmnibusLBL = new Label();
            listView1 = new ListView();
            columnNumGuia = new ColumnHeader();
            columnTipoEncomienda = new ColumnHeader();
            columnDestino = new ColumnHeader();
            HDRnumCMB = new ComboBox();
            despacharHDRBTN = new Button();
            cancelarBTN = new Button();
            SuspendLayout();
            // 
            // servicioOmnibusLBL
            // 
            servicioOmnibusLBL.AutoSize = true;
            servicioOmnibusLBL.Location = new Point(22, 35);
            servicioOmnibusLBL.Name = "servicioOmnibusLBL";
            servicioOmnibusLBL.Size = new Size(116, 15);
            servicioOmnibusLBL.TabIndex = 0;
            servicioOmnibusLBL.Text = "Servicio de Ómnibus";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnNumGuia, columnTipoEncomienda, columnDestino });
            listView1.GridLines = true;
            listView1.Location = new Point(26, 82);
            listView1.Name = "listView1";
            listView1.Size = new Size(494, 206);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnNumGuia
            // 
            columnNumGuia.Text = "N° Guía";
            columnNumGuia.Width = 150;
            // 
            // columnTipoEncomienda
            // 
            columnTipoEncomienda.Text = "Tipo de Encomienda";
            columnTipoEncomienda.Width = 150;
            // 
            // columnDestino
            // 
            columnDestino.Text = "Destino";
            columnDestino.Width = 200;
            // 
            // HDRnumCMB
            // 
            HDRnumCMB.FormattingEnabled = true;
            HDRnumCMB.Location = new Point(144, 32);
            HDRnumCMB.Margin = new Padding(3, 2, 3, 2);
            HDRnumCMB.Name = "HDRnumCMB";
            HDRnumCMB.Size = new Size(376, 23);
            HDRnumCMB.TabIndex = 10;
            HDRnumCMB.SelectedIndexChanged += HDRnumCMB_SelectedIndexChanged;
            // 
            // despacharHDRBTN
            // 
            despacharHDRBTN.Location = new Point(327, 311);
            despacharHDRBTN.Margin = new Padding(3, 2, 3, 2);
            despacharHDRBTN.Name = "despacharHDRBTN";
            despacharHDRBTN.Size = new Size(117, 24);
            despacharHDRBTN.TabIndex = 12;
            despacharHDRBTN.Text = "Despachar HDR";
            despacharHDRBTN.Click += despacharHDRBTN_Click;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(450, 311);
            cancelarBTN.Margin = new Padding(3, 2, 3, 2);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(70, 24);
            cancelarBTN.TabIndex = 13;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // DespachoHDRTransporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 348);
            Controls.Add(cancelarBTN);
            Controls.Add(despacharHDRBTN);
            Controls.Add(HDRnumCMB);
            Controls.Add(listView1);
            Controls.Add(servicioOmnibusLBL);
            Name = "DespachoHDRTransporte";
            Text = "Despacho de Hoja de Ruta de Ómnibus";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label servicioOmnibusLBL;
        private ListView listView1;
        private ColumnHeader columnNumGuia;
        private ColumnHeader columnTipoEncomienda;
        private ColumnHeader columnDestino;
        private ComboBox HDRnumCMB;
        private Button despacharHDRBTN;
        private Button cancelarBTN;
    }
}