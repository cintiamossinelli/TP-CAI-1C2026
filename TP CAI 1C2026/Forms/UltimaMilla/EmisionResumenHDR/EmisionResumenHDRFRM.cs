namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDR
{
    public partial class EmisionResumenHDRFRM : Form
    {
        private readonly EmisionResumenHDRModelo modelo = new EmisionResumenHDRModelo();

        public EmisionResumenHDRFRM()
        {
            InitializeComponent();
        }

        private void buscarFleteroBTN_Click(object sender, EventArgs e)
        {
            var fletero = modelo.BuscarFletero(dniFleteroTXT.Text);
            if (fletero == null)
            {
                nombreFleteroLBL.Text = string.Empty;
                hdrEntregarLST.Items.Clear();
                hdrRetirarLST.Items.Clear();
                return;
            }

            nombreFleteroLBL.Text = fletero.Nombre;

            hdrEntregarLST.Items.Clear();
            hdrRetirarLST.Items.Clear();

            if (!modelo.TryObtenerEntregasYRetirosPorDni(fletero.Dni, out var entregasFiltradas, out var retirosFiltrados, out var mensaje))
            {
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nombreFleteroLBL.Text = string.Empty;
                return;
            }

            foreach (var entrega in entregasFiltradas)
            {
                ListViewItem item = new ListViewItem(entrega.NroHojaRuta.ToString());
                item.SubItems.Add(entrega.Domicilio);
                item.SubItems.Add(entrega.CantEncomiendas.ToString());
                item.Tag = entrega.DniFleteroAsignado;
                hdrEntregarLST.Items.Add(item);
            }

            foreach (var retiro in retirosFiltrados)
            {
                ListViewItem item = new ListViewItem(retiro.NroHojaRuta.ToString());
                item.SubItems.Add(retiro.Domicilio);
                item.SubItems.Add(retiro.CantEncomiendas.ToString());
                item.Tag = retiro.DniFleteroAsignado;
                hdrRetirarLST.Items.Add(item);
            }
        }

        private void emitirResumenBTN_Click(object sender, EventArgs e)
        {
            if (hdrEntregarLST.Items.Count == 0 && hdrRetirarLST.Items.Count == 0)
            {
                MessageBox.Show("No hay Hojas de Ruta cargadas para procesar la emisión de este fletero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dniNormalizado = EmisionResumenHDRModelo.NormalizarCuit(dniFleteroTXT.Text);
            if (dniNormalizado == null)
            {
                MessageBox.Show("El DNI ingresado no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ListViewItem item in hdrEntregarLST.Items)
            {
                var tagDni = item.Tag as string;
                if (string.IsNullOrWhiteSpace(tagDni) || tagDni != dniNormalizado)
                {
                    MessageBox.Show($"El DNI ingresado no coincide con la HDR N° {item.Text} en la lista de Entregas.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            foreach (ListViewItem item in hdrRetirarLST.Items)
            {
                var tagDni = item.Tag as string;
                if (string.IsNullOrWhiteSpace(tagDni) || tagDni != dniNormalizado)
                {
                    MessageBox.Show($"El DNI ingresado no coincide con la HDR N° {item.Text} en la lista de Retiros.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea generar y emitir el resumen de HDR para este fletero?",
                "Confirmar Emisión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                modelo.EmitirResumen(dniNormalizado);

                MessageBox.Show("¡Resumen de Emisión HDR generado con éxito! Se registró la orden de despacho.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarPantalla();
            }
        }

        private void LimpiarPantalla()
        {
            dniFleteroTXT.Clear();
            nombreFleteroLBL.Text = "Nombre del Fletero";
            hdrEntregarLST.Items.Clear();
            hdrRetirarLST.Items.Clear();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }
    }
}