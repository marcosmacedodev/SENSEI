using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.App.Contracts;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IRepositoryProduto _repositoryProduto;
        private readonly IRepository _repository;
        public ProdutoService(IRepository repository, IRepositoryProduto repositoryProduto){
            _repository = repository;
            _repositoryProduto = repositoryProduto;
        }

        public async Task<Produto> AddProduto(Produto entity)
        {
            try
            {
                entity.Id = 0;
                _repository.Add<Produto>(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryProduto.GetProdutoById(entity.Id, true);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduto(Produto entity)
        {
            try
            {
                _repository.Delete<Produto>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> GetProdutoById(int id, bool includeCategorias)
        {
            try
            {
                Produto produto = await _repositoryProduto.GetProdutoById(id, includeCategorias);
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto[]> GetProdutos(bool includeCategorias)
        {
           try
           {
                Produto[] produtos = await _repositoryProduto.GetProdutos(includeCategorias);
                return produtos;
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<Produto> SaveProduto(Produto entity)
        {
            try
            {
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryProduto.GetProdutoById(entity.Id, true);
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