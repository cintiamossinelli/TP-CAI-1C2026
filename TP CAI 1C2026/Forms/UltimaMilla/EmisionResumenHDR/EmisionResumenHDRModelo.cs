using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDR
{
    internal class EmisionResumenHDRModelo
    {
        internal Fletero? BuscarFletero(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("El DNI del fletero no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var dniNormalizado = NormalizarCuit(text);
            if (dniNormalizado == null)
            {
                MessageBox.Show("El DNI del fletero debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var fleteroEntidad = FleteroAlmacen.Fleteros
                .FirstOrDefault(f => f.DNI.ToString() == dniNormalizado
                && f.IdCentroDeDistribucion == Program.CdActual);

            if (fleteroEntidad == null)
            {
                MessageBox.Show($"No se encontró un fletero con DNI {dniNormalizado}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new Fletero
            {
                Dni = fleteroEntidad.DNI.ToString(),
                Nombre = fleteroEntidad.Nombre
            };
        }

        public static string? NormalizarCuit(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return null;
            }

            string dni = new string(texto.Where(char.IsDigit).ToArray());

            if (!long.TryParse(dni, out _))
            {
                return null;
            }

            if (dni.Length != 7 && dni.Length != 8)
            {
                return null;
            }

            return dni;
        }

        public List<HDREntrega> BuscarEntregasPorDni(string dni)
        {
            return HDREntregaAlmacen.HDREntregas
                .Where(e => e.DniFletero.ToString() == dni && e.Estado == EstadoHDREnum.Emitida)
                .Select(e => new HDREntrega(
                    e.NroHDR,
                    e.Domicilio,
                    e.CantEncomiendas,
                    e.DniFletero.ToString()
                ))
                .ToList();
        }

        public List<HDRRetiro> BuscarRetirosPorDni(string dni)
        {
            return HDRRetiroAlmacen.HDRRetiros
                .Where(r => r.DniFletero.ToString() == dni && r.Estado == EstadoHDREnum.Emitida)
                .Select(r => new HDRRetiro(
                    r.NroHDR,
                    r.Domicilio,
                    r.CantEncomiendas,
                    r.DniFletero.ToString()
                ))
                .ToList();
        }

        public (List<HDREntrega> entregas, List<HDRRetiro> retiros) ObtenerEntregasYRetirosPorDni(string dni)
        {
            var entregas = BuscarEntregasPorDni(dni);
            var retiros = BuscarRetirosPorDni(dni);
            return (entregas, retiros);
        }

        public bool TryObtenerEntregasYRetirosPorDni(string dni, out List<HDREntrega> entregas, out List<HDRRetiro> retiros, out string mensaje)
        {
            entregas = BuscarEntregasPorDni(dni);
            retiros = BuscarRetirosPorDni(dni);

            if ((entregas == null || entregas.Count == 0) && (retiros == null || retiros.Count == 0))
            {
                mensaje = $"El DNI {dni} no tiene hojas de ruta asociadas.";
                return false;
            }

            mensaje = string.Empty;
            return true;
        }

        public void EmitirResumen(string dni)
        {
            var hdrRetiros = HDRRetiroAlmacen.HDRRetiros
                .Where(r => r.DniFletero.ToString() == dni && r.Estado == EstadoHDREnum.Emitida)
                .ToList();

            foreach (var retiro in hdrRetiros)
            {
                retiro.Estado = EstadoHDREnum.PendienteRendicion;
            }

            var hdrEntregas = HDREntregaAlmacen.HDREntregas
                .Where(e => e.DniFletero.ToString() == dni && e.Estado == EstadoHDREnum.Emitida)
                .ToList();

            foreach (var entrega in hdrEntregas)
            {
                var guiasDeLaHDR = GuiaAlmacen.Guias
                    .Where(g => entrega.Guias.Contains(g.NroGuia))
                    .ToList();

                if (guiasDeLaHDR.Any(g => (int)g.TipoEntrega == 2))
                {
                    entrega.Estado = EstadoHDREnum.EntregadaAlFletero;
                }
                else if (guiasDeLaHDR.Any(g => (int)g.TipoEntrega == 3))
                {
                    entrega.Estado = EstadoHDREnum.PendienteRendicion;
                }
            }

            HDRRetiroAlmacen.Guardar();
            HDREntregaAlmacen.Guardar();
        }
    }
}