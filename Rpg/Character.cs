namespace Rpg;

public class Character : ITakeDamage, IReceiveHealing
{
    private const int MinimumHealth = 0;

    public Character()
    {
        Health = 1000;
        Level = 1;
    }

    public int Health { get; private set; }
    public int Level { get; }
    public CharacterStatus Status { get; private set; }

    public void ReceiveHealing(int health)
    {
        throw new NotImplementedException();
    }

    public bool IsDead => Status == CharacterStatus.Dead;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < MinimumHealth)
        {
            Health = MinimumHealth;
            Status = CharacterStatus.Dead;
        }
    }

    public void Damage(ITakeDamage target, int damage)
    {
        target.TakeDamage(damage);
    }

    public void Heal(IReceiveHealing target, int health)
    {
        if (target.IsDead) return;
        
        target.ReceiveHealing(health);
    }
}
