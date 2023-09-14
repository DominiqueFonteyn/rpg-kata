namespace Rpg.Tests;

public class CharacterTests
{
    [Fact]
    public void CreatedCharacter_HasHealthEqualTo1000()
    {
        var character = new Character();
        
        Assert.Equal(1000, character.Health);
    }

    [Fact]
    public void CreatedCharacter_HasLevelEqualTo1()
    {
        var character = new Character();
        
        Assert.Equal(1, character.Level);
    }

    [Fact]
    public void CreatedCharacter_IsAlive()
    {
        var character = new Character();
        
        Assert.True(character.IsAlive);
    }
}