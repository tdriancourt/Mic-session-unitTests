namespace Mic.FootballGame.Api;

public record PlayerDto(string Name, string Email, Guid? Id = null);