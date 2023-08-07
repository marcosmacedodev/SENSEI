
using Sensei.Domain.Dtos;

namespace Sensei.Domain.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<CategoriaProduto> CategoriaProdutos { get; set; }
    }
}