
using Sensei.Domain.Models;

namespace Sensei.Persistence.Contracts
{
    public interface IRepositoryEstado
    {
        Task<Estado> GetEstadoById(int id);
        Task<Estado[]> GetEstados();
    }
}