namespace CyberplayAPI.Helpers
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

        public static string Root =>
    Directory
    .GetParent(
        AppDomain
        .CurrentDomain
        .BaseDirectory)
    .Parent
    .FullName;

        // =====================
        // DATA
        // =====================

        public static string Data =>
            Path.Combine(
                Root,
                "Data");
    }
}
