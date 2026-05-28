namespace CyberplayAPI.Helpers
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
        // ROOT
        // =====================

        public static string Root =>
            Directory
            .GetParent(Base)
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
