namespace Cyberplay.Reportes.Core
{
    public class ReporteResumen
    {
        public string Titulo { get; set; }

        public string Valor { get; set; }

        public ReporteResumen()
        {
        }

        public ReporteResumen(
            string titulo,
            string valor)
        {
            Titulo = titulo;
            Valor = valor;
        }
    }
}