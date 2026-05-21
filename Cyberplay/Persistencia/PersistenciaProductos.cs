using Cyberplay.Modelos;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Persistencia
{
    internal class PersistenciaProductos
    {
        private string ruta = "productos.json";

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
