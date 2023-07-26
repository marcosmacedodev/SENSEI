using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensei.Domain.Models
{
    public class CategoriaProduto
    {
        public int CategoriaId { get; set; }
        public int? ProdutoId { get; set; }
        public Categoria Categoria { get; set; }
        public Produto Produto { get; set; }
    }
}