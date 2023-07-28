using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.App.Contracts;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IRepositoryPagamento _repositoryPagamento;
        private readonly IRepository _repository;
        public PagamentoService(IRepository repository, IRepositoryPagamento repositoryPagamento)
        {
            _repository = repository;
            _repositoryPagamento = repositoryPagamento;
        }

        public async Task<Pagamento> AddPagamento(Pagamento entity)
        {
            try
            {
                entity.Id = 0;
                _repository.Add<Pagamento>(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryPagamento.GetPagamentoById(entity.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePagamento(Pagamento entity)
        {
            try
            {
                _repository.Delete<Pagamento>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pagamento> GetPagamentoById(int id)
        {
            try
            {
                Pagamento pagamento = await _repositoryPagamento.GetPagamentoById(id);
                return pagamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pagamento[]> GetPagamentos()
        {
           try
           {
                Pagamento[] pagamentos = await _repositoryPagamento.GetPagamentos();
                return pagamentos;
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<Pagamento> SavePagamento(Pagamento entity)
        {
            try
            {
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryPagamento.GetPagamentoById(entity.Id);
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