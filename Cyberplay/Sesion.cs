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
        public TipoTarifa TarifaActual { get; private set; }
        public TipoTarifa TarifaInicial { get; private set; }
        public List<CambioTarifa> HistorialTarifas { get; private set; }

        // =======================

        public Sesion()
        {
            Cronometro = new Cronometro();
            Modo = ModoSesion.Libre;
            TarifaActual = TipoTarifa.M2;
            HistorialTarifas = new List<CambioTarifa>();
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

        //CAMBIAR TARIFA
        public void CambiarTarifa(TipoTarifa nuevaTarifa)
        {
            TarifaActual = nuevaTarifa;
            HistorialTarifas.Add(new CambioTarifa(Cronometro.TiempoTranscurrido,
                    nuevaTarifa));
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
