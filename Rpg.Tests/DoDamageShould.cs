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

    [Theory]
    [InlineData(true, 999)]
    [InlineData(false, 1001)]
    [InlineData(false, 10001)]
    public void KillCharacter_WhenHealthBelowOne(bool stillAlive, int damage)
    {
        var character = new Character();
        
        character.DoDamage(damage);
        
        Assert.Equal(stillAlive, character.IsAlive);
    }

}