namespace Mic.FootballGame.Domain;

public class Player(string name, string email, int technicalScore)
{
    public Guid Id { get; set; }
    public string Name { get; } = name;
    public string Email { get; } = email;
    public int TechnicalScore { get; } = technicalScore;
}

public record Address(string Number, string AddressLine, string Locality, string Zipcode);