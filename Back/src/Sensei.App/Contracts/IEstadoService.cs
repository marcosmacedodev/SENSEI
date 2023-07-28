using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface IEstadoService
    {
        Task<Estado> GetEstadoById(int id);
        Task<Estado[]> GetEstados();
        Task<Estado> AddEstado(Estado entity);
        Task<Estado> SaveEstado(Estado entity);
        Task<bool> DeleteEstado(Estado entity);
    }
}