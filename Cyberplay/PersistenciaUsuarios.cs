using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cyberplay
{
    public class PersistenciaUsuarios
    {
        private string ruta = "usuarios.txt";


        public List<Usuario> CargarUsuarios()
        {
            List<Usuario> usuarios =
                new List<Usuario>();

            // =====================
            // VALIDAR EXISTE
            // =====================

            if (!File.Exists(ruta))
            {
                return usuarios;
            }

            // =====================
            // LEER LINEAS
            // =====================

            string[] lineas =
                File.ReadAllLines(ruta);

            // =====================
            // RECORRER
            // =====================

            foreach (string linea
                in lineas)
            {
                string[] datos =
                    linea.Split('|');

                Usuario usuario =
                    new Usuario(
                        datos[0],
                        datos[1],
                        datos[2]);

                // =================
                // TIEMPO
                // =================

                long ticks =
                    long.Parse(
                        datos[3]);

                usuario.TiempoTotalJugado =
                    new TimeSpan(
                        ticks);

                usuarios.Add(
                    usuario);
            }

            return usuarios;
        }
        public void GuardarUsuarios(List<Usuario> usuarios)
        {
            // =====================
            // ESCRIBIR ARCHIVO
            // =====================

            using (StreamWriter writer =
                new StreamWriter(ruta))
            {
                foreach (Usuario usuario
                    in usuarios)
                {
                    string linea =
                        usuario.NombreCuenta
                        + "|"
                        + usuario.NombreCliente
                        + "|"
                        + usuario.Telefono
                        + "|"
                        + usuario.TiempoTotalJugado.Ticks;

                    writer.WriteLine(
                        linea);
                }
            }
        }
    }
}
