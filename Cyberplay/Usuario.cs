using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    internal class Usuario
    {
        // =====================
        // NOMBRE USUARIO
        // =====================

        public string Nombre
        {
            get;
            set;
        }

        // =====================
        // TIEMPO ACUMULADO
        // =====================

        public TimeSpan TiempoTotalJugado
        {
            get;
            set;
        }

        // =====================

        public Usuario(
            string nombre)
        {
            Nombre = nombre;

            TiempoTotalJugado =
                TimeSpan.Zero;
        }

        // =====================

        public override string ToString()
        {
            return Nombre;
        }
    }
}
