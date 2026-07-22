using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Utilidades
{
    public class PdfReportInfo
    {
        public string Titulo { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaEmision { get; set; }

        public List<string> Filtros { get; set; } = new List<string>();
    }
}
