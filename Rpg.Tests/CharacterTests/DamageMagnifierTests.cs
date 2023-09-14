namespace Rpg.Tests.CharacterTests;

public class DamageMagnifierTests
{
    [Fact]
    public void Apply_None_DoesNothing()
    {
        Assert.Equal(
            100,
            DamageMagnifier.None.Apply(100));
    }
    
    [Fact]
    public void Apply_ReduceBy_DoesNothing()
    {
        Assert.Equal(
            90,
            DamageMagnifier.ReduceBy(0.1m).Apply(100));
    }
    
    [Fact]
    public void Apply_IncreaseBy_DoesNothing()
    {
        Assert.Equal(
            110,
            DamageMagnifier.IncreaseBy(0.1m).Apply(100));
    }
}
