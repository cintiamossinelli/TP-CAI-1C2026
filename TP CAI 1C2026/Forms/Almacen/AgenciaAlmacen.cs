using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class AgenciaAlmacen
    {
        private static List<AgenciaEntidad> agencias = new();

        static AgenciaAlmacen()
        {
            if (File.Exists(@"Forms\Datos\Agencias.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\Agencias.json");
                agencias = JsonSerializer.Deserialize<List<AgenciaEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(agencias);
            File.WriteAllText(@"Forms\Datos\Agencias.json", json);
        }
    }
}
