using Mic.FootballGame.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mic.FootballGame.Data.FootballSessionConfigurations;

public class FootballSessionConfiguration : IEntityTypeConfiguration<FootballSession>
{
    public void Configure(EntityTypeBuilder<FootballSession> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Address, navigationBuilder =>
        {
            navigationBuilder.Property(a => a.Locality)
                .HasMaxLength(255);
            navigationBuilder.Property(a => a.AddressLine)
                .HasMaxLength(1024);
            navigationBuilder.Property(a => a.Zipcode)
                .HasMaxLength(10);
            navigationBuilder.Property(a => a.Number)
                .HasMaxLength(10);
        });

        builder.HasMany(x => x.Players)
            .WithMany();

        builder.Property(x => x.Schedule);
        builder.Property(x => x.Duration);
        builder.Property(x => x.MaxPlayer);
        builder.Property(x => x.MinPlayer);

        builder.ToTable("FootballSessions");
    }
}