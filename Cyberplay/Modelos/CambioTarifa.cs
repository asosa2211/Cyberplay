using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class CambioTarifa
    {
        public TimeSpan TiempoCambio { get; set; }
        public TipoTarifa TarifaNueva { get; set; }

        // =======================
        public CambioTarifa()
        {
        }

        public CambioTarifa(TimeSpan tiempoCambio, TipoTarifa tarifaNueva)
        {
            TiempoCambio = tiempoCambio;
            TarifaNueva = tarifaNueva;
        }
    }
}
