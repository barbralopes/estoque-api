using backend.Models;
using backend.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend.Services;

public class ProdutoService
{
    private readonly IMongoCollection<Produto> _produtosCollection;

    public ProdutoService(
        IOptions<MongoDbSettings> mongoDbSettings,
        IMongoClient mongoClient)
    {
        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        _produtosCollection = mongoDatabase
            .GetCollection<Produto>("produtos");
    }

    public async Task<List<Produto>> GetAsync()
    {
        return await _produtosCollection
            .Find(_ => true)
            .ToListAsync();
    }
}