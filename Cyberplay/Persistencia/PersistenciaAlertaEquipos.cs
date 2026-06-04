using Cyberplay.Helpers;
using Cyberplay.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Persistencia
{
    public class PersistenciaAlertasEquipos
    {
        private string ruta =
            Path.Combine(
                Rutas.Data,
                "alertasEquipos.json");

        public List<AlertaEquipo>
            CargarAlertas()
        {
            return PersistenciaJsonAtomica
                .Cargar(
                    ruta,
                    new List<AlertaEquipo>());
        }

        public void GuardarAlerta(
            AlertaEquipo alerta)
        {
            List<AlertaEquipo> alertas =
                CargarAlertas();

            alertas.Add(
                alerta);

            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    alertas);
        }
    }
}
