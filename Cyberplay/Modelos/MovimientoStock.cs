using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class MovimientoStock
    {
        public string
            Producto
        {
            get;
            set;
        }

        public string
            Categoria
        {
            get;
            set;
        }

        public int
            Entrada
        {
            get;
            set;
        }

        public int
            Recibido
        {
            get;
            set;
        }

        public int
            Entregado
        {
            get;
            set;
        }

        public int
            Retiro
        {
            get;
            set;
        }

        public int
            NumeroCaja
        {
            get;
            set;
        }

        public DateTime
            Fecha
        {
            get;
            set;
        }
        =
        DateTime.Now;
    }
}
