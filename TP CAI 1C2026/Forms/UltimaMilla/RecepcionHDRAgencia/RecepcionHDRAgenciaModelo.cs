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
                new HDR
                {
                    NumeroHDR = "HDR001"
                },

                new HDR
                {
                    NumeroHDR = "HDR002"
                },

                new HDR
                {
                    NumeroHDR = "HDR003"
                }
            };
        }

        internal List<Encomienda>
            ObtenerEncomiendasHDR(HDR hdr)
        {
            return new List<Encomienda>
            {
                new Encomienda
                {
                    NumeroGuia = "GUIA001",
                    TipoEncomienda = "S"
                },

                new Encomienda
                {
                    NumeroGuia = "GUIA002",
                    TipoEncomienda = "L"
                },

                new Encomienda
                {
                    NumeroGuia = "GUIA003",
                    TipoEncomienda = "M"
                },

                new Encomienda
                {
                    NumeroGuia = "GUIA004",
                    TipoEncomienda = "XL"
                }
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
