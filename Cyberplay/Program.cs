using Cyberplay.Formularios;
using Cyberplay.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestPDF.Infrastructure;



namespace Cyberplay
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            QuestPDF.Settings.License = LicenseType.Community;
            // =====================
            // CREAR CARPETAS
            // =====================

            Directory.CreateDirectory(
                Rutas.Data);

            Directory.CreateDirectory(
                Rutas.API);

            Directory.CreateDirectory(
                Rutas.Web);

            Directory.CreateDirectory(Rutas.Tunnel);
            Directory.CreateDirectory(Rutas.Capturas);

            //Application.Run(new frmLogin());
            frmLogin login = new frmLogin();

            if (login.ShowDialog()
                == DialogResult.OK)
            {
                Application.Run(new frmPrincipal());
            }
        }
    }
}
