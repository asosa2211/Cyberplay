using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class IngresoCaja
    {
        // =====================
        // FECHA
        // =====================

        public DateTime Fecha
        {
            get;
            set;
        }
            = DateTime.Now;

        // =====================
        // CONCEPTO
        // =====================

        public string Concepto
        {
            get;
            set;
        }

        // =====================
        // MONTO
        // =====================

        public decimal Monto
        {
            get;
            set;
        }

        // =====================
        // CAJERO
        // =====================

        public string Cajero
        {
            get;
            set;
        }
    }
}
