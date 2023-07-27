using Microsoft.EntityFrameworkCore;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;
using Sensei.Persistence.DataContext;

namespace Sensei.Persistence.Services
{
    public class RepositoryCategoria : IRepositoryCategoria
    {
        private readonly Context _context;
        public RepositoryCategoria(Context context){
            _context = context;
        }
        public async Task<Categoria> GetCategoriaById(int id, bool includeProdutos)
        {
            IQueryable<Categoria> query = _context.Categorias
                .Where(cat => cat.Id.Equals(id))
                .OrderBy(cat => cat.Id).AsNoTracking();

            if(includeProdutos){
                query = query.Include(cat => cat.CategoriaProdutos).ThenInclude(cp => cp.Produto);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Categoria[]> GetCategorias(bool includeProdutos)
        {
            IQueryable<Categoria> query = _context.Categorias.OrderBy(cat => cat.Id).AsNoTracking();

            if(includeProdutos){
                query = query.Include(cat => cat.CategoriaProdutos).ThenInclude(cp => cp.Produto);
            }
            return await query.ToArrayAsync();
        }
    }
}