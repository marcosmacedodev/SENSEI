using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface IClienteService
    {
        Task<Cliente[]> GetClientes();
        Task<Cliente> GetClienteById(int id);
        Task<Cliente> AddCliente(Cliente entity);
        Task<Cliente> SaveCliente(Cliente entity);
        Task<bool> DeleteCliente(Cliente entity);
    }
}