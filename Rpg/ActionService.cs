namespace Rpg;

public class ActionService
{
    public void DoDamage(Character attacker, Character receiver, int amount)
    {
        if(attacker == receiver)
            return;

        amount = (attacker.Level - receiver.Level) switch
        {
            > 5 => (int)(amount * 1.5),
            < -5 => (int)(amount / 2),
            _ => amount
        };

        receiver.Health = Math.Max(receiver.Health - amount, 0);
    }
    
    public void HealCharacter(Character healer, int amount)
    {
        if (healer.IsAlive)
            healer.Health = Math.Min(healer.Health + amount, 1000);
    }
}