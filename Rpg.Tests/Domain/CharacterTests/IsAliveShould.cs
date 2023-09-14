using Rpg.Domain;
using Rpg.Domain.Primitives;

namespace Rpg.Tests.Domain.CharacterTests
{
    public class IsAliveShould
    {
        [Fact]
        public void ReturnFalse_WhenHealthBelowZero()
        {
            var character = CharacterCreator.Build().WithHealth(new Health(-100)).Create();

            Assert.False(character.IsAlive);
        }

        [Fact]
        public void ReturnTrue_WhenHealthGreaterThanZero()
        {
            var character = CharacterCreator.Build().WithHealth(new Health(500)).Create();

            Assert.True(character.IsAlive);
        }
    }
}
