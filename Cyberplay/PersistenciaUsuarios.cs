using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Cyberplay
{
    public class PersistenciaUsuarios
    {
        private string ruta = "usuarios.json";


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
            string json =
                JsonConvert.SerializeObject(
                    usuarios,
                    Formatting.Indented);

            File.WriteAllText(
                ruta,
                json);
        }
    }
}
