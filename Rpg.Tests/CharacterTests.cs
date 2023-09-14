namespace Rpg.Tests;

public class CharacterTests
{
    [Fact]
    public void WhenCreatingACharacter_ShouldHaveHealthEqual1000()
    {
        var character = new Character();
        
        Assert.Equal(1000, character.Health);
    }

    [Fact]
    public void WhenCreatingACharacter_ShouldBeLevel1()
    {
        var character = new Character();
        
        Assert.Equal(1, character.Level);
    }

    [Fact]
    public void WhenCreatingACharacter_ItIsAlive()
    {
        var character = new Character();
        
        Assert.True(character.Alive);
    }

    [Fact]
    public void TakeDamage_WhenTakingDamage_CharacterHealthGoesDown()
    {
        var character = new Character();

        character.TakeDamage(100);
        
        Assert.Equal(900, character.Health); 
    }

    [Fact]
    public void TakeDamage_WhenTakingMoreDamageThanHealth_CharacterDiesAndHealthIsZero()
    {
        var character = new Character();
        
        character.TakeDamage(character.Health+1);
        
        Assert.Equal(0, character.Health);
        Assert.False(character.Alive);
    }

    [Fact]
    public void Heal_WhenHealingNegativeAmount_ThrowException()
    {
        var character = new Character();
        
        void Act() => character.HealSelf(-10);

        Assert.Throws<ApplicationException>(Act);
    }
    
    [Fact]
    public void Heal_WhenCharacterIsHealed_IncreaseHealth()
    {
        var character = new Character();
        var startingHealth = character.Health;
        character.TakeDamage(1);

        character.HealSelf(1);
        
        Assert.Equal(character.Health, startingHealth);
    }

    [Fact]
    public void Heal_WhenCharacterIsDead_ItCannotBeHealed()
    {
        var character = new Character();
        character.TakeDamage(character.Health);
        
        character.HealSelf(1);
        
        Assert.False(character.Alive);
    }

    [Fact]
    public void Heal_WhenCharacterIsHealedAbove1000_HealthShouldBe1000()
    {
        var character = new Character();
        character.TakeDamage(1);
        
        character.HealSelf(10);
        
        Assert.Equal(1000, character.Health);
    }

    [Fact]
    public void DealDamage_ACharacterDealsDamage()
    {
        var character1 = new Character();
        var character2 = new Character();

        character1.Attack(character2, 100);
        
        Assert.Equal(900, character2.Health);
    }

    [Fact]
    public void DealDamage_ACharacterCannotDamageItself()
    {
        var character = new Character();
        var startingHealth = character.Health;

        character.Attack(character, 100);
        
        Assert.Equal(startingHealth, character.Health);
    }

    [Fact]
    public void DealDamage_WhenTargetLevelIs5OrHigherlevelThanAttacker_ReduceDamage()
    {
        var attacker = new Character();
        var target = new Character(6);
        var intendedDamage = 100;
        var startingHealth = target.Health;
        
        attacker.Attack(target, intendedDamage);

        var actualDamage = intendedDamage / 2;
        Assert.Equal(startingHealth - actualDamage, target.Health);
    }
    
    [Fact]
    public void DealDamage_WhenTargetLevelIs5OrHigherlevelThanAttacker_ReduceDamageRoundedDown()
    {
        var attacker = new Character();
        var target = new Character(6);
        var intendedDamage = 99;
        var startingHealth = target.Health;
        
        attacker.Attack(target, intendedDamage);

        var actualDamage = (int) Math.Floor((decimal)intendedDamage / 2);
        Assert.Equal(startingHealth - actualDamage, target.Health);
    }
    
    [Fact]
    public void DealDamage_WhenAttackerLevelIs5OrHigherlevelThanTarget_increaseDamageRoundedDown()
    {
        var attacker = new Character(6);
        var target = new Character();
        var intendedDamage = 100;
        var startingHealth = target.Health;
        
        attacker.Attack(target, intendedDamage);

        var actualDamage = (int) Math.Floor(intendedDamage* 1.5m) ;
        Assert.Equal(startingHealth - actualDamage, target.Health);
    }
}