using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _produtoService;

    public ProdutosController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var produtos = await _produtoService.GetAsync();
        return Ok(produtos); // 200
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var produto = await _produtoService.GetByIdAsync(id);

        if (produto == null)
            return NotFound(); // 404

        return Ok(produto); // 200
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); // 400

        var produtoCriado = await _produtoService.CreateAsync(produto);

        return CreatedAtAction( // 201
            nameof(GetById),
            new { id = produtoCriado.Id },
            produtoCriado
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var produto = await _produtoService.GetByIdAsync(id);

        if (produto == null)
            return NotFound(); // 404

        await _produtoService.DeleteAsync(id);

        return NoContent(); // 204 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); // 400

        var atualizado = await _produtoService.UpdateAsync(id, produto);

        if (!atualizado)
            return NotFound(); // 404

        return NoContent(); // 204
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> AtualizarParcial(int id, [FromBody] Produto produto)
    {
        var atualizado = await _produtoService.UpdatePartialAsync(id, produto);

        if (!atualizado)
            return NotFound(); // 404

        return NoContent(); // 204
    }
}