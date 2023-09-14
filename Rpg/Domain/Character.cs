using Rpg.Domain.Primitives;
using Rpg.Faults;

namespace Rpg.Domain
{
    public class Character
    {
        public Character()
        {
            Health = new Health();
            Level = new Level();
        }

        public Character(Health health)
        {
            Health = health;
        }

        public void Heal(Character otherCharacter, HealingAmount amount)
        {
            if (!otherCharacter.IsAlive)
            {
                throw new CharacterAlreadyDeadException();
            }

            otherCharacter.Health = otherCharacter.Health.Heal(amount);
        }

        public void InflictDamage(Character otherCharacter, Damage damage)
        {
            otherCharacter.SufferDamage(damage);
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
