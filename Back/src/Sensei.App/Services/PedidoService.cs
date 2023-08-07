using AutoMapper;
using Sensei.App.Contracts;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IRepositoryPedido _repositoryPedido;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public PedidoService(IRepository repository, IRepositoryPedido repositoryPedido, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryPedido = repositoryPedido;
        }

        public async Task<PedidoDto> AddPedido(PedidoDto pedidoDto)
        {
            try
            {
                Pedido entity = _mapper.Map<Pedido>(pedidoDto);
                _repository.Add<Pedido>(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryPedido.GetPedidoById(entity.Id, false);
                    return _mapper.Map<PedidoDto>(entity);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePedido(PedidoDto pedidoDto)
        {
            try
            {
                Pedido entity = _mapper.Map<Pedido>(pedidoDto);
                _repository.Delete<Pedido>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto> GetPedidoById(int id, bool includeProdutos)
        {
            try
            {
                Pedido entity = await _repositoryPedido.GetPedidoById(id, false);
                return _mapper.Map<PedidoDto>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto[]> GetPedidos(bool includeProdutos)
        {
           try
           {
                Pedido[] entities = await _repositoryPedido.GetPedidos(includeProdutos);
                return _mapper.Map<PedidoDto[]>(entities);
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<PedidoDto> SavePedido(PedidoDto pedidoDto)
        {
            try
            {
                Pedido entity = _mapper.Map<Pedido>(pedidoDto);
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryPedido.GetPedidoById(entity.Id, false);
                    return _mapper.Map<PedidoDto>(entity);
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