using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class GestorUsuarios
    {
        // =========================
        // LISTA USUARIOS
        // =========================

        private List<Usuario> usuarios =
            new List<Usuario>();

        // =========================
        // AGREGAR
        // =========================

        public bool AgregarUsuario(
    Usuario usuario)
        {
            // =====================
            // VALIDAR DUPLICADO
            // =====================

            if (BuscarUsuario(
                usuario.NombreCuenta)
                != null)
            {
                return false;
            }

            // =====================
            // AGREGAR
            // =====================

            usuarios.Add(usuario);

            return true;
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

        public bool EditarUsuario(
    string nombreCuentaActual,
    string nuevoNombreCuenta,
    string nuevoNombreCliente,
    string nuevoTelefono)
        {
            // =====================
            // BUSCAR USUARIO
            // =====================

            Usuario usuario =
                BuscarUsuario(
                    nombreCuentaActual);

            // =====================
            // NO EXISTE
            // =====================

            if (usuario == null)
            {
                return false;
            }

            // =====================
            // VALIDAR NUEVO NOMBRE
            // =====================

            if (nombreCuentaActual
                .ToLower()
                !=
                nuevoNombreCuenta
                .ToLower())
            {
                if (BuscarUsuario(
                    nuevoNombreCuenta)
                    != null)
                {
                    return false;
                }
            }

            // =====================
            // ACTUALIZAR
            // =====================

            usuario.NombreCuenta =
                nuevoNombreCuenta;

            usuario.NombreCliente =
                nuevoNombreCliente;

            usuario.Telefono =
                nuevoTelefono;

            return true;
        }

        public bool EliminarUsuario(
    string nombreCuenta)
        {
            // =====================
            // BUSCAR
            // =====================

            Usuario usuario =
                BuscarUsuario(
                    nombreCuenta);

            // =====================
            // NO EXISTE
            // =====================

            if (usuario == null)
            {
                return false;
            }

            // =====================
            // ELIMINAR
            // =====================

            usuarios.Remove(usuario);

            return true;
        }
        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }
    }
}
