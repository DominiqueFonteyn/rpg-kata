namespace Rpg;

public class Character : ITakeDamage
{
    private const int MinimumHealth = 0;
    public int Health { get; private set; }
    public int Level { get; }
    public CharacterStatus Status { get; private set; }

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

        if (Health < MinimumHealth)
        {
            Health = MinimumHealth;
            Status = CharacterStatus.Dead;
        }
    }
}