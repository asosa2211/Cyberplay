using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    internal class Cronometro
    {
        public DateTime HoraInicio { get; private set; }
        public bool EnEjecucion { get; private set; }
        public bool Pausado { get; private set; }
        private DateTime horaPausa;
        private TimeSpan tiempoPausado;

        // =========================

        public void Iniciar()
        {
            HoraInicio = DateTime.Now;
            tiempoPausado = TimeSpan.Zero;
            EnEjecucion = true;
            Pausado = false;
        }

        // =========================

        public void Pausar()
        {
            if (!EnEjecucion || Pausado)
                return;

            horaPausa = DateTime.Now;
            Pausado = true;
        }

        // =========================

        public void Reanudar()
        {
            if (!Pausado)
                return;

            tiempoPausado += DateTime.Now - horaPausa;
            Pausado = false;
        }

        // =========================

        public void Detener()
        {
            EnEjecucion = false;
            Pausado = false;
        }

        // =========================

        public TimeSpan TiempoTranscurrido
        {
            get
            {
                if (!EnEjecucion)
                    return TimeSpan.Zero;

                if (Pausado)
                    return horaPausa - HoraInicio - tiempoPausado;

                return DateTime.Now - HoraInicio - tiempoPausado;
            }
        }
    }
}
