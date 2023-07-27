using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface ICategoriaService
    {
        Task<Categoria> AddCategoria(Categoria entity);
        Task<Categoria> SaveCategoria(Categoria entity);
        Task<bool> DeleteCategoria(Categoria entity);
        Task<Categoria> GetCategoriaById(int id, bool includeProdutos);
        Task<Categoria[]> GetCategorias(bool includeProdutos);
    }
}