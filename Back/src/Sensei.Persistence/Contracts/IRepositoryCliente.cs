
using Sensei.Domain.Models;

namespace Sensei.Persistence.Contracts
{
    public interface IRepositoryCliente
    {
        Task<Cliente> GetClienteById(int id);
        Task<Cliente[]> GetClientes();
    }
}