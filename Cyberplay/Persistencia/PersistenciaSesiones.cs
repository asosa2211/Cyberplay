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
            Directory.CreateDirectory(
                Path.GetDirectoryName(
                    ruta));

            string rutaTemporal =
                ruta + ".tmp";

            string rutaBackup =
                ruta + ".bak";

            string json =
                JsonConvert.SerializeObject(
                    sesiones,
                    Formatting.Indented);

            File.WriteAllText(
                rutaTemporal,
                json);

            JsonConvert.DeserializeObject
                <List<EstadoSesion>>(
                    File.ReadAllText(
                        rutaTemporal));

            if (File.Exists(ruta))
            {
                File.Copy(
                    ruta,
                    rutaBackup,
                    true);
            }

            if (File.Exists(ruta))
            {
                File.Delete(
                    ruta);
            }

            File.Move(
                rutaTemporal,
                ruta);
        }

        // =====================
        // CARGAR
        // =====================

        public List<EstadoSesion>
            Cargar()
        {
            List<EstadoSesion> sesiones =
                CargarDesdeArchivo(
                    ruta);

            if (sesiones != null)
            {
                return sesiones;
            }

            sesiones =
                CargarDesdeArchivo(
                    ruta + ".bak");

            return sesiones
                ?? new List<EstadoSesion>();
        }

        private List<EstadoSesion> CargarDesdeArchivo(
            string archivo)
        {
            try
            {
                if (!File.Exists(archivo))
                {
                    return null;
                }

                string json =
                    File.ReadAllText(
                        archivo);

                return JsonConvert
                    .DeserializeObject<
                        List<EstadoSesion>>(
                            json)
                    ?? new List<EstadoSesion>();
            }
            catch
            {
                return null;
            }
        }
    }
}
