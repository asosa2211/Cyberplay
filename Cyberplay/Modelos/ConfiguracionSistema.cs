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

        public int ToleranciaMinutos
        {
            get;
            set;
        }
    }
}
