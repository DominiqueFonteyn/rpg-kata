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

        [Fact]
        public void Damage_10_Health990()
        {
            var ole = new Character();
            var simon = new Character();

            ole.Damage(simon, 10);

            Assert.Equal(990, simon.Health);
        }
    }

    public class Character
    {

        public int Health { get; } = 1000;
        public int Level { get; } = 1;
        public bool IsAlive { get; } = true;

        public void Damage(Character simon, int damage)
        {
            throw new NotImplementedException();
        }
    }
}
