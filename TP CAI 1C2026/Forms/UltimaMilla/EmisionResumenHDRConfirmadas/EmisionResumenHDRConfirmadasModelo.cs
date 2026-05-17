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
        new Fletero { Dni = 33334444, Nombre = "Marcos Gutierrez" }
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

    

