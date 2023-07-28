using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Models;

namespace Sensei.Persistence.Contracts
{
    public interface IRepositoryPagamento
    {
        Task<Pagamento> GetPagamentoById(int? id);
        Task<Pagamento []> GetPagamentos();
    }
}