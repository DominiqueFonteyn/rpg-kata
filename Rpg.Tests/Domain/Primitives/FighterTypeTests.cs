using Rpg.Domain.Enums;
using Rpg.Domain.Primitives;

namespace Rpg.Tests.Domain.Primitives;

public class FighterTypeTests
{
    [Fact]
    public void Range_WhenMelee_Equals2()
    {
        var meleeFighter = new FighterType(FightingType.Melee);
        Assert.Equal(2, meleeFighter.Range);

    }

    [Fact]
    public void Range_WhenRanged_Equals20()
    {
        var rangedFighter = new FighterType(FightingType.Ranged);
        Assert.Equal(20, rangedFighter.Range);
    }
}