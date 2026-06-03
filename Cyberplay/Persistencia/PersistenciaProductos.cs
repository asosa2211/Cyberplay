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
    public class PersistenciaProductos
    {
        private string ruta = Path.Combine(Rutas.Data, "productos.json");

        public void GuardarProductos(List<Producto> productos)
        {
            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    productos);
        }

        public List<Producto> CargarProductos()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<Producto>());
        }
    }
}
