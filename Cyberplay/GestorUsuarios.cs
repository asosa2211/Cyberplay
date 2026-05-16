using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    internal class GestorUsuarios
    {
        // =========================
        // LISTA USUARIOS
        // =========================

        private List<Usuario> usuarios =
            new List<Usuario>();

        // =========================
        // AGREGAR
        // =========================

        public void AgregarUsuario(
            Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        // =========================
        // OBTENER TODOS
        // =========================

        //  BUSCAR USUARIO
        public Usuario BuscarUsuario(string nombreCuenta)
        {
            foreach (Usuario usuario
                in usuarios)
            {
                if (usuario.NombreCuenta
                    .ToLower()
                    ==
                    nombreCuenta
                    .ToLower())
                {
                    return usuario;
                }
            }

            return null;
        }
        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }
    }
}
