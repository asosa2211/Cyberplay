using Cyberplay.Reportes.Atributos;
using System;

namespace Cyberplay.Reportes.Formatters
{
    public static class ReporteFormatter
    {
        public static string Formatear(
            object valor,
            ReporteColumnaAttribute atributo)
        {
            if (valor == null)
                return string.Empty;

            //---------------------------------------
            // Formato definido en el atributo
            //---------------------------------------

            if (atributo != null &&
                !string.IsNullOrWhiteSpace(
                    atributo.Formato))
            {
                if (valor is IFormattable formateable)
                {
                    return formateable.ToString(
                        atributo.Formato,
                        null);
                }
            }

            //---------------------------------------
            // Formatos automáticos
            //---------------------------------------

            switch (valor)
            {
                case decimal d:
                    return d.ToString("N2");

                case double db:
                    return db.ToString("N2");

                case float f:
                    return f.ToString("N2");

                case DateTime fecha:
                    return fecha.ToString("dd/MM/yyyy HH:mm");

                case bool b:
                    return b ? "Sí" : "No";

                default:
                    return valor.ToString();
            }
        }
    }
}