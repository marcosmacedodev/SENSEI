using System.ComponentModel.DataAnnotations.Schema;
 
namespace Sensei.Domain.Models
{
    [Table("categorias")]
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<CategoriaProduto> CategoriaProdutos { get; set; }
    }
}