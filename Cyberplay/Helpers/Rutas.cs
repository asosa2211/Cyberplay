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

        public static string Base =>
            AppDomain
            .CurrentDomain
            .BaseDirectory;

        // =====================
        // DATA
        // =====================

        public static string Data =>
            Path.Combine(
                Base,
                "Data");

        // =====================
        // API
        // =====================

        public static string API =>
            Path.Combine(
                Base,
                "API");

        // =====================
        // WEB
        // =====================

        public static string Web =>
            Path.Combine(
                Base,
                "Web");

        // =====================
        // TUNNEL
        // =====================

        public static string Tunnel =>
            Path.Combine(
                Base,
                "Tunnel");
    }
}
