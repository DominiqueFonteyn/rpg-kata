namespace Rpg;

public class FactionService
{
    public void Join(Character character, string factionName)
    {
        if (character.Factions.Any(faction => string.Equals(faction, factionName, StringComparison.OrdinalIgnoreCase)))
    }

    public bool AreAllies(Character character1, Character character2)
    {
    }
}