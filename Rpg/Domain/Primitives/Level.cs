namespace Rpg.Domain.Primitives;

public struct Level
{
    public Level(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
}