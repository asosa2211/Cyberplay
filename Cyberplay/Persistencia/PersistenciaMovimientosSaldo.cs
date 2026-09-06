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
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<MovimientoSaldo>());
        }

        public void GuardarMovimientos(List<MovimientoSaldo> movimientos)
        {
            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    movimientos);
        }
    }
}
