using AutoMapper;
using Sensei.App.Contracts;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;

namespace Sensei.App.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IRepositoryProduto _repositoryProduto;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public ProdutoService(IRepository repository, IRepositoryProduto repositoryProduto, IMapper mapper){
            _mapper = mapper;
            _repository = repository;
            _repositoryProduto = repositoryProduto;
        }

        public async Task<ProdutoDto> AddProduto(ProdutoDto produtoDto)
        {
            try
            {
                Produto entity = _mapper.Map<Produto>(produtoDto);
                _repository.Add<Produto>(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryProduto.GetProdutoById(entity.Id, true);
                    return _mapper.Map<ProdutoDto>(entity);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduto(ProdutoDto produtoDto)
        {
            try
            {
                Produto entity = _mapper.Map<Produto>(produtoDto);
                _repository.Delete<Produto>(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto> GetProdutoById(int id, bool includeCategorias)
        {
            try
            {
                Produto entity = await _repositoryProduto.GetProdutoById(id, includeCategorias);
                return _mapper.Map<ProdutoDto>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto[]> GetProdutos(bool includeCategorias)
        {
           try
           {
                Produto[] entities = await _repositoryProduto.GetProdutos(includeCategorias);
                return _mapper.Map<ProdutoDto[]>(entities);
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<ProdutoDto> SaveProduto(ProdutoDto produtoDto)
        {
            try
            {
                Produto entity = _mapper.Map<Produto>(produtoDto);
                _repository.Update(entity);
                if(await _repository.SaveChangesAsync()){
                    entity = await _repositoryProduto.GetProdutoById(entity.Id, true);
                    return _mapper.Map<ProdutoDto>(entity);
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