using Sensei.Domain.Dtos;

namespace Sensei.App.Contracts
{
    public interface IEstadoService
    {
        Task<EstadoDto> GetEstadoById(int id);
        Task<EstadoDto[]> GetEstados();
        Task<EstadoDto> AddEstado(EstadoDto estadoDto);
        Task<EstadoDto> SaveEstado(EstadoDto estadoDto);
        Task<bool> DeleteEstado(EstadoDto estadoDto);
    }
}