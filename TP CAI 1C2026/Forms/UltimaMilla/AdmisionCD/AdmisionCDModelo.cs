using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCD;

namespace TP_CAI_1C2026.Forms.UltimaMilla.AdmisionCD
{
    internal class AdmisionCDModelo
    {

        private List<GuiasImpuestas> guiasAgregadas = new List<GuiasImpuestas>();
        internal GuiasImpuestas? BuscarGuias(string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    MessageBox.Show("El número de guía no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Simulación de búsqueda en una base de datos o servicio
                var numGuiasSimulados = new List<GuiasImpuestas>
                {
                    new GuiasImpuestas { Id = "CD-CAB-123", Tamaño = "S" },
                    new GuiasImpuestas { Id = "AG-ROS-333", Tamaño = "M" },
                    new GuiasImpuestas { Id = "AG-CAB-103", Tamaño = "L" },
                    new GuiasImpuestas { Id = "AG-REC-123", Tamaño = "XL" },
                    new GuiasImpuestas { Id = "CD-COR-111", Tamaño = "S" },
                    new GuiasImpuestas { Id = "AG-TUC-12", Tamaño = "M" },
                    new GuiasImpuestas { Id = "AG-SAL-56", Tamaño = "L" },
                    new GuiasImpuestas { Id = "AG-CAT-1236", Tamaño = "XL" },
                };

                var guiaEncontrada = numGuiasSimulados.FirstOrDefault(g => g.Id == text);
                if (guiaEncontrada == null)
                    {
                        MessageBox.Show($"No se encontró una guía con el número {text}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                return guiaEncontrada;
            }
    }
}
