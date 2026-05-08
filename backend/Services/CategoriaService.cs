using backend.Models;
using backend.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend.Services;

public class CategoriaService
{
    private readonly IMongoCollection<Categoria> _categoriasCollection;

    public CategoriaService(
        IOptions<MongoDbSettings> mongoDbSettings,
        IMongoClient mongoClient)
    {
        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        _categoriasCollection = mongoDatabase
            .GetCollection<Categoria>("categorias");
    }
}