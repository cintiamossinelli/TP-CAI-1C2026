using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter;
using TP_CAI_1C2026.Forms.Imposicion.ImposicionCD;
using static System.Net.Mime.MediaTypeNames;

namespace TP_CAI_1C2026.Forms.Imposicion.ImposicionCallCenter
{
    internal class ImposicionCallCenterModelo
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
            new Cliente { Cuit = "30-67337754-4", RazonSocial = "Empresa C" },
            new Cliente { Cuit = "33078369", RazonSocial = "José Perez" },
            new Cliente { Cuit = "9123456", RazonSocial = "Juan Gonzalez" }
        };

            var clienteEncontrado = clientesSimulados.FirstOrDefault(c => c.Cuit == cuitFormateado);
            if (clienteEncontrado == null)
            {
                MessageBox.Show($"No se encontró un cliente con CUIT, CUIL o DNI {cuitFormateado}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return new List<CentroDeDistribucion>
        {
            new CentroDeDistribucion { Id = 1, Nombre = "Rosario" },
            new CentroDeDistribucion { Id = 2, Nombre = "Santa Fe" },
            new CentroDeDistribucion { Id = 3, Nombre = "Buenos Aires" },
            new CentroDeDistribucion { Id = 4, Nombre = "Córdoba" },
            new CentroDeDistribucion { Id = 5, Nombre = "Mendoza" },
            new CentroDeDistribucion { Id = 6, Nombre = "San Miguel de Tucumán" },
            new CentroDeDistribucion { Id = 7, Nombre = "Neuquén" },
            new CentroDeDistribucion { Id = 8, Nombre = "Salta" },
            new CentroDeDistribucion { Id = 9, Nombre = "San Salvador de Jujuy" },
            new CentroDeDistribucion { Id = 10, Nombre = "Mar del Plata" }
        };
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
            }},
            new Ciudad { Id = 4, Nombre = "Córdoba", Agencias = new List<Agencia>
            {
                new() { Id = 10,  Nombre = "Córdoba Centro" },
                new() { Id = 11, Nombre = "Córdoba Norte" },
                new() { Id = 12, Nombre = "Córdoba Sur" },
                new() { Id = 13, Nombre = "Córdoba Oeste" }
            }},
            new Ciudad { Id = 5, Nombre = "Mendoza", Agencias = new List<Agencia>
            {
                new() { Id = 14,  Nombre = "Mendoza Centro" },
                new() { Id = 15, Nombre = "Mendoza Norte" },
                new() { Id = 16, Nombre = "Mendoza Sur" },
                new() { Id = 17, Nombre = "Mendoza Oeste" }
            }},
            new Ciudad { Id = 6, Nombre = "San Miguel de Tucumán", Agencias = new List<Agencia>
            {
                new() { Id = 18,  Nombre = "San Miguel de Tucumán Centro" },
                new() { Id = 19, Nombre = "San Miguel de Tucumán Norte" },
                new() { Id = 20, Nombre = "San Miguel de Tucumán Sur" },
                new() { Id = 21, Nombre = "San Miguel de Tucumán Oeste" }
            }},
            new Ciudad { Id = 7, Nombre = "Neuquén", Agencias = new List<Agencia>
            {
                new() { Id = 22,  Nombre = "Neuquén Centro" },
                new() { Id = 23, Nombre = "Neuquén Norte" },
                new() { Id = 24, Nombre = "Neuquén Sur" },
                new() { Id = 25, Nombre = "Neuquén Oeste" }
            }},
            new Ciudad { Id = 8, Nombre = "Salta", Agencias = new List<Agencia>
            {
                new() { Id = 26,  Nombre = "Salta Centro" },
                new() { Id = 27, Nombre = "Salta Norte" },
                new() { Id = 28, Nombre = "Salta Sur" },
                new() { Id = 29, Nombre = "Salta Oeste" }
            }},
            new Ciudad { Id = 9, Nombre = "San Salvador de Jujuy", Agencias = new List<Agencia>
            {
                new() { Id = 30,  Nombre = "San Salvador de Jujuy Centro" },
                new() { Id = 31, Nombre = "San Salvador de Jujuy Norte" },
                new() { Id = 32, Nombre = "San Salvador de Jujuy Sur" },
                new() { Id = 33, Nombre = "San Salvador de Jujuy Oeste" }
            }},
            new Ciudad { Id = 10, Nombre = "Mar del Plata", Agencias = new List<Agencia>
            {
                new() { Id = 34,  Nombre = "Mar del Plata Centro" },
                new() { Id = 35, Nombre = "Mar del Plata Norte" },
                new() { Id = 36, Nombre = "Mar del Plata Sur" },
                new() { Id = 37, Nombre = "Mar del Plata Oeste" }
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

            if (!long.TryParse(cuit, out _))
            {
                return null;
            }

            if (cuit.Length == 11)
            {
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
            }
            else if (cuit.Length != 7 && cuit.Length != 8)
            {
                return null;
            }
            else
            {
                return cuit;
            }

            // Formato XX-XXXXXXXX-X
            return $"{cuit[..2]}-{cuit.Substring(2, 8)}-{cuit[10]}";
        }

        internal DetalleEncomienda AgregarCaja(TamañoEnvio? tamaño, int cantidad)
        {
            //validaciones
            if (tamaño == null)
            {
                MessageBox.Show("Seleccione un tamaño de caja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Si ya existe un detalle con el mismo tamaño, sumar las cantidades
            var existente = detallesAgregados.FirstOrDefault(d => string.Equals(d.LetraTamaño, tamaño.Letra, StringComparison.OrdinalIgnoreCase));
            if (existente != null)
            {
                existente.Cantidad += cantidad;
                return existente;
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

        internal void LimpiarDetalles()
        {
            detallesAgregados.Clear();
        }

        internal List<string> GenerarNumerosGuias()
        {
            var resultado = new List<string>();
            // Genero números de guía con formato: TIPO-CODIGO-XXX, donde XXX es un número secuencial para cada encomienda agregada.

            // CUANDO TENGAMOS USUARIOS, ACÁ HAY QUE CAMBIAR EL TIPO Y CODIGO POR LO QUE CORRESPONDA SEGÚN EL USUARIO Y SU SEDE O LO QUE SEA.
            int contador = 1;
            foreach (var det in detallesAgregados)
            {
                for (int i = 0; i < det.Cantidad; i++)
                {
                    resultado.Add($"CC-1-{contador}");
                    contador++;
                }
            }

            return resultado;
        }

        internal bool ValidarConfirmacion(
            CentroDeDistribucion? ciudadRetiroSelected,
            string direccionCliente,
            bool cdChecked,
            CentroDeDistribucion? cdSelected,
            bool agenciaChecked,
            Ciudad? ciudadAgenciaSelected,
            Agencia? agenciaSelected,
            bool domicilioChecked,
            object? ciudadDestSelected,
            string direccionDest,
            string dniDest,
            string nombreDest)
        {

            if (ciudadRetiroSelected == null)
            {
                MessageBox.Show("Debe seleccionar una ciudad de retiro de la encomienda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(direccionCliente))
            {
                MessageBox.Show("La dirección de retiro de la encomienda no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cdChecked)
            {
                if (cdSelected == null)
                {
                    MessageBox.Show("Debe seleccionar un CD destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (agenciaChecked)
            {
                if (ciudadAgenciaSelected == null || agenciaSelected == null)
                {
                    MessageBox.Show("Debe seleccionar una ciudad y una agencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (domicilioChecked)
            {
                if (ciudadDestSelected is null || string.IsNullOrWhiteSpace(direccionDest))
                {
                    MessageBox.Show("Debe seleccionar una ciudad e ingresar un domicilio destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Validar DNI: numérico positivo y con 7 u 8 caracteres
            if (string.IsNullOrWhiteSpace(dniDest)) 
            {
                MessageBox.Show("El DNI del destinatario no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dniDest.Length <= 6 || dniDest.Length > 8 || !dniDest.All(char.IsDigit) || !long.TryParse(dniDest, out long dniVal) || dniVal <= 0)
            {
                MessageBox.Show("Debe ingresar un DNI válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar nombre: no vacío y sin números
            if (string.IsNullOrWhiteSpace(nombreDest))
            {
                MessageBox.Show("El nombre del destinatario no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (nombreDest.Any(char.IsDigit))
            {
                MessageBox.Show("Ha ingresado un número en el nombre del destinatario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Debe existir al menos una encomienda agregada
            if (!detallesAgregados.Any())
            {
                MessageBox.Show("Debe ingresar al menos una encomienda en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
