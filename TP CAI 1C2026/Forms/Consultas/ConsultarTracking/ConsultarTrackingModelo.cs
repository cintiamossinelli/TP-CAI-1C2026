using TP_CAI_1C2026.Forms.Almacen;

namespace TP_CAI_1C2026.Forms.Consultas.ConsultarTracking;

internal class ConsultarTrackingModelo
{
    internal Guia? BuscarGuia(string nGuia, out string error)
    {
        error = string.Empty;

        if (string.IsNullOrWhiteSpace(nGuia))
        {
            error = "El número de guía no puede estar vacío.";
            return null;
        }

        GuiaEntidad? entidad =
            GuiaAlmacen.Guias
            .FirstOrDefault(g => g.NroGuia == nGuia);

        if (entidad == null)
        {
            error = $"No se encontró ninguna guía con el número {nGuia}.";
            return null;
        }

        return new Guia
        {
            NGuia = entidad.NroGuia,
            CuitDniCuil = entidad.CuitDniCuilCliente,
            TipoCaja = entidad.TipoCaja.ToString(),
            Origen = ResolverOrigen(entidad),
            Destino = ResolverDestino(entidad),
            Historial = entidad.Historial?
                .Select(h => new HistorialGuia
                {
                    Fecha = h.Fecha.ToShortDateString(),
                    Estado = h.Estado.ToString()
                })
                .ToList()
                ?? new List<HistorialGuia>()
        };
    }

    private static string ResolverOrigen(GuiaEntidad entidad)
    {
        switch (entidad.TipoImposicion)
        {
            case TipoImposicionEnum.CD:
                CentroDeDistribucionEntidad? cd =
                    CentroDeDistribucionAlmacen.CentrosDeDistribucion
                    .FirstOrDefault(c =>
                        c.IdCentroDeDistribucion ==
                        entidad.IdCentroDeDistribucionImposicion);
                return cd?.Nombre ?? $"CD {entidad.IdCentroDeDistribucionImposicion}";

            case TipoImposicionEnum.Agencia:
                AgenciaEntidad? agencia =
                    AgenciaAlmacen.Agencias
                    .FirstOrDefault(a =>
                        a.IdAgencia ==
                        entidad.IdAgenciaImposicion);
                return agencia?.Nombre ?? $"Agencia {entidad.IdAgenciaImposicion}";

            case TipoImposicionEnum.EnDomicilio:
                return entidad.DireccionRetiroDomicilio;

            default:
                return string.Empty;
        }
    }

    private static string ResolverDestino(GuiaEntidad entidad)
    {
        switch (entidad.TipoEntrega)
        {
            case TipoEntregaEnum.CD:
                CentroDeDistribucionEntidad? cd =
                    CentroDeDistribucionAlmacen.CentrosDeDistribucion
                    .FirstOrDefault(c =>
                        c.IdCentroDeDistribucion ==
                        entidad.IdCentroDeDistribucionEntrega);
                return cd?.Nombre ?? $"CD {entidad.IdCentroDeDistribucionEntrega}";

            case TipoEntregaEnum.Agencia:
                AgenciaEntidad? agencia =
                    AgenciaAlmacen.Agencias
                    .FirstOrDefault(a =>
                        a.IdAgencia ==
                        entidad.IdAgenciaEntrega);
                return agencia?.Nombre ?? $"Agencia {entidad.IdAgenciaEntrega}";

            case TipoEntregaEnum.ADomicilio:
                return entidad.DireccionEntrega;

            default:
                return string.Empty;
        }
    }
}
