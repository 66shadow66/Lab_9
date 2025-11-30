using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoardGameClub.ApiLab46.Models;

public class Session
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string GameId { get; set; } = string.Empty;
    public string MemberId { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
}