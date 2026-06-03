using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class TarifaExtraAlmacen
    {
        private static List<TarifaExtraEntidad> tarifas = new();

        static TarifaExtraAlmacen()
        {
            if (File.Exists(@"Forms\Datos\Tarifas.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\Tarifas.json");
                tarifas = JsonSerializer.Deserialize<List<TarifaExtraEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(tarifas);
            File.WriteAllText(@"Forms\Datos\Tarifas.json", json);
        }
    }
}
