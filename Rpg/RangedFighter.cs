namespace Rpg;

public class RangedFighter : Character
{
    public RangedFighter(int level = StartingLevel) : base(level)
    {
        Range = 20;
    }
}