namespace Rpg.Tests.ActionTests;

public class DoDamageShould
{
    private readonly ActionService _actionService = new();
    private readonly CharacterRepository _characterRepository = new();
    private Character? _characterOne;
    private Character? _characterTwo;

    public DoDamageShould()
    {
        _characterOne = _characterRepository.TryAddCharacter("characterOne", FighterType.Melee, 1);
        _characterTwo = _characterRepository.TryAddCharacter("characterTwo", FighterType.Ranged, 2); 
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
        var highLevelCharacter = _characterRepository.TryAddCharacter("highLevelCharacter", FighterType.Melee, 1);
        _characterRepository.IncreaseLevel(highLevelCharacter!, 10);
        
        var lowLevelCharacter = _characterRepository.TryAddCharacter("lowLevelCharacter", FighterType.Melee, 1);

        _actionService.DoDamage(highLevelCharacter!, lowLevelCharacter!, 100);
        Assert.Equal(850, lowLevelCharacter!.Health);
    }
    
    [Fact]
    public void ToCharacter5LevelsHigher_WillDecreaseDamageByhalf()
    {
        var highLevelCharacter = _characterRepository.TryAddCharacter("highLevelCharacter", FighterType.Melee, 1);
        _characterRepository.IncreaseLevel(highLevelCharacter!, 10);
        
        var lowLevelCharacter = _characterRepository.TryAddCharacter("lowLevelCharacter", FighterType.Melee, 1);

        _actionService.DoDamage(lowLevelCharacter!, highLevelCharacter!, 100);
        Assert.Equal(950, highLevelCharacter!.Health);
    }

    [Fact]
    public void NotDoDamageToSelf()
    {
        _actionService.DoDamage(_characterOne!, _characterOne!, 500);
        Assert.Equal(1000, _characterOne.Health);
    }
    
    [Fact]
    public void NotDamageOpponentForMeleeFighterIfTargetIsNotWithing2Meters()
    {
        var meleeFighter = _characterRepository.TryAddCharacter("meleeFighter", FighterType.Melee, 100);

        var targetCharacter = _characterRepository.TryAddCharacter("targetCharacter", FighterType.Melee, 102);

        _actionService.DoDamage(meleeFighter!, targetCharacter!, 500);
        Assert.Equal(500, targetCharacter!.Health);

        _actionService.MoveCharacter(meleeFighter!, -1);
        _actionService.DoDamage(meleeFighter!, targetCharacter!, 100);
        Assert.Equal(500, targetCharacter!.Health);
    }
    
    [Fact]
    public void NotDamageOpponentForRangedFighterIfTargetIsNotWithing20Meters()
    {
        var rangedFighter = _characterRepository.TryAddCharacter("rangedFighter", FighterType.Ranged, 100);

        var targetCharacter = _characterRepository.TryAddCharacter("targetCharacter", FighterType.Melee, 120);

        _actionService.DoDamage(rangedFighter!, targetCharacter!, 500);
        Assert.Equal(500, targetCharacter!.Health);

        _actionService.MoveCharacter(rangedFighter!, -1);
        _actionService.DoDamage(rangedFighter!, targetCharacter!, 100);
        Assert.Equal(500, targetCharacter!.Health);
    }
}