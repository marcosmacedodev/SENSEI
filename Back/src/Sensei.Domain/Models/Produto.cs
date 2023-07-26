using System.ComponentModel.DataAnnotations.Schema;

namespace Sensei.Domain.Models
{
    [Table("produtos")]
    public class Produto
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public int Preco { get; set; }
    }
}