using Cyberplay.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class Sesion
    {
        public Cronometro Cronometro { get; private set; }
        public ModoSesion Modo { get; private set; }
        public TimeSpan TiempoLimite { get; private set; }
        public TipoTarifa TarifaActual { get; private set; }
        public TipoTarifa TarifaInicial { get; private set; }
        public List<CambioTarifa> HistorialTarifas { get; private set; }
        public Usuario UsuarioActual { get; private set; }

        public List<VentaProducto> ProductosConsumidos { get; set; }
                                    = new List<VentaProducto>();

        // =======================

        public Sesion(TipoTarifa tarifaInicial, Usuario usuario)
        {
            Cronometro = new Cronometro();
            Modo = ModoSesion.Libre;
            TarifaActual = tarifaInicial;
            HistorialTarifas = new List<CambioTarifa>();
            UsuarioActual = usuario;
        }

        // =======================

        public void IniciarLibre()
        {
            //Modo = ModoSesion.Libre;
            //Cronometro.Iniciar();
            // =====================
            // GUARDAR TARIFA INICIAL
            // =====================

            if (Cronometro.TiempoTranscurrido
                == TimeSpan.Zero)
            {
                TarifaInicial =
                    TarifaActual;
            }

            // =====================
            // INICIAR
            // =====================

            Cronometro.Iniciar();

            Modo = ModoSesion.Libre;
        }

        // =======================

        public void IniciarLimitado(TimeSpan tiempo)
        {
            // Modo = ModoSesion.Limitado;
            //TiempoLimite = tiempo;
            //Cronometro.Iniciar();
            // =====================
            // GUARDAR TARIFA INICIAL
            // =====================

            if (Cronometro.TiempoTranscurrido
                == TimeSpan.Zero)
            {
                TarifaInicial =
                    TarifaActual;
            }

            // =====================
            // CONFIGURAR
            // =====================

            TiempoLimite = tiempo;

            Modo = ModoSesion.Limitado;

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

        //CAMBIAR USUARIO
        public void CambiarUsuario(Usuario usuario)
        {
            UsuarioActual = usuario;
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
