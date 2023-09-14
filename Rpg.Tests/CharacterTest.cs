namespace Rpg.Tests
{
    public class CharacterTest:CharacterInteractionBaseTest
    {

        private void AssertBaseValues(Character character)
        {
            Assert.Equal(1, character.Level);
            Assert.Equal(1000, character.Health);
            Assert.True(character.Alive);
            Assert.Equal(0, character.Position.x);
            Assert.Empty(character.Factions);

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

        [Fact]
        public void JoinFactions_Succed()
        {
            MeleeCharacter.JoinFactions("newFaction");
            Assert.Contains("newFaction", MeleeCharacter.Factions);

        }

        [Fact]
        public void LeaveFactions_Succed()
        {
            MeleeCharacter.JoinFactions("faction");
            MeleeCharacter.LeaveFactions("faction");
            Assert.DoesNotContain("faction", MeleeCharacter.Factions);

        }
    }
}
