namespace Rpg.Tests;

public class CreateCharacterTests
{
    private readonly CharacterRepository _characterRepository = new();

    public CreateCharacterTests()
    {
    }
    
    [Fact]
    public void ShouldCreatCharacterWithHealth1000()
    {
        var character = _characterRepository.TryAddCharacter("playerOne", FighterType.Melee, 1);
        
        Assert.Equal(1000, character.Health);
    }
    
    [Fact]
    public void ShouldReturnNullWhenNameExists()
    {
        var character1a = _characterRepository.TryAddCharacter("playerOne", FighterType.Melee, 1);
        var character1b = _characterRepository.TryAddCharacter("playerOne", FighterType.Melee, 1);
        
        Assert.Null(character1b);
    }
    
    [Fact]
    public void ShouldCreatCharacterWithLevel1()
    {
        var character = _characterRepository.TryAddCharacter("playerOne", FighterType.Melee, 1);
        
        Assert.Equal(1, character.Level);
    }
    
    [Fact]
    public void ShouldCreatCharacterWhichIsAlive()
    {
        var character = _characterRepository.TryAddCharacter("playerOne", FighterType.Melee, 1);
        
        Assert.True(character.IsAlive);
    }
}