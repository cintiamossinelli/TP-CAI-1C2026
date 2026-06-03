using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class HDRRetiroAlmacen
    {
        private static List<HDRRetiroEntidad> hdrRetiro = new();

        static HDRRetiroAlmacen()
        {
            if (File.Exists(@"Forms\Datos\HDRRetiro.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\HDRRetiro.json");
                hdrRetiro = JsonSerializer.Deserialize<List<HDRRetiroEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(hdrRetiro);
            File.WriteAllText(@"Forms\Datos\HDRRetiro.json", json);
        }
    }
}
