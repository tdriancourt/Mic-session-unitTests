using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Mic.FootballGame.Data;

public class FootballSessionDbContextFactory : IDesignTimeDbContextFactory<FootballSessionDbContext>
{
    public FootballSessionDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("dbcontextsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("SqlServer");

        var options = new DbContextOptionsBuilder<FootballSessionDbContext>()
            .UseSqlServer(connectionString);
        return new FootballSessionDbContext(options.Options);
    }
}