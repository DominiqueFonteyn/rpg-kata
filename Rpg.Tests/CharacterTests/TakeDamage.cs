namespace Rpg.Tests.CharacterTests;

public class TakeDamage : CharacterTestBase
{
    [Fact]
    public void ReducesHealth()
    {
        const int damage = 300;
        var player = new Character();

        player.TakeDamage(damage);

        Assert.Equal(MaximumHealth - damage, player.CurrentHealth);
    }

    [Fact]
    public void DamageExceedsCurrentHealth_Dies()
    {
        var player = new Character();

        player.TakeDamage(MaximumHealth + 300);

        Assert.Equal(CharacterStatus.Dead, player.Status);
    }

    [Fact]
    public void DamageExceedsCurrentHealth_HealthIsZero()
    {
        var player = new Character();

        player.TakeDamage(MaximumHealth + 300);

        Assert.Equal(MinimumHealth, player.CurrentHealth);
    }

    [Fact]
    public void HealthMoreThanZero_StillAlive()
    {
        var player = new Character();

        player.TakeDamage(MaximumHealth - 300);

        Assert.Equal(CharacterStatus.Alive, player.Status);
    }
}
