using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public bool Alive { get; set; }

        public Character(string name)
        {
            Name = name;
            Health = 1000;
            Level = 1;
            Alive = true;
        }

        public void DealDamage(Character target, int damage)
        {
            if (damage < 0)
                throw new ArgumentException("negative damage");
            if (target == this)
                throw new ArgumentException("Can't damage to itself");

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
