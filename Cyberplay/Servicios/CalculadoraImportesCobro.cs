using Cyberplay.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cyberplay
{
    internal static class CalculadoraImportesCobro
    {
        public static bool ReasignarVentasSesionesActivasACaja(
            IEnumerable<VentaProducto> ventas,
            HashSet<Guid> idsVentasActivas,
            int numeroCaja)
        {
            if (ventas == null
                || idsVentasActivas == null
                || idsVentasActivas.Count == 0)
            {
                return false;
            }

            bool actualizoVentas = false;

            foreach (VentaProducto venta
                in ventas.Where(
                    x =>
                    x != null
                    && x.CobradaEnSesion
                    && idsVentasActivas.Contains(
                        x.Id)))
            {
                if (venta.NumeroCaja == numeroCaja)
                {
                    continue;
                }

                venta.NumeroCaja = numeroCaja;
                actualizoVentas = true;
            }

            return actualizoVentas;
        }

        public static bool EsVentaContabilizadaEnCaja(
            VentaProducto venta,
            int numeroCaja,
            HashSet<Guid> idsVentasCobradasEnSesion)
        {
            if (venta == null)
            {
                return false;
            }

            if (!venta.CobradaEnSesion)
            {
                return venta.NumeroCaja == numeroCaja;
            }

            // Las ventas de una sesión se contabilizan en la caja donde
            // finalmente se registra el cobro, aunque se hayan vendido
            // antes de un cambio de caja.
            return idsVentasCobradasEnSesion != null
                && idsVentasCobradasEnSesion.Contains(venta.Id);
        }

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
