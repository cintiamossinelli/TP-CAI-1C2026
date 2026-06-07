using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class EmpresaTransporteAlmacen
    {
        private static List<EmpresaTransporteEntidad> empresasTransporte = new();
        public static IReadOnlyCollection<EmpresaTransporteEntidad> EmpresasTransporte => empresasTransporte.AsReadOnly();
        static EmpresaTransporteAlmacen()
        {
            if (File.Exists(@"Forms\Datos\EmpresasTransporte.json"))
            {
                string json = File.ReadAllText(@"Forms\Datos\EmpresasTransporte.json");
                empresasTransporte = JsonSerializer.Deserialize<List<EmpresaTransporteEntidad>>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonSerializer.Serialize(empresasTransporte);
            File.WriteAllText(@"Forms\Datos\EmpresasTransporte.json", json);
        }
    }
}
