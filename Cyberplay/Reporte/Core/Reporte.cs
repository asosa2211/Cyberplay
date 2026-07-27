using System;
using System.Collections.Generic;

namespace Cyberplay.Reportes.Core
{
    public class Reporte
    {
        public string Empresa { get; set; }

        public string Titulo { get; set; }

        public string Subtitulo { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaGeneracion { get; set; }

        public string Desde { get; set; }

        public string Hasta { get; set; }

        public bool Horizontal { get; set; }

        public List<ReporteParametro> Parametros { get; set; }

        public List<ReporteResumen> Resumenes { get; set; }

        public List<ReporteTabla> Tablas { get; set; }

        public Reporte()
        {
            Parametros = new List<ReporteParametro>();

            Resumenes = new List<ReporteResumen>();

            Tablas = new List<ReporteTabla>();

            FechaGeneracion = DateTime.Now;

            Empresa = "CYBERPLAY";
        }
    }
}