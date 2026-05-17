using System;
using System.Collections.Generic;
using System.Text;

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
                    Empresa = "Empresa A",
                    FechayHora = new DateTime(2026, 6, 1, 8, 0, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-1-1", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "CD-1-2", Tamaño = "M", destino = "Santa Fe" },
                    }
                },
                new Servicio
                {
                    Id = 2,
                    Empresa = "Empresa B",
                    FechayHora = new DateTime(2026, 6, 1, 10, 30, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-1-3", Tamaño = "L", destino = "Córdoba" },
                        new() { Id = "AG-1-4", Tamaño = "S", destino = "Mendoza" },
                    }

                },
                new Servicio
                {
                    Id = 3,
                    Empresa = "Empresa C",
                    FechayHora = new DateTime(2026, 6, 1, 13, 15, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CD-1-9", Tamaño = "M", destino = "Rosario" },
                        new() { Id = "CC-1-7", Tamaño = "L", destino = "Santa Fe" },
                    }

                },
                new Servicio
                {
                    Id = 4,
                    Empresa = "Empresa D",
                    FechayHora = new DateTime(2026, 6, 1, 15, 45, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-1-5", Tamaño = "S", destino = "Córdoba" },
                        new() { Id = "CD-1-6", Tamaño = "M", destino = "Mendoza" },
                    }

                },
                new Servicio
                {
                    Id = 5,
                    Empresa = "Empresa E",
                    FechayHora = new DateTime(2026, 6, 2, 9, 0, 0),
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-1-8", Tamaño = "L", destino = "Rosario" },
                        new() { Id = "AG-1-10", Tamaño = "S", destino = "Santa Fe" },
                    }

                },
                new Servicio
                {
                    Id = 6,
                    Empresa = "Empresa A",
                    FechayHora = new DateTime(2026, 6, 4, 20, 0, 0),

                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CD-1-11", Tamaño = "M", destino = "Córdoba" },
                        new() { Id = "CC-1-12", Tamaño = "L", destino = "Mendoza" },
                    }
                },
                new Servicio
                {
                    Id = 7,
                    Empresa = "Empresa B",
                    FechayHora = new DateTime(2026, 6, 19, 13, 30, 0),

                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-1-13", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "CD-1-14", Tamaño = "M", destino = "Santa Fe" },
                    }
                },
                new Servicio
                {
                    Id = 8,
                    Empresa = "Empresa C",
                    FechayHora = new DateTime(2026, 6, 17, 13, 15, 0),

                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-1-15", Tamaño = "L", destino = "Córdoba" },
                        new() { Id = "AG-1-16", Tamaño = "S", destino = "Mendoza" },
                    }
                },
                new Servicio
                {
                    Id = 9,
                    Empresa = "Empresa D",
                    FechayHora = new DateTime(2026, 6, 12, 15, 45, 0),

                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CD-1-17", Tamaño = "M", destino = "Olavarria" },
                        new() { Id = "CC-1-18", Tamaño = "L", destino = "Mar del Plata" },
                    }
                },
                new Servicio
                {
                    Id = 10,
                    Empresa = "Empresa E",
                    FechayHora = new DateTime(2026, 6, 21, 9, 0, 0),

                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-1-19", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "CD-1-20", Tamaño = "M", destino = "La Pampa" },



                    }
                },
                // Servicios con fecha anterior o igual a hoy (para pruebas)
                new Servicio
                {
                    Id = 11,
                    Empresa = "Empresa F",
                    FechayHora = new DateTime(2026, 5, 17, 7, 30, 0), // hoy
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-2-21", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "CD-2-22", Tamaño = "M", destino = "Santa Fe" }
                    }
                },
                new Servicio
                {
                    Id = 12,
                    Empresa = "Empresa G",
                    FechayHora = new DateTime(2026, 5, 10, 12, 0, 0), // anterior
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-2-23", Tamaño = "L", destino = "Córdoba" },
                        new() { Id = "AG-2-24", Tamaño = "S", destino = "Mendoza" }
                    }
                },
                new Servicio
                {
                    Id = 13,
                    Empresa = "Empresa H",
                    FechayHora = new DateTime(2026, 4, 25, 16, 45, 0), // anterior
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CD-2-25", Tamaño = "M", destino = "Olavarria" },
                        new() { Id = "CC-2-26", Tamaño = "L", destino = "Mar del Plata" }
                    }
                },
                new Servicio
                {
                    Id = 14,
                    Empresa = "Empresa I",
                    FechayHora = new DateTime(2026, 12, 1, 9, 0, 0), // anterior año
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-2-27", Tamaño = "S", destino = "Buenos Aires" },
                        new() { Id = "CD-2-28", Tamaño = "M", destino = "La Pampa" }
                    }
                },
                new Servicio
                {
                    Id = 15,
                    Empresa = "Empresa J",
                    FechayHora = new DateTime(2026, 5, 1, 8, 15, 0), // anterior
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
                    Empresa = "Empresa K",
                    FechayHora = new DateTime(2026, 5, 9, 9, 0, 0), // dentro de los últimos 10 días
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "AG-3-31", Tamaño = "S", destino = "Rosario" },
                        new() { Id = "CD-3-32", Tamaño = "M", destino = "Cañada de Gómez" }
                    }
                },
                new Servicio
                {
                    Id = 17,
                    Empresa = "Empresa L",
                    FechayHora = new DateTime(2026, 5, 12, 14, 30, 0), // dentro de los últimos 10 días
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CC-3-33", Tamaño = "L", destino = "Córdoba" },
                        new() { Id = "AG-3-34", Tamaño = "S", destino = "Mendoza" }
                    }
                },
                new Servicio
                {
                    Id = 18,
                    Empresa = "Empresa M",
                    FechayHora = new DateTime(2026, 5, 14, 18, 0, 0), // dentro de los últimos 10 días
                    GuiasAsociadas = new List<Guias>
                    {
                        new() { Id = "CD-3-35", Tamaño = "M", destino = "Olavarria" },
                        new() { Id = "CC-3-36", Tamaño = "L", destino = "Mar del Plata" }
                    }
                },
                new Servicio
                {
                    Id = 19,
                    Empresa = "Empresa N",
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
                    Empresa = "Empresa O",
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

