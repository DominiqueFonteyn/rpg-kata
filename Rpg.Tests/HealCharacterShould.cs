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
}