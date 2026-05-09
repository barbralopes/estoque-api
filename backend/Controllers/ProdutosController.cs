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

        return Ok(produtos);
    }

    [HttpGet("{id}")]
public async Task<IActionResult> GetById(int id)
    {
        var produto = await _produtoService.GetByIdAsync(id);

        if (produto == null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> CriarCProduto([FromBody] Produto produto)
    {
        var produtoCriado = await _produtoService.CreateAsync(produto);

        return Ok("Produto criado com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarProduto(int id)
    {
        var produto = await _produtoService.GetByIdAsync(id);

        if (produto == null)
            return NotFound("Produto não encontrado");

        await _produtoService.DeleteAsync(produto);

        return Ok("Produto deletado com sucesso");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produto)
    {
        var atualizado = await _produtoService.UpdateAsync(id, produto);

        if (!atualizado)
            return NotFound("Produto não encontrado");

        return Ok("Produto atualizado com sucesso");
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> AtualizarParcial(int id, [FromBody] Produto produto)
    {
        var atualizado = await _produtoService.UpdatePartialAsync(id, produto);

        if (!atualizado)
            return NotFound("Produto não encontrado");

        return Ok("Produto atualizado com sucesso");
    }


}

