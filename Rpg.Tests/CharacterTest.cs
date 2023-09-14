using Xunit;

namespace Rpg.Tests
{
    public class CharacterTest
    {
        [Fact]
        public void Health_StartsAt1000()
        {
            var character = new Character();

            Assert.Equal(1000, character.Health);
        }
    }

    public class Character
    {
        public Character()
        {
        }

        public int Health { get; internal set; }
    }
}
