using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class AlertaEquipo
    {
        public DateTime FechaHora
        {
            get;
            set;
        }

        public int NumeroEquipo
        {
            get;
            set;
        }

        public string TipoEquipo
        {
            get;
            set;
        }

        public string Cajero
        {
            get;
            set;
        }

        public string Motivo
        {
            get;
            set;
        }
    }
}
