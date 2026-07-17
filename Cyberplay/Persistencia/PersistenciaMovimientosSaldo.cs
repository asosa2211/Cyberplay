using Cyberplay.Helpers;
using Cyberplay.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Persistencia
{
    public class PersistenciaMovimientosSaldo
    {
        private string ruta = Path.Combine(Rutas.Data, "movimientosSaldo.json");

        public List<MovimientoSaldo> CargarMovimientos()
        {
            if (!File.Exists(ruta))
                return new List<MovimientoSaldo>();

            string json = File.ReadAllText(ruta);

            return JsonConvert.DeserializeObject<List<MovimientoSaldo>>(json)
                   ?? new List<MovimientoSaldo>();
        }

        public void GuardarMovimientos(List<MovimientoSaldo> movimientos)
        {
            string json = JsonConvert.SerializeObject(movimientos, Formatting.Indented);

            File.WriteAllText(ruta, json);
        }
    }
}
