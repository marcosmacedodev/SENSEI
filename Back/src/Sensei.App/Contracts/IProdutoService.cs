using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface IProdutoService
    {
        Task<Produto> GetProdutoById(int id, bool includeCategorias);
        Task<Produto[]> GetProdutos(bool includeCategorias);
        Task<Produto> AddProduto(Produto entity);
        Task<Produto> SaveProduto(Produto entity);
        Task<bool> DeleteProduto(Produto entity);
    }
}