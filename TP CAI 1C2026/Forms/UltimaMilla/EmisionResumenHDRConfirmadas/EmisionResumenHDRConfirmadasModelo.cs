using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDRConfirmadas
{
    internal class EmisionResumenHDRConfirmadasModelo
    {
        // Devuelve las HDR asociadas a un fletero (por DNI)
        internal List<HDREnTransito> ObtenerHDRPorFletero(int dniFletero)
        {
            var hdrsEntrega = HDREntregaAlmacen.HDREntregas
                .Where(h => h.DniFletero == dniFletero && h.Estado == EstadoHDREnum.PendienteRendicion)
                .Select(h => new HDREnTransito
                {
                    NroHDR = h.NroHDR.ToString(),
                    Domicilio = h.Domicilio,
                    CantEcomiendas = h.CantEncomiendas,
                    DniFletero = h.DniFletero,
                    Estado = h.Estado.ToString()
                });

            var hdrsRetiro = HDRRetiroAlmacen.HDRRetiros
                .Where(h => h.DniFletero == dniFletero && h.Estado == EstadoHDREnum.PendienteRendicion)
                .Select(h => new HDREnTransito
                {
                    NroHDR = h.NroHDR.ToString(),
                    Domicilio = h.Domicilio,
                    CantEcomiendas = h.CantEncomiendas,
                    DniFletero = h.DniFletero,
                    Estado = h.Estado.ToString()
                });

            return hdrsEntrega.Concat(hdrsRetiro).ToList();
        }

        // Intenta buscar un fletero validando el texto del DNI, devuelve mensaje en caso de error
        internal bool TryBuscarFletero(string dniText, out Fletero? fletero, out string mensaje)
        {
            mensaje = string.Empty;
            fletero = null;
            if (string.IsNullOrWhiteSpace(dniText))
            {
                mensaje = "Ingrese DNI.";
                return false;
            }

            if (!int.TryParse(dniText, out int dniInt) || dniText.Length != 8)
            {
                mensaje = "El DNI debe ser numérico y de 8 dígitos.";
                return false;
            }

            fletero = BuscarFletero(dniText);
            if (fletero == null)
            {
                mensaje = "No existe ningún fletero registrado con ese DNI.";
                return false;
            }

            return true;
        }

        // Verifica que una colección de HDR pertenezcan al DNI indicado
        internal bool HDRsPertenecenADni(IEnumerable<HDREnTransito> hdrsList, int dni)
        {
            if (hdrsList == null) return false;
            return hdrsList.Any(h => h.DniFletero == dni);
        }

        // Construye el mensaje resumen para mostrar en el dialog
        internal string ConstruirResumen(IEnumerable<HDREnTransito> seleccionadas, IEnumerable<HDREnTransito> noSeleccionadas, string dniText)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Resumen Hojas de ruta para el DNI {dniText}:\n");
            sb.AppendLine("Confirmadas:");

            foreach (var h in seleccionadas)
            {
                sb.AppendLine($"- Nro HDR: {h.NroHDR} | Domicilio: {h.Domicilio} | Cant. Encomiendas: {h.CantEcomiendas}");
            }

            if (noSeleccionadas != null && noSeleccionadas.Any())
            {
                sb.AppendLine();
                sb.AppendLine("No Confirmadas:");
                foreach (var h in noSeleccionadas)
                {
                    sb.AppendLine($"- Nro HDR: {h.NroHDR} | Domicilio: {h.Domicilio} | Cant. Encomiendas: {h.CantEcomiendas}");
                }
            }

            return sb.ToString();
        }

        // Actualiza estados de HDRs: las seleccionadas pasan a "Confirmada", las otras a "No Confirmada"
        internal void ActualizarEstados(IEnumerable<HDREnTransito> todas)
        {
            if (todas == null) return;
        }

        internal Fletero? BuscarFletero(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                return null;
            }

            if (!int.TryParse(dni, out int dniInt) || dniInt <= 0 || dni.Length != 8)
            {
                return null;
            }

            var fleteroEntidad = FleteroAlmacen.Fleteros.FirstOrDefault(f => f.DNI == dniInt);

            if (fleteroEntidad == null)
            {
                return null;
            }

            return new Fletero
            {
                Dni = fleteroEntidad.DNI,
                Nombre = fleteroEntidad.Nombre
            };


        }
    }
}

    

