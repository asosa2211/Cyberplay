using Cyberplay.Helpers;
using Cyberplay.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Persistencia
{
    public class PersistenciaEgresosCaja
    {
        private string ruta = Path.Combine(Rutas.Data, "egresosCaja.json");

        // =====================
        // GUARDAR
        // =====================

        public void GuardarEgresos(
            List<EgresoCaja> egresos)
        {
            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    egresos);
        }

        // =====================
        // CARGAR
        // =====================

        public List<EgresoCaja>
            CargarEgresos()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<EgresoCaja>());
        }
    }
}
