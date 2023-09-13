using NSubstitute;

namespace Rpg.Tests;

public class CharacterTests
{
    private const int MaximumHealth = 1000;
    private const int MinimumHealth = 0;

    [Fact]
    public void NewCharacter_HasHealth()
    {
        var c = new Character();

        Assert.Equal(MaximumHealth, c.Health);
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

        Assert.Equal(MaximumHealth - damage, player.Health);
    }

    [Fact]
    public void TakeDamage_DamageExceedsCurrentHealth_Dies()
    {
        var player = new Character();

        player.TakeDamage(MaximumHealth + 300);

        Assert.Equal(CharacterStatus.Dead, player.Status);
    }

    [Fact]
    public void TakeDamage_DamageExceedsCurrentHealth_HealthIsZero()
    {
        var player = new Character();

        player.TakeDamage(MaximumHealth + 300);

        Assert.Equal(MinimumHealth, player.Health);
    }

    [Fact]
    public void TakeDamage_HealthMoreThanZero_StillAlive()
    {
        var player = new Character();

        player.TakeDamage(MaximumHealth - 300);

        Assert.Equal(CharacterStatus.Alive, player.Status);
    }

    [Fact]
    public void IsDead_StatusEqualsDead_ReturnsTrue()
    {
        var player = new Character();
        var target = new Character();
        
        player.Damage(target, MaximumHealth + 100);
        
        Assert.True(target.IsDead);
    }
    
    [Fact]
    public void IsDead_StatusEqualAlive_ReturnsAlive()
    {
        var player = new Character();

        Assert.False(player.IsDead);
    }

    [Fact]
    public void Heal_CallsIsDead()
    {
        var player = new Character();
        var target = Substitute.For<IReceiveHealing>();
        target.IsDead.Returns(false);

        player.Heal(target, 500);

        _ = target
            .Received(1)
            .IsDead;
    }

    [Fact]
    public void Heal_TargetNotDead_CallsReceiveHealing()
    {
        const int health = 300;
        var player = new Character();
        var target = Substitute.For<IReceiveHealing>();
        target.IsDead.Returns(false);

        player.Heal(target, health);

        target
            .Received(1)
            .ReceiveHealing(health);
    }

    [Fact]
    public void Heal_TargetDead_DoesNotCallReceiveHealing()
    {
        var player = new Character();
        var target = Substitute.For<IReceiveHealing>();
        target.IsDead.Returns(true);

        player.Heal(target, 500);

        target
            .DidNotReceive()
            .ReceiveHealing(Arg.Any<int>());
    }
}
