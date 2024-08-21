using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neoris.Data;
using Neoris.DTOs;

namespace Neoris.Service
{
    public class ClienteService : IClienteService
    {
        private readonly MiDbContext _context;
        private readonly IMapper _mapper;

        public ClienteService(MiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            cliente.Estado = true;
             
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
             
            return cliente; 
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
         
        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<int> UpdateClienteAsync(Cliente cliente)
        {
            cliente.Discriminator = "C";
            _context.Clientes.Update(cliente);
           return await _context.SaveChangesAsync();

             
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
