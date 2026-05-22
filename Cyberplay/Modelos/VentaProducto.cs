using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class VentaProducto
    {
        public Guid Id { get; set; }
            = Guid.NewGuid();

   
        public string Producto { get; set; }

     
        public int Cantidad { get; set; }

     
        public decimal PrecioUnitario { get; set; }

    
        public decimal Total { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string Cajero { get; set; }
    }
}
