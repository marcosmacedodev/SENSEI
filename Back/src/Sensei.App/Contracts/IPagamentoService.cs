using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;

namespace Sensei.App.Contracts
{
    public interface IPagamentoService
    {
        Task<PagamentoDto> GetPagamentoById(int id);
        Task<PagamentoDto[]> GetPagamentos();
        Task<PagamentoDto> AddPagamento(PagamentoDto pagamentoDto);
        Task<PagamentoDto> SavePagamento(PagamentoDto pagamentoDto);
        Task<bool> DeletePagamento(PagamentoDto pagamentoDto);
    }
}