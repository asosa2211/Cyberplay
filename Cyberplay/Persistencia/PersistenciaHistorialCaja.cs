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
    public class PersistenciaHistorialCajas
    {
        private string ruta =
            "historial_cajas.json";

        public void GuardarCaja(
            Caja caja)
        {
            List<Caja> cajas =
                CargarHistorial();

            cajas.Add(caja);

            string json =
                JsonConvert.SerializeObject(
                    cajas,
                    Formatting.Indented);

            File.WriteAllText(
                ruta,
                json);
        }

        public List<Caja>
            CargarHistorial()
        {
            if (!File.Exists(ruta))
            {
                return new List<Caja>();
            }

            string json =
                File.ReadAllText(ruta);

            List<Caja> cajas =
                JsonConvert.DeserializeObject
                    <List<Caja>>(json);

            if (cajas == null)
            {
                return new List<Caja>();
            }

            return cajas;
        }
    }
}
