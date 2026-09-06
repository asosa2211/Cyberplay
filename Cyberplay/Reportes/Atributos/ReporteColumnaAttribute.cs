using Cyberplay.Reportes.Core;
using System;

namespace Cyberplay.Reportes.Atributos
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReporteColumnaAttribute : Attribute
    {
        public string Titulo { get; }

        public int Orden { get; set; }

        public int Ancho { get; set; }

        public bool Visible { get; set; }

        public string Formato { get; set; }

        public AlineacionColumna Alineacion { get; set; }

        public ReporteColumnaAttribute(
            string titulo)
        {
            Titulo = titulo;

            Orden = 0;

            Ancho = 2;

            Visible = true;

            Formato = "";

            Alineacion = AlineacionColumna.Izquierda;
        }
    }
}