using Cyberplay.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Servicios
{
    internal class GestorProductos
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public List<Producto>  ObtenerProductos()
        {
            return productos;
        }
    }
}
