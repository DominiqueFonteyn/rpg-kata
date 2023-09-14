using Rpg.Domain;
using Rpg.Domain.Primitives;
using Rpg.Faults;

namespace Rpg.Tests.Domain
{
    public class CharacterTests
    {
        [Fact]
        public void WhenCreated_ShouldHave1000Health()
        {
            var character = new Character();

            Assert.Equal(new Health(1000), character.Health);
        }

        [Fact]
        public void WhenCreated_ShouldBeLevelOne()
        {
            var character = new Character();

            Assert.Equal(new Level(1), character.Level);
        }

        [Fact]
        public void IsAlive_WhenHealthBelowZero_ReturnsFalse()
        {
            var character = new Character(new Health(-100));

            Assert.False(character.IsAlive);
        }

        [Fact]
        public void IsAlive_WhenHealthGreaterThanZero_ReturnsTrue()
        {
            var character = new Character(new Health(500));

            Assert.True(character.IsAlive);
        }

        [Theory]
        [InlineData(200, 800, true)] 
        [InlineData(2000, 0, false)]
        [InlineData(1000, 0, false)]
        public void InflictDamage_LowersHealthByDamageValueWithinBounds(int damageValue, int expectedHealth, bool isAlive)
        {
            var attacker = new Character();
            var defender = new Character();

            attacker.InflictDamage(defender, new Damage(damageValue));

            Assert.Equal(expectedHealth, defender.Health.Value);
            Assert.Equal(isAlive, defender.IsAlive);
        }

        [Fact]
        public void Heal_WhenDead_CannotBeHealed()
        {
            var healer = new Character();
            var deadCharacter = new Character(new Health(0));

            Assert.Throws<CharacterAlreadyDeadException>(
                () => healer.Heal(deadCharacter, new HealthAmount(10)));
        }

        [Fact]
        public void Heal_WhenAlreadyMaxHealth_CannotBeHealed()
        {
            var healer = new Character();
            var maxHealthCharacter = new Character(new Health(1000));

            healer.Heal(maxHealthCharacter, new HealthAmount(200));

            Assert.Equal(new Health(1000), maxHealthCharacter.Health);
        }

        [Fact]
        public void Heal_HealsCharacter()
        {
            var healer = new Character();
            var damagedCharacter = new Character(new Health(250));

            healer.Heal(damagedCharacter, new HealthAmount(200));

            Assert.Equal(new Health(450), damagedCharacter.Health);

        }
    }
}