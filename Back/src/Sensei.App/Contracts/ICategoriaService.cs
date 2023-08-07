using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> AddCategoria(CategoriaDto categoriaDto);
        Task<CategoriaDto> SaveCategoria(CategoriaDto categoriaDto);
        Task<bool> DeleteCategoria(CategoriaDto categoriaDto);
        Task<CategoriaDto> GetCategoriaById(int id, bool includeProdutos);
        Task<CategoriaDto[]> GetCategorias(bool includeProdutos);
    }
}