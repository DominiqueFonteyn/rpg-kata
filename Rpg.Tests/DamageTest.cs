using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg.Tests
{
    public class DamageTest : CharacterInteractionBaseTest
    {
        [Fact]
        public void DamageSubstracted_Succeed()
        {
            someCharacter.DealDamage(otherCharacter, 1);
            Assert.Equal(999, otherCharacter.Health);
            Assert.True(otherCharacter.Alive);
        }
        [Fact]
        public void DamageKill_Succeed()
        {
            someCharacter.DealDamage(otherCharacter, 1001);
            Assert.Equal(0, otherCharacter.Health);
            Assert.False(otherCharacter.Alive);
        }

        [Fact]
        public void ExactDamageAlive_Succeed()
        {
            someCharacter.DealDamage(otherCharacter, otherCharacter.Health);
            Assert.Equal(0, otherCharacter.Health);
            Assert.True(otherCharacter.Alive);
        }

        [Fact]
        public void ThrowArgException_NegativeDamage()
        {
            var ex = Record.Exception(() => someCharacter.DealDamage(otherCharacter, -1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("negative damage", ex.Message);
        }

        [Fact]
        public void ThrowArgException_WhenTryToDamageItself()
        {
            
            var ex = Record.Exception(() => someCharacter.DealDamage(someCharacter, 1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Can't damage to itself", ex.Message);
        }

        [Fact]
        public void LevelAbove5Level_DamageShouldReduce50_Succed()
        {
            otherCharacter.Level = 6;
            someCharacter.DealDamage(otherCharacter, 5);
            Assert.Equal(997.5m, otherCharacter.Health );
        }

        [Fact]
        public void LevelBelow5Level_DamageShouldIncrease50_Succed()
        {
            someCharacter.Level = 6;
            someCharacter.DealDamage(otherCharacter, 5);
            Assert.Equal(992.5m, otherCharacter.Health );
        }
    }
}
