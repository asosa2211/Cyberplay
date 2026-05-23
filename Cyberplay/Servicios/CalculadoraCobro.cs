using Cyberplay.Core;
using Cyberplay.Modelos;
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

            if (minutos <= estacion.ToleranciaMinutos)
            {
                return 0;
            }

            // =====================
            // RESTAR TOLERANCIA
            // =====================

            minutos -= estacion.ToleranciaMinutos;

            int minutosBloque = 15;

            TipoEquipoConfiguracion tipo = ObtenerConfiguracionTipo(estacion);

            if (tipo != null && !tipo.UsaTarifasMultijugador)
            {
                minutosBloque =
                    estacion.MinutosCiclo;
            }

            // =====================
            // CANTIDAD BLOQUES
            // =====================

            int cantidadBloques =
                (int)Math.Ceiling(
                    minutos / minutosBloque);

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
            TipoEquipoConfiguracion tipo = ObtenerConfiguracionTipo(estacion);

            if (tipo != null && !tipo.UsaTarifasMultijugador)
            {
                return estacion.TarifaCiclo/3;
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

        private TipoEquipoConfiguracion ObtenerConfiguracionTipo(Estacion estacion)
        {
            return SesionSistema
                .Configuracion
                .TiposEquipo
                .FirstOrDefault(
                    t =>
                    t.Nombre
                    == estacion
                        .TipoEquipo);
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
