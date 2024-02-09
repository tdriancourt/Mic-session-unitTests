using AutoFixture;

namespace Mic.FootballGame.Domain.TestData;

public class DomainCustomization : CompositeCustomization
{
    public DomainCustomization() : base(
        new PlayerCustomization(),
        new FootballSessionCustomization())
    {
    }

    public static IFixture CreateFixture()
    {
        return new Fixture().Customize(new DomainCustomization());
    }
}

public class PlayerCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Player>(composer =>
            composer.FromFactory(() => new Player(
                fixture.Create<string>(),
                $"{Guid.NewGuid()}@mic-mons.be",
                10)));
    }
}

public class FootballSessionCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<FootballSession>(composer =>
            composer.FromFactory(() => new FootballSession(
                Guid.NewGuid(),
                DateTime.Now.AddHours(2),
                TimeSpan.FromMinutes(90),
                fixture.Create<Address>(),
                10,
                20)));
    }
}