using Cyberplay.Modelos;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Utilidades
{
    public static class PdfHelper
    {
        private static IContainer EstiloCabecera(IContainer container)
        {
            return container
                .BorderBottom(1)
                .PaddingVertical(5)
                .PaddingHorizontal(3)
                .DefaultTextStyle(x => x.Bold());
        }

        private static IContainer EstiloCelda(IContainer container)
        {
            return container
                .BorderBottom(0.5f)
                .PaddingVertical(3)
                .PaddingHorizontal(3);
        }
        public static void ExportarUtilidadProducto(string rutaArchivo,
    PdfReportInfo info, List<ResumenProducto> productos)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    page.Header()
                        .Column(column =>
                        {
                            column.Item()
                                .Text("CYBERPLAY")
                                .FontSize(22)
                                .Bold();

                            column.Item()
                                .Text(info.Titulo)
                                .FontSize(16);

                            column.Item()
                                .LineHorizontal(1);
                        });

                    page.Content()
                        .Column(column =>
                        {
                            column.Spacing(5);

                            column.Item()
                                .Text($"Fecha de emisión: {info.FechaEmision:dd/MM/yyyy HH:mm}");

                            column.Item()
                                .Text($"Usuario: {info.Usuario}");

                            column.Item()
                                .PaddingTop(10)
                                .Text("Filtros")
                                .Bold();

                            foreach (string filtro in info.Filtros)
                            {
                                column.Item()
                                    .Text($"• {filtro}");
                            }

                            column.Item().PaddingTop(15);
                            column.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(4); // Producto
                                    columns.RelativeColumn(2); // Categoría
                                    columns.RelativeColumn(2); // Precio
                                    columns.RelativeColumn(2); // Cantidad
                                    columns.RelativeColumn(2); // Total
                                    columns.RelativeColumn(2); // Utilidad
                                });

                                tabla.Header(header =>
                                {
                                    header.Cell().Element(EstiloCabecera).Text("Producto");
                                    header.Cell().Element(EstiloCabecera).Text("Categoría");
                                    header.Cell().Element(EstiloCabecera).AlignRight().Text("Precio");
                                    header.Cell().Element(EstiloCabecera).AlignRight().Text("Cantidad");
                                    header.Cell().Element(EstiloCabecera).AlignRight().Text("Total");
                                    header.Cell().Element(EstiloCabecera).AlignRight().Text("Utilidad");
                                });

                                foreach (ResumenProducto producto in productos)
                                {
                                    tabla.Cell().Element(EstiloCelda).Text(producto.Producto);

                                    tabla.Cell().Element(EstiloCelda).Text(producto.Categoria);

                                    tabla.Cell().Element(EstiloCelda)
                                        .AlignRight()
                                        .Text(producto.Precio.ToString("0.00"));

                                    tabla.Cell().Element(EstiloCelda)
                                        .AlignRight()
                                        .Text(producto.Cantidad.ToString("0.##"));

                                    tabla.Cell().Element(EstiloCelda)
                                        .AlignRight()
                                        .Text(producto.Total.ToString("0.00"));

                                    tabla.Cell().Element(EstiloCelda)
                                        .AlignRight()
                                        .Text(producto.Utilidad.ToString("0.00"));
                                }
                            });
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.Span("Página ");
                            text.CurrentPageNumber();
                            text.Span(" de ");
                            text.TotalPages();
                        });
                });
            })
.GeneratePdf(rutaArchivo);
        }

    }
}
