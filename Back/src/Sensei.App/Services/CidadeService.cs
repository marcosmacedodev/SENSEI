using AutoMapper;
using Sensei.App.Contracts;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly IRepositoryCidade _repositoryCidade;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CidadeService(IRepository repository, IRepositoryCidade repositoryCidade, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryCidade = repositoryCidade;
        }

        public async Task<CidadeDto> AddCidade(CidadeDto cidadeDto)
        {
            try
            {
                Cidade entity = _mapper.Map<Cidade>(cidadeDto);
                _repository.Add<Cidade>(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryCidade.GetCidadeById(entity.Id);
                    return _mapper.Map<CidadeDto>(entity);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCidade(CidadeDto cidadeDto)
        {
            try
            {
                Cidade entity = _mapper.Map<Cidade>(cidadeDto);
                _repository.Delete<Cidade>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CidadeDto> GetCidadeById(int id)
        {
            try
            {
                Cidade entity = await _repositoryCidade.GetCidadeById(id);
                return _mapper.Map<CidadeDto>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CidadeDto[]> GetCidades()
        {
           try
           {
                Cidade[] entities = await _repositoryCidade.GetCidades();
                return _mapper.Map<CidadeDto[]>(entities);
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<CidadeDto> SaveCidade(CidadeDto cidadeDto)
        {
            try
            {
                Cidade entity = _mapper.Map<Cidade>(cidadeDto);
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryCidade.GetCidadeById(entity.Id);
                    return _mapper.Map<CidadeDto>(entity);
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