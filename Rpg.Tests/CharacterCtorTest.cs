namespace Rpg.Tests
{
    public class CharacterCtorTest
    {
        [Fact]
        public void CreateCharacter_CorrectValues()
        {
            var character = new Character("test");
            Assert.Equal("test", character.Name);
            Assert.Equal(1, character.Level);
            Assert.Equal(1000, character.Health);
            Assert.True(character.Alive);
        }
    }
}
