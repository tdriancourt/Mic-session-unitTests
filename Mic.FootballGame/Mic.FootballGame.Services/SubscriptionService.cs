using Mic.FootballGame.Data;
using Mic.FootballGame.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mic.FootballGame.Service;

public interface ISubscriptionService
{
    public Task Subscribe(Guid sessionId, Player player);
}

public class SubscriptionService : ISubscriptionService
{
    private readonly IFootballSessionRepository _footballSessionRepository;

    public SubscriptionService(IFootballSessionRepository footballSessionRepository)
    {
        _footballSessionRepository = footballSessionRepository;
    }

    public async Task Subscribe(Guid sessionId, Player player)
    {
        var session = await _footballSessionRepository
            .Query()
            .SingleOrDefaultAsync(x => x.Id == sessionId);

        if (session is null)
            throw new EntityNotFoundException($"Session with id:{sessionId} is not found");

        session.Add(player);
    }
}