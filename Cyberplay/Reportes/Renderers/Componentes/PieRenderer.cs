using Cyberplay.Reportes.Core;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Cyberplay.Reportes.Renderers.Componentes
{
    public class PieRenderer
    {
        public void Dibujar(
            IContainer container,
            Reporte reporte)
        {
            container
                .BorderTop(1)
                .PaddingTop(5)
                .Row(row =>
                {
                    row.RelativeItem()
                        .Text(text =>
                        {
                            text.Span("Generado por Cyberplay");
                        });

                    row.RelativeItem()
                        .AlignRight()
                        .Text(text =>
                        {
                            text.Span("Página ");

                            text.CurrentPageNumber();

                            text.Span(" de ");

                            text.TotalPages();
                        });
                });
        }
    }
}