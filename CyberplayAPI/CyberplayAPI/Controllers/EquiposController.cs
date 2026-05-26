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

        public List<EquipoDTO>
    ObtenerEquipos()
        {
            // =====================
            // RUTA
            // =====================

            string ruta =
                @"C:\Users\Cyber\source\repos\asosa2211\Cyberplay\Cyberplay\bin\Debug\estado_web.json";

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

            string json =
                System.IO.File
                    .ReadAllText(
                        ruta);

            // =====================
            // DESERIALIZAR
            // =====================

            List<EquipoDTO>
                equipos =
                    JsonConvert
                        .DeserializeObject
                        <List<EquipoDTO>>
                        (json);

            if (equipos == null)
            {
                return
                    new List<EquipoDTO>();
            }

            return equipos;
        }

    }
}
