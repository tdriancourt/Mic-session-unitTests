using Mic.FootballGame.Data.FootballSessionConfigurations;
using Mic.FootballGame.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mic.FootballGame.Data;

public class FootballSessionDbContext : DbContext
{
    public FootballSessionDbContext(DbContextOptions<FootballSessionDbContext> options) : base(options)
    {
    }

    public DbSet<FootballSession> FootballSessions { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FootballSessionConfiguration).Assembly);
    }
}