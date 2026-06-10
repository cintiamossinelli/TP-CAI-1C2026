using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Imposicion.ImposicionAgencia
{
    using System.Linq;
    using TP_CAI_1C2026.Forms.Almacen;

    internal class ImposicionAgenciaModelo
    {
        List<DetalleEncomienda> detallesAgregados = new();

        internal Cliente? BuscarCliente(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("El CUIT, CUIL o DNI del cliente no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var cuitFormateado = NormalizarCuit(text);
            if (cuitFormateado == null) //es que no es valido.
            {
                MessageBox.Show("El CUIT, CUIL o DNI del cliente debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var clienteEntidad = ClienteAlmacen.Clientes.FirstOrDefault(c => c.CuitDniCuilCliente == cuitFormateado);
            if (clienteEntidad == null)
            {
                MessageBox.Show($"No se encontró un cliente con CUIT, CUIL o DNI {cuitFormateado}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new Cliente
            {
                Cuit = clienteEntidad.CuitDniCuilCliente,
                RazonSocial = clienteEntidad.RazonSocial
            };
        }

        internal List<Agencia> ObtenerAgencias(Ciudad? ciudadSeleccionada)
        {
            return ciudadSeleccionada.Agencias;
        }

        internal List<CentroDeDistribucion> ObtenerCDS()
        {
            return CentroDeDistribucionAlmacen.CentrosDeDistribucion
              .Select(cd => new CentroDeDistribucion
              {
                  Id = cd.IdCentroDeDistribucion,
                  Nombre = cd.Nombre
              })
              .ToList();
        }

        internal List<Ciudad> ObtenerCiudades()
        {
            return CiudadAlmacen.Ciudades
                .Select(ciudad => new Ciudad
                {
                    Id = ciudad.IdCiudad,
                    Nombre = ciudad.Nombre,
                    Agencias = AgenciaAlmacen.Agencias
                        .Where(agencia => ciudad.Agencias.Contains(agencia.IdAgencia))
                        .Select(agencia => new Agencia
                        {
                            Id = agencia.IdAgencia,
                            Nombre = agencia.Nombre
                        })
                        .ToList()
                })
                .ToList();
        }

        internal List<TamañoEnvio> ObtenerTamañosEnvio()
        {
            return Enum.GetValues<TipoTamañoEnvioEnum>()
                .Select(tamaño => new TamañoEnvio
                {
                    Letra = tamaño.ToString()
                })
                .ToList();
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
            {
                var resultado = new List<string>();

                int ultimoNumero = GuiaAlmacen.Guias
                    .Select(guia => guia.NroGuia?.Split('-').LastOrDefault())
                    .Where(numero => int.TryParse(numero, out _))
                    .Select(int.Parse)
                    .DefaultIfEmpty(0)
                    .Max();

                int contador = ultimoNumero + 1;
                foreach (var det in detallesAgregados)
                {
                    for (int i = 0; i < det.Cantidad; i++)
                    {
                        resultado.Add($"AG-1-{contador}");
                        contador++;
                    }
                }

                return resultado;
            }
        }

        internal List<string> GuardarGuias(
    string cuitDniCuilCliente,
    bool cdChecked,
    CentroDeDistribucion? cdSelected,
    bool agenciaChecked,
    Ciudad? ciudadAgenciaSelected,
    Agencia? agenciaSelected,
    bool domicilioChecked,
    Ciudad? ciudadDestSelected,
    string direccionDest,
    string dniDest,
    string nombreDest)
        {
            string cuitCliente = NormalizarCuit(cuitDniCuilCliente) ?? cuitDniCuilCliente;
            DateTime fechaActual = DateTime.Now;
            List<string> numerosGuias = GenerarNumerosGuias();
            List<GuiaEntidad> guias = new();
            int indiceGuia = 0;

            foreach (var detalle in detallesAgregados)
            {
                TipoTamañoEnvioEnum tipoCaja = ObtenerTipoCaja(detalle.LetraTamaño);

                for (int i = 0; i < detalle.Cantidad; i++)
                {
                    EstadoGuiaEnum estado = ObtenerEstadoInicial(cdChecked, cdSelected, agenciaChecked, ciudadAgenciaSelected, domicilioChecked, ciudadDestSelected);

                    guias.Add(new GuiaEntidad
                    {
                        NroGuia = numerosGuias[indiceGuia],
                        CuitDniCuilCliente = cuitCliente,
                        FechaImposicion = fechaActual,
                        TipoImposicion = TipoImposicionEnum.CD,
                        IdCentroDeDistribucionImposicion = 0,
                        IdAgenciaImposicion = 1,
                        DireccionRetiroDomicilio = string.Empty,
                        TipoEntrega = ObtenerTipoEntrega(cdChecked, agenciaChecked, domicilioChecked),
                        IdCentroDeDistribucionEntrega = ObtenerIdCentroDeDistribucionEntrega(cdChecked, cdSelected, domicilioChecked, ciudadDestSelected),
                        IdAgenciaEntrega = agenciaChecked && agenciaSelected != null ? agenciaSelected.Id : 0,
                        DireccionEntrega = domicilioChecked ? direccionDest : string.Empty,
                        DniDestinatario = dniDest,
                        NombreDestinatario = nombreDest,
                        TipoCaja = tipoCaja,
                        PrecioVenta = 0,
                        Estado = estado,
                        Historial = CrearHistorial(estado, fechaActual),
                        ComisionFletero = new List<GuiaComisionFletero>(),
                        ComisionAgencia = new List<GuiaComisionAgencia>(),
                        IntentosDeEntrega = 0
                    });

                    indiceGuia++;
                }
            }

            GuiaAlmacen.AgregarGuias(guias);
            return numerosGuias;
        }

        private static TipoTamañoEnvioEnum ObtenerTipoCaja(string letraTamaño)
        {
            return Enum.Parse<TipoTamañoEnvioEnum>(letraTamaño);
        }

        private static TipoEntregaEnum ObtenerTipoEntrega(bool cdChecked, bool agenciaChecked, bool domicilioChecked)
        {
            if (cdChecked)
            {
                return TipoEntregaEnum.CD;
            }

            if (agenciaChecked)
            {
                return TipoEntregaEnum.Agencia;
            }

            return TipoEntregaEnum.ADomicilio;
        }

        private static int ObtenerIdCentroDeDistribucionEntrega(
            bool cdChecked,
            CentroDeDistribucion? cdSelected,
            bool domicilioChecked,
            Ciudad? ciudadDestSelected)
        {
            if (cdChecked && cdSelected != null)
            {
                return cdSelected.Id;
            }

            if (domicilioChecked && ciudadDestSelected != null)
            {
                return ciudadDestSelected.Id;
            }

            return 0;
        }
        private static EstadoGuiaEnum ObtenerEstadoInicial(
            bool cdChecked,
            CentroDeDistribucion? cdSelected,
            bool agenciaChecked,
            Ciudad? ciudadAgenciaSelected,
            bool domicilioChecked,
            Ciudad? ciudadDestSelected)
        {
            bool yaEstaEnDestino =
                cdChecked && cdSelected?.Id == 1 ||
                agenciaChecked && ciudadAgenciaSelected?.Id == 1 ||
                domicilioChecked && ciudadDestSelected?.Id == 1;

            return yaEstaEnDestino ? EstadoGuiaEnum.EnDestino : EstadoGuiaEnum.Admitida;
        }

        private static List<HistorialGuia> CrearHistorial(EstadoGuiaEnum estado, DateTime fecha)
        {
            List<HistorialGuia> historial = new()
        {
            new HistorialGuia { Fecha = fecha, Estado = EstadoGuiaEnum.ImpuestaEnAgencia }
        };

            if (estado == EstadoGuiaEnum.EnDestino)
            {
                historial.Add(new HistorialGuia { Fecha = fecha, Estado = EstadoGuiaEnum.ImpuestaEnAgencia });
            }

            return historial;
        }

        internal bool ValidarConfirmacion(
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
