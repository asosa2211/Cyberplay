using Cyberplay.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cyberplay.Persistencia
{
    public class PersistenciaEgresosCaja
    {
        private string ruta =
            "egresosCaja.json";

        // =====================
        // GUARDAR
        // =====================

        public void GuardarEgresos(
            List<EgresoCaja> egresos)
        {
            string json =
                JsonConvert.SerializeObject(
                    egresos,
                    Formatting.Indented);

            File.WriteAllText(
                ruta,
                json);
        }

        // =====================
        // CARGAR
        // =====================

        public List<EgresoCaja>
            CargarEgresos()
        {
            if (!File.Exists(ruta))
            {
                return
                    new List<EgresoCaja>();
            }

            string json =
                File.ReadAllText(ruta);

            return JsonConvert
                .DeserializeObject<
                    List<EgresoCaja>>(
                        json)
                ??
                new List<EgresoCaja>();
        }
    }
}
