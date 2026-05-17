using System;
using System.Collections.Generic;
using System.Linq;

namespace TP_CAI_1C2026.Forms.UltimaMilla.RecepcionHDRAgencia
{
    internal class RecepcionHDRAgenciaModelo
    {
        internal List<HDR> ObtenerHDRsPendientes()
        {
            return new List<HDR>
            {
                new HDR { NumeroHDR = "1001" },
                new HDR { NumeroHDR = "1002" },
                new HDR { NumeroHDR = "1003" },
                new HDR { NumeroHDR = "1004" }
            };
        }

        internal List<Encomienda> ObtenerEncomiendasHDR(HDR hdr)
        {
            if (hdr == null)
                return new List<Encomienda>();

            return hdr.NumeroHDR switch
            {
                "1001" => new List<Encomienda>
                {
                    new Encomienda { NumeroGuia = "CD-2-111", TipoEncomienda = "S" }

                },
                "1002" => new List<Encomienda>
                {
                    new Encomienda { NumeroGuia = "AG-2-123", TipoEncomienda = "L" }
                },
                "1003" => new List<Encomienda>
                {
                    new Encomienda { NumeroGuia = "CC-3-21", TipoEncomienda = "M" }
                },
                "1004" => new List<Encomienda>
                {
                    new Encomienda { NumeroGuia = "AG-1-333", TipoEncomienda = "XL" },
                    new Encomienda { NumeroGuia = "AG-3-56", TipoEncomienda = "S" }
                },
                _ => new List<Encomienda>()
            };
        }

        internal void RecepcionarHDR(HDR hdr)
        {
            // Simulación de recepción
            // Más adelante:
            // - actualizar estado HDR
            // - actualizar encomiendas
            // - registrar fecha recepción
            // - guardar en BD
        }
    }
}
