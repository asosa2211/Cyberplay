using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Cyberplay.Helpers
{
    public static class Sonidos
    {
        public static void Reproducir(
            string archivo)
        {
            string ruta =
                Path.Combine(
                    Rutas.Root,
                    "Sonidos",
                    archivo);

            if (!File.Exists(ruta))
            {
                return;
            }

            try
            {
                SoundPlayer player =
                    new SoundPlayer(ruta);

                player.Play();
            }
            catch
            {
            }
        }
    }
}
