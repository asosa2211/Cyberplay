using Cyberplay.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Helpers
{
    public static class GeneradorTickets
    {
        public static string
            Generar()
        {
            PersistenciaTickets
                persistencia =
                    new PersistenciaTickets();

            int numero =
                persistencia
                    .ObtenerSiguienteTicket();

            return
                $"TK-{numero:D6}";
        }
    }
}
