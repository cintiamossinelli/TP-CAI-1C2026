using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP_CAI_1C2026.Forms.Consultas.ConsultarTracking
{
    public partial class ConsultarTrackingFRM : Form
    {
        private readonly ConsultarTrackingModelo modelo = new ConsultarTrackingModelo();

        public ConsultarTrackingFRM()
        {
            InitializeComponent();
        }

        private void ConsultarTrackingFRM_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void buscarBTN_Click(object sender, EventArgs e)
        {
            var guia = modelo.BuscarGuia(guiaTXT.Text, out string error);
            if (guia == null)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cuitDniCuilLBL.Text = guia.CuitDniCuil;
            origenLBL.Text = guia.Origen;
            destinoLBL.Text = guia.Destino;
            tipoCajaLBL.Text = guia.TipoCaja;            

            historialLST.Items.Clear();
            foreach (var historial in guia.Historial)
            {
                var item = new ListViewItem(historial.Fecha);
                item.SubItems.Add(historial.Estado);
                historialLST.Items.Add(item);
            }
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            guiaTXT.Clear();
            cuitDniCuilLBL.Text = "CUIT/DNI/CUIL";
            origenLBL.Text = "Origen";
            destinoLBL.Text = "Destino";
            tipoCajaLBL.Text = "Tipo de Caja";            
            historialLST.Items.Clear();
        }
    }
}