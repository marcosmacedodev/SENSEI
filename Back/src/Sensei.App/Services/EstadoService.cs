using AutoMapper;
using Sensei.App.Contracts;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IRepositoryEstado _repositoryEstado;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public EstadoService(IRepository repository, IRepositoryEstado repositoryEstado, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryEstado = repositoryEstado;
        }

        public async Task<EstadoDto> AddEstado(EstadoDto estadoDto)
        {
            try
            {
                Estado entity = _mapper.Map<Estado>(estadoDto);
                _repository.Add<Estado>(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryEstado.GetEstadoById(entity.Id);
                    return _mapper.Map<EstadoDto>(entity);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEstado(EstadoDto estadoDto)
        {
            try
            {
                Estado entity = _mapper.Map<Estado>(estadoDto);
                _repository.Delete<Estado>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EstadoDto> GetEstadoById(int id)
        {
            try
            {
                Estado entity = await _repositoryEstado.GetEstadoById(id);
                return _mapper.Map<EstadoDto>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EstadoDto[]> GetEstados()
        {
           try
           {
                Estado[] entities = await _repositoryEstado.GetEstados();
                return _mapper.Map<EstadoDto[]>(entities);
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<EstadoDto> SaveEstado(EstadoDto estadoDto)
        {
            try
            {
                Estado entity = _mapper.Map<Estado>(estadoDto);
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryEstado.GetEstadoById(entity.Id);
                    return _mapper.Map<EstadoDto>(entity);
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