namespace Rpg.Tests;

public class CharacterTests
{
    [Fact]
    public void NewCharacter_HasHealth()
    {
        var c = new Character();

        Assert.Equal(1000, c.Health);
    }

    [Fact]
    public void NewCharacter_HasLevel()
    {
        var c = new Character();

        Assert.Equal(1, c.Level);
    }

    [Fact]
    public void NewCharacter_IsAlive()
    {
        var c = new Character();

        Assert.Equal(CharacterStatus.Alive, c.Status);
    }
}
