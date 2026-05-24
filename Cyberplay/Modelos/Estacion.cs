using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class Estacion
    {
        public string Nombre
        {
            get;
            set;
        }

        public bool SoportaMultijugador
        {
            get;
            set;
        }
        public TipoEstacion Tipo
        {
            get;
            set;
        }

        // =====================
        // TIPO EQUIPO
        // =====================

        public string TipoEquipo
        {
            get;
            set;
        }

        // =====================
        // TARIFAS CONSOLAS
        // =====================

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

        // =====================
        // PC
        // =====================

        public decimal TarifaCiclo
        {
            get;
            set;
        }

        public int MinutosCiclo
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
    }
}
