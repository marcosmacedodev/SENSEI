
using Microsoft.EntityFrameworkCore;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;
using Sensei.Persistence.DataContext;

namespace Sensei.Persistence.Services
{
    public class RepositoryCidade : IRepositoryCidade
    {
        private readonly SenseiContext _context;
        public RepositoryCidade(SenseiContext context)
        {
            _context = context;
        }
        public async Task<Cidade> GetCidadeById(int id)
        {
            IQueryable<Cidade> query = _context.Cidades

            .Where(cid => cid.Id.Equals(id))
            .AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cidade[]> GetCidades()
        {
            IQueryable<Cidade> query = _context.Cidades

            .OrderBy(cid => cid.Id)
            .AsNoTracking();
            return await query.ToArrayAsync();
        }
    }
}