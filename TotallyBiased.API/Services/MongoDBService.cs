using DotNetEnv;
using MongoDB.Bson;
using MongoDB.Driver;
using TotallyBiased.API.Models;

namespace TotallyBiased.API.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Playlist> _playlistCollection;

    public MongoDBService()
    {
        Env.TraversePath().Load();

        MongoClient client = new MongoClient(Env.GetString("MONGO_URI"));
        IMongoDatabase database = client.GetDatabase("sample_mflix");
        _playlistCollection = database.GetCollection<Playlist>("playlist");
    }

    public async Task<List<Playlist>> GetAsync()
    {
        return await _playlistCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task CreateAsync(Playlist playlist)
    {
        await _playlistCollection.InsertOneAsync(playlist);
        return;
    }

    public async Task AddToPlaylistAsync(string id, string movieId)
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
    }
}