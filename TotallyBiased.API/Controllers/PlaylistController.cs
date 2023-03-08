using Microsoft.AspNetCore.Mvc;
using TotallyBiased.API.Models;
using TotallyBiased.API.Services;

namespace TotallyBiased.API.Controllers;

[Controller]
[Route("api/[controller]")]
public class PlaylistController : Controller
{
    private readonly MongoDBService _mongoDbService;

    public PlaylistController(MongoDBService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    [HttpGet]
    public async Task<List<Playlist>> Get()
    {
        return await _mongoDbService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Playlist playlist)
    {
        await _mongoDbService.CreateAsync(playlist);
        return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId)
    {
        await _mongoDbService.AddToPlaylistAsync(id, movieId);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mongoDbService.DeleteAsync(id);
        return NoContent();
    }
}