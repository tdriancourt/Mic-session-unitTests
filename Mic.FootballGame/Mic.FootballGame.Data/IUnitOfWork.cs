namespace Mic.FootballGame.Data;

public interface IUnitOfWork
{
    Task<int> Commit();
}

public class UnitOfWork(FootballSessionDbContext dbContext) : IUnitOfWork
{
    public Task<int> Commit()
    {
        return dbContext.SaveChangesAsync();
    }
}