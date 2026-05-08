using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class CategoriaService
{
    private readonly AppDbContext _context;

    public CategoriaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> GetAsync()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task CreateAsync(Categoria categoria)
    {
        _context.Categorias.Add(categoria);

        await _context.SaveChangesAsync();
    }
}