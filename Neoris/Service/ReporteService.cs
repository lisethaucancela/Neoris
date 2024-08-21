using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Neoris.Data;
using Neoris.DTOs;

namespace Neoris.Service
{
    public class ReporteService: IReporteService
    {
        private readonly MiDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICuentasService _cuentaService;

        public ReporteService(MiDbContext context, IMapper mapper, ICuentasService cuentaService)
        {
            _context = context;
            _mapper = mapper;
            _cuentaService = cuentaService;
        }

        public async Task<List<ReporteCuentaDto>> GenerarReporteAsync(int clienteId, DateTime fechaInicio, DateTime fechaFin)
        {

            var cuentas = await _context.Cuentas
            .Where(c => c.ClienteId == clienteId)
            .Include(c => c.Movimientos)
            .ToListAsync();

            foreach (var cuenta in cuentas)
            {
                cuenta.Movimientos = cuenta.Movimientos
                    .Where(m => m.Fecha >= fechaInicio && m.Fecha <= fechaFin)
                    .ToList();
            }

            var reporte = cuentas.Select(c => new ReporteCuentaDto
            {
                NumeroCuenta = c.NumeroCuenta,
                Saldo = c.SaldoInicial,
                Movimientos = _mapper.Map<List<MovimientoDto>>(c.Movimientos)
            }).ToList();

            return reporte;
        }
    }
}
