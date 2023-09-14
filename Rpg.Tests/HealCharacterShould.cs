namespace Rpg.Tests;

public class HealCharacterShould
{

    [Fact]
    public void HealCharacter_NoMoreThanMaxHealth()
    {
        var character = new Character()
        {
            Health = 10
        };
        
        character.Heal();

        Assert.Equal(510, character.Health);
    }
    
    [Fact]
    public void NotHealCharacterThatIsNotAlive()
    {
        var character = new Character()
        {
            IsAlive = false,
            Health = 0
        };

        character.Heal();

        Assert.Equal(0, character.Health);
    }

    [Fact]
    public void OnlyHealItself()
    {
        var character = new Character()
        {
            Health = 100
        };

        character.Heal();

        Assert.Equal(600, character.Health);
    }
    
}