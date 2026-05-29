using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberplay.Helpers
{
    public class GestorBackups
    {

        private void EliminarBackupsAntiguos(
    string rutaBackups)
        {
            // =====================
            // NO EXISTE
            // =====================

            if (!Directory.Exists(
                rutaBackups))
            {
                return;
            }

            // =====================
            // OBTENER CARPETAS
            // =====================

            DirectoryInfo directorio =
                new DirectoryInfo(
                    rutaBackups);

            DirectoryInfo[] backups =
                directorio
                    .GetDirectories()
                    .OrderByDescending(
                        x => x.CreationTime)
                    .ToArray();

            // =====================
            // MENOS DE 10
            // =====================

            if (backups.Length <= 10)
            {
                return;
            }

            // =====================
            // ELIMINAR SOBRANTES
            // =====================

            for (int i = 10;
                 i < backups.Length;
                 i++)
            {
                try
                {
                    backups[i]
                        .Delete(
                            true);
                }
                catch
                {
                    // Ignorar errores
                    // para no interrumpir
                    // la creación del backup
                }
            }
        }
        public void CrearBackup()
        {
            if (!Directory.Exists(
    Rutas.Data))
            {
                MessageBox.Show(
                    "No existe la carpeta Data.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // =====================
            // NOMBRE BACKUP
            // =====================

            string nombreBackup =
                DateTime.Now
                    .ToString(
                        "yyyy-MM-dd_HH-mm-ss");

            // =====================
            // RUTAS DESTINO
            // =====================

            string rutaBackupProyecto =
                Path.Combine(
                    Rutas.Backups,
                    nombreBackup);

            string rutaBackupSistema =
                Path.Combine(
                    Rutas.BackupsSistema,
                    nombreBackup);

            // =====================
            // CREAR CARPETAS
            // =====================

            Directory.CreateDirectory(rutaBackupProyecto);

            Directory.CreateDirectory(rutaBackupSistema);

            // =====================
            // OBTENER ARCHIVOS DATA
            // =====================

            string[] archivos =
                Directory.GetFiles(
                    Rutas.Data);

            // =====================
            // COPIAR ARCHIVOS
            // =====================

            foreach (string archivo
                in archivos)
            {
                string nombreArchivo =
                    Path.GetFileName(
                        archivo);

                // =====================
                // DESTINO PROYECTO
                // =====================

                string destinoProyecto =
                    Path.Combine(
                        rutaBackupProyecto,
                        nombreArchivo);

                // =====================
                // DESTINO SISTEMA
                // =====================

                string destinoSistema =
                    Path.Combine(
                        rutaBackupSistema,
                        nombreArchivo);

                // =====================
                // COPIAR
                // =====================

                File.Copy(
                    archivo,
                    destinoProyecto,
                    true);

                File.Copy(
                    archivo,
                    destinoSistema,
                    true);
            }

            // =====================
            // LIMPIAR BACKUPS
            // =====================

            EliminarBackupsAntiguos(
                Rutas.Backups);

            EliminarBackupsAntiguos(
                Rutas.BackupsSistema);
        }
    }
}
