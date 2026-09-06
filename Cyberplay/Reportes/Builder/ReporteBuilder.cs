using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberplay.Reportes.Core;

namespace Cyberplay.Reportes.Builder
{
    public class ReporteBuilder
    {
        private readonly Reporte reporte;

        public ReporteBuilder()
        {
            reporte = new Reporte();
        }

        public ReporteBuilder Empresa(string empresa)
        {
            reporte.Empresa = empresa;
            return this;
        }

        public ReporteBuilder Titulo(string titulo)
        {
            reporte.Titulo = titulo;
            return this;
        }

        public ReporteBuilder Subtitulo(string subtitulo)
        {
            reporte.Subtitulo = subtitulo;
            return this;
        }

        public ReporteBuilder Horizontal(bool horizontal = true)
        {
            reporte.Horizontal = horizontal;
            return this;
        }

        public ReporteBuilder Fecha(DateTime fecha)
        {
            reporte.FechaGeneracion = fecha;
            return this;
        }

        public ReporteBuilder AgregarParametro(string nombre, string valor)
        {
            reporte.Parametros.Add(new ReporteParametro()
                {
                    Nombre = nombre,
                    Valor = valor
                });

            return this;
        }

        public ReporteBuilder AgregarResumen(string etiqueta, string valor)
        {
            reporte.Resumenes.Add(new ReporteResumen()
                {
                    Etiqueta = etiqueta,
                    Valor = valor
                });

            return this;
        }

        public ReporteBuilder AgregarResumen(
    string etiqueta,
    string valor,
    string colorFondo,
    string colorTexto = "#FFFFFF")
        {
            reporte.Resumenes.Add(
                new ReporteResumen()
                {
                    Etiqueta = etiqueta,
                    Valor = valor,
                    ColorFondo = colorFondo,
                    ColorTexto = colorTexto
                });

            return this;
        }

        public ReporteBuilder AgregarTabla(ReporteTabla tabla)
        {
            reporte.Tablas.Add(tabla);

            return this;
        }

        public ReporteBuilder AgregarTablas(IEnumerable<ReporteTabla> tablas)
        {
            reporte.Tablas.AddRange(tablas);

            return this;
        }

        public Reporte Build()
        {
            return reporte;
        }
    }
}
