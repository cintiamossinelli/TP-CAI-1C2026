using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Linq;
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

            var cliente = modelo.BuscarCliente(idClienteTXT.Text);
            if (cliente == null)
            {
                nombreClienteLBL.Text = string.Empty;
                cuentaCorrienteLST.Items.Clear();
                calculoSaldoLBL.Text = string.Empty;
                return;
            }

            nombreClienteLBL.Text = cliente.RazonSocial;
            desdeDTP.Value = DateTime.Now.AddDays(-30);
            hastaDTP.Value = DateTime.Now;
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
           idClienteTXT.Text = string.Empty;
           cuentaCorrienteLST.Items.Clear();
           calculoSaldoLBL.Text = string.Empty;
           nombreClienteLBL.Text = string.Empty;
           desdeDTP.Value = DateTime.Now.AddDays(-30);
           hastaDTP.Value = DateTime.Now;
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

            var cliente = modelo.ObtenerClientes(idClienteTXT.Text, fechaDesde, fechaHasta);
            if (cliente == null)
            {
                MessageBox.Show("No se encontró un cliente con el CUIT, CUIL o DNI ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nombreClienteLBL.Text = string.Empty;
                cuentaCorrienteLST.Items.Clear();
                calculoSaldoLBL.Text = string.Empty;
                return;
            }

            nombreClienteLBL.Text = cliente.RazonSocial;

            cuentaCorrienteLST.Items.Clear();

            var entradas = new List<(DateTime Fecha, ListViewItem Item)>();

            foreach (var f in cliente.Factura ?? Enumerable.Empty<Facturas>())
            {
                var it = new ListViewItem(f.Fecha.ToShortDateString());
                it.SubItems.Add($"{f.Descripcion} {f.NumeroFactura}");
                it.SubItems.Add(f.Total.ToString("N2"));
                entradas.Add((f.Fecha.Date, it));
            }

            foreach (var n in cliente.NotasDeCredito ?? Enumerable.Empty<NotaDeCredito>())
            {
                var it = new ListViewItem(n.Fecha.ToShortDateString());
                it.SubItems.Add($"{n.Descripcion} {n.NumeroNotaCredito}");
                it.SubItems.Add(n.Total.ToString("N2"));
                entradas.Add((n.Fecha.Date, it));
            }

            foreach (var r in cliente.Recibos ?? Enumerable.Empty<Recibo>())
            {
                var it = new ListViewItem(r.Fecha.ToShortDateString());
                it.SubItems.Add($"{r.Descripcion} {r.NumeroRecibo}");
                it.SubItems.Add(r.Total.ToString("N2"));
                entradas.Add((r.Fecha.Date, it));
            }

            foreach (var eItem in entradas.OrderBy(ei => ei.Fecha))
            {
                cuentaCorrienteLST.Items.Add(eItem.Item);
            }

            calculoSaldoLBL.Text = modelo.CalcularSaldo(cliente).ToString("N2");

            if (!cuentaCorrienteLST.Items.Cast<ListViewItem>().Any())
            {
                MessageBox.Show("No hay movimientos en el rango de fechas indicado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
