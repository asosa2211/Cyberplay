using Cyberplay.Reportes.Core;
using Cyberplay.Reportes.Estilos;
using Cyberplay.Reportes.Renderers.Componentes;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Cyberplay.Reportes.Renderers
{
    public class ReportePdfRenderer
    {
        private readonly EncabezadoRenderer encabezado =
            new EncabezadoRenderer();

        private readonly ResumenRenderer resumen =
            new ResumenRenderer();

        private readonly TablaRenderer tabla =
            new TablaRenderer();

        private readonly PieRenderer pie =
            new PieRenderer();


        public void Generar(
            Reporte reporte,
            string rutaArchivo)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    //-------------------------------------------------
                    // Configuración
                    //-------------------------------------------------

                    page.Margin(
                        ReporteStyles.MargenPagina);

                    page.Size(
                        reporte.Horizontal
                            ? PageSizes.A4.Landscape()
                            : PageSizes.A4);

                    page.DefaultTextStyle(
                        x => x.FontSize(
                            ReporteStyles.Texto));

                    //-------------------------------------------------
                    // Contenido
                    //-------------------------------------------------

                    page.Content()
                        .Column(col =>
                        {
                            // Encabezado

                            col.Item()
                                .Element(x =>
                                    encabezado.Dibujar(
                                        x,
                                        reporte));

                            // Resúmenes

                            col.Item()
                                .Element(x =>
                                    resumen.Dibujar(
                                        x,
                                        reporte.Resumenes));

                            // Tablas

                            foreach (ReporteTabla tablaReporte
                                     in reporte.Tablas)
                            {
                                col.Item()
                                    .PaddingTop(15)
                                    .Element(x =>
                                        tabla.Dibujar(
                                            x,
                                            tablaReporte));
                            }
                        });

                    //-------------------------------------------------
                    // Pie
                    //-------------------------------------------------

                    page.Footer()
                        .Element(x =>
                            pie.Dibujar(
                                x,
                                reporte));
                });
            })
            .GeneratePdf(rutaArchivo);
        }
    }
}