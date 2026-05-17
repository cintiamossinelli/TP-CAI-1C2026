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
                    new GuiasImpuestas { Id = "CD-1-123", Tamaño = "S", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "AG-1-333", Tamaño = "M", Estado = "En Tránsito" },
                    new GuiasImpuestas { Id = "AG-1-103", Tamaño = "L", Estado = "Entregada" },
                    new GuiasImpuestas { Id = "AG-2-123", Tamaño = "XL", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "CD-2-111", Tamaño = "S", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "AG-2-12", Tamaño = "M", Estado = "En Tránsito" },
                    new GuiasImpuestas { Id = "AG-3-56", Tamaño = "L", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "AG-3-1", Tamaño = "XL", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "CC-3-35", Tamaño = "S", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "AG-3-20", Tamaño = "M", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "CC-3-21", Tamaño = "L", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "AG-3-22", Tamaño = "XL", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "CD-3-23", Tamaño = "XL", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "AG-3-24", Tamaño = "M", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "AG-3-25", Tamaño = "XL", Estado = "Impuesta" },
                    new GuiasImpuestas { Id = "CD-3-26", Tamaño = "S", Estado = "Impuesta" },
                };

                // Primero ver si ya tenemos esa guía en las agregadas (estado actualizado)
                var existenteEnMemoria = guiasAgregadas.FirstOrDefault(g => string.Equals(g.Id, text, StringComparison.OrdinalIgnoreCase));
                if (existenteEnMemoria != null)
                {
                    // Si ya existe en memoria pero su estado no es 'Impuesta', no permitir su búsqueda
                    if (!string.Equals(existenteEnMemoria.Estado, "Impuesta", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"La guía con el número {text} no está en estado 'Impuesta'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    // Devuelvo la instancia en memoria que está en estado 'Impuesta'
                    return existenteEnMemoria;
                }

                var guiaEncontrada = numGuiasSimulados.FirstOrDefault(g => g.Id == text);
                if (guiaEncontrada == null)
                {
                    MessageBox.Show($"No se encontró una guía con el número {text}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Sólo aceptar guías que estén en estado 'Impuesta'
                if (!string.Equals(guiaEncontrada.Estado, "Impuesta", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"La guía con el número {text} no está en estado 'Impuesta'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Conservamos la instancia en memoria para futuras búsquedas/actualizaciones
                guiasAgregadas.Add(guiaEncontrada);
                return guiaEncontrada;
            }

        internal bool ValidarHayGuiasParaAdmitir(IEnumerable<GuiasImpuestas> guias)
        {
            if (guias == null || !guias.Any())
            {
                MessageBox.Show("No hay guías para admitir. Por favor, agregue al menos una guía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        internal bool ValidarHayGuiasParaRechazar(IEnumerable<GuiasImpuestas> guias)
        {
            if (guias == null || !guias.Any())
            {
                MessageBox.Show("No hay guías para rechazar. Por favor, agregue al menos una guía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        internal void CambiarEstadoDeGuias(IEnumerable<GuiasImpuestas> guias, string nuevoEstado)
        {
            if (guias == null) return;
            foreach (var g in guias)
            {
                if (g != null)
                {
                    g.Estado = nuevoEstado;
                }
            }
        }
    }
}
