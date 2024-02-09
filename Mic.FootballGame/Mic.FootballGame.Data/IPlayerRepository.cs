using Mic.FootballGame.Domain;

namespace Mic.FootballGame.Data;

public interface IPlayerRepository
{
    IQueryable<Player> Query();
    Task Add(Player player, CancellationToken cancellationToken);
}

public class PlayerRepository(FootballSessionDbContext dbContext) : IPlayerRepository
{
    public IQueryable<Player> Query()
    {
        return dbContext.Players.AsQueryable();
    }

    public async Task Add(Player player, CancellationToken cancellationToken)
    {
        await dbContext.Players.AddAsync(player, cancellationToken);
    }
}