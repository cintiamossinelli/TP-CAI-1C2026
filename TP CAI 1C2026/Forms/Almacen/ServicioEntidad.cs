using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class ServicioEntidad
    {
        public int IdServicio { get; set; }
        public int IdEmpresaTransporte { get; set; }
        public List<ServicioParada> Paradas { get; set; }
    }
}
