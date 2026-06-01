using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class HDRTransporteAlmacen
    {
        private static List<HDRTransporteEntidad> hdrTransporte = new();

        static HDRTransporteAlmacen()
        {
            if (File.Exists(@"datos\HDRTransporte.json"))
            {
                string json = File.ReadAllText(@"datos\HDRTransporte.json");
                hdrTransporte = JsonSerializer.Deserialize<List<HDRTransporteEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(hdrTransporte);
            File.WriteAllText(@"datos\HDRTransporte.json", json);
        }
    }
}
