namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega;

internal class EmisionHDREntregaModelo
{
    private List<Fletero> fleteros = new List<Fletero>
    {
        new Fletero { Dni = 12345678, Nombre = "Carlos López" },
        new Fletero { Dni = 87654321, Nombre = "Roberto Gómez" },
        new Fletero { Dni = 11223344, Nombre = "Pedro Martínez" }
    };

    private List<Guia> guias = new List<Guia>
    {
        new Guia { NGuia = "CD-3-1", TipoCaja = "S", LugarEntrega = "Av. Corrientes 1234, Buenos Aires" },
        new Guia { NGuia = "CD-3-2", TipoCaja = "M", LugarEntrega = "Agencia Microcentro, Buenos Aires" },
        new Guia { NGuia = "AG-9-1", TipoCaja = "XL", LugarEntrega = "Agencia Palermo, Buenos Aires" },
        new Guia { NGuia = "AG-5-1", TipoCaja = "L", LugarEntrega = "Av. Santa Fe 567, Rosario" },
        new Guia { NGuia = "AG-5-2", TipoCaja = "S", LugarEntrega = "Agencia Rosario Norte, Rosario" },
        new Guia { NGuia = "CD-4-1", TipoCaja = "S", LugarEntrega = "Av. Colón 890, Córdoba" },
        new Guia { NGuia = "CD-4-2", TipoCaja = "M", LugarEntrega = "Agencia Córdoba Centro, Córdoba" },
        new Guia { NGuia = "CD-5-1", TipoCaja = "L", LugarEntrega = "Av. San Martín 123, Mendoza" },
        new Guia { NGuia = "CD-5-2", TipoCaja = "XL", LugarEntrega = "Agencia Mendoza Centro, Mendoza" },
        new Guia { NGuia = "CD-6-1", TipoCaja = "S", LugarEntrega = "Av. Alem 456, Tucumán" },
        new Guia { NGuia = "CD-6-2", TipoCaja = "M", LugarEntrega = "Agencia San Miguel de Tucumán Centro, Tucumán" }
    };

    private List<string> localidades = new List<string>
    {
        "Buenos Aires",
        "Córdoba",
        "Rosario",
        "Mendoza",
        "Tucumán"
    };

    private int ultimoNumeroHDR = 500;

    internal Fletero? BuscarFletero(string dni)
    {
        if (string.IsNullOrWhiteSpace(dni))
        {
            MessageBox.Show("El DNI no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        if (!int.TryParse(dni, out int dniInt) || dniInt <= 0 || dni.Length != 8)
        {
            MessageBox.Show("El DNI debe ser numérico, positivo y de 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var fletero = fleteros.FirstOrDefault(f => f.Dni == dniInt);
        if (fletero == null)
        {
            MessageBox.Show($"No se encontró ningún fletero con DNI {dni}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        return fletero;
    }

    internal List<Guia> ObtenerGuiasPendientes()
    {
        return guias;
    }

    internal Guia? BuscarGuia(string nGuia)
    {
        if (string.IsNullOrWhiteSpace(nGuia))
        {
            MessageBox.Show("Debe ingresar un número de guía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var guia = guias.FirstOrDefault(g => g.NGuia == nGuia);
        if (guia == null)
        {
            MessageBox.Show($"No se encontró ninguna guía con el número {nGuia}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        return guia;
    }

    internal List<string> ObtenerLocalidades()
    {
        return localidades;
    }

    internal bool GenerarHDR(Fletero fletero, List<Guia> guiasAgregadas, out string mensajeExito, out string error)
    {
        error = string.Empty;
        mensajeExito = string.Empty;

        if (guiasAgregadas.Count == 0)
        {
            error = "Debe agregar al menos una guía a la HDR.";
            return false;
        }

        ultimoNumeroHDR++;
        mensajeExito = $"HDR N° {ultimoNumeroHDR} generada correctamente para el fletero {fletero.Nombre}.";
        return true;
    }
}