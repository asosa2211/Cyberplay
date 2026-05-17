using Cyberplay.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cyberplay.Persistencia
{
    public class PersistenciaCajeros
    {
        private string ruta =
            "cajeros.json";

        public void GuardarCajeros(
            List<Cajero> cajeros)
        {
            string json =
                JsonConvert.SerializeObject(
                    cajeros,
                    Formatting.Indented);

            File.WriteAllText(
                ruta,
                json);
        }

        public List<Cajero>
            CargarCajeros()
        {
            if (!File.Exists(ruta))
            {
                return new List<Cajero>();
            }

            string json =
                File.ReadAllText(ruta);

            List<Cajero> cajeros =
                JsonConvert.DeserializeObject
                    <List<Cajero>>(json);

            if (cajeros == null)
            {
                return new List<Cajero>();
            }

            return cajeros;
        }
    }
}
