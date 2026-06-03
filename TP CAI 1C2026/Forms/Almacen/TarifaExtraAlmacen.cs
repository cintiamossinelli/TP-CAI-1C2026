using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class TarifaExtraAlmacen
    {
        private static List<TarifaExtraEntidad> tarifas = new();

        static TarifaExtraAlmacen()
        {
            if (File.Exists(@"datos\Tarifas.json"))
            {
                string json = File.ReadAllText(@"datos\Tarifas.json");
                tarifas = JsonSerializer.Deserialize<List<TarifaExtraEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(tarifas);
            File.WriteAllText(@"datos\Tarifas.json", json);
        }
    }
}
