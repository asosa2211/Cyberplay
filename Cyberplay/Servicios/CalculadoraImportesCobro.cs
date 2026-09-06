using System;
using System.Linq;

namespace Cyberplay
{
    internal static class CalculadoraImportesCobro
    {
        public static decimal ObtenerTotalProductos(
            RegistroCobro cobro)
        {
            if (cobro == null)
            {
                return 0;
            }

            if (cobro.TotalProductos > 0)
            {
                return cobro.TotalProductos;
            }

            return cobro.ProductosConsumidos?
                .Sum(
                    x =>
                    x.Total)
                ?? 0;
        }

        public static decimal ObtenerTotalTiempoEfectivo(
            RegistroCobro cobro)
        {
            if (cobro == null)
            {
                return 0;
            }

            decimal totalProductos =
                ObtenerTotalProductos(
                    cobro);

            decimal totalTiempo =
                cobro.TotalCobrado
                - totalProductos;

            if (totalTiempo >= 0)
            {
                return totalTiempo;
            }

            decimal totalDesdeBruto =
                cobro.TotalTiempoJugado
                - cobro.SaldoPromocionalUtilizado;

            return Math.Max(
                0,
                totalDesdeBruto);
        }

        public static decimal ObtenerTotalEfectivo(
            RegistroCobro cobro)
        {
            if (cobro == null)
            {
                return 0;
            }

            return ObtenerTotalTiempoEfectivo(
                    cobro)
                + ObtenerTotalProductos(
                    cobro);
        }
    }
}
