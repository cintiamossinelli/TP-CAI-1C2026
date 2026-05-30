using System;
using System.Collections.Generic;
using System.Linq;

namespace TP_CAI_1C2026.Forms.UltimaMilla.RecepcionHDRAgencia
{
    internal class RecepcionHDRAgenciaModelo
    {
        // Estado seleccionado mantenido en el modelo
        internal HDR Seleccionada { get; set; }

        // Encomiendas pertenecientes al HDR seleccionado
        internal List<Encomienda> EncomiendasHDR { get; set; } = new List<Encomienda>();

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
            {
                EncomiendasHDR = new List<Encomienda>();
                return EncomiendasHDR;
            }

            var lista = hdr.NumeroHDR switch
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

            EncomiendasHDR = lista;
            return lista;
        }

        internal void RecepcionarHDR(HDR hdr)
        {

        }

        // Validación de selección de HDR (mover validaciones desde la UI al modelo)
        internal bool ValidarSeleccionHDR(HDR hdr, int selectedIndex, out string mensaje)
        {
            mensaje = string.Empty;
            if (hdr == null || selectedIndex == -1)
            {
                mensaje = "Debe seleccionar un HDR.";
                return false;
            }
            return true;
        }

        internal bool ConfirmarRecepcionHDR(HDR hdr)
        {
            // Aquí podría ir la lógica de negocio para marcar el HDR como recibido en la base de datos.
            // En este ejemplo simulado simplemente retornamos true para indicar éxito.
            return hdr != null;
        }
    }
}
