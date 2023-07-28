using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface ICidadeService
    {
        Task<Cidade> GetCidadeById(int id);
        Task<Cidade[]> GetCidades();
        Task<Cidade> AddCidade(Cidade entity);
        Task<Cidade> SaveCidade(Cidade entity);
        Task<bool> DeleteCidade(Cidade entity);
    }
}