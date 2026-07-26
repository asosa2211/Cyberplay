using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Cyberplay.Utilidades
{
    public static class PdfStyles
    {
        public const float TituloEmpresa = 20;

        public const float TituloReporte = 14;

        public const float TextoNormal = 10;

        public const float TextoPequeno = 8;


        // ==========================
        // ENCABEZADO TABLA
        // ==========================

        public static IContainer EncabezadoTabla(
            IContainer container)
        {
            return container
                .Background("#1F4E78")
                .Border(0.5f)
                .BorderColor("#163A5C")
                .PaddingVertical(6)
                .PaddingHorizontal(5)
                .AlignMiddle()
                .DefaultTextStyle(
                    x =>
                        x.Bold()
                         .FontColor("#FFFFFF")
                         .FontSize(9));
        }



        // ==========================
        // CELDA NORMAL
        // ==========================

        public static IContainer CeldaTabla(
            IContainer container)
        {
            return container
                .BorderBottom(0.5f)
                .BorderColor("#D9D9D9")
                .PaddingVertical(5)
                .PaddingHorizontal(5)
                .AlignMiddle()
                .DefaultTextStyle(
                    x =>
                        x.FontSize(9));
        }



        // ==========================
        // CELDA NUMERICA
        // ==========================

        public static IContainer CeldaNumero(
            IContainer container)
        {
            return container
                .BorderBottom(0.5f)
                .BorderColor("#D9D9D9")
                .PaddingVertical(5)
                .PaddingHorizontal(5)
                .AlignMiddle()
                .AlignRight()
                .DefaultTextStyle(
                    x =>
                        x.FontSize(9));
        }



        // ==========================
        // ZEBRA
        // ==========================

        public static IContainer CeldaZebra(
            IContainer container,
            bool alternar)
        {
            return container
                .Background(
                    alternar
                    ? "#F2F2F2"
                    : "#FFFFFF")

                .BorderBottom(0.5f)
                .BorderColor("#D9D9D9")

                .PaddingVertical(5)

                .PaddingHorizontal(5)

                .AlignMiddle()

                .DefaultTextStyle(
                    x =>
                        x.FontSize(9));
        }



        // ==========================
        // LINEA SEPARADORA
        // ==========================

        public static IContainer Linea(
            IContainer container)
        {
            return container
                .BorderBottom(1)
                .BorderColor("#808080");
        }

        public static IContainer TarjetaResumen(
    IContainer container)
        {
            return container
                .Border(1)
                .Padding(10);
        }


       
    }
}