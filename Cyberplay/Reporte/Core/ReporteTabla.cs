using System.Collections.Generic;

namespace Cyberplay.Reportes.Core
{
    public class ReporteTabla
    {
        public string Titulo { get; set; }

        public List<ReporteColumna> Columnas { get; set; }

        public List<ReporteFila> Filas { get; set; }

        public ReporteTabla()
        {
            Columnas = new List<ReporteColumna>();

            Filas = new List<ReporteFila>();
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
    }
}
