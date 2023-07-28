using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.App.Contracts;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IRepositoryEndereco _repositoryEndereco;
        private readonly IRepository _repository;
        public EnderecoService(IRepository repository, IRepositoryEndereco repositoryEndereco)
        {
            _repository = repository;
            _repositoryEndereco = repositoryEndereco;
        }

        public async Task<Endereco> AddEndereco(Endereco entity)
        {
            try
            {
                entity.Id = 0;
                _repository.Add<Endereco>(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryEndereco.GetEnderecoById(entity.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEndereco(Endereco entity)
        {
            try
            {
                _repository.Delete<Endereco>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Endereco> GetEnderecoById(int id)
        {
            try
            {
                Endereco endereco = await _repositoryEndereco.GetEnderecoById(id);
                return endereco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Endereco[]> GetEnderecos()
        {
           try
           {
                Endereco[] enderecos = await _repositoryEndereco.GetEnderecos();
                return enderecos;
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<Endereco> SaveEndereco(Endereco entity)
        {
            try
            {
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryEndereco.GetEnderecoById(entity.Id);
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