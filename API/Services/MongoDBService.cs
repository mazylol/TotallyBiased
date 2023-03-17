using DotNetEnv;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using TotallyBiased.API.Models;

namespace TotallyBiased.API.Services;

public class MongoDbService
{
    private readonly IMongoCollection<Movie> _movieCollection;

    public MongoDbService()
    {
        Env.TraversePath().Load();

        var pack = new ConventionPack { new CamelCaseElementNameConvention() };
        ConventionRegistry.Register("elementNameConvention", pack, _ => true);

        var client = new MongoClient(Env.GetString("MONGO_URI"));
        var database = client.GetDatabase("data");
        _movieCollection = database.GetCollection<Movie>("movies");
    }

    public Task<ActionResult<Movie>> GetAsync(string? shorthand)
    {
        try
        {
            var cursor = _movieCollection.AsQueryable();
            var result = cursor.First(document => document.Shorthand == shorthand);
            return Task.FromResult<ActionResult<Movie>>(result);
        }
        catch
        {
            return Task.FromResult<ActionResult<Movie>>(new NotFoundResult());
        }
    }

    public async Task CreateAsync(Movie movie)
    {
        await _movieCollection.InsertOneAsync(movie);
    }

    /*public async Task AddToPlaylistAsync(string id, string movieId)
    {
        FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);
        UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("movieIds", movieId);
        await _playlistCollection.UpdateOneAsync(filter, update);
    }

    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);
        await _playlistCollection.DeleteOneAsync(filter);
        return;
    } */
}