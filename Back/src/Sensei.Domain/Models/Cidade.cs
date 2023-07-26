using System.ComponentModel.DataAnnotations.Schema;

namespace Sensei.Domain.Models
{
    [Table("cidades")]
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}