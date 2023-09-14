namespace Rpg;

public class Character
{
    private const int StartingHealth = 1000;
    private const int StartingLevel = 1;

    public Character(int level = StartingLevel)
    {
        Health = StartingHealth;
        Level = level;
        Id = Guid.NewGuid();
    }

    private Guid Id { get; }
    public int Health { get; private set; }
    public int Level { get; private set; }
    public bool Alive => Health > 0;

    public void TakeDamage(int damage)
    {
        var healthAfterDamage = Health - damage; 
        Health = healthAfterDamage < 0
            ? 0
            : healthAfterDamage;
    }

    private void Heal(int healingAmount)
    {
        if (healingAmount < 0) throw new ApplicationException("Can't heal negative amount");
        
        if (!Alive) return;

        var healthAfterHealing = Health + healingAmount;
        Health = healthAfterHealing > StartingHealth 
            ? StartingHealth
            : healthAfterHealing; 
    }

    public void HealSelf(int healingAmount)
    {
        Heal(healingAmount);
    }

    public void Attack(Character target, int damage)
    {
        if (Id == target.Id) return;
        
        var damageMultiplier = CalculateAttackModifier(target);

        var modifiedDamage = (int)Math.Floor(damage * damageMultiplier);
        target.TakeDamage(modifiedDamage);
    }

    private decimal CalculateAttackModifier(Character target)
    {
        if (target.Level > Level + 4)
            return 0.5m;
        
        if (Level > target.Level + 4)
            return 1.5m;

        return 1;
    }
}