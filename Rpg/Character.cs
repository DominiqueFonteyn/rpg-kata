namespace Rpg;

public class Character
{
    private const int StartingHealth = 1000;
    private const int StartingLevel = 1;

    public Character()
    {
        Health = StartingHealth;
        Level = StartingLevel;
    }

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

    public void Heal(int healingAmount)
    {
        if (!Alive) return;

        var healthAfterHealing = Health + healingAmount;
        Health = healthAfterHealing > StartingHealth 
            ? StartingHealth
            : healthAfterHealing; 
    }
}