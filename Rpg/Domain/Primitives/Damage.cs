namespace Rpg.Domain.Primitives;

public struct Damage
{
    public Damage(int value)
    {
        Value = value;
    }

    public Damage HalfDamage => new Damage(Value / 2);
    public Damage IncreasedDamage => new Damage((int) Math.Round(Value * 1.5m));

    public int Value { get; set; }
}