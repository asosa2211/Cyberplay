using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Helpers
{
    public static class Rutas
    {
        // =====================
        // BASE
        // =====================

        private static string basePath =
            AppDomain
            .CurrentDomain
            .BaseDirectory;

        // =====================
        // ROOT
        // =====================

        public static string Root
        {
            get
            {
                // =====================
                // DESARROLLO
                // =====================

                if (basePath.Contains(
                    @"bin\Debug"))
                {
                    return Directory
                        .GetParent(basePath)
                        .Parent
                        .Parent
                        .FullName;
                }

                // =====================
                // PORTABLE
                // =====================

                return basePath;
            }
        }

        // =====================
        // DATA
        // =====================

        public static string Data =>
            Path.Combine(
                Root,
                "Data");

        public static string Backups =>
        Path.Combine(
        Root,
        "Backups");

        public static string BackupsSistema =>
    Path.Combine(
        @"C:\SystemData",
        "Backups");

        // =====================
        // API
        // =====================

        public static string API =>
            Path.Combine(
                Root,
                "API");

        // =====================
        // WEB
        // =====================

        public static string Web =>
            Path.Combine(
                Root,
                "Web");

        // =====================
        // TUNNEL
        // =====================

        public static string Tunnel =>
            Path.Combine(
                Root,
                "Tunnel");
    }
}
