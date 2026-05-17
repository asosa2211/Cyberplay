using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    internal class CambioTarifa
    {
        public TimeSpan TiempoCambio { get; set; }
        public TipoTarifa TarifaNueva { get; set; }
        // =======================
        public CambioTarifa(TimeSpan tiempoCambio, TipoTarifa tarifaNueva)
        {
            TiempoCambio = tiempoCambio;
            TarifaNueva = tarifaNueva;
        }
    }
}
