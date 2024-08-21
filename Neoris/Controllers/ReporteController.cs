using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neoris.Service;

namespace Neoris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteService _reporteService;

        public ReporteController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet]
        public async Task<IActionResult> GenerarReporte([FromQuery] int clienteId, [FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                return BadRequest("La fecha inicio debe ser menor a la fecha fin.");
            }

            var reporte = await _reporteService.GenerarReporteAsync(clienteId, fechaInicio, fechaFin);

            if (reporte == null || !reporte.Any())
            {
                return NotFound("No se encontraron datos para el reporte.");
            }

            return Ok(reporte);
        }
    }
}
