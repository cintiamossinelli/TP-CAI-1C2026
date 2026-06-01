using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class HDREntregaAlmacen
    {
        private static List<HDREntregaEntidad> hdrEntrega = new();

        static HDREntregaAlmacen()
        {
            if (File.Exists(@"datos\HDREntrega.json"))
            {
                string json = File.ReadAllText(@"datos\HDREntrega.json");
                hdrEntrega = JsonSerializer.Deserialize<List<HDREntregaEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(hdrEntrega);
            File.WriteAllText(@"datos\HDREntrega.json", json);
        }
    }
}
