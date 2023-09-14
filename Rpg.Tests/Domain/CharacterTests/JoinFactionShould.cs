using Rpg.Domain;
using Rpg.Domain.Primitives;

namespace Rpg.Tests.Domain.CharacterTests;

public class JoinFactionShould
{
    [Fact]
    public void AddFactionToFactionList()
    {
        var character = CharacterCreator.Build().Create();

        var faction = new Faction("Knights");
        character.JoinFaction(faction);

        Assert.NotEmpty(character.Factions);
    }
}