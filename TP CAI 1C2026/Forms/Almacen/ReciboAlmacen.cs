using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class ReciboAlmacen
    {
        private static List<ReciboEntidad> recibos = new();

        static ReciboAlmacen()
        {
            if (File.Exists(@"Forms\Datos\Recibos.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\Recibos.json");
                recibos = JsonSerializer.Deserialize<List<ReciboEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(recibos);
            File.WriteAllText(@"Forms\Datos\Recibos.json", json);
        }
    }
}
