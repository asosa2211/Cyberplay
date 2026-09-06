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
    public class PersistenciaUsuarios
    {
        private string ruta = Path.Combine(Rutas.Data, "usuarios.json");


        public List<Usuario>
    CargarUsuarios()
        {
            List<Usuario> usuarios =
                CargarDesdeArchivo(
                    ruta);

            if (TieneUsuarios(
                usuarios))
            {
                return usuarios;
            }

            List<Usuario> respaldo =
                CargarDesdeArchivo(
                    ruta + ".bak");

            if (TieneUsuarios(
                respaldo))
            {
                return respaldo;
            }

            List<Usuario> respaldoHistorico =
                CargarDesdeBackups();

            if (TieneUsuarios(
                respaldoHistorico))
            {
                return respaldoHistorico;
            }

            return usuarios
                ?? new List<Usuario>();
        }
        public void GuardarUsuarios(
    List<Usuario> usuarios)
        {
            if (usuarios == null)
            {
                return;
            }

            List<Usuario> ordenados =
                usuarios
                .OrderBy(
                    u =>
                    u.NombreCuenta,
                    StringComparer.CurrentCultureIgnoreCase)
                .ToList();

            if (ordenados.Count == 0
                && ExisteRespaldoConUsuarios())
            {
                return;
            }

            PersistenciaJsonAtomica
                .Guardar(
                    ruta,
                    ordenados);
        }

        private List<Usuario> CargarDesdeArchivo(
            string rutaArchivo)
        {
            try
            {
                if (!File.Exists(
                    rutaArchivo))
                {
                    return null;
                }

                string json =
                    File.ReadAllText(
                        rutaArchivo);

                return JsonConvert
                    .DeserializeObject<List<Usuario>>(
                        json);
            }
            catch
            {
                return null;
            }
        }

        private List<Usuario> CargarDesdeBackups()
        {
            List<string> archivos =
                ObtenerArchivosBackupUsuarios();

            foreach (string archivo
                in archivos)
            {
                List<Usuario> usuarios =
                    CargarDesdeArchivo(
                        archivo);

                if (TieneUsuarios(
                    usuarios))
                {
                    return usuarios;
                }
            }

            return null;
        }

        private List<string> ObtenerArchivosBackupUsuarios()
        {
            List<string> archivos =
                new List<string>();

            AgregarArchivosBackup(
                archivos,
                Rutas.Backups);

            AgregarArchivosBackup(
                archivos,
                Rutas.BackupsSistema);

            return archivos
                .Distinct(
                    StringComparer.OrdinalIgnoreCase)
                .OrderByDescending(
                    x =>
                    File.GetLastWriteTime(
                        x))
                .ToList();
        }

        private void AgregarArchivosBackup(
            List<string> archivos,
            string rutaBackups)
        {
            try
            {
                if (!Directory.Exists(
                    rutaBackups))
                {
                    return;
                }

                foreach (string archivo
                    in Directory.GetFiles(
                        rutaBackups,
                        "usuarios.json",
                        SearchOption.AllDirectories))
                {
                    archivos.Add(
                        archivo);
                }
            }
            catch
            {

            }
        }

        private bool ExisteRespaldoConUsuarios()
        {
            if (TieneUsuarios(
                CargarDesdeArchivo(
                    ruta)))
            {
                return true;
            }

            if (TieneUsuarios(
                CargarDesdeArchivo(
                    ruta + ".bak")))
            {
                return true;
            }

            return TieneUsuarios(
                CargarDesdeBackups());
        }

        private bool TieneUsuarios(
            List<Usuario> usuarios)
        {
            return usuarios != null
                && usuarios.Any(
                    u =>
                    u != null
                    &&
                    !string.IsNullOrWhiteSpace(
                        u.NombreCuenta));
        }
    }
}
