using AutoFixture;
using FluentAssertions;
using Mic.FootballGame.Domain.TestData;
using Microsoft.Extensions.Time.Testing;
using Xunit;

namespace Mic.FootballGame.Domain.Tests;

public partial class FootballGameTests
{
    public class AddV1
    {
        [Fact]
        public void ShouldAddPlayer()
        {
            // Arrange
            var session = new FootballSession(Guid.NewGuid(), DateTime.Now.AddHours(2),
                TimeSpan.FromMinutes(90),
                new Address("5", "rue de la pépinière", "Gosselies", "6041"),
                10, 14);
            var player = new Player("A Clerbois", "  ", 12);
            // Act
            session.Add(player);
            // Assert
        }
        
        [Fact]
        public void ShouldThrowIfSessionIsFull() 
        {
            // Arrange
            var fixture = DomainCustomization.CreateFixture();
            var maxPlayer = 5;
            var session = new FootballSession(Guid.NewGuid(),
                // The schedule must be in the future because I have a new rule to avoid subscription on started session. See the following test to see TimeProvider usage.
                DateTime.Now.AddHours(2),
                TimeSpan.FromMinutes(90),
                fixture.Create<Address>(),
                1, maxPlayer);
            var player = fixture.Create<Player>();

            foreach (var initialPlayer in Enumerable.Range(0, maxPlayer)
                         .Select(i => new Player($"player{i}", $"player{i}@acme.com", 5)).ToList())
                session.Add(initialPlayer);
            // Act
            var action = () =>  session.Add((player));
            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }
        
        [Fact]
        public void ShouldThrowIfSessionIsOver()
        {
            // Arrange 
            var fixture = DomainCustomization.CreateFixture();
            var fakeTimer = new FakeTimeProvider();
            var session = new FootballSession(
                Guid.NewGuid(), 
                // Schedule is set at a certain moment.
                fakeTimer.GetUtcNow().DateTime,
                TimeSpan.Zero,
                fixture.Create<Address>(),
                0, 12);
            var player = fixture.Create<Player>();
        
            // Now I can manipulate time that the FootballSession will receive from time provider. So we will be 1 second later that the schedule
            fakeTimer.Advance(TimeSpan.FromSeconds(1));
            // Act
            var act = () => session.Add(player);
            // Assert
            act.Should().ThrowExactly<InvalidOperationException>()
                .WithMessage($"Cannot add a player to the session({session.Id}) because session has already started.");
        }
    }
}