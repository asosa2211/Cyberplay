using Cyberplay.Modelos;
using Cyberplay.Helpers;
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
        public int NumeroEquipo{ get; set; }
        public string TipoEquipo{ get; set; }
        public DateTime HoraInicio{ get; set; }
        public string NombreCuenta{ get; set; }
        public DateTime Fecha{ get; set; }
        public TimeSpan TiempoJugado{ get; set; }
        public decimal TotalCobrado{ get; set; }
        public decimal TotalProductos { get; set; }
        public decimal SaldoPromocionalUtilizado { get; set; }
        public TipoTarifa TarifaInicial { get; set; }
        public TipoTarifa TarifaFinal{ get; set; }  
        public int NumeroCaja{ get; set; }

        public string TicketId { get; set; }
        public List<VentaProducto> ProductosConsumidos { get; set;  } =
                                            new List<VentaProducto>();

        public List<CambioTarifa> HistorialTarifas { get;  set; } =
                                            new List<CambioTarifa>();

        public decimal TotalTiempoJugado
        {
            get;
            set;
        }

        public string EquipoDescripcion
        {
            get
            {
                if (NumeroEquipo > 0
                    && !string.IsNullOrWhiteSpace(TipoEquipo))
                {
                    return NumeroEquipo + " | " + TipoEquipo;
                }

                int numero =
                    EquipoIdentidad.ObtenerNumero(
                        Equipo);

                string tipo =
                    EquipoIdentidad.ObtenerTipo(
                        Equipo);

                if (numero > 0
                    && !string.IsNullOrWhiteSpace(tipo)
                    && tipo != numero.ToString())
                {
                    return EquipoIdentidad.Formatear(
                        numero,
                        tipo);
                }

                return Equipo;
            }
        }


        //CONSTRUCTOR
        public RegistroCobro()
        {
        }

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

        public RegistroCobro(string nombreCuenta, DateTime horaInicio, DateTime fecha,
                             TimeSpan tiempoJugado, decimal totalCobrado, TipoTarifa tarifaFinal,
                             string cajero, int numeroEquipo, string tipoEquipo, int numeroCaja)
            : this(nombreCuenta, horaInicio, fecha, tiempoJugado, totalCobrado,
                  tarifaFinal, cajero, numeroEquipo.ToString(), numeroCaja)
        {
            NumeroEquipo = numeroEquipo;
            TipoEquipo = tipoEquipo;
        }
    }
}
