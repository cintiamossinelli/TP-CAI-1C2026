using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class HDRTransporteAlmacen
    {
        private static List<HDRTransporteEntidad> hdrTransporte = new();
        public static IReadOnlyCollection<HDRTransporteEntidad> HDRTransportes => hdrTransporte.AsReadOnly();

        static HDRTransporteAlmacen()
        {
            if (File.Exists(@"Forms\Datos\HDRTransporte.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\HDRTransporte.json");
                hdrTransporte = JsonSerializer.Deserialize<List<HDRTransporteEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(hdrTransporte);
            File.WriteAllText(@"Forms\Datos\HDRTransporte.json", json);
        }
    }
}
