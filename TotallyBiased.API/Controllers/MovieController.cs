using Microsoft.AspNetCore.Mvc;
using TotallyBiased.API.Models;
using TotallyBiased.API.Services;

namespace TotallyBiased.API.Controllers;

[Controller]
[Route("api/[controller]")]
public class MovieController : Controller
{
    private readonly MongoDbService _mongoDbService;

    public MovieController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    [HttpGet]
    public Task<Movie> Get(string shorthand)
    {
        return _mongoDbService.GetAsync(shorthand);
    }

    [HttpPost]
    public async Task<string> Put()
    {
        Movie test = new Movie
        {
            Shorthand = "test",
            Title = "Test",
            Year = 2021,
            Rating = "PG",
            Runtime = "1h 30m",
            Genre = "Comedy",
            Director = "Test",
            Actors = new[] { "Test", "Test" },
            Thoughts = "Test",
            Score = 5
        };

        await _mongoDbService.CreateAsync(test);

        return "Put into the database";
    }
}