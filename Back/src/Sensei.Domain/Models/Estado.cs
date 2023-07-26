using System.ComponentModel.DataAnnotations.Schema;

namespace Sensei.Domain.Models
{
    [Table("estados")]
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Cidade> Cidades { get; set; }
    }
}