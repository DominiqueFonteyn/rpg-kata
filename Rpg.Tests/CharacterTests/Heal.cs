using NSubstitute;

namespace Rpg.Tests.CharacterTests;

public class Heal : CharacterTestBase
{
    [Fact]
    public void CallsIsDead()
    {
        var player = new Character();
        var target = Substitute.For<IReceiveHealing>();
        target.IsDead.Returns(false);

        player.Heal(target, 500);

        _ = target
            .Received(1)
            .IsDead;
    }

    [Fact]
    public void TargetNotDead_CallsReceiveHealing()
    {
        const int health = 300;
        var player = new Character();
        var target = Substitute.For<IReceiveHealing>();
        target.IsDead.Returns(false);

        player.Heal(target, health);

        target
            .Received(1)
            .ReceiveHealing(health);
    }

    [Fact]
    public void TargetDead_DoesNotCallReceiveHealing()
    {
        var player = new Character();
        var target = Substitute.For<IReceiveHealing>();
        target.IsDead.Returns(true);

        player.Heal(target, 500);

        target
            .DidNotReceive()
            .ReceiveHealing(Arg.Any<int>());
    }
}
