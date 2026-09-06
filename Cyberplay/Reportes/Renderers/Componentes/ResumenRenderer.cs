using Cyberplay.Reportes.Core;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Cyberplay.Reportes.Renderers.Componentes
{
    public class ResumenRenderer
    {
        public void Dibujar(IContainer container, List<ReporteResumen> resumenes)
        {
            if (resumenes == null || !resumenes.Any())
            {
                return;
            }

            container
                .PaddingVertical(10)
                .Row(row =>
                {
                    foreach (ReporteResumen resumen in resumenes)
                    {
                        row.RelativeItem()
                            .Background(resumen.ColorFondo)
                            .Border(1)
                            .BorderColor("#D9D9D9")
                            .Padding(8)
                            .Column(col =>
                            {
                                col.Item()
                                    .Text(text =>
                                    {
                                        text.Span(resumen.Etiqueta)
                                            .FontColor(resumen.ColorTexto)
                                            .FontSize(9);
                                    });

                                col.Item()
                                    .Text(text =>
                                    {
                                        text.Span(resumen.Valor)
                                            .Bold()
                                            .FontSize(15)
                                            .FontColor(resumen.ColorTexto);
                                    });
                            });
                    }
                });
        }
    }
}