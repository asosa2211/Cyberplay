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
    public class PersistenciaMovimientoStock
    {
        private string ruta = Path.Combine(Rutas.Data, "movimientos_stock.json");

        public void GuardarMovimiento(
            MovimientoStock movimiento)
        {
            List<MovimientoStock>
                movimientos =
                    CargarMovimientos();

            movimientos.Add(
                movimiento);

            string json =
                JsonConvert.SerializeObject(
                    movimientos,
                    Formatting.Indented);

            File.WriteAllText(
                ruta,
                json);
        }

        public List<MovimientoStock>
            CargarMovimientos()
        {
            if (!File.Exists(ruta))
            {
                return
                    new List<MovimientoStock>();
            }

            string json =
                File.ReadAllText(ruta);

            List<MovimientoStock>
                movimientos =
                    JsonConvert
                    .DeserializeObject
                    <List<MovimientoStock>>
                    (json);

            if (movimientos == null)
            {
                return
                    new List<MovimientoStock>();
            }

            return movimientos;
        }
    }
}
