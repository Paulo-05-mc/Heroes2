namespace Heroes.Models;

public class Heroe
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string HeroeName { get; set; } = null!;
    public int Age { get; set; }
}