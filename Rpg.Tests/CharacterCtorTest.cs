namespace Rpg.Tests
{
    public class CharacterCtorTest
    {

        private void AssertBaseValues(Character character)
        {
            Assert.Equal(1, character.Level);
            Assert.Equal(1000, character.Health);
            Assert.True(character.Alive);
            Assert.Equal(0, character.Position.x);

        }
        [Fact]
        public void CreateMeleeCharacter_CorrectValues()
        {
            var character = new MeleeCharacter();
            AssertBaseValues(character);
            Assert.Equal(2, character.Range);
        }

        [Fact]
        public void CreateRangedCharacter_CorrectValues()
        {
            var character = new RangedCharacter();
            AssertBaseValues(character);
            Assert.Equal(20, character.Range);
        }
    }
}
