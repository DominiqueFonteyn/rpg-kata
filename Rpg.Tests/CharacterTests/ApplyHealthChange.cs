namespace Rpg.Tests.CharacterTests;

public class ApplyHealthChange : CharacterTestBase
{
    [Fact]
    public void ReceiveHealing_IncreasesHealth()
    {
        var player = new Character();
        player.TakeDamage(500);
        
        player.ApplyHealthChange(HealthModifier.Healing(200));
        
        Assert.Equal(700, player.CurrentHealth);
    }
    
    [Fact]
    public void TakeDamage_IncreasesHealth()
    {
        var player = new Character();
        
        player.ApplyHealthChange(HealthModifier.Damage(200));
        
        Assert.Equal(800, player.CurrentHealth);
    }
}
