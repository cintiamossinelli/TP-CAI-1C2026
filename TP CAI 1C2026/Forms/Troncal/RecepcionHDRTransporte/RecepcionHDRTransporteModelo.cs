using System;
using System.Collections.Generic;
using System.Text;
using TP_CAI_1C2026.Forms.UltimaMilla.AdmisionCD;

namespace TP_CAI_1C2026.Forms.Troncal.RecepcionHDRTransporte
{
    internal class RecepcionHDRTransporteModelo
    {
        
        internal List<Servicio> ObtenerServicios()
        {
            return new List<Servicio>
            {
                new Servicio
                {
                    Id = 1,
                    Empresa = "Flecha Bus",
                    FechayHora = new DateTime(2026, 6, 1, 8, 0, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-1-1", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "CD-1-123", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "AG-1-333", Tamaño = "M", destino = "Córdoba" },
                        new() { Id = "CD-1-2", Tamaño = "M", destino = "Santa Fe" }
                    }
                },
                new Servicio
                {
                    Id = 2,
                    Empresa = "Chevallier",
                    FechayHora = new DateTime(2026, 6, 1, 10, 30, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-1-3", Tamaño = "L", destino = "Córdoba" },
                        new() { Id = "AG-1-4", Tamaño = "S", destino = "Mendoza" },
                        new() { Id = "AG-1-103", Tamaño = "L", destino = "Rosario" },
                        new() { Id = "AG-2-123", Tamaño = "XL", destino = "Córdoba" },
                    }

                },
                new Servicio
                {
                    Id = 3,
                    Empresa = "Andesmar",
                    FechayHora = new DateTime(2026, 6, 6, 13, 15, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CD-1-9", Tamaño = "M", destino = "Rosario" },
                        new() { Id = "CC-1-7", Tamaño = "L", destino = "Santa Fe" },
                        new() { Id = "CD-2-111", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "AG-2-12", Tamaño = "M", destino = "Rosario" },
                    }

                },
                new Servicio
                {
                    Id = 4,
                    Empresa = "El Rosarino",
                    FechayHora = new DateTime(2026, 6, 7, 15, 45, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-1-5", Tamaño = "S", destino = "Córdoba" },
                        new() { Id = "CD-1-6", Tamaño = "M", destino = "Mendoza" },
                        new() { Id = "AG-3-56", Tamaño = "L", destino = "Mendoza" },
                        new() { Id = "AG-3-1", Tamaño = "XL", destino = "Mendoza" },
                    }

                },
                new Servicio
                {
                    Id = 5,
                    Empresa = "Via Bariloche",
                    FechayHora = new DateTime(2026, 6, 8, 9, 0, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-1-8", Tamaño = "L", destino = "Rosario" },
                        new() { Id = "AG-1-10", Tamaño = "S", destino = "Santa Fe" },
                        new() { Id = "CC-3-35", Tamaño = "S", destino = "Mendoza" },
                        new() { Id = "AG-3-20", Tamaño = "M", destino = "Mar del Plata" },
                    }

                },
                new Servicio
                {
                    Id = 6,
                    Empresa = "Pullman",
                    FechayHora = new DateTime(2026, 6, 4, 20, 0, 0),

                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CD-1-11", Tamaño = "M", destino = "Córdoba" },
                        new() { Id = "CC-1-12", Tamaño = "L", destino = "Mendoza" },
                        new() { Id = "CC-3-21", Tamaño = "L", destino = "Mar del Plata" },
                        new() { Id = "AG-3-22", Tamaño = "XL", destino = "Mar del Plata" },
                    }
                },
                new Servicio
                {
                    Id = 7,
                    Empresa = "Plusmar",
                    FechayHora = new DateTime(2026, 6, 19, 13, 30, 0),

                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-1-13", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "CD-1-14", Tamaño = "M", destino = "Santa Fe" },
                        new() { Id = "CD-3-23", Tamaño = "XL", destino = "Olavarria" },
                        new() { Id = "AG-3-24", Tamaño = "M", destino = "La Pampa" },
                    }
                },
                new Servicio
                {
                    Id = 8,
                    Empresa = "Crucero del Norte",
                    FechayHora = new DateTime(2026, 6, 17, 13, 15, 0),

                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-1-15", Tamaño = "L", destino = "Córdoba" },
                        new() { Id = "AG-1-16", Tamaño = "S", destino = "Mendoza" },
                        new() { Id = "AG-3-25", Tamaño = "XL", destino = "Olavarria" },
                        new() { Id = "CD-3-26", Tamaño = "S", destino = "La Pampa" },
                    }
                },
                new Servicio
                {
                    Id = 9,
                    Empresa = "Balut",
                    FechayHora = new DateTime(2026, 6, 12, 15, 45, 0),

                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CD-1-17", Tamaño = "M", destino = "Olavarria" },
                        new() { Id = "CC-1-18", Tamaño = "L", destino = "Mar del Plata" },
                        new() { Id = "AG-3-259", Tamaño = "XL", destino = "Olavarria" },
                        new() { Id = "CD-3-267", Tamaño = "S", destino = "La Pampa" },
                    }
                },
                new Servicio
                {
                    Id = 10,
                    Empresa = "El Rápido Argentino",
                    FechayHora = new DateTime(2026, 6, 21, 9, 0, 0),

                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-1-19", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "CD-1-20", Tamaño = "M", destino = "La Pampa" },
                        new() { Id = "AG-3-144", Tamaño = "XL", destino = "Olavarria" },
                        new() { Id = "CD-3-999", Tamaño = "S", destino = "La Pampa" },
                    }
                },
                new Servicio
                {
                    Id = 11,
                    Empresa = "Flecha Bus",
                    FechayHora = new DateTime(2026, 5, 30, 7, 30, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-2-21", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "CD-2-22", Tamaño = "M", destino = "Santa Fe" },
                        new() { Id = "AG-3-259", Tamaño = "XL", destino = "Olavarria" },
                        new() { Id = "CD-3-777", Tamaño = "S", destino = "La Pampa" },
                    }
                },
                new Servicio
                {
                    Id = 12,
                    Empresa = "Chevallier",
                    FechayHora = new DateTime(2026, 5, 29, 12, 0, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-2-23", Tamaño = "L", destino = "Córdoba" },
                        new() { Id = "AG-2-24", Tamaño = "S", destino = "Mendoza" }
                    }
                },
                new Servicio
                {
                    Id = 13,
                    Empresa = "Andesmar",
                    FechayHora = new DateTime(2026, 5, 28, 16, 45, 0), // anterior
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CD-2-25", Tamaño = "M", destino = "Olavarria" },
                        new() { Id = "CC-2-26", Tamaño = "L", destino = "Mar del Plata" }
                    }
                },
                new Servicio
                {
                    Id = 14,
                    Empresa = "El Rosarino",
                    FechayHora = new DateTime(2026, 5, 29, 9, 0, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-2-27", Tamaño = "S", destino = "Buenos Aires" },
                        new() { Id = "CD-2-28", Tamaño = "M", destino = "La Pampa" }
                    }
                },
                new Servicio
                {
                    Id = 15,
                    Empresa = "Via Bariloche",
                    FechayHora = new DateTime(2026, 5, 30, 8, 15, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-2-29", Tamaño = "L", destino = "Rosario" },
                        new() { Id = "AG-2-30", Tamaño = "S", destino = "Santa Fe" }
                    }
                },
                // Servicios adicionales dentro de los últimos 10 días (para que aparezcan en el filtro)
                new Servicio
                {
                    Id = 16,
                    Empresa = "Pullman",
                    FechayHora = new DateTime(2026, 5, 27, 9, 0, 0), // dentro de los últimos 10 días
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-3-31", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "CD-3-32", Tamaño = "M", destino = "Cañada de Gómez" }
                    }
                },
                new Servicio
                {
                    Id = 17,
                    Empresa = "Plusmar",
                    FechayHora = new DateTime(2026, 5, 28, 14, 30, 0), // dentro de los últimos 10 días
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-3-33", Tamaño = "L", destino = "Córdoba" },
                        new() { Id = "AG-3-34", Tamaño = "S", destino = "Mendoza" }
                    }
                },
                new Servicio
                {
                    Id = 18,
                    Empresa = "Crucero del Norte",
                    FechayHora = new DateTime(2026, 5, 29, 18, 0, 0), // dentro de los últimos 10 días
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CD-3-35", Tamaño = "M", destino = "Olavarria" },
                        new() { Id = "CC-3-36", Tamaño = "L", destino = "Mar del Plata" }
                    }
                },
                new Servicio
                {
                    Id = 19,
                    Empresa = "Balut",
                    FechayHora = new DateTime(2026, 5, 7, 7, 45, 0), // límite inferior (hace 10 días)
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-3-37", Tamaño = "S", destino = "Buenos Aires" },
                        new() { Id = "CD-3-38", Tamaño = "M", destino = "La Pampa" }
                    }
                },
                new Servicio
                {
                    Id = 20,
                    Empresa = "El Rápido Argentino",
                    FechayHora = new DateTime(2026, 5, 16, 11, 15, 0), // dentro de los últimos 10 días
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-3-39", Tamaño = "L", destino = "Rosario" },
                        new() { Id = "AG-3-40", Tamaño = "S", destino = "Santa Fe" }
                    }
                },
            };
        }
    }
}

