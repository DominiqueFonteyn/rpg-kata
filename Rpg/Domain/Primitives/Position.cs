namespace Rpg.Domain.Primitives;

public struct Position
{
    public Position() 
        : this(0)
    {
    }

    public Position(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
}