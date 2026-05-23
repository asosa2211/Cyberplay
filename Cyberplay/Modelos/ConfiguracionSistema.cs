using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class ConfiguracionSistema
    {
        // =====================
        // CATEGORIAS
        // =====================

        public List<string>
            Categorias
        {
            get;
            set;
        }
            = new List<string>();

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

        // =====================
        // EQUIPOS
        // =====================

        public int CantidadPC
        {
            get;
            set;
        }

        public int CantidadPS4
        {
            get;
            set;
        }

        // =====================
        // TOLERANCIA
        // =====================

        public int ToleranciaMinutos
        {
            get;
            set;
        }
    }
}
