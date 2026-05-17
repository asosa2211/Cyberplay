using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    internal class Cronometro
    {
        public DateTime HoraInicio
        {
            get;
            set;
        }

        public bool EnEjecucion
        {
            get;
            private set;
        }

        public bool Pausado
        {
            get;
            private set;
        }

        public DateTime HoraPausa
        {
            get;
            set;
        }

        // =========================

        public TimeSpan TiempoAcumulado
        {
            get;
            set;
        }

        // =========================

        public void Iniciar()
        {
            HoraInicio =
                DateTime.Now;

            TiempoAcumulado =
                TimeSpan.Zero;

            EnEjecucion = true;

            Pausado = false;
        }

        // =========================

        public void Pausar()
        {
            if (!EnEjecucion ||
                Pausado)
            {
                return;
            }

            TiempoAcumulado =
                TiempoTranscurrido;

            HoraPausa =
                DateTime.Now;

            Pausado = true;
        }

        // =========================

        public void Reanudar()
        {
            if (!Pausado)
            {
                return;
            }

            HoraInicio =
                DateTime.Now;

            Pausado = false;
        }

        // =========================

        public void Detener()
        {
            EnEjecucion = false;

            Pausado = false;

            TiempoAcumulado =
                TimeSpan.Zero;
        }

        // =========================

        public TimeSpan TiempoTranscurrido
        {
            get
            {
                if (!EnEjecucion)
                {
                    return TiempoAcumulado;
                }

                if (Pausado)
                {
                    return TiempoAcumulado;
                }

                return TiempoAcumulado +
                       (DateTime.Now -
                        HoraInicio);
            }
        }
    }
}
