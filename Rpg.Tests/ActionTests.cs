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
        _actionService.DoDamage(_characterOne!,_characterTwo!, 500);
        Assert.Equal(500, _characterTwo!.Health);
    }
    
    [Fact]
    public void DoingDamageShouldReduceHealthToLessThan0()
    {
        _actionService.DoDamage(_characterOne!,_characterTwo!, 5000);
        Assert.Equal(0, _characterTwo!.Health);
    }
}