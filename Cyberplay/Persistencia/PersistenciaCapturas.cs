using Cyberplay.Helpers;
using Cyberplay.Modelos;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Cyberplay.Persistencia
{
    public class PersistenciaCapturas
    {
        private string ruta =
            Path.Combine(
                Rutas.Data,
                "capturaSistema.json");

        public void GuardarCaptura(
            CapturaSistema captura)
        {
            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    captura);
        }
    }
}
