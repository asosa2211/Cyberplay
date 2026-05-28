using CyberplayAPI.Helpers;
using CyberplayAPI.Modelos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;

namespace CyberplayAPI.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class EquiposController
        : ControllerBase
    {
        [HttpGet]

        public List<EquipoDTO>  ObtenerEquipos()
        {
            // =====================
            // RUTA
            // =====================

            string ruta = Path.Combine(Rutas.Data, "estado_web.json");

            // =====================
            // VALIDAR
            // =====================

            if (!System.IO.File.Exists(
    ruta))
            {
                return
                    new List<EquipoDTO>();
            }

            // =====================
            // JSON
            // =====================

            string json;

            using (FileStream stream =
                new FileStream(
                    ruta,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite))
            {
                using (StreamReader reader =
                    new StreamReader(stream))
                {
                    json =
                        reader.ReadToEnd();
                }
            }

            // =====================
            // DESERIALIZAR
            // =====================

            List<EquipoDTO>
equipos =
    JsonConvert
        .DeserializeObject
        <List<EquipoDTO>>
        (json)

    ?? new List<EquipoDTO>();

            if (equipos == null)
            {
                return
                    new List<EquipoDTO>();
            }

            return equipos;
        }

    }
}
