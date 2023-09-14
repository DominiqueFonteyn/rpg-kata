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
            MeleeCharacter.DealDamage(RangedCharacter, 1);
            Assert.Equal(999, RangedCharacter.Health);
            Assert.True(RangedCharacter.Alive);
        }
        [Fact]
        public void DamageKill_Succeed()
        {
            MeleeCharacter.DealDamage(RangedCharacter, 1001);
            Assert.Equal(0, RangedCharacter.Health);
            Assert.False(RangedCharacter.Alive);
        }

        [Fact]
        public void ExactDamageAlive_Succeed()
        {
            MeleeCharacter.DealDamage(RangedCharacter, RangedCharacter.Health);
            Assert.Equal(0, RangedCharacter.Health);
            Assert.True(RangedCharacter.Alive);
        }

        [Fact]
        public void ThrowArgException_NegativeDamage()
        {
            var ex = Record.Exception(() => MeleeCharacter.DealDamage(RangedCharacter, -1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("negative damage", ex.Message);
        }

        [Fact]
        public void ThrowArgException_WhenTryToDamageItself()
        {
            
            var ex = Record.Exception(() => MeleeCharacter.DealDamage(MeleeCharacter, 1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Can't damage to itself", ex.Message);
        }

        [Fact]
        public void LevelAbove5Level_DamageShouldReduce50_Succed()
        {
            RangedCharacter.Level = 6;
            MeleeCharacter.DealDamage(RangedCharacter, 5);
            Assert.Equal(997.5m, RangedCharacter.Health );
        }

        [Fact]
        public void LevelBelow5Level_DamageShouldIncrease50_Succed()
        {
            MeleeCharacter.Level = 6;
            MeleeCharacter.DealDamage(RangedCharacter, 5);
            Assert.Equal(992.5m, RangedCharacter.Health );
        }

        [Fact]
        public void LevelMoreThan5Greater_RawDamageDoesntKill()
        {
            RangedCharacter.Level = 6;
            MeleeCharacter.DealDamage(RangedCharacter, 1001);
            Assert.True(RangedCharacter.Alive);
            Assert.Equal(499.5m, RangedCharacter.Health);
        }

        [Fact]
        public void LevelMoreThan5Below_AddedDamageKills()
        {
            MeleeCharacter.Level = 6;
            MeleeCharacter.DealDamage(RangedCharacter, 667);
            Assert.False(RangedCharacter.Alive);
            Assert.Equal(0, RangedCharacter.Health);
        }

        [Fact]
        public void MeleeCharacterInRange_DealDamageSucceed()
        {
            RangedCharacter.Position.x = 1;
            MeleeCharacter.DealDamage(RangedCharacter, 1);
            Assert.Equal(999, RangedCharacter.Health);
        }

        [Fact]
        public void Exception_MeleeCharacterOutsideRange()
        {
            RangedCharacter.Position.x = 5;
            var ex = Record.Exception(() => MeleeCharacter.DealDamage(RangedCharacter, 1));
            Assert.IsType<TargetOutOfRangeException>(ex);
            Assert.Equal("Target out of range", ex.Message);
        }

        [Fact]
        public void RangedCharacterInRange_DealDamageSucceed()
        {
            RangedCharacter.Position.x = 13;
            RangedCharacter.DealDamage(MeleeCharacter, 1);
            Assert.Equal(999, MeleeCharacter.Health);
        }

        [Fact]
        public void Exception_RangedCharacterOutsideRange()
        {
            RangedCharacter.Position.x = 30;
            var ex = Record.Exception(() => RangedCharacter.DealDamage(MeleeCharacter, 1));
            Assert.IsType<TargetOutOfRangeException>(ex);
            Assert.Equal("Target out of range", ex.Message);
        }
    }
}
