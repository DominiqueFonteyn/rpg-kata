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
    public void Heal_WhenCharacterIsHealed_IncreaseHealth()
    {
        var character = new Character();
        var startingHealth = character.Health;
        character.TakeDamage(1);

        character.Heal(1);
        
        Assert.Equal(character.Health, startingHealth);
    }

    [Fact]
    public void Heal_WhenCharacterIsDead_ItCannotBeHealed()
    {
        var character = new Character();
        character.TakeDamage(character.Health);
        
        character.Heal(1);
        
        Assert.False(character.Alive);
    }

    [Fact]
    public void Heal_WhenCharacterIsHealedAbove1000_HealthShouldBe1000()
    {
        var character = new Character();
        character.TakeDamage(1);
        
        character.Heal(10);
        
        Assert.Equal(1000, character.Health);
    }
}