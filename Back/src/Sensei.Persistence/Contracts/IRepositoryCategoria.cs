using Sensei.Domain.Models;

namespace Sensei.Persistence.Contracts
{
    public interface IRepositoryCategoria
    {
        Task<Categoria> GetCategoriaById(int id, bool includeProdutos);
        Task<Categoria []> GetCategorias(bool includeProdutos);
    }
}