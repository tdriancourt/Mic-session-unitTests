using AutoFixture;
using Mic.FootballGame.Api.Controllers;
using Mic.FootballGame.Data;
using Mic.FootballGame.Domain;
using Mic.FootballGame.Domain.TestData;
using Moq;
using Xunit;

namespace Mic.FootballGame.Api.Tests;

public class PlayerControllerTest
{
    public class Get
    {
        [Fact]
        public void ShouldReturnPlayerDto()
        {
            // Arrange
            var fixture = DomainCustomization.CreateFixture();
            var player = fixture.Create<Player>();
            var playerRepositoryMock = new Mock<IPlayerRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var sut = new PlayersController(playerRepositoryMock.Object, unitOfWorkMock.Object);

            playerRepositoryMock.Setup(x => x.Query())
                .Returns(new[] { player }.AsQueryable());
            
            // Act
            var actual = sut.Get(player.Id);
            // Assert
            Assert.Equal(actual.Name, player.Name);
            Assert.Equal(actual.Email, player.Email);
        }
        
        // Practice: Write the following test. 
        public void ShouldThrowIfPlayerDoestExist()
        {}
    }
}