using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Models;

namespace Sensei.Persistence.Contracts
{
    public interface IRepositoryEndereco
    {
        Task<Endereco> GetEnderecoById(int id);
        Task<Endereco []> GetEnderecos();
    }
}