using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.App.Contracts;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly IRepositoryCidade _repositoryCidade;
        private readonly IRepository _repository;
        public CidadeService(IRepository repository, IRepositoryCidade repositoryCidade)
        {
            _repository = repository;
            _repositoryCidade = repositoryCidade;
        }

        public async Task<Cidade> AddCidade(Cidade entity)
        {
            try
            {
                entity.Id = 0;
                _repository.Add<Cidade>(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryCidade.GetCidadeById(entity.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCidade(Cidade entity)
        {
            try
            {
                _repository.Delete<Cidade>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cidade> GetCidadeById(int id)
        {
            try
            {
                Cidade cidade = await _repositoryCidade.GetCidadeById(id);
                return cidade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cidade[]> GetCidades()
        {
           try
           {
                Cidade[] cidades = await _repositoryCidade.GetCidades();
                return cidades;
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<Cidade> SaveCidade(Cidade entity)
        {
            try
            {
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryCidade.GetCidadeById(entity.Id);
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