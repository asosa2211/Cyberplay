using Cyberplay.Helpers;
using Cyberplay.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Cyberplay.Servicios
{
    public class GeneradorCapturaImagen
    {
        private readonly string ruta =
            Path.Combine(
                Rutas.Capturas,
                "EstadoActual.png");


        public void Generar(CapturaSistema captura)
        {

            //=========================
            // TAMAÑO DINÁMICO
            //=========================

            int altoEncabezado = 170;
            int altoFila = 34;
            int altoResumen = 120;

            int altoImagen =
                altoEncabezado +
                (captura.Equipos.Count * altoFila) +
                altoResumen + 50;

            using (Bitmap bmp =
                new Bitmap(900, altoImagen))

            using (Graphics g =
                Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                g.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                g.TextRenderingHint =
                    System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                //=========================
                // FUENTES
                //=========================

                Font titulo =
                    new Font(
                        "Segoe UI",
                        18,
                        FontStyle.Bold);

                Font subtitulo =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Regular);

                Font encabezado =
                    new Font(
                        "Segoe UI",
                        9,
                        FontStyle.Bold);

                Font fila =
                    new Font(
                        "Segoe UI",
                        9,
                        FontStyle.Regular);

                Font resumen =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold);

                Brush texto =
                    Brushes.Black;

                Brush blanco =
                    Brushes.White;

                int y = 20;

                //=========================
                // TITULO
                //=========================

                g.DrawString(
                    "ESTADO ACTUAL DEL NEGOCIO",
                    titulo,
                    texto,
                    20,
                    y);

                y += 40;

                g.DrawString(
                    $"Fecha: {captura.FechaHora:dd/MM/yyyy HH:mm:ss}",
                    subtitulo,
                    texto,
                    20,
                    y);

                y += 22;

                g.DrawString(
                    $"Caja: {captura.NumeroCaja}",
                    subtitulo,
                    texto,
                    20,
                    y);

                y += 22;

                g.DrawString(
                    $"Cajero: {captura.Cajero}",
                    subtitulo,
                    texto,
                    20,
                    y);

                y += 35;

                //=========================
                // POSICIONES COLUMNAS
                //=========================

                int xEquipo = 30;
                int xUsuario = 110;
                int xTarifa = 250;
                int xTiempo = 320;
                int xBsTiempo = 470;
                int xProductos = 590;
                int xTotal = 730;

                //=========================
                // ENCABEZADO TABLA
                //=========================

                Rectangle rectHeader =
                    new Rectangle(
                        20,
                        y,
                        860,
                        altoFila);

                g.FillRectangle(
                    Brushes.SteelBlue,
                    rectHeader);

                g.DrawRectangle(
                    Pens.Black,
                    rectHeader);

                g.DrawString(
                    "Equipo",
                    encabezado,
                    blanco,
                    xEquipo,
                    y + 8);

                g.DrawString(
                    "Usuario",
                    encabezado,
                    blanco,
                    xUsuario,
                    y + 8);

                g.DrawString(
                    "Tarifa",
                    encabezado,
                    blanco,
                    xTarifa,
                    y + 8);

                g.DrawString(
                    "Tiempo Jugado",
                    encabezado,
                    blanco,
                    xTiempo,
                    y + 8);

                g.DrawString(
                    "Bs Tiempo",
                    encabezado,
                    blanco,
                    xBsTiempo,
                    y + 8);

                g.DrawString(
                    "Productos",
                    encabezado,
                    blanco,
                    xProductos,
                    y + 8);

                g.DrawString(
                    "Total Bs",
                    encabezado,
                    blanco,
                    xTotal,
                    y + 8);

                y += altoFila;

                //=========================
                // TOTALES
                //=========================

                decimal totalTiempo = 0;
                decimal totalProductos = 0;
                decimal totalGeneral = 0;

                int filaActual = 0;

                //=========================
                // FILAS
                //=========================

                foreach (var equipo in captura.Equipos)
                {
                    Rectangle rectFila =
                        new Rectangle(
                            20,
                            y,
                            860,
                            altoFila);

                    if (filaActual % 2 == 0)
                    {
                        g.FillRectangle(
                            Brushes.White,
                            rectFila);
                    }
                    else
                    {
                        g.FillRectangle(
                            new SolidBrush(
                                Color.FromArgb(
                                    245,
                                    245,
                                    245)),
                            rectFila);
                    }

                    g.DrawRectangle(
                        Pens.Gainsboro,
                        rectFila);

                    g.DrawString(
                        $"{equipo.TipoEquipo} #{equipo.NumeroEquipo}",
                        fila,
                        texto,
                        xEquipo,
                        y + 8);

                    g.DrawString(
                        equipo.NombreCuenta,
                        fila,
                        texto,
                        xUsuario,
                        y + 8);

                    g.DrawString(
                        equipo.Tarifa,
                        fila,
                        texto,
                        xTarifa,
                        y + 8);

                    g.DrawString(
                        equipo.TiempoJugado.ToString(@"hh\:mm\:ss"),
                        fila,
                        texto,
                        xTiempo,
                        y + 8);

                    g.DrawString(
                        equipo.TotalTiempo.ToString("0.00"),
                        fila,
                        texto,
                        xBsTiempo,
                        y + 8);

                    g.DrawString(
                        equipo.TotalProductos.ToString("0.00"),
                        fila,
                        texto,
                        xProductos,
                        y + 8);

                    g.DrawString(
                        equipo.TotalGeneral.ToString("0.00"),
                        fila,
                        texto,
                        xTotal,
                        y + 8);

                    totalTiempo += equipo.TotalTiempo;
                    totalProductos += equipo.TotalProductos;
                    totalGeneral += equipo.TotalGeneral;

                    filaActual++;
                    y += altoFila;
                }

                //=========================
                // RESUMEN
                //=========================

                y += 20;

                g.DrawLine(
                    Pens.Gray,
                    20,
                    y,
                    880,
                    y);

                y += 15;

                g.DrawString(
                    $"Equipos ocupados : {captura.Equipos.Count}",
                    resumen,
                    texto,
                    20,
                    y);

                y += 25;

                g.DrawString(
                    $"Total tiempo     : Bs. {totalTiempo:0.00}",
                    resumen,
                    texto,
                    20,
                    y);

                y += 25;

                g.DrawString(
                    $"Total productos  : Bs. {totalProductos:0.00}",
                    resumen,
                    texto,
                    20,
                    y);

                y += 25;

                g.DrawString(
                    $"TOTAL GENERAL    : Bs. {totalGeneral:0.00}",
                    new Font(
                        "Segoe UI",
                        11,
                        FontStyle.Bold),
                    Brushes.DarkGreen,
                    20,
                    y);

                bmp.Save(
                    ruta,
                    System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
