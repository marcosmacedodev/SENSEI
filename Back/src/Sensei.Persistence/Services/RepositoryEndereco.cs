
using Microsoft.EntityFrameworkCore;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;
using Sensei.Persistence.DataContext;

namespace Sensei.Persistence.Services
{
    public class RepositoryEndereco : IRepositoryEndereco
    {
        private readonly Context _context;
        public RepositoryEndereco(Context context)
        {
            _context = context;
            
        }
        public async Task<Endereco> GetEnderecoById(int id)
        {
            IQueryable<Endereco> query = _context.Enderecos

            .Where(end => end.Id.Equals(id))
            .AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Endereco[]> GetEnderecos()
        {
            IQueryable<Endereco> query = _context.Enderecos

            .OrderBy(end => end.Id)
            .AsNoTracking();
            return await query.ToArrayAsync();
        }
    }
}