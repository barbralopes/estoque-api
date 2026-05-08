using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models;

public class Produto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public int Estoque { get; set; }

    public string CategoriaId { get; set; } = null!;
}