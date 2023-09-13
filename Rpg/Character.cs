namespace Rpg;

public class Character : ITakeDamage
{
    public int Health { get; private set; }
    public int Level { get; }
    public CharacterStatus Status { get; }

    public Character()
    {
        Health = 1000;
        Level = 1;
    }

    public void Damage(ITakeDamage target, int damage)
    {
        target.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}

public interface ITakeDamage
{
    void TakeDamage(int damage);
}