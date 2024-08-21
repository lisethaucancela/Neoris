using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neoris.DTOs;
using Neoris.Data;
using AutoMapper;
using Neoris.Service;

namespace Neoris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;
        private readonly IMapper _mapper;

        public MovimientosController(IMovimientoService movimientoService, IMapper mapper)
        {
            _movimientoService = movimientoService;
            _mapper = mapper;
        }

        // GET: api/Movimientos
        [HttpGet]
        public async Task<IEnumerable<MovimientoDto>> GetMovimientos()
        { 
            var movimientos = await _movimientoService.GetAllMovimientosAsync();
            return _mapper.Map<IEnumerable<MovimientoDto>>(movimientos);
        }

        // GET: api/Movimientos/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<MovimientoDto>> GetMovimiento(int id)
        {
            var movimientos = await _movimientoService.GetMovimientoByIdAsync(id);
            if (movimientos == null)
            { 
                return Enumerable.Empty<MovimientoDto>(); 
            }

            return _mapper.Map<IEnumerable<MovimientoDto>>(movimientos);
        }

        // PUT: api/Movimientos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimiento(MovimientoDto movimientoDto)
        {
            var movimiento = _mapper.Map<Movimiento>(movimientoDto);
            var mov = await _movimientoService.UpdateMovimientoAsync(movimiento);

            return Ok(mov);
        }

        // POST: api/Movimientos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovimientoDto>> PostMovimiento(MovimientoDto movimientoDto)
        {
            var movimiento = _mapper.Map<Movimiento>(movimientoDto);
            var createdMovimiento = await _movimientoService.RegistrarMovimientoAsync(movimiento);
           

            return CreatedAtAction("GetMovimiento", new { id = movimiento.Id }, createdMovimiento);
        }

        // DELETE: api/Movimientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimiento(int id)
        { 
            await _movimientoService.DeleteMovimientoAsync(id);

            return Ok();
        }

       
    }
}
