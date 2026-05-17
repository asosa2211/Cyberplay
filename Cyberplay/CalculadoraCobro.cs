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

        public decimal CalcularCosto(Estacion estacion,
    TipoTarifa tarifaInicial,
    List<CambioTarifa> historial,
    TimeSpan tiempo)
        {
            // =====================
            // MINUTOS
            // =====================

            double minutos =
                tiempo.TotalMinutes;

            // =====================
            // TOLERANCIA
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
            // CANTIDAD BLOQUES
            // =====================

            int cantidadBloques =
                (int)Math.Ceiling(
                    minutos / 15);

            // =====================
            // TOTAL
            // =====================

            decimal total = 0;

            // =====================
            // RECORRER BLOQUES
            // =====================

            for (int i = 1;
                 i <= cantidadBloques;
                 i++)
            {
                // =================
                // TARIFA BLOQUE
                // =================

                TipoTarifa tarifaBloque =
                    ObtenerTarifaParaBloque(
                        i,
                        tarifaInicial,
                        historial);

                // =================
                // PRECIO BLOQUE
                // =================

                decimal precio =
                    ObtenerPrecioBloque(estacion,
                        tarifaBloque);

                // =================
                // SUMAR
                // =================

                total += precio;
            }

            // =====================
            // RETORNAR
            // =====================

            return total;
        }
        // =========================================
        // OBTENER PRECIO POR BLOQUE
        // =========================================

        private decimal ObtenerPrecioBloque(Estacion estacion,
            TipoTarifa tarifa)
        {
            if (estacion.Tipo
    == TipoEstacion.PC)
            {
                return estacion.TarifaCiclo;
            }
            switch (tarifa)
            {
                case TipoTarifa.M2:
                    return estacion.Tarifa2M / 4;

                case TipoTarifa.M3:
                    return estacion.Tarifa3M / 4;

                case TipoTarifa.M4:
                    return estacion.Tarifa4M / 4;

                default:
                    return 0;
            }
        }

        private TipoTarifa ObtenerTarifaParaBloque(int numeroBloque, TipoTarifa tarifaInicial,
                                                    List<CambioTarifa> historial)
        {
            // ==========================
            // TIEMPO DONDE TERMINA BLOQUE
            // ==========================

            double minutosBloque =
                (numeroBloque * 15) + 2;

            TipoTarifa tarifaActual =
                tarifaInicial;

            // ==========================
            // RECORRER HISTORIAL
            // ==========================

            foreach (var cambio in historial)
            {
                // ======================
                // SI CAMBIO OCURRIÓ
                // ANTES DE TERMINAR
                // ESTE BLOQUE
                // ======================

                if (cambio.TiempoCambio
                    .TotalMinutes
                    <= minutosBloque)
                {
                    tarifaActual =
                        cambio.TarifaNueva;
                }
            }

            return tarifaActual;
        }
    }
}
