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
        }
    
}
