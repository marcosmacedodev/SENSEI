using Sensei.Domain.Models;

namespace Sensei.Domain.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public ICollection<ItemPedido> ItensPedidos { get; set; }
        public int ClienteId { get; set; }
        public ClienteDto Cliente { get; set; }
        public int EnderecoId { get; set; }
        public EnderecoDto Endereco { get; set; }
        public PagamentoDto Pagamento { get; set; }
    }
}