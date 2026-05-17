using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_CAI_1C2026.Forms.Administracion.ResultadoCostoVentas
{
    internal class ResultadoCostosVentasModelo
    {
        public Fecha Fecha { get; private set; }
        public List<Empresa> Empresas { get; } = new List<Empresa>();

        public decimal TotalCostos { get; private set; }
        public decimal TotalVentas { get; private set; }
        public decimal ResultadoTotal { get; private set; }

        public ResultadoCostosVentasModelo(Fecha fecha)
        {
            Fecha = fecha ?? throw new ArgumentNullException(nameof(fecha));
        }

        public void Cargar(IEnumerable<Empresa> empresas)
        {
            Empresas.Clear();
            if (empresas != null) Empresas.AddRange(empresas);
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            TotalCostos = Empresas.Sum(e => e?.CostoTotal ?? 0m);
            TotalVentas = Empresas.Sum(e => e?.VentasTotales ?? 0m);
            ResultadoTotal = TotalVentas - TotalCostos;
        }

        public bool ValidarFecha(out string mensajeError)
        {
            mensajeError = null;
            if (Fecha == null)
            {
                mensajeError = "Fecha inválida";
                return false;
            }

            if (Fecha.Mes < 1 || Fecha.Mes > 12)
            {
                mensajeError = "El mes debe estar entre 1 y 12.";
                return false;
            }

            // El año debe estar entre 2000 y el año actual
            if (Fecha.Año < 2000 || Fecha.Año > DateTime.Now.Year)
            {
                mensajeError = "El año debe estar entre 2000 y el año actual.";
                return false;
            }

            // Si el año es el actual, el mes no puede ser mayor al mes actual
            if (Fecha.Año == DateTime.Now.Year && Fecha.Mes > DateTime.Now.Month)
            {
                mensajeError = "El mes no puede ser mayor al mes actual para el año seleccionado.";
                return false;
            }

            return true;
        }

        // Intenta crear el modelo a partir de textos de mes y año (útil para usar desde el form)
        public static bool TryCrearDesdeInputs(string mesTexto, string anioTexto, IEnumerable<Empresa>? datos, out ResultadoCostosVentasModelo modelo, out string mensajeError)
        {
            modelo = null;
            mensajeError = null;

            if (!int.TryParse(mesTexto, out var mes))
            {
                mensajeError = "Mes inválido.";
                return false;
            }

            if (!int.TryParse(anioTexto, out var anio))
            {
                mensajeError = "Año inválido.";
                return false;
            }

            var fecha = new Fecha { Mes = mes, Año = anio };
            var temp = new ResultadoCostosVentasModelo(fecha);
            if (!temp.ValidarFecha(out mensajeError))
            {
                return false;
            }

            // Si no se pasaron datos, obtener datos de prueba por defecto
            if (datos == null)
            {
                datos = ObtenerDatosPrueba(mes, anio);
            }

            temp.Cargar(datos);
            modelo = temp;
            return true;
        }

        // Datos de prueba incorporados en el modelo (pueden sustituirse por acceso a BD)
        public static IEnumerable<Empresa> ObtenerDatosPrueba(int mes, int anio)
        {
            // Generar datos determinísticos basados en mes/año para facilitar pruebas
            var lista = new List<Empresa>
            {
                new Empresa { EmpresaTransporte = $"Transporte {mes}-A", CantidadEnvios = 10 + (mes % 5), CostoTotal = 1000m + anio % 100, VentasTotales = 1500m + anio % 200 },
                new Empresa { EmpresaTransporte = $"Logistica {mes}-B", CantidadEnvios = 5 + (anio % 3), CostoTotal = 500m + mes * 10, VentasTotales = 700m + mes * 15 }
            };

            return lista;
        }
    }
}
