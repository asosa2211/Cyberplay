using Cyberplay.Reportes.Estilos;

namespace Cyberplay.Reportes.Core
{
    public class ReportePieTabla
    {
        public string Etiqueta { get; set; }

        public string Valor { get; set; }

        public bool Negrita { get; set; }

        public string ColorTexto { get; set; }

        public string ColorFondo { get; set; }

        public ReportePieTabla()
        {
            Etiqueta = "";

            Valor = "";

            Negrita = false;

            ColorTexto = ReporteStyles.Negro;

            ColorFondo = ReporteStyles.Blanco;
        }
    }
}