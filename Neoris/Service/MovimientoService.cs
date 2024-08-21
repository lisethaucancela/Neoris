using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Neoris.Data;
using Neoris.DTOs;

namespace Neoris.Service
{
    public class MovimientoService: IMovimientoService
    {
        private readonly MiDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICuentasService _cuentaService;

        public MovimientoService(MiDbContext context, IMapper mapper, ICuentasService cuentaService)
        {
            _context = context;
            _mapper = mapper;
            _cuentaService = cuentaService;
        }
        public async Task<string> RegistrarMovimientoAsync(Movimiento movimiento)
        {
            var cuenta = await _cuentaService.GetCuentaByNumeroAsync(movimiento.NumeroCuenta);
            if (cuenta == null)
            {
                return "Cuenta No encotrada";
            }

            if ( cuenta.SaldoInicial + movimiento.Valor < 0)
            {
                return "Saldo no disponible.";
            }
             
            movimiento.Fecha = DateTime.UtcNow;
            movimiento.Saldo = cuenta.SaldoInicial + movimiento.Valor;
            await _context.Movimientos.AddAsync(movimiento);

            cuenta.SaldoInicial += movimiento.Valor;
            await _cuentaService.UpdateCuentaAsync(cuenta);

            await _context.SaveChangesAsync();

            return "Movimiento registrado";
        }
        public async Task<Movimiento> GetMovimientoByIdAsync(int id) {
            var movimiento = await _context.Movimientos.FindAsync(id);
            return movimiento;
        }
        public async Task<IEnumerable<Movimiento>> GetAllMovimientosAsync() {

            return await _context.Movimientos.ToListAsync();
        }
        public async Task<int> UpdateMovimientoAsync(Movimiento movimiento)
        {
            _context.Entry(movimiento).State = EntityState.Modified;


           return await _context.SaveChangesAsync();
        }
            
        public async Task DeleteMovimientoAsync(int id) {
            var movimiento = await _context.Movimientos.FindAsync(id);
            _context.Movimientos.Remove(movimiento);
            await _context.SaveChangesAsync();
        }

        private bool MovimientoExists(int id)
        {
            return _context.Movimientos.Any(e => e.Id == id);
        }
    }
}
