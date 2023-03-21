using Microsoft.AspNetCore.Mvc;
using TotallyBiased.API.Authentication;
using TotallyBiased.API.Models;
using TotallyBiased.API.Services;

namespace TotallyBiased.API.Controllers;

[Controller]
[Route("api/[controller]")]
public class AdminController : Controller
{
    private readonly MongoDbService _mongoDbService;

    public AdminController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    [HttpPost("add")]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public async Task<string> Add([FromBody] Movie movieJson)
    {
        await _mongoDbService.CreateAsync(movieJson);
        return "Put into the database";
    }
}