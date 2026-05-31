using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    
        public class Producto
        {
       
            public Guid Id { get; set;  } = Guid.NewGuid();

            public string Nombre { get; set; }

            public decimal PrecioCosto { get; set; }

            public decimal PrecioVenta { get; set; }

            public int Stock { get; set; }

            public string Categoria { get; set; }

            public TipoVentaProducto TipoVenta { get; set; }
                = TipoVentaProducto.ConStock;
        }

        public enum TipoVentaProducto
        {
            ConStock = 0,
            MontoDirecto = 1,
            Contadores = 2
        }
    
}
