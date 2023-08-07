using AutoMapper;
using Sensei.App.Contracts;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IRepository _repository;
        private readonly IRepositoryCategoria _repositoryCategoria;
        private readonly IMapper _mapper;
        public CategoriaService(IRepository repository, IRepositoryCategoria repositoryCategoria, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryCategoria = repositoryCategoria;
            _repository = repository;
        }
        public async Task<CategoriaDto> AddCategoria(CategoriaDto categoriaDto)
        {
            try
            {
                Categoria entity = _mapper.Map<Categoria>(categoriaDto);
                _repository.Add<Categoria>(entity);
                if(await _repository.SaveChangesAsync())
                {
                    entity = await _repositoryCategoria.GetCategoriaById(entity.Id, false);
                    return _mapper.Map<CategoriaDto>(entity);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCategoria(CategoriaDto categoriaDto)
        {
            try
            {
                Categoria entity = _mapper.Map<Categoria>(categoriaDto);
                _repository.Delete<Categoria>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto> GetCategoriaById(int id, bool includeProdutos)
        {
            try
            {
                Categoria entity = await _repositoryCategoria.GetCategoriaById(id, includeProdutos);
                return _mapper.Map<CategoriaDto>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto[]> GetCategorias(bool includeProdutos)
        {
            try
            {
                Categoria[] entities = await _repositoryCategoria.GetCategorias(includeProdutos);
                return _mapper.Map<CategoriaDto[]>(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto> SaveCategoria(CategoriaDto categoriaDto)
        {
           try
           {
                Categoria entity = _mapper.Map<Categoria>(categoriaDto);
                _repository.Update<Categoria>(entity);
                if (await _repository.SaveChangesAsync()){
                    entity = await _repositoryCategoria.GetCategoriaById(entity.Id, false);
                    return _mapper.Map<CategoriaDto>(entity);
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