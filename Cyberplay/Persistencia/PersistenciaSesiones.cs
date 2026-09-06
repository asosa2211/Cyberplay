using Cyberplay.Helpers;
using Cyberplay.Persistencia;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay
{
    public class PersistenciaSesiones
    {
        private string ruta = Path.Combine(Rutas.Data, "sesiones.json");

        // =====================
        // GUARDAR
        // =====================

        public void Guardar(
            List<EstadoSesion>
                sesiones)
        {
            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    sesiones);
        }

        // =====================
        // CARGAR
        // =====================

        public List<EstadoSesion>
            Cargar()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<EstadoSesion>());
        }
    }
}
