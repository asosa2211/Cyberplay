using System;
using System.Collections.Concurrent;
using System.Linq;

namespace CyberplayAPI.Servicios
{
    public static class
        VisitantesService
    {
        // =====================
        // LISTA
        // =====================

        private static
            ConcurrentDictionary
            <string, DateTime>
            visitantes =
                new ConcurrentDictionary
                <string, DateTime>();

        // =====================
        // REGISTRAR
        // =====================

        public static void
            RegistrarVisitante(
                string id)
        {
            visitantes[id] =
                DateTime.Now;
        }

        // =====================
        // LIMPIAR
        // =====================

        public static void
            LimpiarInactivos()
        {
            var eliminar =
                visitantes

                .Where(
                    x =>
                    (DateTime.Now
                    - x.Value)
                    .TotalSeconds > 15)

                .Select(
                    x =>
                    x.Key)

                .ToList();

            foreach (string id
                in eliminar)
            {
                visitantes.TryRemove(
                    id,
                    out _);
            }
        }

        // =====================
        // CONTAR
        // =====================

        public static int
            ObtenerCantidad()
        {
            LimpiarInactivos();

            return visitantes.Count;
        }
    }
}