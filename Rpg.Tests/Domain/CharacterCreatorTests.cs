using Rpg.Domain;
using Rpg.Domain.Enums;
using Rpg.Domain.Primitives;

namespace Rpg.Tests.Domain;

public class CharacterCreatorTests
{
    [Fact]
    public void WhenCreated_ShouldHave1000Health()
    {
        var character = CharacterCreator.Build().Create();

        Assert.Equal(new Health(1000), character.Health);
    }

    [Fact]
    public void WhenCreated_ShouldBeLevelOne()
    {
        var character = CharacterCreator.Build().Create();

        Assert.Equal(new Level(1), character.Level);
    }

    [Fact]
    public void WhenCreated_ShouldBeAtPositionZero()
    {
        var character = CharacterCreator.Build().Create();

        Assert.Equal(new Position(), character.Position);
    }

    [Fact]
    public void WhenCreated_ShouldBeMeleeFighter()
    {
        var character = CharacterCreator.Build().Create();

        Assert.Equal(FightingType.Melee, character.FighterType.FightingType);
    }

    [Fact]
    public void WhenCreated_BelongsToNoFaction()
    {
        var character = CharacterCreator.Build().Create();

        Assert.Empty(character.Factions);
    }

    [Fact]
    public void WhenCreated_SetsValues()
    {
        var fightingType = FightingType.Ranged;
        var health = new Health(400);
        var position = new Position(2);
        var level = new Level(3);

        var character = CharacterCreator.Build()
            .OfType(new FighterType(fightingType))
            .WithHealth(health)
            .AtPosition(position)
            .WithLevel(level)
            .Create();

        Assert.Equal(fightingType, character.FighterType.FightingType);
        Assert.Equal(health, character.Health);
        Assert.Equal(position, character.Position);
        Assert.Equal(level, character.Level);
    }
}