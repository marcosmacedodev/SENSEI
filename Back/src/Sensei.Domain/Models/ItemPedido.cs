namespace Sensei.Domain.Models
{
    public class ItemPedido
    {
        public double Desconto { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        public int ProdutoId { get; set; }
        public int? PedidoId { get; set; }
        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }
    }
}