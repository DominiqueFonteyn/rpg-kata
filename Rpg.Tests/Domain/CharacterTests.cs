using Rpg.Domain;
using Rpg.Domain.Enums;
using Rpg.Domain.Primitives;
using Rpg.Faults;

namespace Rpg.Tests.Domain
{
    public class CharacterTests
    {
        [Fact]
        public void WhenCreated_ShouldHave1000Health()
        {
            var character = CharacterCreator.Build().Create();

            Assert.Equal(new Health(1000), character.Health);
        }

        [Fact]
        public void WhenCreated_ShouldBeLevelOne()
        {
            var character = CharacterCreator.Build().Create();

            Assert.Equal(new Level(1), character.Level);
        }

        [Fact]
        public void IsAlive_WhenHealthBelowZero_ReturnsFalse()
        {
            var character = CharacterCreator.Build().WithHealth(new Health(-100)).Create();

            Assert.False(character.IsAlive);
        }

        [Fact]
        public void IsAlive_WhenHealthGreaterThanZero_ReturnsTrue()
        {
            var character = CharacterCreator.Build().WithHealth(new Health(500)).Create();

            Assert.True(character.IsAlive);
        }

        [Theory]
        [InlineData(200, 800, true)] 
        [InlineData(2000, 0, false)]
        [InlineData(1000, 0, false)]
        public void InflictDamage_LowersHealthByDamageValueWithinBounds(int damageValue, int expectedHealth, bool isAlive)
        {
            var attacker = CharacterCreator.Build().Create();
            var defender = CharacterCreator.Build().Create();

            attacker.InflictDamage(defender, new Damage(damageValue));

            Assert.Equal(expectedHealth, defender.Health.Value);
            Assert.Equal(isAlive, defender.IsAlive);
        }

        [Fact]
        public void Heal_WhenDead_CannotBeHealed()
        {
            var deadCharacter = CharacterCreator.Build().WithHealth(new Health(0)).Create();

            Assert.Throws<CharacterAlreadyDeadException>(
                () => deadCharacter.Heal(new HealingAmount(10)));
        }

        [Fact]
        public void Heal_WhenAlreadyMaxHealth_CannotBeHealed()
        {
            var maxHealthCharacter = CharacterCreator.Build().WithHealth(new Health(1000)).Create();

            maxHealthCharacter.Heal(new HealingAmount(200));

            Assert.Equal(new Health(1000), maxHealthCharacter.Health);
        }

        [Fact]
        public void Heal_HealsCharacter()
        {
            var damagedCharacter = CharacterCreator.Build().WithHealth(new Health(250)).Create();

            damagedCharacter.Heal(new HealingAmount(200));

            Assert.Equal(new Health(450), damagedCharacter.Health);

        }

        [Fact]
        public void ACharacterCannotDamageToHimself()
        {
            var character = CharacterCreator.Build().Create();

            character.InflictDamage(character, new Damage(200));

            Assert.Equal(new Health(Health.MaxHealth), character.Health);
        }

        [Fact]
        public void WhenDamagingAFighterWith5LevelsAboveMyDamageIsReducedBy50Percent()
        {
            var strongCharacter = CharacterCreator.Build().WithLevel(new Level(6)).Create();
            var weakCharacter = CharacterCreator.Build().WithLevel(new Level(1)).Create();

            weakCharacter.InflictDamage(strongCharacter, new Damage(200));

            Assert.Equal(new Health(900), strongCharacter.Health);
        }

        [Fact]
        public void WhenDamagingAFighterWith5LevelsBelow_DamageIsIncreasedBy50Percent()
        {
            var strongCharacter = CharacterCreator.Build().WithLevel(new Level(6)).Create();
            var weakCharacter = CharacterCreator.Build().WithLevel(new Level(1)).Create();

            strongCharacter.InflictDamage(weakCharacter, new Damage(200));

            Assert.Equal(new Health(700), weakCharacter.Health);
        }

        [Theory]
        [InlineData(FightingType.Ranged, FighterType.MaxRangedRange + 1)]
        [InlineData(FightingType.Melee, FighterType.MaxMeleeRange + 1)]
        public void InflictDamage_WhenOutOfRange_DoesNotInflictDamage(FightingType fightingType, int position)
        {
            var defender = CharacterCreator.Build()
                .OfType(new FighterType(fightingType))
                .AtPosition(new Position(0))
                .Create();
            var attacker = CharacterCreator.Build()
                .OfType(new FighterType(fightingType))
                .AtPosition(new Position(position))
                .Create();

            attacker.InflictDamage(defender, new Damage(100));

            Assert.Equal(new Health(Health.StartingValue), defender.Health);
        }
        
        [Theory]
        [InlineData(FightingType.Ranged, FighterType.MaxRangedRange - 1)]
        [InlineData(FightingType.Melee, FighterType.MaxMeleeRange - 1)]
        public void InflictDamage_WhenInRange_DoesInflictDamage(FightingType fightingType, int position)
        {
            var defender = CharacterCreator.Build()
                .OfType(new FighterType(fightingType))
                .AtPosition(new Position(0))
                .Create();
            var attacker = CharacterCreator.Build()
                .OfType(new FighterType(fightingType))
                .AtPosition(new Position(position))
                .Create();

            attacker.InflictDamage(defender, new Damage(100));

            Assert.Equal(new Health(900), defender.Health);
        }
    }
}