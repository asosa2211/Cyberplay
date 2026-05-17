using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class EstadoSesion
    {
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

        public TimeSpan TiempoTranscurrido
        {
            get;
            set;
        }
    }
}
