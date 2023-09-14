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

        [Fact]
        public void LevelStart1()
        {
            var character = new Character();

            Assert.Equal(1, character.Level);
        }

        [Fact]
        public void StartingAlive()
        {
            var character = new Character();

            Assert.True(character.IsAlive);
        }
    }

    public class Character
    {
        public Character()
        {
            Health = 1000;
            Level = 1;
        }

        public int Health { get; }
        public int Level { get; }
        public bool IsAlive { get; }
    }
}
