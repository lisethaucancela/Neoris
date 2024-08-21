using Neoris.DTOs;

namespace Neoris.Service
{
    public interface IMovimientoService
    {

        Task<string> RegistrarMovimientoAsync(Movimiento movimiento);
        Task<Movimiento> GetMovimientoByIdAsync(int id);
        Task<IEnumerable<Movimiento>> GetAllMovimientosAsync();
        Task<int> UpdateMovimientoAsync(Movimiento Movimiento);
        Task DeleteMovimientoAsync(int id);
    }
}
