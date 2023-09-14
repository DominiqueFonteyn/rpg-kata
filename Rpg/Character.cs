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
            target.Health -= damage;
            if (target.Health < 0)
            {
                target.Health = 0;
                target.Alive = false;
            }
        }

    }
}
