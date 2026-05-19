using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class RegistroCobro
    {
        public string Cajero{ get; set; }
        public string Equipo{ get; set; }
        public DateTime HoraInicio{ get; set; }
        public string NombreCuenta{ get; set; }
        public DateTime Fecha{ get; set; }
        public TimeSpan TiempoJugado{ get; set; }
        public decimal TotalCobrado{ get; set; }
        public TipoTarifa TarifaFinal{ get; set; }  
        public int NumeroCaja{ get; set; }
      

        //CONSTRUCTOR
        public RegistroCobro(string nombreCuenta, DateTime horaInicio, DateTime fecha,
                             TimeSpan tiempoJugado, decimal totalCobrado, TipoTarifa tarifaFinal,
                             string cajero, string equipo, int numeroCaja)
        {
            NombreCuenta = nombreCuenta;
            Fecha = fecha;
            TiempoJugado = tiempoJugado;
            TotalCobrado = totalCobrado;
            TarifaFinal =  tarifaFinal;
            Cajero = cajero;
            HoraInicio = horaInicio;
            Equipo = equipo;
            NumeroCaja = numeroCaja;
        }
    }
}
