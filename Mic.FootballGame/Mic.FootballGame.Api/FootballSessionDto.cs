namespace Mic.FootballGame.Api;

public record FootballSessionDto(
    Guid Id,
    DateTime StartAt,
    DateTime EndAt,
    int MinPlayer,
    int MaxPlayer,
    string Address);