using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class ServicioAlmacen
    {
        private static List<ServicioEntidad> servicios = new();

        static ServicioAlmacen()
        {
            if (File.Exists(@"datos\Servicios.json"))
            {
                string json = File.ReadAllText(@"datos\Servicios.json");
                servicios = JsonSerializer.Deserialize<List<ServicioEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(servicios);
            File.WriteAllText(@"datos\Servicios.json", json);
        }
    }
}
