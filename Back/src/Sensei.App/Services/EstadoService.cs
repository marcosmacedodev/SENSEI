using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.App.Contracts;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IRepositoryEstado _repositoryEstado;
        private readonly IRepository _repository;
        public EstadoService(IRepository repository, IRepositoryEstado repositoryEstado)
        {
            _repository = repository;
            _repositoryEstado = repositoryEstado;
        }

        public async Task<Estado> AddEstado(Estado entity)
        {
            try
            {
                entity.Id = 0;
                _repository.Add<Estado>(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryEstado.GetEstadoById(entity.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEstado(Estado entity)
        {
            try
            {
                _repository.Delete<Estado>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Estado> GetEstadoById(int id)
        {
            try
            {
                Estado estado = await _repositoryEstado.GetEstadoById(id);
                return estado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Estado[]> GetEstados()
        {
           try
           {
                Estado[] estados = await _repositoryEstado.GetEstados();
                return estados;
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<Estado> SaveEstado(Estado entity)
        {
            try
            {
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryEstado.GetEstadoById(entity.Id);
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