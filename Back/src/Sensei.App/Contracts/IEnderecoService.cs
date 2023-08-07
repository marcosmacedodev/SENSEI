using Sensei.Domain.Dtos;

namespace Sensei.App.Contracts
{
    public interface IEnderecoService
    {
        Task<EnderecoDto> GetEnderecoById(int id);
        Task<EnderecoDto[]> GetEnderecos();
        Task<EnderecoDto> AddEndereco(EnderecoDto enderecoDto);
        Task<EnderecoDto> SaveEndereco(EnderecoDto enderecoDto);
        Task<bool> DeleteEndereco(EnderecoDto enderecoDto);
    }
}