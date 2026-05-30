using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionResumenHDRConfirmadas
{
    internal class EmisionResumenHDRConfirmadasModelo
    {
        private List<Fletero> fleteros = new List<Fletero>
    {
        new Fletero { Dni = 12345678, Nombre = "Carlos López" },
        new Fletero { Dni = 87654321, Nombre = "Roberto Gómez" },
        new Fletero { Dni = 11223344, Nombre = "Pedro Martínez" },
        new Fletero { Dni = 99999999, Nombre = "Julián Alvarez" },
        new Fletero { Dni = 44445678, Nombre = "Pablo Perez" },
        new Fletero { Dni = 44445678, Nombre = "Marcos Gutierrez" }
    };

        private List<HDREnTransito> hdrs = new List<HDREnTransito>
    {
        // Asociamos cada HDR a un fletero mediante DniFletero y definimos su Estado
        new HDREnTransito  { NroHDR = "1001" , Domicilio = "Perú 102 - CABA" , CantEcomiendas = 3, DniFletero = 44445678, Estado = "En Tránsito" },
        new HDREnTransito  { NroHDR = "1002" , Domicilio = "Cordoba 1112 - CABA" , CantEcomiendas = 4, DniFletero = 12345678, Estado = "En Tránsito" },
        new HDREnTransito  { NroHDR = "1003" , Domicilio = "Florida 222 - CABA" , CantEcomiendas = 4, DniFletero = 87654321, Estado = "En Tránsito" },
        new HDREnTransito  { NroHDR = "1004" , Domicilio = "Lavalle 2345 - CABA" , CantEcomiendas = 1, DniFletero = 11223344, Estado = "En Tránsito" },
        new HDREnTransito  { NroHDR = "1006" , Domicilio = "Mitre 500 - CABA" , CantEcomiendas = 6, DniFletero = 99999999, Estado = "En Tránsito" },
        new HDREnTransito  { NroHDR = "1007" , Domicilio = "Mitre 600 - CABA" , CantEcomiendas = 7, DniFletero = 99999999, Estado = "En Tránsito" },
        new HDREnTransito  { NroHDR = "1005" , Domicilio = "Peron 100 - CABA" , CantEcomiendas = 3, DniFletero = 99999999, Estado = "En Tránsito" },
        new HDREnTransito  { NroHDR = "1008" , Domicilio = "Callao 500 - CABA" , CantEcomiendas = 2, DniFletero = 12345678, Estado = "Confirmada" },
        new HDREnTransito  { NroHDR = "1009" , Domicilio = "Junin 1200 - CABA" , CantEcomiendas = 2, DniFletero = 11223344, Estado = "Confirmada" }
    };

        // Devuelve las HDR asociadas a un fletero (por DNI)
        internal List<HDREnTransito> ObtenerHDRPorFletero(int dniFletero)
        {
            // Filtramos la lista de HDRs por el DNI del fletero y por Estado = "En Tránsito"
            return hdrs.Where(h => h.DniFletero == dniFletero && string.Equals(h.Estado, "En Tránsito", StringComparison.OrdinalIgnoreCase)).ToList();
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

            foreach (var h in todas)
            {
                var existente = hdrs.FirstOrDefault(x => x.NroHDR == h.NroHDR);
                if (existente != null)
                {
                    existente.Estado = h.Estado;
                }
            }
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

            var fletero = fleteros.FirstOrDefault(f => f.Dni == dniInt);

            return fletero;


        }
    }
}

    

