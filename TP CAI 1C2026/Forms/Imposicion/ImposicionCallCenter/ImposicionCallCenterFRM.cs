using System.Text;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter;

namespace TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter
{
    public partial class ImposicionCallCenterFRM : Form
    {
        private readonly ImposicionCallCenterModelo modelo = new ImposicionCallCenterModelo();

        public ImposicionCallCenterFRM()
        {
            InitializeComponent();
        }

        private void ImposicionCallCenterFRM_Load(object sender, EventArgs e)
        {
            //Lleno los combos con datos del modelo
            var tamañosEnvio = modelo.ObtenerTamañosEnvio();
            tipoCajaCMB.DisplayMember = "Letra";
            tipoCajaCMB.ValueMember = "Letra";
            tipoCajaCMB.DataSource = tamañosEnvio;
            tipoCajaCMB.SelectedIndex = -1;

            List<CentroDeDistribucion> cds = modelo.ObtenerCDS();
            destinoCDCMB.Items.Clear();
            foreach (var c in cds)
            {
                destinoCDCMB.Items.Add(c);
            }
            destinoCDCMB.DisplayMember = "Nombre";
            destinoCDCMB.ValueMember = "Id";

            List<Ciudad> ciudades = modelo.ObtenerCiudades();
            ciudadCMB.Items.Clear();
            ciudadAgenciaCMB.Items.Clear();
            ciudadDestinatarioCMB.Items.Clear();
            foreach (var c in ciudades)
            {
                ciudadCMB.Items.Add(c);
                ciudadAgenciaCMB.Items.Add(c);
                ciudadDestinatarioCMB.Items.Add(c);
            }
            ciudadCMB.DisplayMember = "Nombre";
            ciudadCMB.ValueMember = "Id";
            ciudadAgenciaCMB.DisplayMember = "Nombre";
            ciudadAgenciaCMB.ValueMember = "Id";
            ciudadAgenciaCMB.SelectedIndex = -1;
            ciudadDestinatarioCMB.DisplayMember = "Nombre";
            ciudadDestinatarioCMB.ValueMember = "Id";
        }

        private void ciudadAgenciaCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si no hay una ciudad seleccionada, limpio el combo de agencias y salgo
            if (ciudadAgenciaCMB.SelectedIndex == -1)
            {
                agenciaCMB.DataSource = null;
                return;
            }
            // Obtengo la ciudad seleccionada y lleno el combo de agencias con las agencias de esa ciudad
            var ciudadSeleccionada = (Ciudad)ciudadAgenciaCMB.SelectedItem;
            var agencias = ciudadSeleccionada.Agencias.OrderBy(a => a.Nombre).ToList();

            agenciaCMB.DataSource = null;
            agenciaCMB.Items.Clear();
            foreach (var agencia in agencias)
            {
                agenciaCMB.Items.Add(agencia);
            }

            agenciaCMB.DisplayMember = "Nombre";
            agenciaCMB.ValueMember = "Id";
            agenciaCMB.SelectedIndex = -1;
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

        // destinoAgenciaCMB handler removed; event bound to ciudadAgenciaCMB_SelectedIndexChanged instead.

        private void cdRDB_CheckedChanged(object sender, EventArgs e)
        {
            // Habilito combos de CD y deshabilito los de agencia y domicilio, además de limpiar selecciones y texto de destinatario
            destinoCDCMB.Enabled = cdRDB.Checked;
            agenciaCMB.SelectedIndex = -1;
            ciudadAgenciaCMB.SelectedIndex = -1;
            ciudadDestinatarioCMB.SelectedIndex = -1;
            direccionDestinatarioTXT.Text = string.Empty;
        }

        private void agenciaRDB_CheckedChanged(object sender, EventArgs e)
        {
            // Habilito combos de agencia y deshabilito los de CD y domicilio, además de limpiar selecciones y texto de destinatario
            ciudadAgenciaCMB.Enabled = agenciaRDB.Checked;
            agenciaCMB.Enabled = agenciaRDB.Checked;
            destinoCDCMB.SelectedIndex = -1;
            ciudadDestinatarioCMB.SelectedIndex = -1;
            direccionDestinatarioTXT.Text = string.Empty;
        }

        private void domicilioRDB_CheckedChanged_2(object sender, EventArgs e)
        {
            // Habilito combos de domicilio y deshabilito los de CD y agencia, además de limpiar selecciones
            ciudadDestinatarioCMB.Enabled = domicilioRDB.Checked;
            direccionDestinatarioTXT.Enabled = domicilioRDB.Checked;
            destinoCDCMB.SelectedIndex = -1;
            ciudadAgenciaCMB.SelectedIndex = -1;
            agenciaCMB.SelectedIndex = -1;
        }

