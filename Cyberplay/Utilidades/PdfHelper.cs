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
        private static void AgregarLinea(
    IContainer container)
        {
            container
                .BorderBottom(1)
                .PaddingBottom(8);
        }
        private static void AgregarEncabezado(
    IContainer container,
    PdfReportInfo info)
        {
            container
                .Row(row =>
                {

                    // ==========================
                    // COLUMNA IZQUIERDA
                    // ==========================

                    row.RelativeItem()
                        .Column(columna =>
                        {

                            columna.Item()
                                .Text("CYBERPLAY")
                                .FontSize(
                                    PdfStyles.TituloEmpresa)
                                .Bold();


                            columna.Item()
                                .Text(info.Titulo)
                                .FontSize(
                                    PdfStyles.TituloReporte)
                                .Bold();

                        });



                    // ==========================
                    // COLUMNA DERECHA
                    // ==========================

                    row.ConstantItem(220)
                        .Column(columna =>
                        {

                            columna.Item()
                                .AlignRight()
                                .Text(
                                    $"Generado: {info.FechaEmision:dd/MM/yyyy HH:mm}")
                                .FontSize(
                                    PdfStyles.TextoNormal);



                            columna.Item()
                                .AlignRight()
                                .Text(
                                    $"Usuario: {info.Usuario}")
                                .FontSize(
                                    PdfStyles.TextoNormal);



                            if (!string.IsNullOrWhiteSpace(info.Desde))
                            {
                                columna.Item()
                                    .AlignRight()
                                    .Text(
                                        $"Desde: {info.Desde}")
                                    .FontSize(
                                        PdfStyles.TextoNormal);
                            }



                            if (!string.IsNullOrWhiteSpace(info.Hasta))
                            {
                                columna.Item()
                                    .AlignRight()
                                    .Text(
                                        $"Hasta: {info.Hasta}")
                                    .FontSize(
                                        PdfStyles.TextoNormal);
                            }



                            if (!string.IsNullOrWhiteSpace(info.FiltroAdicional))
                            {
                                columna.Item()
                                    .AlignRight()
                                    .Text(
                                        info.FiltroAdicional)
                                    .FontSize(
                                        PdfStyles.TextoNormal);
                            }

                        });

                });
        }

        private static void AgregarResumen(IContainer container, PdfReportInfo info)
        {
            container
                .Row(row =>
                {

                    // ==========================
                    // TOTAL INGRESOS
                    // ==========================

                    row.RelativeItem()
                        .Border(1)
                        .Padding(10)
                        .Column(col =>
                        {
                            col.Item()
                                .Text("TOTAL INGRESOS")
                                .FontSize(9)
                                .Bold();


                            col.Item()
                                .PaddingTop(5)
                                .Text($"{info.TotalIngresos:0.00} Bs")
                                .FontSize(14)
                                .Bold();
                        });



                    row.ConstantItem(20);



                    // ==========================
                    // TOTAL UTILIDAD
                    // ==========================

                    row.RelativeItem()
                        .Border(1)
                        .Padding(10)
                        .Column(col =>
                        {
                            col.Item()
                                .Text("TOTAL UTILIDAD")
                                .FontSize(9)
                                .Bold();


                            col.Item()
                                .PaddingTop(5)
                                .Text(
                                    $"{info.TotalUtilidad:0.00} Bs")
                                .FontSize(14)
                                .Bold();
                        });

                });
        }

        public static void ExportarUtilidadProducto(string rutaArchivo, PdfReportInfo info,
                                                List<ResumenProducto> productos)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);


                    page.Content()
                        .Column(column =>
                        {

                            // ==========================
                            // ENCABEZADO
                            // ==========================

                            column.Item().Element(x => AgregarEncabezado(x, info));


                            // ==========================
                            // SEPARADOR
                            // ==========================

                            column.Item()
                                .Element(AgregarLinea);



                            // ==========================
                            // FILTROS
                            // ==========================

                            foreach (string filtro in info.Filtros)
                            {
                                column.Item()
                                    .Text($"• {filtro}")
                                    .FontSize(10);
                            }

                            column.Item()
                                .Element(AgregarLinea);

                            // ==========================
                            // RESUMEN RAPIDO
                            // ==========================

                            column.Item().PaddingTop(10).Element(x => AgregarResumen(x, info));


                            // ==========================
                            // TABLA
                            // ==========================

                            column.Item()
                                .PaddingTop(15)
                                .Table(tabla =>
                                {

                                    tabla.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(4); // Producto
                                        columns.RelativeColumn(2); // Categoria
                                        columns.RelativeColumn(2); // Precio
                                        columns.RelativeColumn(2); // Cantidad
                                        columns.RelativeColumn(2); // Total
                                        columns.RelativeColumn(2); // Utilidad
                                    });



                                    // ==========================
                                    // CABECERA
                                    // ==========================

                                    tabla.Header(header =>
                                    {
                                        header.Cell()
                                            .Element(
                                                PdfStyles.EncabezadoTabla)
                                            .Text("Producto");


                                        header.Cell()
                                            .Element(
                                                PdfStyles.EncabezadoTabla)
                                            .Text("Categoría");


                                        header.Cell()
                                            .Element(
                                                PdfStyles.EncabezadoTabla)
                                            .AlignRight()
                                            .Text("Precio");


                                        header.Cell()
                                            .Element(
                                                PdfStyles.EncabezadoTabla)
                                            .AlignRight()
                                            .Text("Cantidad");


                                        header.Cell()
                                            .Element(
                                                PdfStyles.EncabezadoTabla)
                                            .AlignRight()
                                            .Text("Total");


                                        header.Cell()
                                            .Element(
                                                PdfStyles.EncabezadoTabla)
                                            .AlignRight()
                                            .Text("Utilidad");
                                    });



                                    // ==========================
                                    // FILAS ZEBRA
                                    // ==========================

                                    bool filaAlterna = false;


                                    foreach (ResumenProducto producto in productos)
                                    {
                                        filaAlterna = !filaAlterna;


                                        tabla.Cell()
                                            .Element(x =>
                                                PdfStyles.CeldaZebra(
                                                    x,
                                                    filaAlterna))
                                            .Text(producto.Producto);



                                        tabla.Cell()
                                            .Element(x =>
                                                PdfStyles.CeldaZebra(
                                                    x,
                                                    filaAlterna))
                                            .Text(producto.Categoria);



                                        tabla.Cell()
                                            .Element(x =>
                                                PdfStyles.CeldaZebra(
                                                    x,
                                                    filaAlterna))
                                            .AlignRight()
                                            .Text(
                                                producto.Precio
                                                .ToString("0.00"));



                                        tabla.Cell()
                                            .Element(x =>
                                                PdfStyles.CeldaZebra(
                                                    x,
                                                    filaAlterna))
                                            .AlignRight()
                                            .Text(
                                                producto.Cantidad
                                                .ToString("0.##"));



                                        tabla.Cell()
                                            .Element(x =>
                                                PdfStyles.CeldaZebra(
                                                    x,
                                                    filaAlterna))
                                            .AlignRight()
                                            .Text(
                                                producto.Total
                                                .ToString("0.00"));



                                        tabla.Cell()
                                            .Element(x =>
                                                PdfStyles.CeldaZebra(
                                                    x,
                                                    filaAlterna))
                                            .AlignRight()
                                            .Text(
                                                producto.Utilidad
                                                .ToString("0.00"));
                                    }
                                });
                        });



                    // ==========================
                    // PIE DE PAGINA
                    // ==========================

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
