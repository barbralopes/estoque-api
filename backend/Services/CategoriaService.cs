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

        public async Task<Categoria> CreateAsync(Categoria categoria)
    {
        _context.Categorias.Add(categoria);

        await _context.SaveChangesAsync();

        return categoria;
    }

        public async Task<Categoria?> GetByIdAsync(int id)
    {
        return await _context.Categorias.FindAsync(id);
    }

        public async Task DeleteAsync(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria == null)
            return;

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
    }

        public async Task<bool> UpdateAsync(int id, Categoria categoriaAtualizada)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria == null)
            return false;

        categoria.Nome = categoriaAtualizada.Nome;

        await _context.SaveChangesAsync();

        return true;
    }

        public async Task<bool> UpdatePartialAsync(int id, Categoria categoriaAtualizada)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria == null)
            return false;

        if (!string.IsNullOrEmpty(categoriaAtualizada.Nome))
            categoria.Nome = categoriaAtualizada.Nome;

        await _context.SaveChangesAsync();

        return true;
    }

}
