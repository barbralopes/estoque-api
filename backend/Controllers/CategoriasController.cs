using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("API Categorias funcionando");
    }
    
}
