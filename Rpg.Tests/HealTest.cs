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
            var ex = Record.Exception(() => MeleeCharacter.Heal(RangedCharacter, 1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Cannot heal other character", ex.Message);
        }

        [Fact]
        public void Exception_CharacterDead()
        {
            MeleeCharacter.Alive = false;
            var ex = Record.Exception(() => MeleeCharacter.Heal(MeleeCharacter, 1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("dead", ex.Message);
        }

        [Fact]
        public void Heal_Succeed()
        {
            MeleeCharacter.Health = 1;
            MeleeCharacter.Heal(MeleeCharacter, 1);
            Assert.True(MeleeCharacter.Alive);
            Assert.Equal(2, MeleeCharacter.Health);
        }

        [Fact]
        public void HealOverflow_CutOff()
        {
            MeleeCharacter.Health = 999;
            MeleeCharacter.Heal(MeleeCharacter, 2);
            Assert.True(MeleeCharacter.Alive);
            Assert.Equal(1000, MeleeCharacter.Health);
        }

        [Fact]
        public void Exception_NegativeAmount()
        {
            var ex = Record.Exception(() => MeleeCharacter.Heal(MeleeCharacter, -1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("negative amount", ex.Message);
        }

    }
}
