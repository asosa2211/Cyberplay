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
    internal class PersistenciaIngresosCaja
    {
        private string ruta = Path.Combine(Rutas.Data, "ingresosCaja.json");

        // =====================
        // GUARDAR
        // =====================

        public void GuardarIngresos(
            List<IngresoCaja> ingresos)
        {
            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    ingresos);
        }

        // =====================
        // CARGAR
        // =====================

        public List<IngresoCaja>
            CargarIngresos()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<IngresoCaja>());
        }
    }
}
