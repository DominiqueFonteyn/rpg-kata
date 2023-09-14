namespace Rpg.Domain.Primitives;

public struct HealthAmount
{
    public HealthAmount(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
}