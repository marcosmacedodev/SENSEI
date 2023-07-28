using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.App.Contracts;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IRepositoryPedido _repositoryPedido;
        private readonly IRepository _repository;
        public PedidoService(IRepository repository, IRepositoryPedido repositoryPedido)
        {
            _repository = repository;
            _repositoryPedido = repositoryPedido;
        }

        public async Task<Pedido> AddPedido(Pedido entity)
        {
            try
            {
                entity.Id = 0;
                _repository.Add<Pedido>(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryPedido.GetPedidoById(entity.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePedido(Pedido entity)
        {
            try
            {
                _repository.Delete<Pedido>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido> GetPedidoById(int id, bool includeProdutos)
        {
            try
            {
                Pedido Pedido = await _repositoryPedido.GetPedidoById(id, false);
                return Pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido[]> GetPedidos(bool includeProdutos)
        {
           try
           {
                Pedido[] Pedidos = await _repositoryPedido.GetPedidos(includeProdutos);
                return Pedidos;
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<Pedido> SavePedido(Pedido entity)
        {
            try
            {
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryPedido.GetPedidoById(entity.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }
    }
}