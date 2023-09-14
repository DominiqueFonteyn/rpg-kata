namespace Rpg;

public class Character
{
    public int Health { get; set; } = 1000;
    public int Level { get; set; } = 1;
    public bool IsAlive { get; set; } = true;

    public void DoDamage(Character victim, int damage)
    {
        if (victim.Equals(this))
            return;
        var resultDamage = damage;

        if (Level <= victim.Level - 5)
            resultDamage = damage / 2;
        if (Level >= victim.Level + 5)
            resultDamage = damage * 2;

        victim.Health -= resultDamage;
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