namespace Rpg.Tests;

public class HealCharacterShould
{
    [Fact]
    public void IncreaseHealthOfThePassedCharacter()
    {
        var character = new Character();
        var healingCharacter = new Character();

        character.Health = 400;
        
        healingCharacter.Heal(character);

        Assert.Equal(900, character.Health);
    }

    [Fact]
    public void HealCharacter_NoMoreThanMaxHealth()
    {
        var character = new Character();
        var healingCharacter = new Character();

        healingCharacter.Heal(character);

        Assert.Equal(1000, character.Health);
    }
    
    [Fact]
    public void NotHealCharacterThatIsNotAlive()
    {
        var character = new Character()
        {
            IsAlive = false,
            Health = 0
        };
        var healingCharacter = new Character();

        healingCharacter.Heal(character);

        Assert.Equal(0, character.Health);
    }
    
}