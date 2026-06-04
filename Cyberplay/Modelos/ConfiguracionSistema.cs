using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Modelos
{
    public class ConfiguracionSistema
    {
        public List<string> Categorias { get; set; } = new List<string>();

        public List<TipoEquipoConfiguracion>
            TiposEquipo
        {
            get;
            set;
        }
            = new List
            <TipoEquipoConfiguracion>();

        public List<EstacionConfiguracion>
            Estaciones
        {
            get;
            set;
        }
            = new List
            <EstacionConfiguracion>();

        public int ToleranciaMinutos
        {
            get;
            set;
        }

        public int MinutosMonitoreoEquipos
        {
            get;
            set;
        } = 3;

        public int InicioEstaciones
        {
            get;
            set;
        }
            = 1;
    }
}
