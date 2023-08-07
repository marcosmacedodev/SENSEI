using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sensei.App.Contracts;
using Sensei.Domain.Dtos;
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
           ProdutoDto produtoDto = await _produtoService.GetProdutoById(id, false);
           if(produtoDto == null) return NotFound();
           return Ok(produtoDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            ProdutoDto[] produtosDto = await _produtoService.GetProdutos(false);
            if(produtosDto?.Length == 0) return NoContent();
            return Ok(produtosDto);
        }
    }
}