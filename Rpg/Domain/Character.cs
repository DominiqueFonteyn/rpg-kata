using Rpg.Domain.Primitives;
using Rpg.Faults;

namespace Rpg.Domain
{
    public class Character
    {
        public Level Level { get; }
        public FighterType FighterType { get; }
        public Health Health { get; private set; }
        public bool IsAlive => Health.Value > 0;
        public Position Position { get; }
        public HashSet<Faction> Factions { get; }

        public Character(Health health, Level level, FighterType fighterType, Position position)
        {
            Health = health;
            Level = level;
            FighterType = fighterType;
            Position = position;
            Factions = new HashSet<Faction>();
        }

        public void JoinFaction(Faction faction)
        {
            Factions.Add(faction);
        }

        public void LeaveFaction(Faction faction)
        {
            if (Factions.Contains(faction))
            {
                Factions.Remove(faction);
            }
        }

        public void Heal(HealingAmount amount)
        {
            if (!IsAlive)
            {
                throw new CharacterAlreadyDeadException();
            }

            Health = Health.Heal(amount);
        }

        public void InflictDamage(Character otherCharacter, Damage damage)
        {
            if (otherCharacter == this) return;
            if (!InRangeOf(otherCharacter)) return;

            var damageToDeal = DetermineDamageToDeal(otherCharacter, damage);

            otherCharacter.SufferDamage(damageToDeal);
        }

        private bool InRangeOf(Character otherCharacter)
        {
            var distance = Position.Value - otherCharacter.Position.Value;

            return distance <= FighterType.Range;
        }

        private void SufferDamage(Damage damage)
        {
            Health = Health.InflictDamage(damage);
        }

        private Damage DetermineDamageToDeal(Character otherCharacter, Damage damage)
        {
            var damageToDeal = damage;

            if (IsMuchWeaker(otherCharacter))
            {
                damageToDeal = damage.HalfDamage;
            }
            else if (IsMuchStronger(otherCharacter))
            {
                damageToDeal = damage.IncreasedDamage;
            }

            return damageToDeal;
        }

        private bool IsMuchWeaker(Character otherCharacter)
        {
            return Level.ExceedByFiveLevel(otherCharacter.Level);
        }

        private bool IsMuchStronger(Character otherCharacter)
        {
            return otherCharacter.Level.ExceedByFiveLevel(Level);
        }
    }
}
