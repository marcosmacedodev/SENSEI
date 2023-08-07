
using Microsoft.EntityFrameworkCore;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;
using Sensei.Persistence.DataContext;

namespace Sensei.Persistence.Services
{
    public class RepositoryPagamento : IRepositoryPagamento
    {
        private readonly SenseiContext _context;
        public RepositoryPagamento(SenseiContext context)
        {
            _context = context;
        }
        public async Task<Pagamento> GetPagamentoById(int id)
        {
            IQueryable<Pagamento> query = _context.Pagamentos

            .Where(pag => pag.PedidoId.Equals(id))
            .AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pagamento[]> GetPagamentos()
        {
            IQueryable<Pagamento> query = _context.Pagamentos

            .OrderBy(pag => pag.PedidoId)
            .AsNoTracking();
            return await query.ToArrayAsync();
        }
    }
}