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
            var deadCharacter = new Character(new Health(0));

            Assert.Throws<CharacterAlreadyDeadException>(
                () => deadCharacter.Heal(new HealingAmount(10)));
        }

        [Fact]
        public void Heal_WhenAlreadyMaxHealth_CannotBeHealed()
        {
            var maxHealthCharacter = new Character(new Health(1000));

            maxHealthCharacter.Heal(new HealingAmount(200));

            Assert.Equal(new Health(1000), maxHealthCharacter.Health);
        }

        [Fact]
        public void Heal_HealsCharacter()
        {
            var damagedCharacter = new Character(new Health(250));

            damagedCharacter.Heal(new HealingAmount(200));

            Assert.Equal(new Health(450), damagedCharacter.Health);

        }

        [Fact]
        public void ACharacterCannotDamageToHimself()
        {
            var character = new Character();

            character.InflictDamage(character, new Damage(200));

            Assert.Equal(new Health(Health.MaxHealth), character.Health);
        }

        [Fact]
        public void WhenDamagingAFighterWith5LevelsAboveMyDamageIsReducedBy50Percent()
        {
            var character = new Character();

            character.InflictDamage(character, new Damage(200));

            Assert.Equal(new Health(Health.MaxHealth), character.Health);

        }

    }
}