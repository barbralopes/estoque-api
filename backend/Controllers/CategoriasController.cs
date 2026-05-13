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
        return Ok(categorias); // 200
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);

        if (categoria == null)
            return NotFound(); // 404

        return Ok(categoria); // 200
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] Categoria categoria)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); // 400

        var categoriaCriada = await _categoriaService.CreateAsync(categoria);

        return CreatedAtAction( // 201
            nameof(GetById),
            new { id = categoriaCriada.Id },
            categoriaCriada
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);

        if (categoria == null)
            return NotFound(); // 404

        await _categoriaService.DeleteAsync(id);

        return NoContent(); // 204
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Categoria categoria)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); // 400

        var atualizado = await _categoriaService.UpdateAsync(id, categoria);

        if (!atualizado)
            return NotFound(); // 404

        return NoContent(); // 204
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> AtualizarParcial(int id, [FromBody] Categoria categoria)
    {
        var atualizado = await _categoriaService.UpdatePartialAsync(id, categoria);

        if (!atualizado)
            return NotFound(); // 404

        return NoContent(); // 204
    }
}