namespace Rpg.Tests.CharacterTests;

public class ReceiveHealing : CharacterTestBase
{
    [Fact]
    public void IncreasesCurrentHealth()
    {
        const int damage = 500;
        const int health = 100;
        var player = new Character();
        player.TakeDamage(damage);

        player.ReceiveHealing(health);

        Assert.Equal(MaximumHealth - damage + health, player.CurrentHealth);
    }

    [Fact]
    public void ExceedsMaxHealth_ResetsToMaxHealth()
    {
        var player = new Character();

        player.ReceiveHealing(100);

        Assert.Equal(MaximumHealth, player.CurrentHealth);
    }
}
