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
    public class PersistenciaCaja
    {
        private string ruta = Path.Combine(Rutas.Data, "caja.json");

        public void GuardarCaja(
            Caja caja)
        {
            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    caja);
        }

        public Caja CargarCaja()
        {
            return PersistenciaJsonAtomica
                .Cargar<Caja>(
                    ruta,
                    null);
        }
    }
}
