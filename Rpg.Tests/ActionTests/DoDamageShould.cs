namespace Rpg.Tests.ActionTests;

public class DoDamageShould
{
    private readonly ActionService _actionService = new();
    private readonly CharacterRepository _characterRepository = new();
    private Character? _characterOne;
    private Character? _characterTwo;

    public DoDamageShould()
    {
        _characterOne = _characterRepository.TryAddCharacter("characterOne");
        _characterTwo = _characterRepository.TryAddCharacter("characterTwo");
    }

    [Fact]
    public void ReduceHealthToTargetPlayerByAmount()
    {
        _actionService.DoDamage(_characterOne!, _characterTwo!, 500);
        Assert.Equal(500, _characterTwo!.Health);
    }

    [Fact]
    public void ReduceHealthToLessThan0()
    {
        _actionService.DoDamage(_characterOne!, _characterTwo!, 5000);
        Assert.Equal(0, _characterTwo!.Health);
    }
    
    [Fact]
    public void ToCharacter5LevelsLower_WillIncreaseDamageByhalf()
    {
        var highLevelCharacter = _characterRepository.TryAddCharacter("highLevelCharacter");
        _characterRepository.IncreaseLevel(highLevelCharacter!, 10);
        
        var lowLevelCharacter = _characterRepository.TryAddCharacter("lowLevelCharacter");

        _actionService.DoDamage(highLevelCharacter!, lowLevelCharacter!, 100);
        Assert.Equal(850, lowLevelCharacter!.Health);
    }
    
    [Fact]
    public void ToCharacter5LevelsHigher_WillDecreaseDamageByhalf()
    {
        var highLevelCharacter = _characterRepository.TryAddCharacter("highLevelCharacter");
        _characterRepository.IncreaseLevel(highLevelCharacter!, 10);
        
        var lowLevelCharacter = _characterRepository.TryAddCharacter("lowLevelCharacter");

        _actionService.DoDamage(lowLevelCharacter!, highLevelCharacter!, 100);
        Assert.Equal(950, highLevelCharacter!.Health);
    }

    [Fact]
    public void NotDoDamageToSelf()
    {
        _actionService.DoDamage(_characterOne!, _characterOne!, 500);
        Assert.Equal(1000, _characterOne.Health);
    }
}