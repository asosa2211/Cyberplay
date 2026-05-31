using System;
using System.Linq;

namespace Cyberplay.Helpers
{
    public static class EquipoIdentidad
    {
        public static string Formatear(int numeroEquipo, string tipoEquipo)
        {
            if (numeroEquipo <= 0)
            {
                return tipoEquipo ?? "";
            }

            if (string.IsNullOrWhiteSpace(tipoEquipo))
            {
                return numeroEquipo.ToString();
            }

            return numeroEquipo + " | " + tipoEquipo;
        }

        public static int ObtenerNumero(string equipo)
        {
            if (string.IsNullOrWhiteSpace(equipo))
            {
                return 0;
            }

            string limpio =
                equipo.Trim();

            int numero;

            if (int.TryParse(limpio, out numero))
            {
                return numero;
            }

            string[] partesPipe =
                limpio.Split('|');

            if (partesPipe.Length > 0
                && int.TryParse(partesPipe[0].Trim(), out numero))
            {
                return numero;
            }

            string[] partesGuion =
                limpio.Split('-');

            if (partesGuion.Length > 1
                && int.TryParse(partesGuion.Last().Trim(), out numero))
            {
                return numero;
            }

            return 0;
        }

        public static string ObtenerTipo(string equipo)
        {
            if (string.IsNullOrWhiteSpace(equipo))
            {
                return "";
            }

            string limpio =
                equipo.Trim();

            string[] partesPipe =
                limpio.Split('|');

            if (partesPipe.Length > 1)
            {
                return partesPipe[1].Trim();
            }

            string[] partesGuion =
                limpio.Split('-');

            if (partesGuion.Length > 1)
            {
                return partesGuion[0].Trim();
            }

            return limpio;
        }
    }
}
