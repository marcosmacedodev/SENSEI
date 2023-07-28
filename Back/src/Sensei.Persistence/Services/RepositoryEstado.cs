
using Microsoft.EntityFrameworkCore;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;
using Sensei.Persistence.DataContext;

namespace Sensei.Persistence.Services
{
    public class RepositoryEstado : IRepositoryEstado
    {
        private readonly Context _context;
        public RepositoryEstado(Context context)
        {
            _context = context;
            
        }
        public async Task<Estado> GetEstadoById(int id)
        {
            IQueryable<Estado> query = _context.Estados

            .Where(est => est.Id.Equals(id))
            .AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Estado[]> GetEstados()
        {
            IQueryable<Estado> query = _context.Estados

            .OrderBy(est => est.Id)
            .AsNoTracking();
            return await query.ToArrayAsync();
        }
    }
}