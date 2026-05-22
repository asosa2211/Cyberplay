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
    internal class PersistenciaIngresosCaja
    {
        private string ruta =
            "ingresosCaja.json";

        // =====================
        // GUARDAR
        // =====================

        public void GuardarIngresos(
            List<IngresoCaja> ingresos)
        {
            string json =
                JsonConvert.SerializeObject(
                    ingresos,
                    Formatting.Indented);

            File.WriteAllText(
                ruta,
                json);
        }

        // =====================
        // CARGAR
        // =====================

        public List<IngresoCaja>
            CargarIngresos()
        {
            if (!File.Exists(ruta))
            {
                return
                    new List<IngresoCaja>();
            }

            string json =
                File.ReadAllText(ruta);

            return JsonConvert
                .DeserializeObject<
                    List<IngresoCaja>>(
                        json)
                ??
                new List<IngresoCaja>();
        }
    }
}
