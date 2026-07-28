using Cyberplay.Reportes.Core;
using Cyberplay.Reportes.Estilos;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Linq;

namespace Cyberplay.Reportes.Renderers.Componentes
{
    public class EncabezadoRenderer
    {
        public void Dibujar(
            IContainer container,
            Reporte reporte)
        {
            container.Column(col =>
            {
                //--------------------------------------------------
                // EMPRESA
                //--------------------------------------------------

                col.Item()
                    .Text(reporte.Empresa)
                    .FontSize(ReporteStyles.TituloEmpresa)
                    .Bold();

                //--------------------------------------------------
                // TITULO
                //--------------------------------------------------

                col.Item()
                    .PaddingTop(2)
                    .Text(reporte.Titulo)
                    .FontSize(ReporteStyles.TituloReporte)
                    .Bold();

                //--------------------------------------------------
                // SUBTITULO (Opcional)
                //--------------------------------------------------

                if (!string.IsNullOrWhiteSpace(reporte.Subtitulo))
                {
                    col.Item()
                        .PaddingTop(2)
                        .Text(reporte.Subtitulo)
                        .FontSize(11);
                }

                //--------------------------------------------------
                // LINEA SEPARADORA
                //--------------------------------------------------

                col.Item()
                    .PaddingTop(8)
                    .BorderBottom(1);

                //--------------------------------------------------
                // INFORMACIÓN GENERAL
                //--------------------------------------------------

                col.Item()
                    .PaddingTop(10)
                    .Text(text =>
                    {
                        text.Span("Generado: ").Bold();
                        text.Span(
                            reporte.FechaGeneracion.ToString("dd/MM/yyyy HH:mm"));
                    });

                //--------------------------------------------------
                // PARAMETROS
                //--------------------------------------------------

                if (reporte.Parametros.Any())
                {
                    col.Item()
                        .PaddingTop(8)
                        .Column(parametros =>
                        {
                            for (int i = 0; i < reporte.Parametros.Count; i += 2)
                            {
                                parametros.Item()
                                    .PaddingBottom(3)
                                    .Row(row =>
                                    {
                                        //--------------------------------------
                                        // Columna izquierda
                                        //--------------------------------------

                                        ReporteParametro izquierda =
                                            reporte.Parametros[i];

                                        row.RelativeItem()
                                            .Text(text =>
                                            {
                                                text.Span(
                                                    izquierda.Nombre + ": ")
                                                    .Bold();

                                                text.Span(
                                                    izquierda.Valor);
                                            });

                                        //--------------------------------------
                                        // Columna derecha
                                        //--------------------------------------

                                        if (i + 1 < reporte.Parametros.Count)
                                        {
                                            ReporteParametro derecha =
                                                reporte.Parametros[i + 1];

                                            row.RelativeItem()
                                                .Text(text =>
                                                {
                                                    text.Span(
                                                        derecha.Nombre + ": ")
                                                        .Bold();

                                                    text.Span(
                                                        derecha.Valor);
                                                });
                                        }
                                        else
                                        {
                                            row.RelativeItem();
                                        }
                                    });
                            }
                        });
                }

                //--------------------------------------------------
                // ESPACIO FINAL
                //--------------------------------------------------

                col.Item()
                    .PaddingBottom(10);
            });
        }
    }
}