
namespace Sensei.Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public ICollection<ItemPedido> ItensPedidos { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}