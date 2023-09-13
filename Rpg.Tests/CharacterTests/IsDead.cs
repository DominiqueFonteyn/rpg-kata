namespace Rpg.Tests.CharacterTests;

public class IsDead : CharacterTestBase
{
    [Fact]
    public void StatusEqualsDead_ReturnsTrue()
    {
        var player = new Character();
        var target = new Character();

        player.Damage(target, MaximumHealth + 100);

        Assert.True(target.IsDead);
    }

    [Fact]
    public void StatusEqualAlive_ReturnsAlive()
    {
        var player = new Character();

        Assert.False(player.IsDead);
    }
}