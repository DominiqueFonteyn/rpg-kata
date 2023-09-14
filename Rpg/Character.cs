using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    public abstract class Character
    {
        public decimal Health { get; set; } = 1000;
        public int Level { get; set; } = 1;
        public bool Alive { get; set; } = true;

        public abstract int Range { get; }

        public void DealDamage(Character target, decimal damage)
        {
            if (damage < 0)
                throw new ArgumentException("negative damage");
            if (target == this)
                throw new ArgumentException("Can't damage to itself");
            if (target.Level - Level >= 5)
                damage = damage / 2;
            if ( Level - target.Level >= 5)
                damage = damage + damage/2;

            target.Health -= damage;
            if (target.Health < 0)
            {
                target.Health = 0;
                target.Alive = false;
            }
        }

        public void Heal(Character target, int amount)
        {
            if(target != this)
                 throw new ArgumentException("Cannot heal other character");
            if (!target.Alive)
                throw new ArgumentException("dead");
            if (amount < 0)
                throw new ArgumentException("negative amount");
            target.Health += amount;
            if (target.Health > 1000)
                target.Health = 1000;
        }
    }
}
