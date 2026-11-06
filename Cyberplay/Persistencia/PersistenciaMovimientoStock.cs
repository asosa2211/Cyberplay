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
        private readonly string ruta;

        public PersistenciaMovimientoStock()
        {
            ruta = Path.Combine(
                Rutas.Data,
                "movimientos_stock.json");
        }

        internal PersistenciaMovimientoStock(
            string ruta)
        {
            this.ruta = ruta;
        }

        public void GuardarMovimiento(
            MovimientoStock movimiento)
        {
            GuardarMovimientos(
                new[] { movimiento });
        }

        public void GuardarMovimientos(
            IEnumerable<MovimientoStock> nuevosMovimientos)
        {
            if (nuevosMovimientos == null)
            {
                return;
            }

            List<MovimientoStock> nuevos =
                nuevosMovimientos
                    .Where(x => x != null)
                    .ToList();

            if (nuevos.Count == 0)
            {
                return;
            }

            List<MovimientoStock>
                movimientos =
                    CargarMovimientos();

            movimientos.AddRange(
                nuevos);

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
