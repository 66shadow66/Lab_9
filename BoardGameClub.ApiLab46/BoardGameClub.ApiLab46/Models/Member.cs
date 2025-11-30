using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoardGameClub.ApiLab46.Models;

public class Member
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = "Member";
}