using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.App.Contracts;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository _repository;
        private readonly IRepositoryCliente _repositoryCliente;
        public ClienteService(IRepository repository, IRepositoryCliente repositoryCliente){
            _repositoryCliente = repositoryCliente;
            _repository = repository;
        }
        public async Task<Cliente> AddCliente(Cliente entity)
        {
            try
            {
                entity.Id = 0;
                _repository.Add<Cliente>(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryCliente.GetClienteById(entity.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCliente(Cliente entity)
        {
            try
            {
                _repository.Delete<Cliente>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            try
            {
                Cliente cliente = await _repositoryCliente.GetClienteById(id);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente[]> GetClientes()
        {
            try
            {
                Cliente[] clientes = await _repositoryCliente.GetClientes();
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> SaveCliente(Cliente entity)
        {
            try
            {
                _repository.Update<Cliente>(entity);
                if(await _repository.SaveChangesAsync()){
                    return await _repositoryCliente.GetClienteById(entity.Id);
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