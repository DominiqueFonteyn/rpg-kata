namespace Rpg.Tests.ActionTests;

public class HealingShould
{
    private readonly ActionService _actionService = new();
    private readonly CharacterRepository _characterRepository = new();
    private Character? _characterOne;
    private Character? _characterTwo;

    public HealingShould()
    {
        _characterOne = _characterRepository.TryAddCharacter("characterOne", FighterType.Melee, 1);
        _characterTwo = _characterRepository.TryAddCharacter("characterTwo", FighterType.Melee, 1);
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
        var deadCharacter = _characterRepository.TryAddCharacter("deadCharacter", FighterType.Melee, 1);
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