using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    internal class CalculadoraCobro
    {
        // =========================================
        // CALCULAR COSTO BASE
        // =========================================

        public decimal CalcularCostoBase(
            TipoTarifa tarifa,
            TimeSpan tiempo)
        {

                // =====================
                // MINUTOS TOTALES
                // =====================

                double minutos =
                    tiempo.TotalMinutes;

                // =====================
                // TOLERANCIA GENERAL
                // =====================

                if (minutos <= 2)
                {
                    return 0;
                }

                // =====================
                // RESTAR TOLERANCIA
                // =====================

                minutos -= 2;

                // =====================
                // BLOQUES DE 15 MIN
                // =====================

                int bloques =
                    (int)Math.Ceiling(
                        minutos / 15);

                // =====================
                // PRECIO BLOQUE
                // =====================

                decimal precioBloque =
                    ObtenerPrecioBloque(tarifa);

                // =====================
                // TOTAL
                // =====================

                return bloques * precioBloque;
            }

        // =========================================
        // OBTENER PRECIO POR BLOQUE
        // =========================================

        private decimal ObtenerPrecioBloque(
            TipoTarifa tarifa)
        {
            switch (tarifa)
            {
                case TipoTarifa.M2:
                    return 2.5m;

                case TipoTarifa.M3:
                    return 3m;

                case TipoTarifa.M4:
                    return 3.5m;

                default:
                    return 0;
            }
        }
    }
}
