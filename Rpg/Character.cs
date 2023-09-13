namespace Rpg;

public class Character : ITakeDamage, IReceiveHealing
{
    private const int MinimumHealth = 0;
    private const int MaximumHealth = 1000;

    public Character()
    {
        CurrentHealth = MaximumHealth;
        Level = 1;
    }

    public int CurrentHealth { get; private set; }
    public int Level { get; }
    public CharacterStatus Status { get; private set; }

    public bool IsDead => Status == CharacterStatus.Dead;

    public void ReceiveHealing(int health)
    {
        CurrentHealth += health;

        if (CurrentHealth > MaximumHealth)
        {
            CurrentHealth = MaximumHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth < MinimumHealth)
        {
            CurrentHealth = MinimumHealth;
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
