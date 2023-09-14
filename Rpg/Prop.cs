namespace Rpg;

public abstract class Prop : GameObject
{
    protected override bool CanBeHealed => false;
    protected override bool CanDealDamage => false;

    protected Prop(decimal initialHealth) : base(initialHealth)
    {
    }
}
