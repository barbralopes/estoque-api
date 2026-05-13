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

        public async Task<Produto?> GetByIdAsync(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

        public async Task<Produto> CreateAsync(Produto produto)
    {
        _context.Produtos.Add(produto);

        await _context.SaveChangesAsync();

        return produto;
    }

        public async Task DeleteAsync(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
            return;

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
    }

        public async Task<bool> UpdateAsync(int id, Produto produtoAtualizado)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
            return false;

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        produto.Estoque = produtoAtualizado.Estoque;
        produto.CategoriaId = produtoAtualizado.CategoriaId; 

        await _context.SaveChangesAsync();

        return true;
    }

        public async Task<bool> UpdatePartialAsync(int id, Produto produtoAtualizado)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
            return false;

        if (!string.IsNullOrEmpty(produtoAtualizado.Nome))
            produto.Nome = produtoAtualizado.Nome;

        if (produtoAtualizado.Preco > 0)
            produto.Preco = produtoAtualizado.Preco;

        if (produtoAtualizado.Estoque >= 0)
            produto.Estoque = produtoAtualizado.Estoque;

        if (produtoAtualizado.CategoriaId > 0)
            produto.CategoriaId = produtoAtualizado.CategoriaId;

        await _context.SaveChangesAsync();

        return true;
    }

}
