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
            using (Bitmap bmp = new Bitmap(800, 1400))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                Font titulo =
                    new Font(
                        "Segoe UI",
                        22,
                        FontStyle.Bold);

                Font subtitulo =
                    new Font(
                        "Segoe UI",
                        11,
                        FontStyle.Regular);

                Font texto =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Regular);

                Brush negro = Brushes.Black;

                //=========================
                // TÍTULO
                //=========================

                g.DrawString(
                    "CAPTURA DE EMERGENCIA",
                    titulo,
                    Brushes.DarkBlue,
                    20,
                    20);

                //=========================
                // FECHA
                //=========================

                g.DrawString(
                    "Fecha: "
                    + captura.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"),
                    texto,
                    negro,
                    22,
                    70);

                //=========================
                // CAJERO
                //=========================

                g.DrawString(
                    "Cajero: "
                    + captura.Cajero,
                    texto,
                    negro,
                    22,
                    95);

                //=========================
                // CAJA
                //=========================

                g.DrawString(
                    "Caja Nº "
                    + captura.NumeroCaja,
                    texto,
                    negro,
                    22,
                    120);

                //=========================
                // LÍNEA
                //=========================

                g.DrawLine(
                    Pens.Gray,
                    20,
                    155,
                    1180,
                    155);

                //INFO EQUIPOS

                // =====================
                // EQUIPOS
                // =====================

                int y = 170;

                foreach (CapturaEquipo equipo
                    in captura.Equipos)
                {
                    Rectangle cuadro =
                        new Rectangle(20, y, 700, 110);

                    g.FillRectangle(
                        Brushes.WhiteSmoke,
                        cuadro);

                    g.DrawRectangle(
                        Pens.Gray,
                        cuadro);

                    Font tituloEquipo =
                        new Font(
                            "Segoe UI",
                            12,
                            FontStyle.Bold);

                    Font textoEquipo =
                        new Font(
                            "Segoe UI",
                            10,
                            FontStyle.Regular);

                    // -------------------------
                    // TÍTULO
                    // -------------------------

                    g.DrawString(
                        $"{equipo.TipoEquipo} #{equipo.NumeroEquipo}",
                        tituloEquipo,
                        Brushes.DarkBlue,
                        35,
                        y + 10);

                    // -------------------------
                    // USUARIO
                    // -------------------------

                    g.DrawString(
                        "Usuario: " + equipo.NombreCuenta,
                        textoEquipo,
                        Brushes.Black,
                        35,
                        y + 40);

                    // -------------------------
                    // TIEMPO
                    // -------------------------

                    g.DrawString(
                        "Tiempo: " +
                        equipo.TiempoJugado.ToString(@"hh\:mm\:ss"),
                        textoEquipo,
                        Brushes.Black,
                        260,
                        y + 40);

                    // -------------------------
                    // TARIFA
                    // -------------------------

                    g.DrawString(
                        "Tarifa: " + equipo.Tarifa,
                        textoEquipo,
                        Brushes.Black,
                        500,
                        y + 40);

                    // -------------------------
                    // TIEMPO COBRADO
                    // -------------------------

                    g.DrawString(
                        "Tiempo Bs: "
                        + equipo.TotalTiempo.ToString("0.00"),
                        textoEquipo,
                        Brushes.Black,
                        35,
                        y + 70);

                    // -------------------------
                    // PRODUCTOS
                    // -------------------------

                    g.DrawString(
                        "Productos Bs: "
                        + equipo.TotalProductos.ToString("0.00"),
                        textoEquipo,
                        Brushes.Black,
                        260,
                        y + 70);

                    // -------------------------
                    // TOTAL
                    // -------------------------

                    Font total =
                        new Font(
                            "Segoe UI",
                            14,
                            FontStyle.Bold);

                    g.DrawString(
                        "TOTAL: Bs "
                        + equipo.TotalGeneral.ToString("0.00"),
                        total,
                        Brushes.DarkRed,
                        520,
                        y + 65);

                    // -------------------------
                    // NOTA
                    // -------------------------

                    if (!string.IsNullOrWhiteSpace(
                        equipo.Nota))
                    {
                        g.DrawString(
                            "Nota: " + equipo.Nota,
                            textoEquipo,
                            Brushes.DarkGreen,
                            820,
                            y + 40);
                    }

                    y += 125;
                }

                bmp.Save(
                    ruta,
                    ImageFormat.Png);
            }
        }
    }
}
