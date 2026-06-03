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
    public class PersistenciaHistorialCajas
    {
        private string ruta = Path.Combine(Rutas.Data, "historial_cajas.json");

        public void GuardarCaja(
            Caja caja)
        {
            List<Caja> cajas =
                CargarHistorial();

            cajas.Add(caja);

            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    cajas);
        }

        public List<Caja>
            CargarHistorial()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<Caja>());
        }

        public int ObtenerSiguienteNumeroCaja()
        {
            List<Caja> cajas =
                CargarHistorial();

            if (cajas.Count == 0)
            {
                return 1;
            }

            return cajas
                .Max(
                    c => c.NumeroCaja)
                + 1;
        }
    }
}
