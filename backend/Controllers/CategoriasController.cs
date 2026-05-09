using backend.Models;
using Microsoft.AspNetCore.Mvc;
using backend.Services;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly CategoriaService _categoriaService;

    public CategoriasController(CategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categorias = await _categoriaService.GetAsync();
        return Ok(categorias);
    }


    [HttpGet("{id}")]
public async Task<IActionResult> GetById(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);

        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }          
    
    [HttpPost]
    public async Task<IActionResult> CriarCategoria([FromBody] Categoria categoria)
    {
        var categoriaCriada = await _categoriaService.CreateAsync(categoria);

        return Ok("Categoria criada com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarCategoria(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);

        if (categoria == null)
            return NotFound("Categoria não encontrada");

        await _categoriaService.DeleteAsync(categoria);

        return Ok("Categoria deletada com sucesso");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Categoria categoria)
    {
        var atualizado = await _categoriaService.UpdateAsync(id, categoria);

        if (!atualizado)
            return NotFound("Categoria não encontrada");

        return Ok("Categoria atualizada com sucesso");
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> AtualizarParcial(int id, [FromBody] Categoria categoria)
    {
        var atualizado = await _categoriaService.UpdatePartialAsync(id, categoria);

        if (!atualizado)
            return NotFound("Categoria não encontrada");

        return Ok("Categoria atualizada com sucesso");
}

}

