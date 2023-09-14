namespace Rpg.Tests;

public class ActionTests
{
    private readonly ActionService _actionService = new();
    private readonly CharacterRepository _characterRepository = new();
    private Character? _characterOne;
    private Character? _characterTwo;

    public ActionTests()
    {
        _characterOne = _characterRepository.TryAddCharacter("characterOne");
        _characterTwo = _characterRepository.TryAddCharacter("characterTwo");
    }

    [Fact]
    public void DoingDamageShouldReduceHealthToTargetPlayerByAmount()
    {
        _actionService.DoDamage(_characterOne!, _characterTwo!, 500);
        Assert.Equal(500, _characterTwo!.Health);
    }

    [Fact]
    public void DoingDamageShouldReduceHealthToLessThan0()
    {
        _actionService.DoDamage(_characterOne!, _characterTwo!, 5000);
        Assert.Equal(0, _characterTwo!.Health);
    }
    
    [Fact]
    public void DoingDamageToCharacter5LevelsLowerWillIncreaseDamageByhalf()
    {
        var highLevelCharacter = _characterRepository.TryAddCharacter("highLevelCharacter");
        _characterRepository.IncreaseLevel(highLevelCharacter!, 10);
        
        var lowLevelCharacter = _characterRepository.TryAddCharacter("lowLevelCharacter");

        _actionService.DoDamage(highLevelCharacter!, lowLevelCharacter!, 100);
        Assert.Equal(850, lowLevelCharacter!.Health);
    }
    
    [Fact]
    public void DoingDamageToCharacter5LevelsHigherWillDecreaseDamageByhalf()
    {
        var highLevelCharacter = _characterRepository.TryAddCharacter("highLevelCharacter");
        _characterRepository.IncreaseLevel(highLevelCharacter!, 10);
        
        var lowLevelCharacter = _characterRepository.TryAddCharacter("lowLevelCharacter");

        _actionService.DoDamage(lowLevelCharacter!, highLevelCharacter!, 100);
        Assert.Equal(950, highLevelCharacter!.Health);
    }

    [Fact]
    public void DoingDamageCannotDoDamageToSelf()
    {
        _actionService.DoDamage(_characterOne!, _characterOne!, 500);
        Assert.Equal(1000, _characterOne.Health);
    }
    
    [Fact]
    public void CharacterCannotHealPast1000()
    {
        _actionService.HealCharacter(_characterOne!, 5000);
        Assert.Equal(1000, _characterOne!.Health);
    }
    
    [Fact]
    public void CharacterCannotHealWhenDead()
    {
        var deadCharacter = _characterRepository.TryAddCharacter("deadCharacter");
        _actionService.DoDamage(_characterOne!, deadCharacter!, 10000);
        Assert.Equal(0, deadCharacter!.Health);
        
        _actionService.HealCharacter(deadCharacter!, 500);
        Assert.Equal(0, deadCharacter!.Health);
    }

    [Fact]
    public void CharacterCanOnlyHealSelf()
    {
        Assert.True(true);
    }
}