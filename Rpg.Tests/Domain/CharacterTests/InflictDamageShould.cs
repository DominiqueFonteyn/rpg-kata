using Rpg.Domain;
using Rpg.Domain.Enums;
using Rpg.Domain.Primitives;

namespace Rpg.Tests.Domain.CharacterTests
{
    public class InflictDamageShould
    {
        [Theory]
        [InlineData(200, 800, true)]
        [InlineData(2000, 0, false)]
        [InlineData(1000, 0, false)]
        public void LowerHealthByDamageValueWithinBounds(int damageValue, int expectedHealth, bool isAlive)
        {
            var attacker = CharacterCreator.Build().Create();
            var defender = CharacterCreator.Build().Create();

            attacker.InflictDamage(defender, new Damage(damageValue));

            Assert.Equal(expectedHealth, defender.Health.Value);
            Assert.Equal(isAlive, defender.IsAlive);
        }

        [Fact]
        public void NotDamageYourself()
        {
            var character = CharacterCreator.Build().Create();

            character.InflictDamage(character, new Damage(200));

            Assert.Equal(new Health(Health.MaxHealth), character.Health);
        }

        [Fact]
        public void ReduceBy50Percent_WhenDamagingAStrongerCharacter()
        {
            var strongCharacter = CharacterCreator.Build().WithLevel(new Level(6)).Create();
            var weakCharacter = CharacterCreator.Build().WithLevel(new Level(1)).Create();

            weakCharacter.InflictDamage(strongCharacter, new Damage(200));

            Assert.Equal(new Health(900), strongCharacter.Health);
        }

        [Fact]
        public void IncreaseDamageBy50Percent_WhenDamagingAWeakerCharacter()
        {
            var strongCharacter = CharacterCreator.Build().WithLevel(new Level(6)).Create();
            var weakCharacter = CharacterCreator.Build().WithLevel(new Level(1)).Create();

            strongCharacter.InflictDamage(weakCharacter, new Damage(200));

            Assert.Equal(new Health(700), weakCharacter.Health);
        }

        [Theory]
        [InlineData(FightingType.Ranged, FighterType.MaxRangedRange + 1)]
        [InlineData(FightingType.Melee, FighterType.MaxMeleeRange + 1)]
        public void NotInflictDamage_WhenOutOfRange(FightingType fightingType, int position)
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
        public void InflictDamage_WhenInRange(FightingType fightingType, int position)
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
