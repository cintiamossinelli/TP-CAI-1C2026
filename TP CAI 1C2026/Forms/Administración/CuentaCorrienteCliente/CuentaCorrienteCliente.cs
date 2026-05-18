using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Administracion.CuentaCorrienteCliente;
using TP_CAI_1C2026.Forms.Administración.CuentaCorrienteCliente;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCD;

namespace TP_CAI_1C2026.Forms.Administracion.CuentaCorrienteCliente
{
    public partial class CuentaCorrienteClienteFRM : Form
    {
        private readonly CuentaCorrienteClienteModelo modelo = new CuentaCorrienteClienteModelo();


        public CuentaCorrienteClienteFRM()
        {
            InitializeComponent();
        }

        private void CuentaCorrienteClienteFRM_Load(object sender, EventArgs e)
        {

        }

        private void buscarClienteBTN_Click(object sender, EventArgs e)
        {
            // Busco el cliente y valido el CUIT en el modelo
            var cliente = modelo.BuscarCliente(idClienteTXT.Text);
            if (cliente == null)
            {
                //salgo directo porque dejo que el modelo muestre el error.
                nombreClienteLBL.Text = string.Empty;
                return;
            }

            nombreClienteLBL.Text = cliente.RazonSocial;
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buscarBTN_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = desdeDTP.Value.Date;
            DateTime fechaHasta = hastaDTP.Value.Date;
            DateTime hoy = DateTime.Today;

            if (fechaDesde > hoy)
            {
                MessageBox.Show("La fecha Desde debe ser anterior a hoy.");
                desdeDTP.Focus();
                return;
            }

            if (fechaHasta > hoy)
            {
                MessageBox.Show("La fecha Hasta debe ser anterior a hoy.");
                hastaDTP.Focus();
                return;
            }

            if (fechaHasta < fechaDesde)
            {
                MessageBox.Show("La fecha Hasta no puede ser menor que la fecha Desde.");
                hastaDTP.Focus();
                return;
            }

            var cliente = modelo.BuscarCliente(idClienteTXT.Text);
            if (cliente == null)
            {
                //salgo directo porque dejo que el modelo muestre el error.
                nombreClienteLBL.Text = string.Empty;
                return;
            }

            nombreClienteLBL.Text = cliente.RazonSocial;
        }
    }
}
