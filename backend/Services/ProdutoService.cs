using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class ProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> GetAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task CreateAsync(Produto produto)
    {
        _context.Produtos.Add(produto);

        await _context.SaveChangesAsync();
    }
}
