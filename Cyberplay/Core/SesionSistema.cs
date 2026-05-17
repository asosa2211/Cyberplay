using Cyberplay.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Core
{
    public static class SesionSistema
    {
        public static Cajero
            CajeroActual
        {
            get;
            set;
        }

        public static Caja
            CajaActual
        {
            get;
            set;
        }
    }
}
