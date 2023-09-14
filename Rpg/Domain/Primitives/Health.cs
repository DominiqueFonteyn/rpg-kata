namespace Rpg.Domain.Primitives;

public struct Health
{
    public Health(int value)
    {
        Value = value;
    }

    public int Value { get; set; }

    public Health InflictDamage(Damage damage)
    {
        var newHealthValue = Value - damage.Value;

        return newHealthValue < 0 ? new Health(0) : new Health(newHealthValue);
    }

    public Health Heal(HealthAmount amount)
    {
        var newHealthValue = Value + amount.Value;
        return newHealthValue < 1000 ? new Health(newHealthValue) : new Health(1000);
    }
}