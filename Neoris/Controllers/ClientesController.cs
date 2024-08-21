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
    public class ClientesController : ControllerBase
    { 
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClientesController(MiDbContext context, IClienteService clienteService, IMapper mapper)
        { 
            _clienteService = clienteService;
            _mapper = mapper;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IEnumerable<ClienteDto>> GetClientes()
        { 
            var clientes = await _clienteService.GetAllClientesAsync();
            return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {  

            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteDto = _mapper.Map<ClienteDto>(cliente);
            return Ok(clienteDto);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCliente(int id, ClienteDto clienteDto)
        { 

            var cliente = _mapper.Map<Cliente>(clienteDto);
            cliente.Id = id;  
            return Ok( await _clienteService.UpdateClienteAsync(cliente));

           
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(ClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest();
            }

            var cliente = _mapper.Map<Cliente>(clienteDto); 
             
            var createdCliente = await _clienteService.CreateClienteAsync(cliente);
             
            var createdClienteDto = _mapper.Map<ClienteDto>(createdCliente);

            return CreatedAtAction(nameof(GetCliente), new { id = createdClienteDto.Nombre }, createdClienteDto);

             
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            await _clienteService.DeleteClienteAsync(id);
           return Ok( );
        }

        
    }
}
