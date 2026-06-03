using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberplay.Modelos;

namespace Cyberplay
{
    public class EstadoSesion
    {
        public int NumeroEquipo
        {
            get;
            set;
        }

        public string IdEstacion
        {
            get;
            set;
        }

        public string TipoEquipo
        {
            get;
            set;
        }

        public string NombreConsola
        {
            get;
            set;
        }

        public bool SesionActiva
        {
            get;
            set;
        }

        public string Usuario
        {
            get;
            set;
        }

        public TipoTarifa Tarifa
        {
            get;
            set;
        }

        public TipoTarifa TarifaInicial
        {
            get;
            set;
        }

        public ModoSesion Modo
        {
            get;
            set;
        }

        public DateTime HoraInicio
        {
            get;
            set;
        }

        public DateTime HoraInicioReal
        {
            get;
            set;
        }

        public TimeSpan TiempoLimite
        {
            get;
            set;
        }

        public bool Pausado
        {
            get;
            set;
        }

        public DateTime HoraPausa
        {
            get;
            set;
        }

        public DateTime FechaSnapshot
        {
            get;
            set;
        }

        public bool EstabaCorriendo
        {
            get;
            set;
        }

        public decimal Tarifa2M
        {
            get;
            set;
        }

        public decimal Tarifa3M
        {
            get;
            set;
        }

        public decimal Tarifa4M
        {
            get;
            set;
        }

        public decimal TarifaCiclo
        {
            get;
            set;
        }

        public int CiclosPorHora
        {
            get;
            set;
        }

        public int ToleranciaMinutos
        {
            get;
            set;
        }

        public TimeSpan TiempoTranscurrido
        {
            get;
            set;
        }

        public List<VentaProducto> ProductosConsumidos
        {
            get;
            set;
        }
            = new List<VentaProducto>();

        public List<CambioTarifa> HistorialTarifas
        {
            get;
            set;
        }
            = new List<CambioTarifa>();

        public string Nota
        {
            get;
            set;
        }
    }
}
