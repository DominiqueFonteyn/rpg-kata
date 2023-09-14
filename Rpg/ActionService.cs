namespace Rpg;

public class ActionService
{
    public void DoDamage(Character attacker, Character receiver, int amount)
    {
        receiver.Health = Math.Max(receiver.Health - amount, 0);
    }
    
    public void HealCharacter(Character attacker, Character receiver, int amount)
    {
        if (receiver.IsAlive)
            receiver.Health = Math.Min(receiver.Health + amount, 1000);
    }
}