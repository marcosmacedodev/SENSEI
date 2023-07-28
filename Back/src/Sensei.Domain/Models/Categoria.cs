using System.ComponentModel.DataAnnotations.Schema;
using Sensei.Domain.Dtos;

namespace Sensei.Domain.Models
{
    [Table("categorias")]
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<CategoriaProduto> CategoriaProdutos { get; set; }

        public static explicit operator Categoria(CategoriaDto categoria){
            return new Categoria(){
                Id = categoria.Id,
                Nome = categoria.Nome,
                CategoriaProdutos = categoria.CategoriaProdutos
            }; 
        }
    }
}