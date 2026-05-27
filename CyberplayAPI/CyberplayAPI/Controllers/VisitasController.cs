using CyberplayAPI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace CyberplayAPI.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class
        VisitasController
        : ControllerBase
    {
        // =====================
        // HEARTBEAT
        // =====================

        [HttpGet("heartbeat")]

        public IActionResult
            Heartbeat(
                [FromQuery]
                string id)
        {
            // =====================
            // VALIDAR
            // =====================

            if (string.IsNullOrWhiteSpace(
                id))
            {
                return BadRequest(
                    "ID inválido");
            }

            // =====================
            // REGISTRAR
            // =====================

            VisitantesService
                .RegistrarVisitante(
                    id);

            // =====================
            // OK
            // =====================

            return Ok(
                "OK");
        }

        // =====================
        // CANTIDAD
        // =====================

        [HttpGet("cantidad")]

        public int
            ObtenerCantidad()
        {
            return
                VisitantesService
                    .ObtenerCantidad();
        }
    }
}