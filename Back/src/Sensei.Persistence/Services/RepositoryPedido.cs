
using Microsoft.EntityFrameworkCore;
using Sensei.Domain.Models;
using Sensei.Persistence.Contracts;
using Sensei.Persistence.DataContext;

namespace Sensei.Persistence.Services
{
    public class RepositoryPedido : IRepositoryPedido
    {
        private readonly Context _context;
        public RepositoryPedido(Context context)
        {
            _context = context;
            
        }
        public async Task<Pedido> GetPedidoById(int id, bool includeProdutos)
        {
            IQueryable<Pedido> query = _context.Pedidos
            .Include(ped => ped.Cliente)
            .Include(ped => ped.Endereco)
            .Include(ped => ped.Pagamento)
            .Where(end => end.Id.Equals(id))
            .AsNoTracking();
            if(includeProdutos){
                query = query.Include(ped => ped.ItensPedidos).ThenInclude(ip => ip.Produto);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pedido[]> GetPedidos(bool includeProdutos)
        {
            IQueryable<Pedido> query = _context.Pedidos
            .Include(ped => ped.Cliente)
            .Include(ped => ped.Endereco)
            .Include(ped => ped.Pagamento)
            .OrderBy(ped => ped.Id)
            .AsNoTracking();
            if(includeProdutos){
                query = query.Include(ped => ped.ItensPedidos).ThenInclude(ip => ip.Produto);
            }
            return await query.ToArrayAsync();
        }
    }
}