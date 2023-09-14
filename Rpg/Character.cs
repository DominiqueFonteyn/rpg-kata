namespace Rpg;

public class Character
{
    public int Health { get; set; } = 1000;
    public int Level => 1;
    public bool IsAlive { get; set; } = true;

    public void DoDamage(Character victim, int damage)
    {
        if (victim.Equals(this))
            return;
        victim.Health -= damage;
        if (victim.Health <= 0) victim.IsAlive = false;
    }

    public void Heal()
    {
        var healedValue = 500;
        if (IsAlive)
        {
            Health += healedValue;
            if (Health > 1000) Health = 1000;
        }
    }
}