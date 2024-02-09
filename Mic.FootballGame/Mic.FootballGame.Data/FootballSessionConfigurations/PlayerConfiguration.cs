using Mic.FootballGame.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mic.FootballGame.Data.FootballSessionConfigurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email)
            .HasMaxLength(255);
        builder.Property(x => x.Name)
            .HasMaxLength(255);
        builder.Property(x => x.TechnicalScore);
    }
}