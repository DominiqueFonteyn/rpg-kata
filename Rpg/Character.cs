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

    public void Heal(Character character)
    {
        var healedValue = 500;
        if (character.IsAlive)
        {
            character.Health += healedValue;
            if (character.Health > 1000) character.Health = 1000;
        }
    }
}