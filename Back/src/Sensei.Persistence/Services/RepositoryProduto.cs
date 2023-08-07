using Microsoft.EntityFrameworkCore;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;
using Sensei.Persistence.DataContext;

namespace Sensei.Persistence.Services
{
    public class RepositoryProduto : IRepositoryProduto
    {
        private readonly SenseiContext _context;
        public RepositoryProduto(SenseiContext context){
            _context = context;
        }
        public async Task<Produto> GetProdutoById(int id, bool includeCategorias)
        {
            IQueryable<Produto> query = _context.Produtos
                                        .Where(prod => prod.Id.Equals(id))
                                        .AsNoTracking();
            if(includeCategorias){
                query = query.Include(prod => prod.CategoriaProdutos).ThenInclude(cp => cp.Categoria);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Produto[]> GetProdutos(bool includeCategorias)
        {
            IQueryable<Produto> query = _context.Produtos
                                        .OrderBy(prod => prod.Id).AsNoTracking();
            if(includeCategorias){
                query = query.Include(prod => prod.CategoriaProdutos).ThenInclude(cp => cp.Categoria);
            }

            return await query.ToArrayAsync();
        }
    }
}