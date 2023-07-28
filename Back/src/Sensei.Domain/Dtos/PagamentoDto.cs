namespace Sensei.Domain.Dtos
{
    public class PagamentoDto
    {
        public int? Id { get; set; }
        public string Estado { get; set; }
        public PedidoDto Pedido { get; set; }
    }
}