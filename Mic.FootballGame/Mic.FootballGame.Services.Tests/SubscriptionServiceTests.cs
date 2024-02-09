using AutoFixture;
using Mic.FootballGame.Data;
using Mic.FootballGame.Domain;
using Mic.FootballGame.Domain.TestData;
using Mic.FootballGame.Service;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Mic.FootballGame.Services.Tests;

public class SubscriptionServiceTests
{
    public class Subscribe
    {
        [Fact]
        public async Task ShouldFindSessionSession()
        {
            var fixture = DomainCustomization.CreateFixture();
            var footballSession = fixture.Create<FootballSession>();
            // Use of queryableMock.Moq To create Queryable that are compatible with LinQ async api.
            var sessionQueryable = new[] { footballSession }.AsQueryable().BuildMock();
            var footballSessionRepositoryMock = new Mock<IFootballSessionRepository>();

            footballSessionRepositoryMock.Setup(x => x.Query())
                .Returns(sessionQueryable);
            var sut = new SubscriptionService(footballSessionRepositoryMock.Object);
            await sut.Subscribe(footballSession.Id, new Player("James", "james@metallica.com", 10));

            footballSessionRepositoryMock.Verify(x => x.Query(), Times.Once);
        }
    }
}