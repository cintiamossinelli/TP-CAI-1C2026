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
            // Busco el cliente y valido el CUIT en el modelo
            var fletero = modelo.BuscarFletero(dniFleteroTXT.Text);
            if (fletero == null)
            {
                // Salgo directo porque dejo que el modelo muestre el error
                nombreFleteroLBL.Text = string.Empty;
                hdrEntregarLST.Items.Clear();
                hdrRetirarLST.Items.Clear();
                return;
            }

            nombreFleteroLBL.Text = fletero.Nombre;

            // 1. Limpiamos las tablas antes de cargar los datos nuevos
            hdrEntregarLST.Items.Clear();
            hdrRetirarLST.Items.Clear();

            // 2. Buscamos los datos mockeados en el modelo mediante el DNI
            List<HDREntrega> entregasFiltradas = modelo.BuscarEntregasPorDni(fletero.Dni);
            List<HDRRetiro> retirosFiltrados = modelo.BuscarRetirosPorDni(fletero.Dni);

            // 3. Llenamos la tabla de Entregas (hdrEntregarLST)
            foreach (var entrega in entregasFiltradas)
            {
                ListViewItem item = new ListViewItem(entrega.NroHojaRuta.ToString());
                item.SubItems.Add(entrega.Domicilio);
                item.SubItems.Add(entrega.CantEncomiendas.ToString());
                // Guardamos el DNI del fletero asignado en el Tag para validaciones posteriores
                item.Tag = entrega.DniFleteroAsignado;
                hdrEntregarLST.Items.Add(item);
            }

            // 4. Llenamos la tabla de Retiros (hdrRetirarLST)
            foreach (var retiro in retirosFiltrados)
            {
                ListViewItem item = new ListViewItem(retiro.NroHojaRuta.ToString());
                item.SubItems.Add(retiro.Domicilio);
                item.SubItems.Add(retiro.CantEncomiendas.ToString());
                // Guardamos el DNI del fletero asignado en el Tag para validaciones posteriores
                item.Tag = retiro.DniFleteroAsignado;
                hdrRetirarLST.Items.Add(item);
            }
        }

        private void emitirResumenBTN_Click(object sender, EventArgs e)
        {
            // 1. Validamos que haya alguna hoja de ruta cargada en las listas antes de avanzar
            if (hdrEntregarLST.Items.Count == 0 && hdrRetirarLST.Items.Count == 0)
            {
                MessageBox.Show("No hay Hojas de Ruta cargadas para procesar la emisión de este fletero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1.b Validamos que el DNI ingresado corresponda a las HDR listadas
            var dniNormalizado = EmisionResumenHDRModelo.NormalizarCuit(dniFleteroTXT.Text);
            if (dniNormalizado == null)
            {
                MessageBox.Show("El DNI ingresado no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificamos cada item en Entregas
            foreach (ListViewItem item in hdrEntregarLST.Items)
            {
                var tagDni = item.Tag as string;
                if (string.IsNullOrWhiteSpace(tagDni) || tagDni != dniNormalizado)
                {
                    MessageBox.Show($"El DNI ingresado no coincide con la HDR N° {item.Text} en la lista de Entregas.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Verificamos cada item en Retiros
            foreach (ListViewItem item in hdrRetirarLST.Items)
            {
                var tagDni = item.Tag as string;
                if (string.IsNullOrWhiteSpace(tagDni) || tagDni != dniNormalizado)
                {
                    MessageBox.Show($"El DNI ingresado no coincide con la HDR N° {item.Text} en la lista de Retiros.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 2. Cuadro de confirmación al usuario
            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea generar y emitir el resumen de HDR para este fletero?", "Confirmar Emisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                MessageBox.Show("¡Resumen de Emisión HDR generado con éxito! Se registró la orden de despacho.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3. Reutilizamos el método LimpiarPantalla que tenías hecho abajo
                LimpiarPantalla();
            }
        }

        private void LimpiarPantalla()
        {
            // Limpieza general con los nombres de tu diseño
            dniFleteroTXT.Clear();
            nombreFleteroLBL.Text = "Nombre del Fletero";
            hdrEntregarLST.Items.Clear();
            hdrRetirarLST.Items.Clear();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }

        private void nombreFleteroLBL_Click(object sender, EventArgs e)
        {

        }

    }
}