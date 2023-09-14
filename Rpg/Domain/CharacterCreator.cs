using Rpg.Domain.Primitives;

namespace Rpg.Domain;

public class CharacterCreator
{
    private Level _level = new();
    private Health _health = new();
    private Position _position = new();
    private FighterType _fighterType = new();

    public static CharacterCreator Build()
    {
        return new CharacterCreator();
    }

    public Character Create()
    {
        return new Character(_health, _level, _fighterType, _position);
    }

    public CharacterCreator WithLevel(Level level)
    {
        _level = level;
        return this;
    }

    public CharacterCreator AtPosition(Position position)
    {
        _position = position;
        return this;
    }

    public CharacterCreator WithHealth(Health health)
    {
        _health = health;
        return this;
    }

    public CharacterCreator OfType(FighterType fighterType)
    {
        _fighterType = fighterType;
        return this;
    }
}