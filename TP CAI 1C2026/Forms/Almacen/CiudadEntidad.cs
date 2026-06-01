using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CAI_1C2026.Forms.Almacen
{
    internal class CiudadEntidad
    {
        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public List<int> Agencias { get; set; }
        public int IdCentroDeDistribucion { get; set; }
    }
}
