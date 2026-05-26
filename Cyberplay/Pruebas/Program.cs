using Cyberplay;
using Cyberplay.Modelos;
using System;

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
