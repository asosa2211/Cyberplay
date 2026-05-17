using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class RegistroCobro
    {
        public string Cajero{ get; set;
        }
        // =========================
        // USUARIO
        // =========================

        public string NombreCuenta
        {
            get;
            set;
        }

        // =========================
        // FECHA
        // =========================

        public DateTime Fecha
        {
            get;
            set;
        }

        // =========================
        // TIEMPO JUGADO
        // =========================

        public TimeSpan TiempoJugado
        {
            get;
            set;
        }

        // =========================
        // TOTAL COBRADO
        // =========================

        public decimal TotalCobrado
        {
            get;
            set;
        }

        // =========================
        // TARIFA FINAL
        // =========================

        public TipoTarifa TarifaFinal
        {
            get;
            set;
        }

        // =========================
        // CONSTRUCTOR
        // =========================

        public RegistroCobro(
            string nombreCuenta,
            DateTime fecha,
            TimeSpan tiempoJugado,
            decimal totalCobrado,
            TipoTarifa tarifaFinal, string cajero)
        {
            NombreCuenta =
                nombreCuenta;

            Fecha =
                fecha;

            TiempoJugado =
                tiempoJugado;

            TotalCobrado =
                totalCobrado;

            TarifaFinal =
                tarifaFinal;

            Cajero = cajero;
        }
    }
}
