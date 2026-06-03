using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Cyberplay.Persistencia
{
    public static class PersistenciaJsonAtomica
    {
        public static void Guardar<T>(
            string ruta,
            T datos)
        {
            Directory.CreateDirectory(
                Path.GetDirectoryName(
                    ruta));

            string temporal =
                ruta + ".tmp";

            string backup =
                ruta + ".bak";

            string json =
                JsonConvert.SerializeObject(
                    datos,
                    Formatting.Indented);

            File.WriteAllText(
                temporal,
                json);

            JsonConvert.DeserializeObject<T>(
                File.ReadAllText(
                    temporal));

            if (File.Exists(ruta))
            {
                File.Copy(
                    ruta,
                    backup,
                    true);
            }

            if (File.Exists(ruta))
            {
                File.Delete(
                    ruta);
            }

            File.Move(
                temporal,
                ruta);
        }

        public static T Cargar<T>(
            string ruta,
            T valorPorDefecto)
        {
            T datos =
                CargarDesdeArchivo(
                    ruta,
                    default(T));

            if (!EqualityComparer<T>
                .Default
                .Equals(
                    datos,
                    default(T)))
            {
                return datos;
            }

            datos =
                CargarDesdeArchivo(
                    ruta + ".bak",
                    default(T));

            if (!EqualityComparer<T>
                .Default
                .Equals(
                    datos,
                    default(T)))
            {
                return datos;
            }

            return valorPorDefecto;
        }

        private static T CargarDesdeArchivo<T>(
            string ruta,
            T valorPorDefecto)
        {
            try
            {
                if (!File.Exists(ruta))
                {
                    return valorPorDefecto;
                }

                string json =
                    File.ReadAllText(
                        ruta);

                T datos =
                    JsonConvert.DeserializeObject<T>(
                        json);

                return datos == null
                    ? valorPorDefecto
                    : datos;
            }
            catch
            {
                return valorPorDefecto;
            }
        }
    }
}
