using Mic.FootballGame.Domain;

namespace Mic.FootballGame.Data;

public interface IFootballSessionRepository
{
    IQueryable<FootballSession> Query();
}

public class FootballSessionRepository(FootballSessionDbContext dbContext) : IFootballSessionRepository
{
    public IQueryable<FootballSession> Query()
    {
        return dbContext.FootballSessions.AsQueryable();
    }
}