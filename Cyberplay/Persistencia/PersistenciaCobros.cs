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
    public class PersistenciaCobros
    {
        private string ruta = Path.Combine(Rutas.Data, "cobros.json");

        public List<RegistroCobro>
    ObtenerCobros()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<RegistroCobro>());
        }
        public decimal ObtenerTotalCobrado()
        {
            decimal total = 0;

            // =====================
            // CARGAR COBROS
            // =====================

            List<RegistroCobro> cobros =
                CargarCobros();

            // =====================
            // SUMAR
            // =====================

            foreach (RegistroCobro cobro
                in cobros)
            {
                total +=
                    cobro.TotalCobrado;
            }

            return total;
        }

        public List<RegistroCobro>
    CargarCobros()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<RegistroCobro>());
        }
        public void GuardarCobro(
    RegistroCobro cobro)
        {
            List<RegistroCobro> cobros =
                CargarCobros();

            cobros.Add(cobro);

            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    cobros);
        }
    }
}
