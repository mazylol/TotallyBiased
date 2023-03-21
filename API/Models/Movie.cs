using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TotallyBiased.API.Models;

public class Movie
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? Shorthand { get; set; }
    public string? Title { get; set; }
    public int Year { get; set; }
    public string? Rating { get; set; }
    public string? Runtime { get; set; }
    public string? Genre { get; set; }
    public string? Director { get; set; }
    public string? Actors { get; set; }
    public string? Thoughts { get; set; }
    public double Score { get; set; }
}