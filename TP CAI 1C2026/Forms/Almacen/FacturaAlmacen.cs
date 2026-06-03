using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class FacturaAlmacen
    {
        private static List<FacturaEntidad> facturas = new();

        static FacturaAlmacen()
        {
            if (File.Exists(@"Forms\Datos\Facturas.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\Facturas.json");
                facturas = JsonSerializer.Deserialize<List<FacturaEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(facturas);
            File.WriteAllText(@"Forms\Datos\Facturas.json", json);
        }

    }
}
