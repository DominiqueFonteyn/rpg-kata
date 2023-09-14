namespace Rpg.Tests;

public class CharacterTests
{
    [Fact]
    public void WhenCreatingAMeleeFighter_ShouldHaveHealthEqual1000()
    {
        var meleeFighter = new MeleeFighter();
        
        Assert.Equal(1000, meleeFighter.Health);
    }

    [Fact]
    public void WhenCreatingAMeleeFighter_ShouldBeLevel1()
    {
        var meleeFighter = new MeleeFighter();
        
        Assert.Equal(1, meleeFighter.Level);
    }

    [Fact]
    public void WhenCreatingAMeleeFighter_ItIsAlive()
    {
        var meleeFighter = new MeleeFighter();
        
        Assert.True(meleeFighter.Alive);
    }

    [Fact]
    public void TakeDamage_WhenTakingDamage_MeleeFighterHealthGoesDown()
    {
        var meleeFighter = new MeleeFighter();

        meleeFighter.TakeDamage(100);
        
        Assert.Equal(900, meleeFighter.Health); 
    }

    [Fact]
    public void TakeDamage_WhenTakingMoreDamageThanHealth_MeleeFighterDiesAndHealthIsZero()
    {
        var meleeFighter = new MeleeFighter();
        
        meleeFighter.TakeDamage(meleeFighter.Health+1);
        
        Assert.Equal(0, meleeFighter.Health);
        Assert.False(meleeFighter.Alive);
    }

    [Fact]
    public void Heal_WhenHealingNegativeAmount_ThrowException()
    {
        var meleeFighter = new MeleeFighter();
        
        void Act() => meleeFighter.HealSelf(-10);

        Assert.Throws<ApplicationException>(Act);
    }
    
    [Fact]
    public void Heal_WhenMeleeFighterIsHealed_IncreaseHealth()
    {
        var meleeFighter = new MeleeFighter();
        var startingHealth = meleeFighter.Health;
        meleeFighter.TakeDamage(1);

        meleeFighter.HealSelf(1);
        
        Assert.Equal(meleeFighter.Health, startingHealth);
    }

    [Fact]
    public void Heal_WhenMeleeFighterIsDead_ItCannotBeHealed()
    {
        var meleeFighter = new MeleeFighter();
        meleeFighter.TakeDamage(meleeFighter.Health);
        
        meleeFighter.HealSelf(1);
        
        Assert.False(meleeFighter.Alive);
    }

    [Fact]
    public void Heal_WhenMeleeFighterIsHealedAbove1000_HealthShouldBe1000()
    {
        var meleeFighter = new MeleeFighter();
        meleeFighter.TakeDamage(1);
        
        meleeFighter.HealSelf(10);
        
        Assert.Equal(1000, meleeFighter.Health);
    }

    [Fact]
    public void DealDamage_AMeleeFighterDealsDamage()
    {
        var meleeFighter1 = new MeleeFighter();
        var meleeFighter2 = new MeleeFighter();

        meleeFighter1.Attack(meleeFighter2, 100);
        
        Assert.Equal(900, meleeFighter2.Health);
    }

    [Fact]
    public void DealDamage_AMeleeFighterCannotDamageItself()
    {
        var meleeFighter = new MeleeFighter();
        var startingHealth = meleeFighter.Health;

        meleeFighter.Attack(meleeFighter, 100);
        
        Assert.Equal(startingHealth, meleeFighter.Health);
    }

    [Fact]
    public void DealDamage_WhenTargetLevelIs5OrHigherLevelThanAttacker_ReduceDamage()
    {
        var attacker = new MeleeFighter();
        var target = new MeleeFighter(6);
        var intendedDamage = 100;
        var startingHealth = target.Health;
        
        attacker.Attack(target, intendedDamage);

        var actualDamage = intendedDamage / 2;
        Assert.Equal(startingHealth - actualDamage, target.Health);
    }
    
    [Fact]
    public void DealDamage_WhenTargetLevelIs5OrHigherLevelThanAttacker_ReduceDamageRoundedDown()
    {
        var attacker = new MeleeFighter();
        var target = new MeleeFighter(6);
        var intendedDamage = 99;
        var startingHealth = target.Health;
        
        attacker.Attack(target, intendedDamage);

        var actualDamage = (int) Math.Floor((decimal)intendedDamage / 2);
        Assert.Equal(startingHealth - actualDamage, target.Health);
    }
    
    [Fact]
    public void DealDamage_WhenAttackerLevelIs5OrHigherLevelThanTarget_increaseDamageRoundedDown()
    {
        var attacker = new MeleeFighter(6);
        var target = new MeleeFighter();
        var intendedDamage = 100;
        var startingHealth = target.Health;
        
        attacker.Attack(target, intendedDamage);

        var actualDamage = (int) Math.Floor(intendedDamage* 1.5m) ;
        Assert.Equal(startingHealth - actualDamage, target.Health);
    }

    [Fact]
    public void DealDamage_MeleeFighterCantAttackOutside2Meters()
    {
        var attacker = new MeleeFighter();
        var target = new MeleeFighter();
        var startingHealth = target.Health;

        attacker.Attack(target, 100, distance: 4); 
        Assert.Equal(target.Health, startingHealth);
    }
    
    [Fact]
    public void DealDamage_MeleeFighterCanAttackWithin2Meters()
    {
        var attacker = new MeleeFighter();
        var target = new MeleeFighter();
        var startingHealth = target.Health;

        attacker.Attack(target, 100, distance: 1); 
        Assert.NotEqual(target.Health, startingHealth);
    }
    
    [Fact]
    public void DealDamage_RangedFighterCantAttackOutside20Meters()
    {
        var attacker = new RangedFighter();
        var target = new RangedFighter();
        var startingHealth = target.Health;

        attacker.Attack(target, 100, distance: 25); 
        Assert.Equal(target.Health, startingHealth);
    }
    
    [Fact]
    public void DealDamage_RangedFighterCanAttackWithin20Meters()
    {
        var attacker = new RangedFighter();
        var target = new RangedFighter();
        var startingHealth = target.Health;

        attacker.Attack(target, 100, distance: 15); 
        Assert.NotEqual(target.Health, startingHealth);
    }

    [Fact]
    public void CharactersMayBelongToMultipleFactions()
    {
        var character = new MeleeFighter();
        string faction1 = "faction1";
        string faction2 = "faction2";
        
        character.JoinFaction(faction1);
        character.JoinFaction(faction2);
        
        Assert.Collection(character.Factions,
            f =>
            {
                Assert.Equal(f, faction1);
            },
            f =>
            {
                Assert.Equal(f, faction2);
            });
        
    }
}