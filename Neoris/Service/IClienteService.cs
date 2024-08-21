using Neoris.DTOs;

namespace Neoris.Service
{
    public interface IClienteService
    {
        Task<Cliente> CreateClienteAsync(Cliente clienteDto);
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<int> UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);

    }
}
