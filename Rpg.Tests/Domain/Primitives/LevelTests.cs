using Rpg.Domain.Primitives;

namespace Rpg.Tests.Domain.Primitives
{
    public class LevelTests
    {
        [Fact]
        public void Ctor_InitializesToOne()
        {
            var level = new Level();

            Assert.Equal(Level.InitialLevel, level.Value);
        }

        [Theory]
        [InlineData(1, 5, false)]
        [InlineData(1, 6, true)]
        public void CheckDifferenceByFive(int lower, int upper, bool isGreaterBy5)
        {
            var lowerLevel = new Level(lower);
            var upperLevel = new Level(upper);

            var exceedByFive = lowerLevel.ExceedByFiveLevel(upperLevel);

            Assert.Equal(isGreaterBy5, exceedByFive);
        }

    }
}
