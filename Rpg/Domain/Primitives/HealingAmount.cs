namespace Rpg.Domain.Primitives;

public struct HealingAmount
{
    public HealingAmount(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
}