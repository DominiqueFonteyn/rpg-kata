namespace Rpg;

public class CharacterRepository
{
    private List<Character> _characters { get; set; } = new();

    public Character? TryAddCharacter(string name)
    {
        if (_characters.Any(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase)))
            return null;
        
        var character = new Character
            {
                Name = name,
                Health = 1000,
                Level = 1
            };
        
        _characters.Add(character);

        return character;
    }

    public void IncreaseLevel(Character character, int amount)
    {
        character.Level += amount;
    }

    public Character? GetCharacter(string name) =>
        _characters.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
}