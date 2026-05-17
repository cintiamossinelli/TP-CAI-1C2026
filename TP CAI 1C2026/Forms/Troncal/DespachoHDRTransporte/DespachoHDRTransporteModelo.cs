using System;
using System.Collections.Generic;

namespace TP_CAI_1C2026.Forms.Troncal.DespachoHDRTransporte
{
    internal class DespachoHDRTransporteModelo
    {
        public List<Servicio> ObtenerServicios()
        {
            var servicios = new List<Servicio>();
            var rnd = new Random(42);

            var empresas = new[]
            {
                "FlechaBus","Chevallier","Andesmar","El Rosarino","Via Bariloche",
                "Plusmar","Pullman","Jacobsen","Don Otto","Mar Y valle"
            };

            var tamaños = new[] { "S", "M", "L", "XL" };
            var destinos = new[] { "Buenos Aires", "Córdoba", "Rosario", "Mendoza", "La Plata", "Mar del Plata" };

            // Generar 15 servicios con fecha dentro de los próximos 10 días
            // y guías con IDs únicos en el formato PREFIX-mainNumber-correlativo
            var prefixes = new[] { "AG", "CC", "CD" };
            var usedIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var counters = new Dictionary<string, int>(); // key = "PREFIX-mainNumber" -> next correlativo

            for (int i = 1; i <= 15; i++)
            {
                var diasOffset = rnd.Next(0, 10); // 0..9 => dentro de los próximos 10 días
                var hora = rnd.Next(6, 22); // horario razonable
                var minuto = rnd.Next(0, 60);

                var servicio = new Servicio
                {
                    Id = i,
                    Empresa = empresas[(i - 1) % empresas.Length],
                    FechayHora = DateTime.Today.AddDays(diasOffset).AddHours(hora).AddMinutes(minuto)
                };

                // Añadir 1-3 guías de ejemplo por servicio
                int guiasCount = 1 + rnd.Next(0, 3);

                for (int g = 1; g <= guiasCount; g++)
                {
                    string newId = null;
                    int attempts = 0;
                    do
                    {
                        attempts++;
                        var prefix = prefixes[rnd.Next(prefixes.Length)];
                        var mainNumber = rnd.Next(1, 51); // 1..50 inclusive
                        var key = $"{prefix}-{mainNumber}";

                        if (!counters.TryGetValue(key, out var corr))
                        {
                            corr = 0;
                        }

                        corr++;
                        counters[key] = corr;

                        newId = $"{prefix}-{mainNumber}-{corr}";

                        if (attempts > 10000)
                        {
                            throw new InvalidOperationException("No se pudo generar un ID único para la guía después de muchos intentos");
                        }
                    }
                    while (usedIds.Contains(newId));

                    usedIds.Add(newId);

                    servicio.GuiasAsociadas.Add(new Guias
                    {
                        Id = newId,
                        Tamaño = tamaños[(i + g) % tamaños.Length],
                        destino = destinos[(i + g) % destinos.Length]
                    });
                }

                servicios.Add(servicio);
            }

            return servicios;
        }
    }
}
