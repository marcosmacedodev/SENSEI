using Sensei.Domain.Enums;

namespace Sensei.Domain.Models
{
    public abstract class Pagamento
    {
        public int PedidoId { get; set; }
        public EstadoPagamento Estado { get; set; }
        public Pedido Pedido { get; set; }
    }
}