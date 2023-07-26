using System.ComponentModel.DataAnnotations.Schema;

namespace Sensei.Domain.Models
{
    [Table("pedidos")]
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
    }
}