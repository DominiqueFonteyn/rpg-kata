namespace Rpg.Tests;

public class CharacterTests
{
    [Fact]
    public void CreatedCharacter_HasHealthEqualTo1000()
    {
        var character = new Character();
        
        Assert.Equal(1000, character.Health);
    }
}