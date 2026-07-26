using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class CapturaEquipo
    {
        public int NumeroEquipo { get; set; }

        public string TipoEquipo { get; set; }

        public string Estado { get; set; }

        public string NombreCuenta { get; set; }

        public DateTime HoraInicio { get; set; }

        public TimeSpan TiempoJugado { get; set; }

        public TimeSpan TiempoRestante { get; set; }

        public string Tarifa { get; set; }

        public decimal TotalTiempo { get; set; }

        public decimal TotalProductos { get; set; }

        public decimal TotalGeneral { get; set; }

        public string Nota { get; set; }
    }
}
