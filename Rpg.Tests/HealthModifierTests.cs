namespace Rpg.Tests;

public class HealthModifierTests
{
    [Fact]
    public void Healing_ReturnsReceiveHealing()
    {
        var result = HealthModifier.Healing(500);

        Assert.IsType<ReceiveHealing>(result);
        Assert.Equal(500, result.Amount);
    }
    
    [Fact]
    public void Damage_ReturnsTakeDamage()
    {
        var result = HealthModifier.Damage(500, DamageMagnifier.None);

        Assert.IsType<TakeDamage>(result);
        Assert.Equal(-500, result.Amount);
    }
}