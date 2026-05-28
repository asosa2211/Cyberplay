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
            string json = JsonConvert.SerializeObject(productos, Formatting.Indented);
            File.WriteAllText(ruta, json);
        }

        public List<Producto> CargarProductos()
        {
            if (!File.Exists(ruta))
            {
                return new List<Producto>();
            }

            string json = File.ReadAllText(ruta);

            return JsonConvert.DeserializeObject<List<Producto>>(json) ?? new List<Producto>();
        }
    }
}
