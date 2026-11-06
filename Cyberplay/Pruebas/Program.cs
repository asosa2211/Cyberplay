using Cyberplay;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cyberplay.Pruebas
{
    internal static class Program
    {
        private static int pruebasEjecutadas = 0;

        private static void Main()
        {
            ProbarCronometroConPausa();
            ProbarRegistroCobro();
            ProbarCierreCaja();
            ProbarVentaSesionTrasCambioDeCaja();
            ProbarGuardadoDeMovimientosPorLote();

            Console.WriteLine(
                "Pruebas OK: "
                + pruebasEjecutadas);
        }

        private static void ProbarCronometroConPausa()
        {
            Cronometro cronometro =
                new Cronometro();

            cronometro.Iniciar();

            DateTime inicioReal =
                cronometro.HoraInicioReal;

            cronometro.HoraInicio =
                DateTime.Now
                - TimeSpan.FromMinutes(30);

            cronometro.Pausar();

            Assert(
                cronometro.TiempoTranscurrido.TotalMinutes >= 29,
                "Debe acumular tiempo antes de pausar.");

            cronometro.Reanudar();

            cronometro.HoraInicio =
                DateTime.Now
                - TimeSpan.FromMinutes(10);

            Assert(
                cronometro.HoraInicioReal == inicioReal,
                "La hora real de inicio no debe cambiar al reanudar.");

            Assert(
                cronometro.TiempoTranscurrido.TotalMinutes >= 39,
                "Debe sumar tiempo antes y despues de la pausa.");
        }

        private static void ProbarRegistroCobro()
        {
            DateTime inicio =
                DateTime.Now
                - TimeSpan.FromMinutes(40);

            RegistroCobro cobro =
                new RegistroCobro(
                    "invitado",
                    inicio,
                    DateTime.Now,
                    TimeSpan.FromMinutes(40),
                    20,
                    TipoTarifa.M2,
                    "juan",
                    "PS4-1",
                    3);

            Assert(
                cobro.NumeroCaja == 3,
                "El cobro debe conservar numero de caja.");

            Assert(
                cobro.TarifaFinal == TipoTarifa.M2,
                "El cobro debe conservar tarifa final.");

            Assert(
                cobro.HoraInicio == inicio,
                "El cobro debe conservar hora real de inicio.");
        }

        private static void ProbarCierreCaja()
        {
            Caja cajaActual =
                new Caja()
                {
                    NumeroCaja = 4,
                    Cajero = "juan",
                    Abierta = true,
                    TotalCobrado = 100,
                    FechaApertura = DateTime.Now
                };

            cajaActual.Abierta =
                false;

            cajaActual.FechaCierre =
                DateTime.Now;

            Caja cajaNueva =
                new Caja()
                {
                    NumeroCaja = cajaActual.NumeroCaja + 1,
                    Cajero = "maria",
                    Abierta = true,
                    TotalCobrado = 0,
                    FechaApertura = DateTime.Now
                };

            Assert(
                !cajaActual.Abierta
                && cajaActual.FechaCierre != null,
                "La caja cerrada debe quedar cerrada y con fecha de cierre.");

            Assert(
                cajaNueva.NumeroCaja == 5
                && cajaNueva.Abierta
                && cajaNueva.TotalCobrado == 0,
                "La caja nueva debe abrir con numero siguiente y total cero.");
        }

        private static void ProbarVentaSesionTrasCambioDeCaja()
        {
            Caja cajaX =
                new Caja()
                {
                    NumeroCaja = 10,
                    Abierta = true,
                    TotalCobrado = 0
                };

            VentaProducto ventaSesion =
                new VentaProducto()
                {
                    NumeroCaja = cajaX.NumeroCaja,
                    CobradaEnSesion = true,
                    Total = 17
                };

            HashSet<Guid> idsSesionActiva =
                new HashSet<Guid>()
                {
                    ventaSesion.Id
                };

            cajaX.Abierta = false;

            Caja cajaY =
                new Caja()
                {
                    NumeroCaja = cajaX.NumeroCaja + 1,
                    Abierta = true,
                    TotalCobrado = 0
                };

            bool reasigno =
                CalculadoraImportesCobro
                    .ReasignarVentasSesionesActivasACaja(
                        new[] { ventaSesion },
                        idsSesionActiva,
                        cajaY.NumeroCaja);

            Assert(
                reasigno
                && ventaSesion.NumeroCaja == cajaY.NumeroCaja,
                "La venta de una sesión activa debe pasar de la caja X a la nueva caja Y.");

            RegistroCobro cobro =
                new RegistroCobro(
                    "invitado",
                    DateTime.Now.AddMinutes(-30),
                    DateTime.Now,
                    TimeSpan.FromMinutes(30),
                    40,
                    TipoTarifa.M2,
                    "maria",
                    "PS4-1",
                    cajaY.NumeroCaja);

            cobro.TotalProductos = 17;
            cobro.ProductosConsumidos.Add(ventaSesion);

            cajaY.TotalCobrado += cobro.TotalCobrado;

            HashSet<Guid> idsCobradasEnY =
                new HashSet<Guid>()
                {
                    ventaSesion.Id
                };

            decimal totalTiempo =
                CalculadoraImportesCobro
                    .ObtenerTotalTiempoEfectivo(
                        cobro);

            bool ventaIncluidaEnY =
                CalculadoraImportesCobro
                    .EsVentaContabilizadaEnCaja(
                        ventaSesion,
                        cajaY.NumeroCaja,
                        idsCobradasEnY);

            bool ventaExcluidaDeX =
                !CalculadoraImportesCobro
                    .EsVentaContabilizadaEnCaja(
                        ventaSesion,
                        cajaX.NumeroCaja,
                        new HashSet<Guid>());

            decimal totalDetalleY =
                totalTiempo
                + (ventaIncluidaEnY
                    ? ventaSesion.Total
                    : 0);

            Assert(
                cobro.NumeroCaja == cajaY.NumeroCaja
                && ventaIncluidaEnY
                && ventaExcluidaDeX,
                "El cobro y la venta deben quedar atribuidos a Y, no a X.");

            Assert(
                cajaY.TotalCobrado == 40
                && totalDetalleY == cajaY.TotalCobrado,
                "El total de caja Y y el total reconstruido en el detalle deben coincidir en 40.");
        }

        private static void ProbarGuardadoDeMovimientosPorLote()
        {
            string carpetaTemporal =
                Path.Combine(
                    Path.GetTempPath(),
                    "Cyberplay.Pruebas."
                    + Guid.NewGuid().ToString("N"));

            string rutaMovimientos =
                Path.Combine(
                    carpetaTemporal,
                    "movimientos_stock.json");

            try
            {
                PersistenciaMovimientoStock persistencia =
                    new PersistenciaMovimientoStock(
                        rutaMovimientos);

                persistencia.GuardarMovimiento(
                    new MovimientoStock()
                    {
                        Producto = "Existente",
                        NumeroCaja = 1,
                        Entrada = 2
                    });

                persistencia.GuardarMovimientos(
                    new List<MovimientoStock>()
                    {
                        new MovimientoStock()
                        {
                            Producto = "Entregado",
                            NumeroCaja = 1,
                            Entregado = 5
                        },
                        new MovimientoStock()
                        {
                            Producto = "Recibido",
                            NumeroCaja = 2,
                            Recibido = 5
                        }
                    });

                List<MovimientoStock> movimientos =
                    persistencia.CargarMovimientos();

                Assert(
                    movimientos.Count == 3,
                    "El guardado por lote debe conservar el movimiento anterior y añadir cada nuevo movimiento una sola vez.");

                Assert(
                    movimientos.Any(
                        x =>
                        x.Producto == "Entregado"
                        && x.NumeroCaja == 1
                        && x.Entregado == 5)
                    && movimientos.Any(
                        x =>
                        x.Producto == "Recibido"
                        && x.NumeroCaja == 2
                        && x.Recibido == 5),
                    "El lote debe preservar los datos de caja y tipo de movimiento.");
            }
            finally
            {
                if (Directory.Exists(carpetaTemporal))
                {
                    Directory.Delete(
                        carpetaTemporal,
                        true);
                }
            }
        }

        private static void Assert(
            bool condicion,
            string mensaje)
        {
            if (!condicion)
            {
                throw new Exception(
                    mensaje);
            }

            pruebasEjecutadas++;
        }
    }
}
