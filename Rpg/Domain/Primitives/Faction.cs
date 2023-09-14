namespace Rpg.Domain.Primitives;

public class Faction
{
    public Faction(string name)
    {
        Name = name;
    }

    public string  Name { get; set; }
}