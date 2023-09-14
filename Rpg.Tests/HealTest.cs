using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg.Tests
{
    public class HealTest
    {
        private Character someCharacter = new Character("Character1");
        private Character otherCharacter = new Character("Character2");

        [Fact]
        public void Exception_CharacterDead()
        {
            otherCharacter.Alive = false;
            var ex = Record.Exception(() => someCharacter.Heal(otherCharacter, 1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("dead", ex.Message);
        }

        [Fact]
        public void Heal_Succeed()
        {
            otherCharacter.Health = 1;
            someCharacter.Heal(otherCharacter, 1);
            Assert.True(otherCharacter.Alive);
            Assert.Equal(2, otherCharacter.Health);
        }

        [Fact]
        public void HealOverflow_CutOff()
        {
            otherCharacter.Health = 999;
            someCharacter.Heal(otherCharacter, 2);
            Assert.True(otherCharacter.Alive);
            Assert.Equal(1000, otherCharacter.Health);
        }

        [Fact]
        public void Exception_NegativeAmount()
        {
            var ex = Record.Exception(() => someCharacter.Heal(otherCharacter, -1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("negative amount", ex.Message);
        }

    }
}
