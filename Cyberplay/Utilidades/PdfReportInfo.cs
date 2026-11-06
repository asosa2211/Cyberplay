using System;
using System.Collections.Generic;

namespace Cyberplay.Modelos
{
    public class PdfReportInfo
    {
        public string Titulo { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaEmision { get; set; }


        public List<string> Filtros { get; set; }
            = new List<string>();


        public string Desde { get; set; }

        public string Hasta { get; set; }

        public string FiltroAdicional { get; set; }


        public decimal TotalIngresos { get; set; }

        public decimal TotalUtilidad { get; set; }
    }
}