using Neoris.DTOs;

namespace Neoris.Service
{
    public interface ICuentasService
    {

        Task<Cuenta> CreateCuentaAsync(Cuenta cuenta);
        Task<Cuenta> GetCuentaByNumeroAsync(string numCuenta);
        Task<IEnumerable<Cuenta>> GetAllCuentasAsync();
        Task<int> UpdateCuentaAsync(Cuenta Cuenta);
        Task DeleteCuentaAsync(int id);
    }
}
