using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class CapturaSistema
    {
        public DateTime FechaHora { get; set; }

        public int NumeroCaja { get; set; }

        public string Cajero { get; set; }

        public List<CapturaEquipo> Equipos { get; set; }
            = new List<CapturaEquipo>();
    }
}
