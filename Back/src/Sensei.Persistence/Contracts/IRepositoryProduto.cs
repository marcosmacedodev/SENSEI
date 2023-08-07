using Sensei.Domain.Models;

namespace Sensei.Persistence.Contracts
{
    public interface IRepositoryProduto
    {
        Task<Produto> GetProdutoById(int id, bool includeCategorias);
        Task<Produto []> GetProdutos(bool includeCategorias);
    }
}