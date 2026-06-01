using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class FleteroAlmacen
    {
        private static List<FleteroEntidad> fleteros = new();

        static FleteroAlmacen()
        {
            if (File.Exists(@"datos\Fleteros.json"))
            {
                string json = File.ReadAllText(@"datos\Fleteros.json");
                fleteros = JsonSerializer.Deserialize<List<FleteroEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(fleteros);
            File.WriteAllText(@"datos\Fleteros.json", json);
        }
    }
}
