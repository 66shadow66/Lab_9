using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoardGameClub.ApiLab46.Models;

public class Game
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; }
}