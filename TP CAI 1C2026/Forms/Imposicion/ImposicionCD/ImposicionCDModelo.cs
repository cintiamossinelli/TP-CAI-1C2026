namespace TP_CAI_1C2026.Forms.Imposicion.ImposicionCD;

public class ImposicionCDModelo
{
    List<DetalleEncomienda> detallesAgregados = new();

    internal Cliente? BuscarCliente(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            MessageBox.Show("El cuit del cliente no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var cuitFormateado = NormalizarCuit(text);
        if (cuitFormateado == null) //es que no es valido.
        {
            MessageBox.Show("El cuit del cliente debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        // Simulación de búsqueda en una base de datos o servicio
        var clientesSimulados = new List<Cliente>
        {
            new Cliente { Cuit = "33-63761744-9", RazonSocial = "Empresa A" },
            new Cliente { Cuit = "30-64621216-9", RazonSocial = "Empresa B" },
            new Cliente { Cuit = "30-67337754-4", RazonSocial = "Empresa C" }
        };

        var clienteEncontrado = clientesSimulados.FirstOrDefault(c => c.Cuit == cuitFormateado);
        if (clienteEncontrado == null)
        {
            MessageBox.Show($"No se encontró un cliente con CUIT {cuitFormateado}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        return clienteEncontrado;
    }

    internal List<Agencia> ObtenerAgencias(Ciudad? ciudadSeleccionada)
    {
        return ciudadSeleccionada.Agencias;
    }

    internal List<CentroDeDistribucion> ObtenerCDS()
    {
        return new List<CentroDeDistribucion>();
    }

    internal List<Ciudad> ObtenerCiudades()
    {
        return new List<Ciudad>
        {
            new Ciudad { Id = 1, Nombre = "Rosario", Agencias = new List<Agencia>
            {
                new() { Id = 1, Nombre = "Rosario Norte" },
                new() { Id = 2, Nombre = "Rosario Sur" },
                new() { Id = 3, Nombre = "Rosario Centro" },
                new() { Id = 4, Nombre = "Rosario Oeste" }
            }},
            new Ciudad { Id = 2, Nombre = "Santa Fe", Agencias = new List<Agencia>
            {
                new() { Id = 5, Nombre = "Santa Fe Centro" },
                new() { Id = 6, Nombre = "Santa Fe Norte" },
                new() { Id = 7, Nombre = "Santa Fe Sur" },
                new() { Id = 8, Nombre = "Santo Tomé" }
            }},
            new Ciudad { Id = 3, Nombre = "Buenos Aires", Agencias = new List<Agencia>
            {
                new() { Id = 9,  Nombre = "Microcentro" },
                new() { Id = 10, Nombre = "Palermo" },
                new() { Id = 11, Nombre = "Belgrano" },
                new() { Id = 12, Nombre = "San Telmo" }
            }}
        };
    }

    internal List<TamañoEnvio> ObtenerTamañosEnvio()
    {
        return new List<TamañoEnvio>()
        {
            new TamañoEnvio { Letra = "S" },
            new TamañoEnvio { Letra = "M" },
            new TamañoEnvio { Letra = "L" },
            new TamañoEnvio { Letra = "XL" }
        };
    }

    public static string? NormalizarCuit(string? texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            return null;
        }

        // Dejar solo números
        string cuit = new string(texto.Where(char.IsDigit).ToArray());

        // Debe tener 11 dígitos
        if (cuit.Length != 11)
        {
            return null;
        }

        if (!long.TryParse(cuit, out _))
        {
            return null;
        }

        int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

        int suma = 0;

        for (int i = 0; i < 10; i++)
        {
            suma += (cuit[i] - '0') * multiplicadores[i];
        }

        int resto = suma % 11;
        int digitoVerificador = 11 - resto;

        if (digitoVerificador == 11)
        {
            digitoVerificador = 0;
        }
        else if (digitoVerificador == 10)
        {
            digitoVerificador = 9;
        }

        if (digitoVerificador != (cuit[10] - '0'))
        {
            return null;
        }

        // Formato XX-XXXXXXXX-X
        return $"{cuit[..2]}-{cuit.Substring(2, 8)}-{cuit[10]}";
    }

    internal DetalleEncomienda AgregarCaja(TamañoEnvio? tamaño, int cantidad)
    {
        //validaciones
        if (cantidad <= 0)
        {
            MessageBox.Show("La cantidad debe ser un número entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }


        var nuevoDetalle = new DetalleEncomienda { LetraTamaño = tamaño.Letra, Cantidad = cantidad };
        detallesAgregados.Add(nuevoDetalle);
        return nuevoDetalle;
    }

    internal bool EliminarDetalle(DetalleEncomienda? detalleEncomienda)
    {
        detallesAgregados.Remove(detalleEncomienda);
        return true;
    }
}
