using Microsoft.AspNetCore.Mvc;
using backend.Services;

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
}   