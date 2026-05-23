using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class TipoEquipoConfiguracion
    {
        // =====================
        // NOMBRE
        // =====================

        public string Nombre
        {
            get;
            set;
        }

        // =====================
        // CANTIDAD
        // =====================

        public int Cantidad
        {
            get;
            set;
        }

        // =====================
        // TARIFA LIBRE
        // =====================

        public decimal TarifaLibre
        {
            get;
            set;
        }

        // =====================
        // MULTIJUGADOR
        // =====================

        public bool
            UsaTarifasMultijugador
        {
            get;
            set;
        }

        // =====================
        // TARIFAS
        // =====================

        public decimal TarifaM2
        {
            get;
            set;
        }

        public decimal TarifaM3
        {
            get;
            set;
        }

        public decimal TarifaM4
        {
            get;
            set;
        }
    }
}
