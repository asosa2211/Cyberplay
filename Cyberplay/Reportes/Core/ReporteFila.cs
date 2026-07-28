using Cyberplay.Reportes.Estilos;
using System.Collections.Generic;

namespace Cyberplay.Reportes.Core
{
    public class ReporteFila
    {
        public List<string> Celdas { get; set; }
        public bool Negrita { get; set; }

        public string ColorFondo { get; set; }

        public string ColorTexto { get; set; }

        public bool Destacada { get; set; }

        public ReporteFila()
        {
            Celdas = new List<string>();
            Negrita = false;

            ColorTexto = ReporteStyles.Negro;

            ColorFondo = ReporteStyles.Blanco;

            Destacada = false;
        }

        public void Agregar(params string[] valores)
        {
            Celdas.AddRange(valores);
        }
    }
}