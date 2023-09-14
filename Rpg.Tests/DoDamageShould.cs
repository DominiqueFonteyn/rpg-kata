namespace Rpg.Tests;

public class DoDamageShould
{
    [Fact]
    public void SubstractFromHealth()
    {
        var character = new Character();
        var initialHealth = character.Health;
        var damage = 1;
        
        character.DoDamage(damage);
        
        Assert.Equal(initialHealth-damage, character.Health);
    }

}