namespace Rpg;

public abstract class GameObject
{
    protected GameObject(decimal initialHealth)
    {
        CurrentHealth = initialHealth;
    }

    protected virtual bool CanBeDamaged => true;
    protected abstract bool CanBeHealed { get; }
    protected abstract bool CanDealDamage { get; }
    public decimal CurrentHealth { get; protected set; }
}
