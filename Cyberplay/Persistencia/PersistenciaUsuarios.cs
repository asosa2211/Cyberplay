using Cyberplay.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class PersistenciaUsuarios
    {
        private string ruta = Path.Combine(Rutas.Data, "usuarios.json");


        public List<Usuario>
    CargarUsuarios()
        {
            if (!File.Exists(ruta))
            {
                return new List<Usuario>();
            }

            string json =
                File.ReadAllText(ruta);

            List<Usuario> usuarios =
                JsonConvert.DeserializeObject
                    <List<Usuario>>(json);

            if (usuarios == null)
            {
                return new List<Usuario>();
            }

            return usuarios;
        }
        public void GuardarUsuarios(
    List<Usuario> usuarios)
        {
            List<Usuario> ordenados =
                usuarios
                .OrderBy(
                    u =>
                    u.NombreCuenta,
                    StringComparer.CurrentCultureIgnoreCase)
                .ToList();

            string json =
                JsonConvert.SerializeObject(
                    ordenados,
                    Formatting.Indented);

            File.WriteAllText(
                ruta,
                json);
        }
    }
}
