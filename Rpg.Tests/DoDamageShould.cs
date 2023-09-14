namespace Rpg.Tests;

public class DoDamageShould
{
    [Fact]
    public void SubstractFromVictimsHealth()
    {
        var hunter = new Character();
        var victim = new Character();
        var initialHealth = victim.Health;
        var damage = 1;
        
        hunter.DoDamage(victim, damage);
        
        Assert.Equal(initialHealth-damage, victim.Health);
    }

    [Theory]
    [InlineData(true, 999)]
    [InlineData(false, 1001)]
    [InlineData(false, 10001)]
    public void KillVictim_WhenHealthBelowOne(bool stillAlive, int damage)
    {
        var hunter = new Character();
        var victim = new Character();
        
        hunter.DoDamage(victim, damage);
        
        Assert.Equal(stillAlive, victim.IsAlive);
    }

    [Fact]
    public void DamageSomebodyElse()
    {
        var hunter = new Character();
        var victim = new Character();
        var damage = 100;
        var initialhunterHealth = 600;

        hunter.Health = initialhunterHealth;
        
        hunter.DoDamage(victim, damage);
        
        Assert.Equal(900, victim.Health);
        Assert.Equal(initialhunterHealth, hunter.Health);
        
    }

    [Fact]
    public void NotDamageItself()
    {
        var hunter = new Character();
        var damage = 100;
        
        hunter.DoDamage(hunter, damage);
        
        Assert.Equal(1000, hunter.Health);
    }

}