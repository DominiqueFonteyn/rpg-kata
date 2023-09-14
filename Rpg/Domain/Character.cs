using Rpg.Domain.Primitives;
using Rpg.Faults;

namespace Rpg.Domain
{
    public class Character
    {
        public Character()
            : this(new Health(), new Level())
        {
        }

        public Character(Health health) 
            : this(health, new Level())
        {
        }

        public Character(Level level)
            : this(new Health(), level)
        {
        }

        private Character(Health health, Level level)
        {
            Health = health;
            Level = level;
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
            if (otherCharacter == this)
                return;

            var damageToDeal = DetermineDamageToDeal(otherCharacter, damage);

            otherCharacter.SufferDamage(damageToDeal);
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

        public bool IsAlive => Health.Value > 0;
        public Health Health { get; private set;  }
        public Level Level { get; }
    }
}
