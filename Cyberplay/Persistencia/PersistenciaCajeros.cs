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
    public class PersistenciaCajeros
    {
        /*private string ruta =
            "cajeros.json";*/

        private string ruta = Path.Combine(Rutas.Data, "cajeros.json");

        public void GuardarCajeros(
            List<Cajero> cajeros)
        {
            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    cajeros);
        }

        public List<Cajero>
            CargarCajeros()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<Cajero>());
        }
    }
}
