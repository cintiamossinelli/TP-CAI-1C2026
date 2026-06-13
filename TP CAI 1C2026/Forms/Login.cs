using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            cdCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            agenciaCMB.DropDownStyle = ComboBoxStyle.DropDownList;

            cdCMB.DisplayMember = nameof(CentroDeDistribucionEntidad.Nombre);
            cdCMB.ValueMember =
                nameof(CentroDeDistribucionEntidad.IdCentroDeDistribucion);
            cdCMB.DataSource =
                CentroDeDistribucionAlmacen.CentrosDeDistribucion
                    .OrderBy(cd => cd.Nombre)
                    .ToList();

            agenciaCMB.DisplayMember = nameof(AgenciaEntidad.Nombre);
            agenciaCMB.ValueMember = nameof(AgenciaEntidad.IdAgencia);
            agenciaCMB.DataSource = AgenciaAlmacen.Agencias
                .OrderBy(agencia => agencia.Nombre)
                .ToList();

            cdCMB.SelectedIndex = -1;
            agenciaCMB.SelectedIndex = -1;

            cdRDB.CheckedChanged += TipoAcceso_CheckedChanged;
            agenciaRDB.CheckedChanged += TipoAcceso_CheckedChanged;
            callcenterRDB.CheckedChanged += TipoAcceso_CheckedChanged;
            confirmarBTN.Click += ConfirmarBTN_Click;

            cdRDB.Checked = true;
            ActualizarCombos();
        }

        private void TipoAcceso_CheckedChanged(object? sender, EventArgs e)
        {
            ActualizarCombos();
        }

        private void ActualizarCombos()
        {
            cdCMB.Enabled = cdRDB.Checked;
            agenciaCMB.Enabled = agenciaRDB.Checked;

            if (!cdRDB.Checked)
            {
                cdCMB.SelectedIndex = -1;
            }

            if (!agenciaRDB.Checked)
            {
                agenciaCMB.SelectedIndex = -1;
            }
        }

        private void ConfirmarBTN_Click(object? sender, EventArgs e)
        {
            if (cdRDB.Checked)
            {
                if (cdCMB.SelectedItem is not CentroDeDistribucionEntidad cd)
                {
                    MessageBox.Show(
                        "Debe seleccionar un centro de distribución.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                Program.AccesoActual = TipoAcceso.CentroDeDistribucion;
                Program.CdActual = cd.IdCentroDeDistribucion;
                Program.AgenciaActual = 0;
            }
            else if (agenciaRDB.Checked)
            {
                if (agenciaCMB.SelectedItem is not AgenciaEntidad agencia)
                {
                    MessageBox.Show(
                        "Debe seleccionar una agencia.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                Program.AccesoActual = TipoAcceso.Agencia;
                Program.CdActual = 0;
                Program.AgenciaActual = agencia.IdAgencia;
            }
            else if (callcenterRDB.Checked)
            {
                Program.AccesoActual = TipoAcceso.CallCenter;
                Program.CdActual = 0;
                Program.AgenciaActual = 0;
            }
            else
            {
                MessageBox.Show(
                    "Debe seleccionar un centro de distribución, una agencia o Call Center.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Hide();

            using var principal = new Principal();
            principal.ShowDialog();

            Program.AccesoActual = TipoAcceso.Ninguno;
            Program.CdActual = 0;
            Program.AgenciaActual = 0;
            Show();
        }
    }
}
