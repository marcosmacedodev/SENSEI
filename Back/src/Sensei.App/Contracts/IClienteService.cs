using Sensei.Domain.Dtos;

namespace Sensei.App.Contracts
{
    public interface IClienteService
    {
        Task<ClienteDto[]> GetClientes();
        Task<ClienteDto> GetClienteById(int id);
        Task<ClienteDto> AddCliente(ClienteDto clienteDto);
        Task<ClienteDto> SaveCliente(ClienteDto clienteDto);
        Task<bool> DeleteCliente(ClienteDto clienteDto);
    }
}