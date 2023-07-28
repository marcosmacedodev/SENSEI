using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface IPagamentoService
    {
        Task<Pagamento> GetPagamentoById(int id);
        Task<Pagamento[]> GetPagamentos();
        Task<Pagamento> AddPagamento(Pagamento entity);
        Task<Pagamento> SavePagamento(Pagamento entity);
        Task<bool> DeletePagamento(Pagamento entity);
    }
}