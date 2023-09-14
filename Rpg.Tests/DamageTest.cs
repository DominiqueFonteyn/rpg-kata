﻿using System;
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
            Assert.Equal(otherCharacter.Health, 999);
            Assert.True(otherCharacter.Alive);
        }
        [Fact]
        public void DamageKill_Succeed()
        {
            someCharacter.DealDamage(otherCharacter, 1001);
            Assert.Equal(otherCharacter.Health, 0);
            Assert.False(otherCharacter.Alive);
        }

        [Fact]
        public void ExactDamageAlive_Succeed()
        {
            someCharacter.DealDamage(otherCharacter, otherCharacter.Health);
            Assert.Equal(otherCharacter.Health, 0);
            Assert.True(otherCharacter.Alive);
        }

        [Fact]
        public void ThrowArgException_NegativeDamage()
        {
            var ex = Record.Exception(() => someCharacter.DealDamage(otherCharacter, -1));
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("negative damage", ex.Message);
        }
    }
}
