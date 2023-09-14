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
    }
}
