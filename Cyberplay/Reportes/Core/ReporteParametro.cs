namespace Cyberplay.Reportes.Core
{
    public class ReporteParametro
    {
        public string Nombre { get; set; }

        public string Valor { get; set; }

        public ReporteParametro()
        {
        }

        public ReporteParametro(
            string nombre,
            string valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}