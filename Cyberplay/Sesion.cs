using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    internal class Sesion
    {
        public Cronometro Cronometro { get; private set; }
        public ModoSesion Modo { get; private set; }
        public TimeSpan TiempoLimite { get; private set; }

        // =======================

        public Sesion()
        {
            Cronometro = new Cronometro();
            Modo = ModoSesion.Libre;
        }

        // =======================

        public void IniciarLibre()
        {
            Modo = ModoSesion.Libre;
            Cronometro.Iniciar();
        }

        // =======================

        public void IniciarLimitado(TimeSpan tiempo)
        {
            Modo = ModoSesion.Limitado;
            TiempoLimite = tiempo;
            Cronometro.Iniciar();
        }

        // =======================
        // CAMBIAR A LIBRE
        // =======================

        public void CambiarALibre()
        {
            Modo = ModoSesion.Libre;
        }

        // =======================
        // CAMBIAR A LIMITADO
        // =======================

        public void CambiarALimitado(TimeSpan tiempo)
        {
            Modo = ModoSesion.Limitado;
            TiempoLimite = tiempo;
        }

        // =======================
        // AGREGAR TIEMPO
        // =======================

        public void AgregarTiempo(TimeSpan tiempoExtra)
        {
            TiempoLimite += tiempoExtra;
        }

        // =======================

        public TimeSpan TiempoRestante
        {
            get
            {
                if (Modo == ModoSesion.Libre)
                    return TimeSpan.Zero;

                return TiempoLimite
                       - Cronometro.TiempoTranscurrido;
            }
        }
    }
}
