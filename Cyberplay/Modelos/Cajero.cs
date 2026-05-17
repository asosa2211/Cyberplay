using Cyberplay.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class Cajero
    {
        public string Usuario
        {
            get;
            set;
        }

        public string NombreCompleto
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public RolUsuario Rol
        {
            get;
            set;
        }

        public Cajero(
            string usuario,
            string nombreCompleto,
            string password,
            RolUsuario rol)
        {
            Usuario =
                usuario;

            NombreCompleto =
                nombreCompleto;

            Password =
                password;

            Rol =
                rol;
        }

        // Constructor vacío JSON
        public Cajero()
        {

        }
    }
}
