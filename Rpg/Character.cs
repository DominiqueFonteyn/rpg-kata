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

        if (ExceedsMaximumHealth())
        {
            CurrentHealth = MaximumHealth;
        }
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (ExceedsMinimumHealth())
        {
            CurrentHealth = MinimumHealth;
            Status = CharacterStatus.Dead;
        }
    }

    public virtual void Damage(ITakeDamage target, int damage)
    {
        if (IsSelf(target))
        {
            return;
        }

        target.TakeDamage(damage);
    }

    public void Heal(IReceiveHealing target, int health)
    {
        if (target.IsDead) return;

        target.ReceiveHealing(health);
    }

    private bool ExceedsMaximumHealth()
    {
        return CurrentHealth > MaximumHealth;
    }

    private bool ExceedsMinimumHealth()
    {
        return CurrentHealth < MinimumHealth;
    }

    private bool IsSelf(ITakeDamage target)
    {
        return target == this;
    }
}
