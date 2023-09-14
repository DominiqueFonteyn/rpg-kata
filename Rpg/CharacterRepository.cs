namespace Rpg;

public class CharacterRepository
{
    private List<Character> _characters { get; set; } = new();

    public Character? TryAddCharacter(string name, FighterType fighterType, int startPostion) 
    {
        if (_characters.Any(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase)))
            return null;
        
        var character = new Character
            {
                Name = name,
                Health = GameConstants.StartHealth,
                Level = 1,
                FighterType = fighterType,
                Postion = startPostion
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