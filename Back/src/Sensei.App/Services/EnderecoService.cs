using AutoMapper;
using Sensei.App.Contracts;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IRepositoryEndereco _repositoryEndereco;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public EnderecoService(IRepository repository, IRepositoryEndereco repositoryEndereco, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryEndereco = repositoryEndereco;
        }

        public async Task<EnderecoDto> AddEndereco(EnderecoDto enderecoDto)
        {
            try
            {
                Endereco entity = _mapper.Map<Endereco>(enderecoDto);
                _repository.Add<Endereco>(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryEndereco.GetEnderecoById(entity.Id);
                    return _mapper.Map<EnderecoDto>(entity);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEndereco(EnderecoDto enderecoDto)
        {
            try
            {
                Endereco entity = _mapper.Map<Endereco>(enderecoDto);
                _repository.Delete<Endereco>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EnderecoDto> GetEnderecoById(int id)
        {
            try
            {
                Endereco entity = await _repositoryEndereco.GetEnderecoById(id);
                return _mapper.Map<EnderecoDto>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EnderecoDto[]> GetEnderecos()
        {
           try
           {
                Endereco[] entities = await _repositoryEndereco.GetEnderecos();
                return _mapper.Map<EnderecoDto[]>(entities);
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<EnderecoDto> SaveEndereco(EnderecoDto enderecoDto)
        {
            try
            {
                Endereco entity = _mapper.Map<Endereco>(enderecoDto);
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryEndereco.GetEnderecoById(entity.Id);
                    return _mapper.Map<EnderecoDto>(entity);
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