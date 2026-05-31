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

        public decimal Utilidad { get; set; }

        public decimal Total { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string Cajero { get; set; }

        public string Categoria
        {
            get;
            set;
        }

        public int NumeroCaja
        {
            get;
            set;
        }

        public TipoVentaProducto TipoVenta
        {
            get;
            set;
        }

        public int ContadorInicial
        {
            get;
            set;
        }

        public int ContadorFinal
        {
            get;
            set;
        }

        public int TotalCopias
        {
            get;
            set;
        }

        public decimal Promedio
        {
            get;
            set;
        }

        public decimal Aproximado
        {
            get;
            set;
        }

        public decimal Diferencia
        {
            get;
            set;
        }

        public string Detalle
        {
            get
            {
                if (TipoVenta != TipoVentaProducto.Contadores)
                {
                    return Producto;
                }

                return Producto
                    + " ("
                    + ContadorInicial
                    + "-"
                    + ContadorFinal
                    + ", prom "
                    + Promedio.ToString("0.00")
                    + ", aprox "
                    + Aproximado.ToString("0.00")
                    + ", dif "
                    + Diferencia.ToString("0.00")
                    + ")";
            }
        }
    }
}
