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

            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    movimientos);
        }

        public List<MovimientoStock>
            CargarMovimientos()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<MovimientoStock>());
        }
    }
}
