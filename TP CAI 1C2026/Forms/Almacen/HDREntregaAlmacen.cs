using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class HDREntregaAlmacen
    {
        private static List<HDREntregaEntidad> hdrEntrega = new();
        public static IReadOnlyCollection<HDREntregaEntidad> HDREntregas => hdrEntrega.AsReadOnly();

        static HDREntregaAlmacen()
        {
            if (File.Exists(@"Forms\Datos\HDREntrega.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\HDREntrega.json");
                hdrEntrega = JsonSerializer.Deserialize<List<HDREntregaEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(hdrEntrega);
            File.WriteAllText(@"Forms\Datos\HDREntrega.json", json);
        }

        public static void Agregar(HDREntregaEntidad hdr)
        {
            hdrEntrega.Add(hdr);
        }
    }
}
