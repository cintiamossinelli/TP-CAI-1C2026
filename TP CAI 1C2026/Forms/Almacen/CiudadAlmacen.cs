using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class CiudadAlmacen
    {
        private static List<CiudadEntidad> ciudades = new();
        public static IReadOnlyCollection<CiudadEntidad> Ciudades => ciudades.AsReadOnly();

        static CiudadAlmacen()
        {
            if (File.Exists(@"Forms\Datos\Ciudades.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\Ciudades.json");
                ciudades = JsonSerializer.Deserialize<List<CiudadEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(ciudades);
            File.WriteAllText(@"Forms\Datos\Ciudades.json", json);
        }
    }
}
