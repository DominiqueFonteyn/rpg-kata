using NSubstitute;

namespace Rpg.Tests;

public class CharacterTests
{
    private const int InitialHealth = 1000;
    private const int MinimumHealth = 0;

    [Fact]
    public void NewCharacter_HasHealth()
    {
        var c = new Character();

        Assert.Equal(InitialHealth, c.Health);
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
        const int damage = 300;
        var player = new Character();
        var target = Substitute.For<ITakeDamage>();

        player.Damage(target, damage);
        
        target
            .Received(1)
            .TakeDamage(damage);
    }

    [Fact]
    public void TakeDamage_ReducesHealth()
    {
        const int damage = 300;
        var player = new Character();

        player.TakeDamage(damage);
        
        Assert.Equal(InitialHealth - damage, player.Health);
    }

    [Fact]
    public void TakeDamage_DamageExceedsCurrentHealth_Dies()
    {
        var player = new Character();
        
        player.TakeDamage(InitialHealth + 300);
        
        Assert.Equal(CharacterStatus.Dead, player.Status);
    }
    
    [Fact]
    public void TakeDamage_DamageExceedsCurrentHealth_HealthIsZero()
    {
        var player = new Character();
        
        player.TakeDamage(InitialHealth + 300);
        
        Assert.Equal(MinimumHealth, player.Health);
    }
    
    [Fact]
    public void TakeDamage_HealthMoreThanZero_StillAlive()
    {
        var player = new Character();
        
        player.TakeDamage(InitialHealth - 300);
        
        Assert.Equal(CharacterStatus.Alive, player.Status);
    }
    
}


