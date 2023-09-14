namespace Rpg.Domain.Primitives;

public struct Level
{
    public const int InitialLevel = 1;

    public Level(int value)
    {
        Value = value;
    }

    public Level() 
        : this(InitialLevel)
    {
    }

    public int Value { get; set; }
}