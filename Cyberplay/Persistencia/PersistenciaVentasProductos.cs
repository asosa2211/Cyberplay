using Cyberplay.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cyberplay.Persistencia
{
    public class PersistenciaVentasProductos
    {
        private string ruta = "ventasProductos.json";

    
        public void GuardarVentas(List<VentaProducto> ventas)
        {
            string json = JsonConvert.SerializeObject(ventas, Formatting.Indented);

            File.WriteAllText(ruta, json);
        }

   
        public List<VentaProducto> CargarVentas()
        {
            if (!File.Exists(ruta))
            {
                return new List<VentaProducto>();
            }

            string json = File.ReadAllText(ruta);

            return JsonConvert.DeserializeObject <List<VentaProducto> >(json) ??
                   new List<VentaProducto>();
        }
    }
}
