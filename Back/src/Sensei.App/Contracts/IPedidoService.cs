using Sensei.Domain.Dtos;

namespace Sensei.App.Contracts
{
    public interface IPedidoService
    {
        Task<PedidoDto> GetPedidoById(int id, bool includeProdutos);
        Task<PedidoDto[]> GetPedidos(bool includeProdutos);
        Task<PedidoDto> AddPedido(PedidoDto pedidoDto);
        Task<PedidoDto> SavePedido(PedidoDto pedidoDto);
        Task<bool> DeletePedido(PedidoDto pedidoDto);
    }
}