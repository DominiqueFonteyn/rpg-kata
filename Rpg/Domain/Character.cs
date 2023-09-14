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

            var attackerTooWeak = Level.ExceedByFiveLevel(otherCharacter.Level);
            var attackerTooStrong = otherCharacter.Level.ExceedByFiveLevel(Level);

            var damageToDeal = damage;
            if (attackerTooWeak)
            {
                damageToDeal = damage.HalfDamage;
            }
            else if (attackerTooStrong)
            {
                damageToDeal = damage.IncreasedDamage;
            }

            otherCharacter.SufferDamage(damageToDeal);
        }

        private void SufferDamage(Damage damage)
        {
            Health = Health.InflictDamage(damage);
        }

        public bool IsAlive => Health.Value > 0;
        public Health Health { get; private set;  }
        public Level Level { get; }
    }
}
