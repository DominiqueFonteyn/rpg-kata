using Xunit;

namespace Rpg.Tests
{
    public class CharacterTest
    {
        [Fact]
        public void Health_StartsAt1000()
        {
            var character = new Character()
            {
                Health = 1000,
            };
            Assert.Equal(1000, character.Health);
        }
            [Fact]
            public void LevelStart1()
            {
            var character = new Character()
            {
                Health = 1000,
                Level = 1,
            };
            Assert.Equal(1, character.Level);

        }
    }

    public class Character
    {
        public Character()
        {
        }

        public int Health { get; internal set; }
        public int Level { get; internal set; }
    }
}
