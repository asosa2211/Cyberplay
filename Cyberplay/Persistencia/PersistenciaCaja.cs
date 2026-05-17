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
    public class PersistenciaCaja
    {
        private string ruta =
            "caja.json";

        public void GuardarCaja(
            Caja caja)
        {
            string json =
                JsonConvert.SerializeObject(
                    caja,
                    Formatting.Indented);

            File.WriteAllText(
                ruta,
                json);
        }

        public Caja CargarCaja()
        {
            if (!File.Exists(ruta))
            {
                return null;
            }

            string json =
                File.ReadAllText(ruta);

            return JsonConvert
                .DeserializeObject<Caja>(
                    json);
        }
    }
}
