using Mic.FootballGame.Api.Controllers;
using Mic.FootballGame.Data;
using Mic.FootballGame.Domain;
using Mic.FootballGame.Service;
using Moq;
using Xunit;

namespace Mic.FootballGame.Api.Tests;

public class FootballSessionControllerTests
{
    public class Subscribe
    {
        
    }
}











/*

[Fact]
public async Task ShouldCallSubscriptionServiceProperly()
{
   // Arrange
   var subscriptionServiceMock = new Mock<ISubscriptionService>();
   var footballSessionRepositoryMock = new Mock<IFootballSessionRepository>();
   var playerRepositoryMock = new Mock<IPlayerRepository>();

   var expectedName = "Joshua Homme";
   var expectedEmail = "joshua.homme@queensofthestoneage.com";
   var expectedTechnicalScore = 10;
   var player = new Player(expectedName, expectedEmail, expectedTechnicalScore);

   playerRepositoryMock.Setup(x => x.Query())
       .Returns(new[] { player }.AsQueryable);

   var sut = new FootballSessionController(
       subscriptionServiceMock.Object,
       footballSessionRepositoryMock.Object,
       playerRepositoryMock.Object,
       Mock.Of<IUnitOfWork>());
   var expectedSessionId = Guid.NewGuid();


   // Act
   await sut.Subscribe(expectedSessionId, new FootballSessionController.Subscription(player.Id));
   // Assert
   subscriptionServiceMock.Verify(x => x.Subscribe(
       It.Is<Guid>(s => s == expectedSessionId), player));
}

*/