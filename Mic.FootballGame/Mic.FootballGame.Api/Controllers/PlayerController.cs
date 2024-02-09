using Mic.FootballGame.Data;
using Mic.FootballGame.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mic.FootballGame.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PlayersController(
    IPlayerRepository playerRepository,
    IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpGet]
    public IEnumerable<PlayerDto> GetAll()
    {
        var players = playerRepository.Query()
            .AsNoTracking()
            .Take(10)
            .Select(x => new PlayerDto(x.Name, x.Email, x.Id))
            .ToList();
        return players;
    }

    [HttpGet("{id}")]
    public PlayerDto Get([FromRoute] Guid id)
    {
        var player = playerRepository.Query().SingleOrDefault(x => x.Id == id);

        if (player is null)
            throw new EntityNotFoundException($"Player with id {id} was not found");
        
        return new PlayerDto(player.Name, player.Email, player.Id);
    }

    [HttpPost]
    public async Task<StatusCodeResult> Add([FromBody] PlayerDto player, CancellationToken cancellationToken)
    {
        // Todo verify if email already exists before adding a new user

        await playerRepository.Add(new Player(player.Name, player.Email, 0), cancellationToken);
        await unitOfWork.Commit();
        return Ok();
    }
}