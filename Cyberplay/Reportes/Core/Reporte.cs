using System;
using System.Collections.Generic;

namespace Cyberplay.Reportes.Core
{
    public class Reporte
    {
        public string Empresa { get; set; }

        public string Titulo { get; set; }

        public string Subtitulo { get; set; }

        public DateTime FechaGeneracion { get; set; }

        public bool Horizontal { get; set; }

        public List<ReporteParametro> Parametros { get; }

        public List<ReporteResumen> Resumenes { get; }

        public List<ReporteTabla> Tablas { get; }

        public Reporte()
        {
            Parametros = new List<ReporteParametro>();
            Resumenes = new List<ReporteResumen>();
            Tablas = new List<ReporteTabla>();

            Empresa = "CYBERPLAY";
            FechaGeneracion = DateTime.Now;
        }
    }
}