using Mic.FootballGame.Data;
using Mic.FootballGame.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mic.FootballGame.Api.Controllers;

[ApiController]
[Route("api/v1/football-session")]
public class FootballSessionController(
    ISubscriptionService subscriptionService,
    IFootballSessionRepository footballSessionRepository,
    IPlayerRepository playerRepository,
    IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpPost("{sessionId}/subscriptions")]
    public async Task<IActionResult> Subscribe([FromRoute] Guid sessionId, [FromBody] Subscription subscription)
    {
        var player = playerRepository
            .Query()
            .Single(x => x.Id == subscription.PlayerId);

        await subscriptionService.Subscribe(sessionId, player);
        await unitOfWork.Commit();
        return Ok();
    }

    [HttpGet]
    public Task<List<FootballSessionDto>> GetAll()
    {
        return footballSessionRepository.Query()
            .Include(x => x.Address)
            .AsNoTracking()
            .Take(10)
            .Select(x => new FootballSessionDto(
                x.Id,
                x.Schedule,
                x.Schedule.Add(x.Duration),
                x.MinPlayer,
                x.MaxPlayer,
                x.Address.ToString()))
            .ToListAsync();
    }

    public record Subscription(Guid PlayerId);
}