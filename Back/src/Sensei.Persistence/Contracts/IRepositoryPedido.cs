using Sensei.Domain.Models;

namespace Sensei.Persistence.Contracts
{
    public interface IRepositoryPedido
    {
        Task<Pedido> GetPedidoById(int id, bool includeProdutos);
        Task<Pedido []> GetPedidos(bool includeProdutos);
    }
}