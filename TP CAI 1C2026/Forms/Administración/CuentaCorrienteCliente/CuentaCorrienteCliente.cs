using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter;
using TP_CAI_1C2026.Forms.Administracion.CuentaCorrienteCliente;

namespace TP_CAI_1C2026.Forms.Administracion.CuentaCorrienteCliente
{
    public partial class CuentaCorrienteClienteFRM : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        List<MovimientoCuentaCorriente> movimientos = new List<MovimientoCuentaCorriente>();

        public CuentaCorrienteClienteFRM()
        {
            InitializeComponent();
        }

        private void CuentaCorrienteClienteFRM_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarMovimientos();

            cuentaCorrienteLST.Items.Clear();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            nombreClienteLBL.Text = "";

            string cuitDniCuil = idClienteLBL.Text;

            Cliente c = BuscarCliente(cuitDniCuil);

            if (c == null)
            {
                MessageBox.Show("No existe un cliente con el CUIT / DNI / CUIL ingresado");
            }
            else
            {
                nombreClienteLBL.Text = c.Nombre;
            }
        }

        private Cliente BuscarCliente(string cuitDniCuil)
        {
            return clientes.Find(f => f.CuitDniCuil == cuitDniCuil);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cuentaCorrienteLST.Items.Clear();

            string cuitDniCuil = idClienteLBL.Text;

            Cliente c = BuscarCliente(cuitDniCuil);

            if (c == null)
            {
                MessageBox.Show("Primero debe buscar un cliente válido");
            }
            else
            {
                DateTime desde = desdeDTP.Value;
                DateTime hasta = hastaDTP.Value;

                if (desde > hasta)
                {
                    MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta");
                }
                else
                {
                    CargarCuentaCorriente(cuitDniCuil, desde, hasta);
                }
            }
        }

        private void CargarCuentaCorriente(string cuitDniCuil, DateTime desde, DateTime hasta)
        {
            decimal saldo = 0;

            foreach (MovimientoCuentaCorriente m in movimientos)
            {
                if (m.CuitDniCuil == cuitDniCuil && m.Fecha >= desde && m.Fecha <= hasta)
                {
                    saldo += m.Importe;

                    var item = new ListViewItem(m.Fecha.ToShortDateString());
                    item.SubItems.Add(m.Descripcion);
                    item.SubItems.Add(m.Importe.ToString("N2"));
                    item.SubItems.Add(saldo.ToString("N2"));

                    cuentaCorrienteLST.Items.Add(item);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarClientes()
        {
            string path = "C:\\users\\Clientes.txt";

            FileInfo fi = new FileInfo(path);

            if (!fi.Exists)
            {
                MessageBox.Show("No existe el archivo en la ruta");
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string[] vector = linea.Split(';');

                    Administracion.CuentaCorrienteCliente.Cliente c = new Administracion.CuentaCorrienteCliente.Cliente();

                    c.CuitDniCuil = vector[0];
                    c.Nombre = vector[1];

                    clientes.Add(c);
                }

                sr.Close();
            }
        }

        private void CargarMovimientos()
        {
            string path = "C:\\users\\MovimientosCuentaCorriente.txt";

            FileInfo fi = new FileInfo(path);

            if (!fi.Exists)
            {
                MessageBox.Show("No existe el archivo en la ruta");
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string[] vector = linea.Split(';');

                    MovimientoCuentaCorriente m = new MovimientoCuentaCorriente();

                    m.CuitDniCuil = vector[0];
                    m.Fecha = Convert.ToDateTime(vector[1]);
                    m.Descripcion = vector[2];
                    m.Importe = Convert.ToDecimal(vector[3]);

                    movimientos.Add(m);
                }

                sr.Close();
            }
        }
    }
}
