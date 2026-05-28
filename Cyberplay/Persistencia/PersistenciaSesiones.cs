using Cyberplay.Helpers;
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
            string json =
                JsonConvert.SerializeObject(
                    sesiones);

            File.WriteAllText(
                ruta,
                json);
        }

        // =====================
        // CARGAR
        // =====================

        public List<EstadoSesion>
            Cargar()
        {
            if (!File.Exists(ruta))
            {
                return new List<EstadoSesion>();
            }

            string json =
                File.ReadAllText(ruta);

            return JsonConvert
                .DeserializeObject<
                    List<EstadoSesion>>(
                        json);
        }
    }
}
