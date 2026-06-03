using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class ClienteAlmacen
    {
        private static List<ClienteEntidad> clientes = new();
        
        static ClienteAlmacen()
        {
            if (File.Exists(@"Forms\Datos\Clientes.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\Clientes.json");
                clientes = JsonSerializer.Deserialize<List<ClienteEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(clientes);
            File.WriteAllText(@"Forms\Datos\Clientes.json", json);
        }
    }
}
