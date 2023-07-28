using Microsoft.AspNetCore.Mvc;
using Sensei.App.Contracts;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;

namespace Sensei.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController: ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService){
            _categoriaService = categoriaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Categoria categoria = await _categoriaService.GetCategoriaById(id, true);
            if (categoria == null) return NotFound();
            return Ok((CategoriaDto)categoria);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Categoria[] categorias = await _categoriaService.GetCategorias(true);
            if (categorias?.Length == 0) return NoContent();
            return Ok(categorias.Select(cat => (CategoriaDto)cat));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoriaDto entity){
            Categoria categoria = await _categoriaService.GetCategoriaById(id, false);
            if (categoria == null) return NotFound();
            entity.Id = id;
            categoria = await _categoriaService.SaveCategoria((Categoria)entity);
            if(categoria == null) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            Categoria categoria = await _categoriaService.GetCategoriaById(id, false);
            if (categoria == null) return NotFound();
            bool result = await _categoriaService.DeleteCategoria(categoria);
            if(!result) 
                return BadRequest();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaDto entity)
        {
            entity = (CategoriaDto)await _categoriaService.AddCategoria((Categoria) entity);
            if (entity == null) return BadRequest();
            return this.Created("", entity);
        }
    }
}