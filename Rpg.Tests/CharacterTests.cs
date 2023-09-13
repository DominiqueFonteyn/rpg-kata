using NSubstitute;

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

    [Fact]
    public void Damage_CallsTakeDamage()
    {
        var player = new Character();
        var target = Substitute.For<ITakeDamage>();

        player.Damage(target, 300);
        
        target.Received(1).TakeDamage(300);
    }

    [Fact]
    public void TakeDamage_ReducesHealth()
    {
        var player = new Character();
        
        player.TakeDamage(300);
        
        Assert.Equal(700, player.Health);
    }
    
}


