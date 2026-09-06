using Cyberplay.Reportes.Core;
using Cyberplay.Reportes.Estilos;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Cyberplay.Reportes.Renderers.Componentes
{
    public class TablaRenderer
    {
        public const string GrisZebra = "#F7F9FC";
        public void Dibujar(
            IContainer container,
            ReporteTabla tabla)
        {
            container.Column(col =>
            {
                DibujarTitulo(
                    col,
                    tabla);

                DibujarTabla(
                    col,
                    tabla);

                DibujarPie(
                    col,
                    tabla);
            });
        }

        private void DibujarTitulo(
    ColumnDescriptor columna,
    ReporteTabla tabla)
        {
            if (!tabla.MostrarTitulo)
                return;

            if (string.IsNullOrWhiteSpace(tabla.Titulo))
                return;

            columna.Item()
                .PaddingTop(15)
                .PaddingBottom(8)
                .Column(col =>
                {
                    col.Item()
                        .Text(tabla.Titulo)
                        .Bold()
                        .FontSize(12);

                    col.Item()
                        .PaddingTop(3)
                        .BorderBottom(0.5f)
                        .BorderColor("#D9D9D9");
                });
        }

        private void DibujarTabla(
    ColumnDescriptor columna,
    ReporteTabla tabla)
        {
            columna.Item().Table(t =>
            {
                DefinirColumnas(t, tabla);

                DibujarCabecera(t, tabla);

                DibujarFilas(t, tabla);
            });

            columna.Item()
                .LineHorizontal(1)
                .LineColor("#D9D9D9");
        }

        private IContainer AplicarAlineacion(IContainer container, AlineacionColumna alineacion)
        {
            switch (alineacion)
            {
                case AlineacionColumna.Centro:
                    return container.AlignCenter();

                case AlineacionColumna.Derecha:
                    return container.AlignRight();

                default:
                    return container.AlignLeft();
            }
        }

        private IContainer CrearCeldaCabecera(
    IContainer container,
    ReporteColumna columna)
        {
            container = container
                .Background(ReporteStyles.Azul)
               
                .PaddingVertical(10)
                .PaddingHorizontal(10);

            switch (columna.Alineacion)
            {
                case AlineacionColumna.Centro:
                case AlineacionColumna.Derecha:
                    return container.AlignCenter();

                default:
                    return container.AlignLeft();
            }
        }

        private IContainer CrearCeldaDatos(
    IContainer container,
    ReporteColumna columna,
    ReporteFila fila,
    bool zebra)
        {
            container = container
                .PaddingVertical(10)
                .PaddingLeft(10)
                .PaddingRight(10);
              

            //------------------------------------
            // Zebra
            //------------------------------------

            if (zebra)
            {
                container =
                    container.Background(GrisZebra);
            }

            //------------------------------------
            // Color personalizado
            //------------------------------------

            if (!string.IsNullOrWhiteSpace(
                fila.ColorFondo)
                &&
                fila.ColorFondo != ReporteStyles.Blanco)
            {
                container =
                    container.Background(
                        fila.ColorFondo);
            }

            //------------------------------------
            // Alineación
            //------------------------------------

            container =
                AplicarAlineacion(
                    container,
                    columna.Alineacion);

            if (columna.Alineacion ==
                AlineacionColumna.Derecha)
            {
                container =
                    container.PaddingRight(3);
            }

            return container;
        }

        private void EscribirTextoCelda(
    IContainer celda,
    string valor,
    ReporteColumna columna,
    ReporteFila fila)
        {
            celda.Text(text =>
            {
                var span = text.Span(valor)
                    .FontSize(columna.TamañoFuente)
                    .FontColor(fila.ColorTexto)
                    .LineHeight(1.2f);

                if (fila.Negrita)
                    span.Bold();
            });
        }

        private void DibujarPie(ColumnDescriptor columna, ReporteTabla tabla)
        {
            if (tabla.Pie == null
                || tabla.Pie.Count == 0)
            {
                return;
            }

            columna.Item()
                .PaddingTop(8)
                .AlignRight()
                .Column(col =>
                {
                    foreach (ReportePieTabla pie
                        in tabla.Pie)
                    {
                        col.Item()
                            .Row(row =>
                            {
                                row.ConstantItem(180)
                                    .Text(text =>
                                    {
                                        var span =
                                            text.Span(
                                                pie.Etiqueta);

                                        if (pie.Negrita)
                                            span.Bold();

                                        span.FontColor(
                                            pie.ColorTexto);
                                    });

                                row.ConstantItem(120)
                                    .AlignRight()
                                    .Text(text =>
                                    {
                                        var span =
                                            text.Span(
                                                pie.Valor);

                                        if (pie.Negrita)
                                            span.Bold();

                                        span.FontColor(
                                            pie.ColorTexto);
                                    });
                            });
                    }
                });
        }

        private void DefinirColumnas(
    TableDescriptor tabla,
    ReporteTabla reporteTabla)
        {
            tabla.ColumnsDefinition(columns =>
            {
                foreach (ReporteColumna columna in reporteTabla.Columnas)
                {
                    if (!columna.Visible)
                        continue;

                    columns.RelativeColumn(columna.Ancho);
                }
            });
        }

        private void DibujarCabecera(
    TableDescriptor tabla,
    ReporteTabla reporteTabla)
        {
            tabla.Header(header =>
            {
                foreach (ReporteColumna columna
                    in reporteTabla.Columnas)
                {
                    if (!columna.Visible)
                        continue;

                    CrearCeldaCabecera(
                        header.Cell(),
                        columna)
                    .Text(text =>
                    {
                        text.Span(columna.Titulo)
                            .Bold()
                            .FontSize(10)
                            .FontColor(
                                ReporteStyles.Blanco);
                    });
                }
            });
        }


        private void DibujarFilas(
    TableDescriptor tabla,
    ReporteTabla reporteTabla)
        {
            bool zebra = false;

            foreach (ReporteFila fila in reporteTabla.Filas)
            {
                zebra = !zebra;

                int indice = 0;

                foreach (ReporteColumna columna in reporteTabla.Columnas)
                {
                    if (!columna.Visible)
                    {
                        indice++;
                        continue;
                    }

                    string valor = "";

                    if (indice < fila.Celdas.Count)
                        valor = fila.Celdas[indice];

                    IContainer celda =
     CrearCeldaDatos(
         tabla.Cell(),
         columna,
         fila,
         reporteTabla.Zebra && zebra);





                    EscribirTextoCelda(celda, valor, columna, fila);

                    indice++;
                }
            }
        }
    }
}