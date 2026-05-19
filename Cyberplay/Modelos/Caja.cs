using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class Caja
    {
        public string Nombre { get; set; }  
        public string Cajero { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime?FechaCierre { get; set; }
        public decimal TotalCobrado { get; set; }
        public bool Abierta { get; set; }
        public int NumeroCaja { get; set; }
        
        //CONSTRUCTOR
        public Caja() 
        {

        }

    }
}
