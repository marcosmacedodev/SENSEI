using AutoMapper;
using Sensei.App.Contracts;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository _repository;
        private readonly IRepositoryCliente _repositoryCliente;
        private readonly IMapper _mapper;
        public ClienteService(IRepository repository, IRepositoryCliente repositoryCliente, IMapper mapper){
            _mapper = mapper;
            _repositoryCliente = repositoryCliente;
            _repository = repository;
        }
        public async Task<ClienteDto> AddCliente(ClienteDto clienteDto)
        {
            try
            {
                Cliente entity = _mapper.Map<Cliente>(clienteDto);
                _repository.Add<Cliente>(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryCliente.GetClienteById(entity.Id);
                    return _mapper.Map<ClienteDto>(entity);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCliente(ClienteDto clienteDto)
        {
            try
            {
                Cliente entity = _mapper.Map<Cliente>(clienteDto);
                _repository.Delete<Cliente>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDto> GetClienteById(int id)
        {
            try
            {
                Cliente entity = await _repositoryCliente.GetClienteById(id);
                return _mapper.Map<ClienteDto>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDto[]> GetClientes()
        {
            try
            {
                Cliente[] entities = await _repositoryCliente.GetClientes();
                return _mapper.Map<ClienteDto[]>(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDto> SaveCliente(ClienteDto clienteDto)
        {
            try
            {
                Cliente entity = _mapper.Map<Cliente>(clienteDto);
                _repository.Update<Cliente>(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryCliente.GetClienteById(entity.Id);
                    return _mapper.Map<ClienteDto>(entity);
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