using Cyberplay.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class Usuario
    {
        // =========================
        // NOMBRE CUENTA
        // =========================

        public string NombreCuenta
        {
            get;
            set;
        }

        // =========================
        // NOMBRE CLIENTE
        // =========================

        public string NombreCliente
        {
            get;
            set;
        }

        // =========================
        // TELEFONO
        // =========================

        public string Telefono
        {
            get;
            set;
        }

        // =========================
        // TIEMPO TOTAL
        // =========================

        public TimeSpan TiempoTotalJugado
        {
            get;
            set;
        }

        // =========================
        // CONSTRUCTOR
        // =========================

        public Usuario(
            string nombreCuenta,
            string nombreCliente,
            string telefono)
        {
            NombreCuenta =
                nombreCuenta;

            NombreCliente =
                nombreCliente;

            Telefono =
                telefono;

        

            TiempoTotalJugado =
                TimeSpan.Zero;
        }

        // =========================
        // MOSTRAR EN COMBO/LISTA
        // =========================

        public override string ToString()
        {
            return NombreCuenta;
        }

        //SALDO PROMOCIONAL
        public decimal SaldoPromocional { get; set; }
    }
}
