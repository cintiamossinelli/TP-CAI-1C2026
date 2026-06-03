using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class CentroDeDistribucionAlmacen
    {
        private static List<CentroDeDistribucionEntidad> centrosDeDistribucion = new();

        static CentroDeDistribucionAlmacen()
        {
            if (File.Exists(@"Forms\Datos\CentrosDeDistribucion.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\CentrosDeDistribucion.json");
                centrosDeDistribucion = JsonSerializer.Deserialize<List<CentroDeDistribucionEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(centrosDeDistribucion);
            File.WriteAllText(@"Forms\Datos\CentrosDeDistribucion.json", json);
        }
    }
}
