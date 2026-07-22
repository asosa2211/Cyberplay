using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class ResumenProducto
    {
        public string Producto { get; set; }

        public string Categoria { get; set; }

        public decimal Precio { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Total { get; set; }

        public decimal Utilidad { get; set; }
    }
}
