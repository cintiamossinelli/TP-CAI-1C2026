using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class GuiaAlmacen
    {
        private static List<GuiaEntidad> guias = new();
        public static IReadOnlyCollection<GuiaEntidad> Guias => guias.AsReadOnly();

        static GuiaAlmacen()
        {
            if (File.Exists(@"Forms\Datos\Guias.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\Guias.json");
                guias = JsonSerializer.Deserialize<List<GuiaEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(guias);
            File.WriteAllText(@"Forms\Datos\Guias.json", json);
        }
    }
}

