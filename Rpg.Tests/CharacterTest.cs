using System.Runtime.Intrinsics.Arm;
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
        [Fact]
        public void TestKill()
        {
            var simon = new Character();
            var ole = new Character();
            simon.Damage(ole, ole.Health + 10);
            Assert.False(ole.IsAlive);
        }
    }
    public class Character
    {

        public int Health { get; protected set; } = 1000;
        public int Level { get; protected set; } = 1;
        public bool IsAlive { get; protected set; } = true;

        public void Damage(Character simon, int damage)
        {
            simon.Health = simon.Health-damage;
        }
    }
}
