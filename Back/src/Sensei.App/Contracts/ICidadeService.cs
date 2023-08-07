using Sensei.Domain.Dtos;

namespace Sensei.App.Contracts
{
    public interface ICidadeService
    {
        Task<CidadeDto> GetCidadeById(int id);
        Task<CidadeDto[]> GetCidades();
        Task<CidadeDto> AddCidade(CidadeDto cidadeDto);
        Task<CidadeDto> SaveCidade(CidadeDto cidadeDto);
        Task<bool> DeleteCidade(CidadeDto cidadeDto);
    }
}