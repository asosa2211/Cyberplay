namespace Cyberplay.Reportes.Core
{
    public class ReporteResumen
    {
        public string Etiqueta { get; set; }

        public string Valor { get; set; }

        /// <summary>
        /// Color del fondo.
        /// Ejemplo: "#2F5597"
        /// </summary>
        public string ColorFondo { get; set; }

        /// <summary>
        /// Color del texto.
        /// Ejemplo: "#FFFFFF"
        /// </summary>
        public string ColorTexto { get; set; }

        /// <summary>
        /// Icono opcional (uso futuro).
        /// </summary>
        public string Icono { get; set; }

        public ReporteResumen()
        {
            ColorFondo = "#FFFFFF";

            ColorTexto = "#000000";

            Icono = "";
        }
    }
}