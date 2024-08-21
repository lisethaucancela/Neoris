using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Neoris.Data;
using Neoris.DTOs;

namespace Neoris.Service
{
    public class CuentasServicecs :ICuentasService
    {
        private readonly MiDbContext _context;
        private readonly IMapper _mapper;

        public CuentasServicecs(MiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Cuenta> CreateCuentaAsync(Cuenta cuenta)
        {
            _context.Cuentas.Add(cuenta);
            
              await _context.SaveChangesAsync();

            return cuenta;
        }


        public async Task<Cuenta> GetCuentaByNumeroAsync(string numCuenta)
        {
            var cuenta = await _context.Cuentas.FindAsync(numCuenta);
            return cuenta;
        }
        public async Task<IEnumerable<Cuenta>> GetAllCuentasAsync()
        {
            return await _context.Cuentas.ToListAsync();
        }
        public async Task<int> UpdateCuentaAsync(Cuenta cuenta)
        {
            _context.Entry(cuenta).State = EntityState.Modified;

             
            return    await _context.SaveChangesAsync();
            
        }
        public async Task DeleteCuentaAsync(int id)
        {
            var cuenta = await _context.Cuentas.FindAsync(id);
            if (cuenta != null)
            {
                _context.Cuentas.Remove(cuenta);
                await _context.SaveChangesAsync();
            }

            
        }

        private bool CuentaExists(string id)
        {
            return _context.Cuentas.Any(e => e.NumeroCuenta == id);
        }
    }
}
