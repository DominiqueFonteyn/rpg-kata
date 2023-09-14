namespace Rpg;

public abstract class HealthModifier
{
    protected HealthModifier(Direction direction, int amount)
    {
        if (amount < 0) throw new Exception("Specify a positive amount");
        Amount = amount;
        if (direction == Direction.Down)
            Amount *= -1;
    }

    public int Amount { get; }

    public static HealthModifier Healing(int amount) => new ReceiveHealing(amount);
    public static HealthModifier Damage(int amount) => new TakeDamage(amount);
    
    protected enum Direction
    {
        Up,
        Down
    }
}

public class ReceiveHealing : HealthModifier
{
    public ReceiveHealing(int amount) : base(Direction.Up, amount)
    {
    }
}

public class TakeDamage : HealthModifier
{
    public TakeDamage(int amount) : base(Direction.Down, amount)
    {
    }
}
