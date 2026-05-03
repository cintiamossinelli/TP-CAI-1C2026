// Fletero.cs
namespace TP_CAI_1C2026.Forms.UltimaMilla.EmisionHDREntrega
{
    internal class Fletero
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }

        public Fletero(int dni, string nombre)
        {
            Dni = dni;
            Nombre = nombre;
        }
    }
}