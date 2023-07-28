using Sensei.Domain.Models;

namespace Sensei.Domain.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<CategoriaProduto> CategoriaProdutos { get; set; }
        public static explicit operator CategoriaDto(Categoria categoria){
            return new CategoriaDto()
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                CategoriaProdutos = categoria.CategoriaProdutos
            }; 
        }
    }
}