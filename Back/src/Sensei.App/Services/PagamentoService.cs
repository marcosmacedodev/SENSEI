using AutoMapper;
using Sensei.App.Contracts;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IRepositoryPagamento _repositoryPagamento;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public PagamentoService(IRepository repository, IRepositoryPagamento repositoryPagamento, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryPagamento = repositoryPagamento;
        }

        public async Task<PagamentoDto> AddPagamento(PagamentoDto pagamentoDto)
        {
            try
            {
                Pagamento entity = _mapper.Map<Pagamento>(pagamentoDto);
                _repository.Add<Pagamento>(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryPagamento.GetPagamentoById(entity.PedidoId);
                    return _mapper.Map<PagamentoDto>(entity);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePagamento(PagamentoDto pagamentoDto)
        {
            try
            {
                Pagamento entity = _mapper.Map<Pagamento>(pagamentoDto);
                _repository.Delete<Pagamento>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PagamentoDto> GetPagamentoById(int id)
        {
            try
            {
                Pagamento entity = await _repositoryPagamento.GetPagamentoById(id);
                return _mapper.Map<PagamentoDto>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PagamentoDto[]> GetPagamentos()
        {
           try
           {
                Pagamento[] entities = await _repositoryPagamento.GetPagamentos();
                return _mapper.Map<PagamentoDto[]>(entities);
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<PagamentoDto> SavePagamento(PagamentoDto pagamentoDto)
        {
            try
            {
                Pagamento entity = _mapper.Map<Pagamento>(pagamentoDto);
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryPagamento.GetPagamentoById(entity.PedidoId);
                    return _mapper.Map<PagamentoDto>(entity);
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