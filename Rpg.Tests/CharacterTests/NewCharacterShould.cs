namespace Rpg.Tests.CharacterTests;

public class NewCharacterShould : CharacterTestBase
{
    [Fact]
    public void HaveInitialHealth()
    {
        var c = new Character();

        Assert.Equal(MaximumHealth, c.CurrentHealth);
    }

    [Fact]
    public void HaveInitialLevel()
    {
        var c = new Character();

        Assert.Equal(1, c.Level);
    }

    [Fact]
    public void BeAlive()
    {
        var c = new Character();

        Assert.Equal(CharacterStatus.Alive, c.Status);
    }
}
