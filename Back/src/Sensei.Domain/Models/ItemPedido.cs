using System.ComponentModel.DataAnnotations.Schema;

namespace Sensei.Domain.Models
{
    [Table("itenspedidos")]
    public class ItemPedido
    {
        public double Desconto { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
    }
}