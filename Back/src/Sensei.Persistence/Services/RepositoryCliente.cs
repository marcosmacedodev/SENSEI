using Microsoft.EntityFrameworkCore;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;
using Sensei.Persistence.DataContext;

namespace Sensei.Persistence.Services
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private readonly Context _context;
        public RepositoryCliente(Context context){
            _context = context;
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            IQueryable<Cliente> query =_context.Clientes
            .Include(cli => cli.Enderecos)
            .Include(cli => cli.Pedidos)
            .Where(cli => cli.Id.Equals(id))
            .AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente[]> GetClientes()
        {
            IQueryable<Cliente> query =_context.Clientes
            .Include(cli => cli.Enderecos)
            .Include(cli => cli.Pedidos)
            .OrderBy(cli => cli.Id)
            .AsNoTracking();
            return await query.ToArrayAsync();
        }
    }
}