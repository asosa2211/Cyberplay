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
    public class PersistenciaVentasProductos
    {
        private string ruta = Path.Combine(Rutas.Data, "VentasProductos.json");


        public void GuardarVentas(List<VentaProducto> ventas)
        {
            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    ventas);
        }

   
        public List<VentaProducto> CargarVentas()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<VentaProducto>());
        }
    }
}
