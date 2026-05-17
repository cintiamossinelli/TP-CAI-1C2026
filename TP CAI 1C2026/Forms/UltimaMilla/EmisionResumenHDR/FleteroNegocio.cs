using System;
using TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega;

namespace TP_CAI_1C2026.UltimaMilla.EmisionResumenHDR
{
    class FleteroNegocio
    {
        public Fletero ValidarYBuscarFletero(string dniTexto)
        {
            // Validaciones de entrada
            if (string.IsNullOrWhiteSpace(dniTexto))
            {
                throw new ArgumentException("Por favor, ingrese el DNI del fletero.");
            }

            if (!long.TryParse(dniTexto, out long dniNumero))
            {
                throw new ArgumentException("El DNI debe contener solo números, sin puntos ni letras.");
            }

            // Busqueda en el modelo del grupo
            var modeloGrupo = new EmisionHDREntregaModelo();
            Fletero fleteroEncontrado = modeloGrupo.BuscarFletero(dniTexto);

            if (fleteroEncontrado == null)
            {
                throw new InvalidOperationException("El DNI ingresado no corresponde a un fletero registrado.");
            }

            return fleteroEncontrado;
        }

        public void ProcesarEmisionResumen(Fletero fletero, int cantidadFilasEntregas, int cantidadFilasRetiros)
        {
            // Validar que tenga movimientos
            if (cantidadFilasEntregas == 0 && cantidadFilasRetiros == 0)
            {
                throw new InvalidOperationException("No se puede emitir el Resumen B.4 porque el fletero no registra movimientos en las grillas.");
            }

            // Persistencia del resumen
            var modeloGrupo = new EmisionHDREntregaModelo();
            // modeloGrupo.GuardarResumen(fletero.Dni);
        }
    }
}