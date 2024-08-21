using Neoris.DTOs;

namespace Neoris.Service
{
    public interface IReporteService
    {
        Task<List<ReporteCuentaDto>> GenerarReporteAsync(int clienteId, DateTime fechaInicio, DateTime fechaFin);
    }
}
