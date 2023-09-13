using NSubstitute;

namespace Rpg.Tests.CharacterTests;

public class Damage : CharacterTestBase
{
    [Fact]
    public void CallsTakeDamage()
    {
        const int damage = 300;
        var player = new Character();
        var target = Substitute.For<ITakeDamage>();

        player.Damage(target, damage);

        target
            .Received(1)
            .TakeDamage(damage);
    }

    [Fact]
    public void TargetIsSelf_DoesNotCallTakeDamage()
    {
        var player = Substitute.ForPartsOf<Character>();

        player.Damage(player, 100);
        
        player
            .DidNotReceive()
            .TakeDamage(100);
    }
}