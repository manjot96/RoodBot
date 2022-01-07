using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RoodBot.Data;
using RoodBot.Data.Models;
using RoodBot.WebApi.Services;

namespace RoodBot.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;

    public GameController(GameService gameService) =>
        _gameService = gameService;

    [HttpGet]
    public async Task<List<Game>> Get() =>
        await _gameService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Game>> Get(string id)
    {
        var Game = await _gameService.GetAsync(id);

        if (Game is null)
        {
            return NotFound();
        }

        return Game;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Game newGame)
    {
        await _gameService.CreateAsync(newGame);

        return CreatedAtAction(nameof(Get), new { id = newGame.Id }, newGame);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Game updatedGame)
    {
        var Game = await _gameService.GetAsync(id);

        if (Game is null)
        {
            return NotFound();
        }

        updatedGame.Id = Game.Id;

        await _gameService.UpdateAsync(id, updatedGame);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Game = await _gameService.GetAsync(id);

        if (Game is null)
        {
            return NotFound();
        }

        await _gameService.RemoveAsync(Game.Id);

        return NoContent();
    }
}
