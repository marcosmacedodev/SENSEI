using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface IEnderecoService
    {
        Task<Endereco> GetEnderecoById(int id);
        Task<Endereco[]> GetEnderecos();
        Task<Endereco> AddEndereco(Endereco entity);
        Task<Endereco> SaveEndereco(Endereco entity);
        Task<bool> DeleteEndereco(Endereco entity);
    }
}