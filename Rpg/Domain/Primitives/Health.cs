namespace Rpg.Domain.Primitives;

public struct Health
{
    public const int StartingValue = 1000;
    public const int MaxHealth = 1000;
    public const int MinHealth = 0;

    public Health(int value)
    {
        Value = value;
    }

    public Health() 
        : this (StartingValue)
    {
    }

    public int Value { get; set; }

    public Health InflictDamage(Damage damage)
    {
        var newHealthValue = Value - damage.Value;

        return newHealthValue < MinHealth ? new Health(MinHealth) : new Health(newHealthValue);
    }

    public Health Heal(HealingAmount amount)
    {
        var newHealthValue = Value + amount.Value;
        return newHealthValue < MaxHealth ? new Health(newHealthValue) : new Health(MaxHealth);
    }
}