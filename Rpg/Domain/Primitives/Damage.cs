namespace Rpg.Domain.Primitives;

public struct Damage
{
    public Damage(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
}