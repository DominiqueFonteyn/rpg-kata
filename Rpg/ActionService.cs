namespace Rpg;

public class ActionService
{
    public void DoDamage(Character attacker, Character receiver, int amount)
    {
        if(attacker == receiver)
            return;
        
        var distance = Math.Abs(attacker.Postion - receiver.Postion);
        if (attacker.FighterType == FighterType.Melee
            && distance > GameConstants.MeleeRange)
        {
            return;
        }
        
        if (attacker.FighterType == FighterType.Ranged
            && distance > GameConstants.RangedRange)
        {
            return;
        }
        
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
            healer.Health = Math.Min(healer.Health + amount, GameConstants.MaxHealth);
    }

    public void MoveCharacter(Character character, int distance)
    {
        character.Postion += distance;
    }
}