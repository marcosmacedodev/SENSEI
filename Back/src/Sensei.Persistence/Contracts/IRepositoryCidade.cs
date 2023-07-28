
using Sensei.Domain.Models;

namespace Sensei.Persistence.Contracts
{
    public interface IRepositoryCidade
    {
        Task<Cidade> GetCidadeById(int id);
        Task<Cidade[]> GetCidades();
    }
}