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
            if (File.Exists(@"Forms\Datos\NotasDeCredito.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\NotasDeCredito.json");
                notasDeCredito = JsonSerializer.Deserialize<List<NotaDeCreditoEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(notasDeCredito);
            File.WriteAllText(@"Forms\Datos\NotasDeCredito.json", json);
        }
    }
}
