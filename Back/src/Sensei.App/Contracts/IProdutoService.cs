using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface IProdutoService
    {
        Task<ProdutoDto> GetProdutoById(int id, bool includeCategorias);
        Task<ProdutoDto[]> GetProdutos(bool includeCategorias);
        Task<ProdutoDto> AddProduto(ProdutoDto produtoDto);
        Task<ProdutoDto> SaveProduto(ProdutoDto produtoDto);
        Task<bool> DeleteProduto(ProdutoDto produtoDto);
    }
}