        private void agregarBTN_Click(object sender, EventArgs e)
        {
            var tamaño = (TamañoEnvio)tipoCajaCMB.SelectedItem;

            if (tamaño == null)
            {
                MessageBox.Show("Seleccione un tamaño de caja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(cantidadTXT.Text, out int cantidad))
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var detalleEncomienda = modelo.AgregarCaja(tamaño, cantidad);
            if (detalleEncomienda != null) //agregarlo a la lista o actualizar existente
            {
                // Buscar si ya hay un item con la misma letra de tamaño
                var letra = detalleEncomienda.LetraTamaño;
                var existente = encomiendaLST.Items.Cast<ListViewItem>().FirstOrDefault(i => string.Equals(i.Text, letra, StringComparison.OrdinalIgnoreCase));
                if (existente != null)
                {
                    // Actualizar la cantidad en la segunda columna
                    if (existente.SubItems.Count > 1)
                    {
                        existente.SubItems[1].Text = detalleEncomienda.Cantidad.ToString();
                    }
                    else
                    {
                        existente.SubItems.Add(detalleEncomienda.Cantidad.ToString());
                    }
                    existente.Tag = detalleEncomienda;
                }
                else
                {
                    var item = new ListViewItem(detalleEncomienda.LetraTamaño);
                    item.SubItems.Add(detalleEncomienda.Cantidad.ToString());
                    item.Tag = detalleEncomienda;
                    encomiendaLST.Items.Add(item);
                }
            }
            tipoCajaCMB.SelectedIndex = -1;
            tipoCajaCMB.SelectedItem = null;
            cantidadTXT.Text = string.Empty;
        }

        private void quitarItemBTN_Click(object sender, EventArgs e)
        {
            if (encomiendaLST.SelectedItems.Count != 1)
            {
                MessageBox.Show("Seleccione un (y solo un) item para quitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var item = encomiendaLST.SelectedItems[0];
            var detalleEncomienda = (DetalleEncomienda)item.Tag;

            // El modelo devuelve true si la eliminación fue exitosa
            if (modelo.EliminarDetalle(detalleEncomienda))
            {
                encomiendaLST.Items.Remove(item);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void confirmarImpBTN_Click(object sender, EventArgs e)
        {
            var cliente = modelo.BuscarCliente(idClienteTXT.Text);
            if (cliente == null)
            {
                //salgo directo porque dejo que el modelo muestre el error.
                nombreClienteLBL.Text = string.Empty;
                return;
            }
            var ciudadRetiroSelected = ciudadCMB.SelectedIndex == -1 ? null : (Ciudad)ciudadCMB.SelectedItem;
            var cdSelected = destinoCDCMB.SelectedIndex == -1 ? null : (CentroDeDistribucion)destinoCDCMB.SelectedItem;
            var ciudadAgSelected = ciudadAgenciaCMB.SelectedIndex == -1 ? null : (Ciudad)ciudadAgenciaCMB.SelectedItem;
            var agenciaSelected = agenciaCMB.SelectedIndex == -1 ? null : (Agencia)agenciaCMB.SelectedItem;
            var ciudadDestSelected = ciudadDestinatarioCMB.SelectedIndex == -1 ? null : (Ciudad)ciudadDestinatarioCMB.SelectedItem;

            bool valido = modelo.ValidarConfirmacion(
                ciudadRetiroSelected,
                domicilioRemitenteTXT.Text,
                cdRDB.Checked,
                cdSelected,
                agenciaRDB.Checked,
                ciudadAgSelected,
                agenciaSelected,
                domicilioRDB.Checked,
                ciudadDestSelected,
                direccionDestinatarioTXT.Text,
                dniDestinatarioTXT.Text,
                nombreDestinatarioTXT.Text);

            if (!valido)
            {
                return;
            }

            // Generar números de guía y mostrarlos
            var guias = modelo.GuardarGuias(
                idClienteTXT.Text,
                ciudadRetiroSelected,
                domicilioRemitenteTXT.Text,
                cdRDB.Checked,
                cdSelected,
                agenciaRDB.Checked,
                ciudadAgSelected,
                agenciaSelected,
                domicilioRDB.Checked,
                ciudadDestSelected,
                direccionDestinatarioTXT.Text,
                dniDestinatarioTXT.Text,
                nombreDestinatarioTXT.Text);

            var sb = new StringBuilder();
            sb.AppendLine("Las siguientes guías fueron impuestas correctamente:");
            foreach (var g in guias)
            {
                sb.AppendLine(g);
            }

            //AL GRABAR, SACARLE CARACTERES ESPECIALES Y LETRAS AL CUIT DEL CLIENTE Y DNI DEL DESTINATARIO

            MessageBox.Show(sb.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ciudadCMB.SelectedIndex = -1;
            domicilioRemitenteTXT.Text = string.Empty;
            idClienteTXT.Text = string.Empty;
            nombreClienteLBL.Text = string.Empty;
            cdRDB.Checked = true;
            destinoCDCMB.SelectedIndex = -1;
            ciudadAgenciaCMB.SelectedIndex = -1;
            agenciaCMB.SelectedIndex = -1;
            ciudadDestinatarioCMB.SelectedIndex = -1;
            direccionDestinatarioTXT.Text = string.Empty;
            dniDestinatarioTXT.Text = string.Empty;
            nombreDestinatarioTXT.Text = string.Empty;
            tipoCajaCMB.SelectedIndex = -1;
            cantidadTXT.Text = string.Empty;
            encomiendaLST.Items.Clear();
            modelo.LimpiarDetalles(); // Limpio los detalles del modelo para la próxima imposición
        }
        private void cancelarImpBTN_Click(object sender, EventArgs e)
        {
            ciudadCMB.SelectedIndex = -1;
            domicilioRemitenteTXT.Text = string.Empty;
            idClienteTXT.Text = string.Empty;
            nombreClienteLBL.Text = string.Empty;
            cdRDB.Checked = true;
            destinoCDCMB.SelectedIndex = -1;
            ciudadAgenciaCMB.SelectedIndex = -1;
            agenciaCMB.SelectedIndex = -1;
            ciudadDestinatarioCMB.SelectedIndex = -1;
            direccionDestinatarioTXT.Text = string.Empty;
            dniDestinatarioTXT.Text = string.Empty;
            nombreDestinatarioTXT.Text = string.Empty;
            tipoCajaCMB.SelectedIndex = -1;
            cantidadTXT.Text = string.Empty;
            encomiendaLST.Items.Clear();
            modelo.LimpiarDetalles(); // Limpio los detalles del modelo para la próxima imposición
        }
    }
}
