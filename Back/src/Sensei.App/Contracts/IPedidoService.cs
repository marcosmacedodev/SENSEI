using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface IPedidoService
    {
        Task<Pedido> GetPedidoById(int id, bool includeProdutos);
        Task<Pedido[]> GetPedidos(bool includeProdutos);
        Task<Pedido> AddPedido(Pedido entity);
        Task<Pedido> SavePedido(Pedido entity);
        Task<bool> DeletePedido(Pedido entity);
    }
}