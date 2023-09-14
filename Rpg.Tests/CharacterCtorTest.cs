namespace Rpg.Tests
{
    public class CharacterCtorTest
    {
        [Fact]
        public void CreateMeleeCharacter_CorrectValues()
        {
            var character = new MeleeCharacter();
            Assert.Equal(1, character.Level);
            Assert.Equal(1000, character.Health);
            Assert.True(character.Alive);
            Assert.Equal(2, character.Range);
        }

        [Fact]
        public void CreateRangedCharacter_CorrectValues()
        {
            var character = new MeleeCharacter();
            Assert.Equal(1, character.Level);
            Assert.Equal(1000, character.Health);
            Assert.True(character.Alive);
            Assert.Equal(20, character.Range);
        }
    }
}
