using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sensei.App.Contracts;
using Sensei.Domain.Models;

namespace Sensei.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController: ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService){
            _produtoService = produtoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
           Produto produto = await _produtoService.GetProdutoById(id, false);
           if(produto == null) return NotFound();
           return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            Produto[] produtos = await _produtoService.GetProdutos(false);
            if(produtos?.Length == 0) return NoContent();
            return Ok(produtos);
        }
    }
}