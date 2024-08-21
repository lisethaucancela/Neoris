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
    public class CuentasController : ControllerBase
    {

        private readonly ICuentasService _cuentasService;
        private readonly IMapper _mapper;
        public CuentasController(ICuentasService cuentasService, IMapper mapper)
        {
            _cuentasService = cuentasService;
            _mapper = mapper;
        }

        // GET: api/Cuentas
        [HttpGet]
        public async Task<IEnumerable<CuentasDto>> GetCuentas()
        {  
            var cuentas = await _cuentasService.GetAllCuentasAsync();
            return _mapper.Map<IEnumerable<CuentasDto>>(cuentas);
        }

        // GET: api/Cuentas/5
        [HttpGet("{id}")]
        public async Task<CuentasDto> GetCuenta(string numCuenta)
        {
            var cuentas = await _cuentasService.GetCuentaByNumeroAsync(numCuenta);

            return _mapper.Map<CuentasDto>(cuentas);
        }

        // PUT: api/Cuentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuenta(CuentasDto cuentaDto)
        { 
            var cuenta = _mapper.Map<Cuenta>(cuentaDto); 
            var cuentas = await _cuentasService.UpdateCuentaAsync(cuenta);
             
            return Ok();
        }

        // POST: api/Cuentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CuentasDto>> PostCuenta(CuentasDto cuentaDto)
        {
            var cuenta = _mapper.Map<Cuenta>(cuentaDto);
            var createdcuenta = await _cuentasService.CreateCuentaAsync(cuenta);

            var createdCuentaDto = _mapper.Map<CuentasDto>(createdcuenta);

            return CreatedAtAction("GetCuenta", new { id = createdCuentaDto.NumeroCuenta }, createdCuentaDto);
        }

        // DELETE: api/Cuentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta(int id)
        {
            await _cuentasService.DeleteCuentaAsync(id);
            return Ok();
        }
         
    }
}
