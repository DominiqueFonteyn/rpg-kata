using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg.Tests
{
    public class HealTest : CharacterInteractionBaseTest
    {
        
        [Fact]
        public void ThrowArgException_WhenTryToHealOther()
        {
            var ex = Record.Exception(() => someCharacter.Heal(otherCharacter, 1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Cannot heal other character", ex.Message);
        }

        [Fact]
        public void Exception_CharacterDead()
        {
            someCharacter.Alive = false;
            var ex = Record.Exception(() => someCharacter.Heal(someCharacter, 1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("dead", ex.Message);
        }

        [Fact]
        public void Heal_Succeed()
        {
            someCharacter.Health = 1;
            someCharacter.Heal(someCharacter, 1);
            Assert.True(someCharacter.Alive);
            Assert.Equal(2, someCharacter.Health);
        }

        [Fact]
        public void HealOverflow_CutOff()
        {
            someCharacter.Health = 999;
            someCharacter.Heal(someCharacter, 2);
            Assert.True(someCharacter.Alive);
            Assert.Equal(1000, someCharacter.Health);
        }

        [Fact]
        public void Exception_NegativeAmount()
        {
            var ex = Record.Exception(() => someCharacter.Heal(someCharacter, -1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("negative amount", ex.Message);
        }

    }
}
