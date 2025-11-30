using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoardGameClub.ApiLab46.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")] public string Name { get; set; } = null!;
    [BsonElement("email")] public string Email { get; set; } = null!;
    [BsonElement("passwordHash")] public string PasswordHash { get; set; } = null!;
    [BsonElement("role")] public string Role { get; set; } = "Member"; // Member або Admin
}