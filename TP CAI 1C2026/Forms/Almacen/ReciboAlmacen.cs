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
            if (File.Exists(@"datos\Recibos.json"))
            {
                string json = File.ReadAllText(@"datos\Recibos.json");
                recibos = JsonSerializer.Deserialize<List<ReciboEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(recibos);
            File.WriteAllText(@"datos\Recibos.json", json);
        }
    }
}
