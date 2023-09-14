using NSubstitute;

namespace Rpg.Tests.CharacterTests;

public class Heal : CharacterTestBase
{
    [Fact]
    public void CallsIsDead()
    {
        var player = Substitute.ForPartsOf<Character>();
        player.IsDead.Returns(false);

        player.Heal(player, 500);

        _ = player
            .Received(1)
            .IsDead;
    }

    [Fact]
    public void TargetNotDead_CallsReceiveHealing()
    {
        const int health = 300;
        var player = Substitute.ForPartsOf<Character>();
        player.IsDead.Returns(false);

        player.Heal(player, health);

        player
            .Received(1)
            .ReceiveHealing(health);
    }

    [Fact]
    public void TargetDead_DoesNotCallReceiveHealing()
    {
        var player = Substitute.ForPartsOf<Character>();
        player.IsDead.Returns(true);

        player.Heal(player, 500);

        player
            .DidNotReceive()
            .ReceiveHealing(Arg.Any<int>());
    }

    [Fact(Skip = "wip")]
    public void OnlyHealsWhenSelf()
    {
        var player = Substitute.ForPartsOf<Character>();
        
        player.Heal(player, 500);

        Assert.Empty(player.ReceivedCalls());
    }
}
