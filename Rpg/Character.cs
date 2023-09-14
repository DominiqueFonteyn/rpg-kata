namespace Rpg;

public class Character
{
    public int Health { get; set; } = 1000;
    public int Level  => 1;
    public bool IsAlive { get; set; } = true;

    public void DoDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0) IsAlive = false;
    }

    public void Heal(Character character)
    {
        var healedValue = 500;
        
        character.Health += healedValue;
    }
}