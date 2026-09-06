using System.Collections.Generic;

namespace Cyberplay.Reportes.Core
{
    public class ReporteTabla
    {
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }

        public List<ReporteColumna> Columnas { get; set; }

        public List<ReporteFila> Filas { get; set; }

        public bool MostrarTitulo { get; set; }

        public bool MostrarTotales { get; set; }

        public bool Zebra { get; set; }

        public bool RepetirCabecera { get; set; }

        public List<ReportePieTabla> Pie { get; set; }

        public ReporteTabla()
        {
            Columnas = new List<ReporteColumna>();

            Filas = new List<ReporteFila>();

            Pie = new List<ReportePieTabla>();

            MostrarTitulo = true;

            MostrarTotales = false;

            Zebra = true;

            RepetirCabecera = true;

        }

        public void AgregarColumna(
            ReporteColumna columna)
        {
            Columnas.Add(columna);
        }

        public void AgregarFila(
            ReporteFila fila)
        {
            Filas.Add(fila);
        }

        public void AgregarPie(ReportePieTabla pie)
        {
            Pie.Add(pie);
        }
    }
}
