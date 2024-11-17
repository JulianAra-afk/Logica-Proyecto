
using Microsoft.AspNetCore.Mvc;
using ServicioAdministracionSedes.Messages;
using ServicioAdministracionSedes.Services;


namespace ServicioAdministracionSedes.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class SedesController : ControllerBase
    {
        private readonly SedesService _sedesService;

        public SedesController(SedesService sedesService)
        {
            _sedesService = sedesService;
        }

        [HttpPost]
        public IActionResult CrearSede([FromBody] SedeMessage nuevaSede)
        {
            _sedesService.CrearSede(nuevaSede);
            return Ok("Sede creada exitosamente.");
        }

        [HttpPut("{id}")]
        public IActionResult ModificarSede(int id, [FromBody] SedeMessage sedeModificada)
        {
            sedeModificada.Id = id;
            _sedesService.ModificarSede(sedeModificada);
            return Ok("Sede modificada exitosamente.");
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerSedePorId(int id)
        {
            _sedesService.ObtenerSedePorId(id);
            return Ok("Consulta de sede enviada.");
        }
    }


}