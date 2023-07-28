using System.ComponentModel.DataAnnotations.Schema;
using Sensei.Domain.Models;

namespace Sensei.Domain.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public int Preco { get; set; }
        [NotMapped]
        public ICollection<CategoriaProduto> CategoriaProdutos { get; set; }
        public ICollection<ItemPedido> ItensPedidos { get; set; }
    }
}