namespace Mic.FootballGame.Domain;

public class FootballSession
{
    private readonly TimeProvider _timeProvider;

    public FootballSession(Guid id,
        DateTime scheduleUtc,
        TimeSpan duration,
        Address address,
        int minPlayer,
        int maxPlayer,
        TimeProvider timeProvider)
    {
        Id = id;
        Schedule = scheduleUtc;
        Duration = duration;
        Address = address;
        MinPlayer = minPlayer;
        MaxPlayer = maxPlayer;
        Players = new List<Player>();
        _timeProvider = timeProvider;
    }

    public FootballSession(Guid id,
        DateTime scheduleUtc,
        TimeSpan duration,
        Address address,
        int minPlayer,
        int maxPlayer) : this(id, scheduleUtc, duration, address, minPlayer, maxPlayer, TimeProvider.System)
    {
    }

    public Guid Id { get; }
    public DateTime Schedule { get; }
    public TimeSpan Duration { get; }

    public Address Address { get; }
    public int MinPlayer { get; }
    public int MaxPlayer { get; }
    public List<Player> Players { get; }

    public void Add(Player player)
    {
        if (Players.Count + 1 > MaxPlayer)
            throw new InvalidOperationException(
                $"Cannot add a player to the session ({Id}) because MaxPlayer is {MaxPlayer}.");
        
        // if I use DateTime.Now I can't change the value in the unit tests. My test will depend on the moment of execution 
        // So I use new .net TimeProvider abstraction
        // if (Schedule < DateTime.Now)
        if (Schedule <= _timeProvider.GetUtcNow())
            throw new InvalidOperationException($"Cannot add a player to the session({Id}) because session has already started.");
        
        Players.Add(player);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private FootballSession()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        Players = new List<Player>();
    }
}
