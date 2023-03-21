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
    public async Task<ActionResult<Movie>> Get(string? shorthand)
    {
        if (shorthand == null)
        {
            return NotFound();
        }

        return await _mongoDbService.GetAsync(shorthand);
    }
}