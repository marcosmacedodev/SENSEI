using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.App.Contracts;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IRepository _repository;
        private readonly IRepositoryCategoria _repositoryCategoria;
        public CategoriaService(IRepository repository, IRepositoryCategoria repositoryCategoria)
        {
            _repositoryCategoria = repositoryCategoria;
            _repository = repository;
        }
        public async Task<Categoria> AddCategoria(Categoria entity)
        {
            try
            {
                entity.Id = 0;
                _repository.Add<Categoria>(entity);
                if(await _repository.SaveChangesAsync())
                {
                    return await GetCategoriaById(entity.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCategoria(Categoria entity)
        {
            try
            {
                _repository.Delete<Categoria>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Categoria> GetCategoriaById(int id, bool includeProdutos)
        {
            try
            {
                Categoria categoria = await _repositoryCategoria.GetCategoriaById(id, includeProdutos);
                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Categoria[]> GetCategorias(bool includeProdutos)
        {
            try
            {
                Categoria[] categorias = await _repositoryCategoria.GetCategorias(includeProdutos);
                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Categoria> SaveCategoria(Categoria entity)
        {
           try
           {
                _repository.Update<Categoria>(entity);
                if (await _repository.SaveChangesAsync()){
                    return await GetCategoriaById(entity.Id, false);
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