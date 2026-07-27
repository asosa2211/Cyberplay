namespace Cyberplay.Reportes.Core
{
    public class ReporteColumna
    {
        /// <summary>
        /// Texto que aparecerá en el encabezado.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Ancho relativo dentro de la tabla.
        /// Ejemplo:
        /// 4 = doble de ancho que 2
        /// </summary>
        public int Ancho { get; set; } = 1;

        /// <summary>
        /// Alineación del contenido.
        /// </summary>
        public AlineacionColumna Alineacion { get; set; }

        public ReporteColumna()
        {
            Alineacion = AlineacionColumna.Izquierda;
        }

        public ReporteColumna(
            string titulo,
            int ancho = 1,
            AlineacionColumna alineacion = AlineacionColumna.Izquierda)
        {
            Titulo = titulo;
            Ancho = ancho;
            Alineacion = alineacion;
        }
    }
}