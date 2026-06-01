using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class NotaDeCreditoAlmacen
    {
        private static List<NotaDeCreditoEntidad> notasDeCredito = new();

        static NotaDeCreditoAlmacen()
        {
            if (File.Exists(@"datos\NotasDeCredito.json"))
            {
                string json = File.ReadAllText(@"datos\NotasDeCredito.json");
                notasDeCredito = JsonSerializer.Deserialize<List<NotaDeCreditoEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(notasDeCredito);
            File.WriteAllText(@"datos\NotasDeCredito.json", json);
        }
    }
}
