namespace Rpg;

public class Character : GameObject, ITakeDamage, IReceiveHealing
{
    private const int MinimumHealth = 0;
    private const int MaximumHealth = 1000;
    
    protected override bool CanBeHealed => true;
    protected override bool CanDealDamage => true;

    public Character() : base(MaximumHealth)
    {
        Level = 1;
    }

    public int Level { get; }
    public CharacterStatus Status { get; private set; }

    public virtual bool IsDead => Status == CharacterStatus.Dead;

    public virtual void ReceiveHealing(int health)
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
            Die();
        }
    }

    private void Die()
    {
        Status = CanBeHealed ? CharacterStatus.Dead : CharacterStatus.Destroyed;
    }

    public void ApplyHealthChange(HealthModifier modifier)
    {
        CurrentHealth += modifier.Amount;
    }

    public virtual void Damage(ITakeDamage target, int damage)
    {
        if (IsSelf(target))
        {
            return;
        }

        target.TakeDamage(damage);
    }

    public virtual void Heal(IReceiveHealing target, int health)
    {
        if (!IsSelf(target)) return;
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

    private bool IsSelf(IReceiveHealing target)
    {
        return target == this;
    }
}
