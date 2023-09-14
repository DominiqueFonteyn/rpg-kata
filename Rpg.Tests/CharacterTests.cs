namespace Rpg.Tests;

public class CharacterTests
{
    public CharacterTests()
    {
    }

    [Fact]
    public void WhenCreatingACharacter_ShouldHaveHealthEqual1000()
    {
        var character = new Character();
        
        Assert.Equal(1000, character.Health);
    }

    [Fact]
    public void WhenCreatingACharacter_ShouldBeLevel1()
    {
        var character = new Character();
        
        Assert.Equal(1, character.Level);
    }
}

public class Character
{
    private const int StartingHealth = 1000;
    private const int StartingLevel = 1;
    public Character()
    {
        Health = StartingHealth;
        Level = StartingLevel;
    }

    public int Health { get; private set; }
    public int Level { get; private set; }
}