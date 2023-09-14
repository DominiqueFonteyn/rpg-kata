using Rpg.Domain;
using Rpg.Domain.Primitives;
using Rpg.Faults;

namespace Rpg.Tests.Domain.CharacterTests
{
    public class HealShould
    {
        [Fact]
        public void NotHeal_WhenDead()
        {
            var deadCharacter = CharacterCreator.Build().WithHealth(new Health(0)).Create();

            Assert.Throws<CharacterAlreadyDeadException>(
                () => deadCharacter.Heal(new HealingAmount(10)));
        }

        [Fact]
        public void NotHeal_WhenAtMaxHealth()
        {
            var maxHealthCharacter = CharacterCreator.Build().WithHealth(new Health(1000)).Create();

            maxHealthCharacter.Heal(new HealingAmount(200));

            Assert.Equal(new Health(1000), maxHealthCharacter.Health);
        }

        [Fact]
        public void HealCharacter()
        {
            var damagedCharacter = CharacterCreator.Build().WithHealth(new Health(250)).Create();

            damagedCharacter.Heal(new HealingAmount(200));

            Assert.Equal(new Health(450), damagedCharacter.Health);

        }
    }
}
