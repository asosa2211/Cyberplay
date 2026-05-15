using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    internal class TarifaInfo
    {
        public TipoTarifa Tipo { get; set; }
        public decimal PrecioHora { get; set; }
        public decimal PrecioBloque15 { get; set; }


        public TarifaInfo(TipoTarifa tipo, decimal precioHora)
        {
            Tipo = tipo;
            PrecioHora = precioHora;
            PrecioBloque15 = precioHora / 4;
        }
    }
}

